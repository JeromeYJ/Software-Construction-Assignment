using System.Timers;

namespace AlarmClock
{
    public delegate void AlarmClockEventHandler(object sender, AlarmClockArgs e); //定义委托类型

    public class AlarmClockArgs : EventArgs
    {
        int time;
        public int Time
        {
            get => time;
        }
        public AlarmClockArgs(int time)
        {
            this.time = time;
        }
    }

    public class AlarmClock
    {
        int time;
        System.Timers.Timer timer;
        public event AlarmClockEventHandler Tick;
        public event AlarmClockEventHandler Alarm;
        List<int> alarmTimeList; 

        public AlarmClock(List<int> alarmTimeList)
        {
            time = 0;
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            //timer.Enabled = true;
            timer.Elapsed += TimerElapsed;
            this.alarmTimeList = alarmTimeList;
        }
        private void TimerElapsed(object? sender, ElapsedEventArgs e)
        {
            time++;
            AlarmClockArgs args = new AlarmClockArgs(time);
            Tick(this, args);
            for (int i = 0; i < alarmTimeList.Count; i++)
                if (time == alarmTimeList[i])
                {
                    Alarm(this, args);
                    break;
                }
        }
        public void Start()
        {
            timer.Start();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("请输入响铃时间的个数：");
            int cnt;
            cnt=Int32.Parse(Console.ReadLine());
            List<int> alarmTimeList = new List<int>();
            Console.WriteLine("请输入响铃时间序列：");
            for (int i = 0; i < cnt; i++)
                alarmTimeList.Add(Int32.Parse(Console.ReadLine()));

            AlarmClock alarm = new AlarmClock(alarmTimeList);
            alarm.Tick += AlarmTick;
            alarm.Alarm += AlarmAlarm;
            alarm.Start();
            Console.ReadKey();  //要加上
        }

        private static void AlarmTick(object sender, AlarmClockArgs e)
        {
            Console.WriteLine($"Tick. time:{e.Time}");
        }
        private static void AlarmAlarm(object sender, AlarmClockArgs e)
        {
            Console.WriteLine($"Alarm. time:{e.Time}");
        }
    }
}