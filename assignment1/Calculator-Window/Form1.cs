namespace Calculator_Window
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s1 = textBox1.Text;
            string s2 = textBox2.Text;
            double d1 = Double.Parse(s1);
            double d2 = Double.Parse(s2);
            double result;
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    result = d1 + d2;
                    break;
                case 1:
                    result = d1 - d2;
                    break;
                case 2:
                    result = d1 * d2;
                    break;
                case 3:
                    result = d1 / d2;
                    break;
                case 4:
                    result = d1 % d2;
                    break;
                default:
                    label5.Text = "计算结果为:  Error";
                    return;
            }
            label5.Text = "计算结果为:  " + result;
        }
    }
}