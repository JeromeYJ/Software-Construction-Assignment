using System.Collections;
using System.Net;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

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
        public delegate void DispURL(URLInfo url);
        public event DispURL DispURLEvent;
        private Queue<string> waiting;
        public Dictionary<string, bool> urls;
        private int count;
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
            count = 0;
            maxCount = 50;
        }

        public void Start(string InitURL)
        {
            string startUrl = InitURL;

            pattern = @"(?<site>(?<protocol>https?)://(?<domain>[\w\d.-]+)(:\d+)?($|/))(\w+/)*(?<file>[^#]*)";
            protocol = Regex.Match(startUrl, pattern).Groups["protocol"].Value;
            domain = Regex.Match(startUrl, pattern).Groups["domain"].Value;
            file = Regex.Match(startUrl, pattern).Groups["file"].Value;
            site = Regex.Match(startUrl, pattern).Groups["site"].Value;

            count = 0;
            waiting.Enqueue(startUrl);
            new Thread(Crawl).Start();   //开始爬行
        }

        private void Crawl()
        {
            Console.WriteLine("开始爬行了……");
            while (count < maxCount && waiting.Count > 0)
            {
                string current = waiting.Dequeue();
                Console.WriteLine("爬行 " + current + " 页面！");
                count++;
                
                string html = Download(current);
                urls[current] = true;
                URLInfo u = new URLInfo(count, current, "success");
                DispURLEvent(u);   //触发事件
                Parse(html, current);
            }
            Console.WriteLine("爬行结束");
        }

        public string Download(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);

                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                urls[url] = false;
                URLInfo u = new URLInfo(count, url, e.Message);
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
                
                if(strRef.StartsWith("//"))
                    strRef = protocol + ":" + strRef;
                else if(strRef.StartsWith("/"))
                    strRef = site.EndsWith("/") ? site + strRef.Substring(1) : site + strRef;


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

        static void Main(string[] args)
        {
            SimpleCrawler myCrawler = new SimpleCrawler();
            string startUrl = "https://baike.baidu.com";

            myCrawler.Start(startUrl);
        }
    }
}