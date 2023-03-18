namespace GenericList
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Value { get; set; }
        public Node(T t)
        {
            Next = null;
            Value = t;
        }
    }
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public GenericList()
        {
            head = null;
            tail = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
                head = tail = n;
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void ForEach(Action<T> action)
        {
            Node<T> n = head;
            while (n != null)
            {
                action(n.Value);
                n = n.Next;
            }
        }

    }
    public class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> list = new GenericList<int>();
            list.Add(1); list.Add(2); list.Add(3); list.Add(4); list.Add(5);

            //打印链表元素
            Console.Write("链表元素为：");
            list.ForEach(m => Console.Write(m + " "));
            Console.WriteLine();

            //求最大值
            Console.Write("链表元素的最大值为：");
            int max = list.Head.Value;
            list.ForEach(m => { if (m > max) max = m; });
            Console.WriteLine(max);

            //求最小值
            Console.Write("链表元素的最小值为：");
            int min = list.Head.Value;
            list.ForEach(m => { if (m < min) min = m; });
            Console.WriteLine(min);

            //求和
            Console.Write("链表元素的和为：");
            int sum = 0;
            list.ForEach(m => sum += m);
            Console.WriteLine(sum);
        }
    }
}