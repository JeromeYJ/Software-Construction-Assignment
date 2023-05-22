using System;
using System.Collections;
using System.Net;
using System.Runtime.Intrinsics.X86;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleCrawler
{
    //包含爬取信息的类
    public class URLInfo
    {
        public int No { get; set; }
        public string Url { get; set; }
        public string Info { get; set; }
        public URLInfo(int no, string url, string info)
        {
            No = no;
            Url = url;
            Info = info;
        }
    }
    public class SimpleCrawler
    {
        static public int cnt = 1;      //用于显示信息编号的静态字段

        public delegate void DispURL(URLInfo url);
        //显示url的事件，用于winform显示
        public event DispURL DispURLEvent;      

        private Queue<string> waiting;
        public Dictionary<string, bool> urls;
        //private int count;
        private int maxCount;

        //协议段
        public string protocol { get; set; }
        //域名段
        public string domain { get; set; }
        //协议与域名段
        public string site { get; set; }
        //文件段
        public string file { get; set; }
        public string pattern { get; set; }

        public SimpleCrawler()
        {
            waiting = new Queue<string>();
            urls = new Dictionary<string, bool>();
            //count = 0;
            maxCount = 100;
        }

        public void Start(string InitURL)
        {
            string startUrl = InitURL;

            pattern = @"(?<site>(?<protocol>https?)://(?<domain>[\w\d.-]+)(:\d+)?($|/))(\w+/)*(?<file>[^#]*)";
            protocol = Regex.Match(startUrl, pattern).Groups["protocol"].Value;
            domain = Regex.Match(startUrl, pattern).Groups["domain"].Value;
            file = Regex.Match(startUrl, pattern).Groups["file"].Value;
            site = Regex.Match(startUrl, pattern).Groups["site"].Value;

            //count = 0;
            waiting.Enqueue(startUrl);

            new Thread(Crawl).Start();   //开始爬行
        }

        private void Crawl()
        {
            List<Action> tasks = new List<Action>();

            //Console.WriteLine("开始爬行了……");
            while (waiting.Count > 0 && tasks.Count < maxCount && cnt < maxCount)
            {
                string current = waiting.Dequeue();
                Console.WriteLine("爬行 " + current + " 页面！");

                tasks.Add(new Action(() => { DownloadAndParse(current); }));

                //string html = Download(current);
                //Parse(html, current);
                //urls[current] = true;
                //URLInfo u = new URLInfo(count, current, "success");
                //DispURLEvent(u);        //触发事件
            }

            //Console.WriteLine("爬行结束");
            Parallel.Invoke(tasks.ToArray());
        }

        //将两个方法合二为一，方便进行并行优化
        public void DownloadAndParse(string current)
        {
            //count++;
            string html = Download(current);
            Parse(html, current);
            urls[current] = true;
            URLInfo u = new URLInfo(cnt++, current, "success");
            DispURLEvent(u);        //触发事件
        }

        public string Download(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);

                string fileName = cnt.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                urls[url] = false;
                URLInfo u = new URLInfo(cnt, url, e.Message);
                DispURLEvent(u);   //触发事件
                return "";
            }
        }

        public void Parse(string html, string url)
        {
            string strRef = @"(href|HREF)\s*=\s*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('\"', '"', '#', '>');
                if (strRef == null || strRef == "" || strRef.StartsWith("javascript:")) 
                    continue;

                strRef = ProcessUrl(strRef, url);


                string pattern1 = @".(htm|html|aspx|php|jsp)$|^[^.]*$";
                Match m = Regex.Match(strRef, pattern);
                if (m.Groups["domain"].Value == domain && 
                    m.Groups["protocol"].Value == protocol &&
                    Regex.IsMatch(m.Groups["file"].Value, pattern1) &&
                    !waiting.Contains(strRef))
                {
                    waiting.Enqueue(strRef);
                }
            }
        }

        //处理url为完整格式
        string ProcessUrl(string url, string pageUrl)
        {
            string tmp;
            if (url.Contains("://"))
                return url;
            if (url.StartsWith("//"))
            {
                Match urlMatch = Regex.Match(pageUrl, pattern);
                tmp = urlMatch.Groups["protocol"].Value;
                return tmp + ":" + url;
            }
            if (url.StartsWith("/"))
            {
                Match urlMatch = Regex.Match(pageUrl, pattern);
                tmp = urlMatch.Groups["site"].Value;
                return tmp.EndsWith("/") ? tmp + url[1..] : tmp + url;
            }
            if (url.StartsWith("../"))
            {
                url = url[3..];
                int idx = pageUrl.LastIndexOf('/');
                return ProcessUrl(url, pageUrl[..idx]);
            }
            if (url.StartsWith("./"))
                return ProcessUrl(url[2..], pageUrl);
            
            //其他情况
            int end = pageUrl.LastIndexOf("/");
            return pageUrl[..end] + "/" + url;
        }

        static void Main(string[] args)
        {
            SimpleCrawler myCrawler = new SimpleCrawler();
            string startUrl = "https://baike.baidu.com";

            myCrawler.Start(startUrl);
        }
    }
}