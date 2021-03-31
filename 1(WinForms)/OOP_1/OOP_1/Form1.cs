using System;
using System.Windows.Forms;

namespace OOP_1
{
    public partial class Form1 : Form
    {
        int input, output;
        int oper;
        bool positive = true;
        int system = 10;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int number = 1;
                textBox1.Text += number.ToString();
                input = int.Parse(textBox1.Text);
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int number = 2;
                textBox1.Text += number.ToString();
                input = int.Parse(textBox1.Text);
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int number = 3;
                textBox1.Text += number.ToString();
                input = int.Parse(textBox1.Text);
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int number = 4;
                textBox1.Text += number.ToString();
                input = int.Parse(textBox1.Text);
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int number = 5;
                textBox1.Text += number.ToString();
                input = int.Parse(textBox1.Text);
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int number = 6;
                textBox1.Text += number.ToString();
                input = int.Parse(textBox1.Text);
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                int number = 7;
                textBox1.Text += number.ToString();
                input = int.Parse(textBox1.Text);
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                int number = 8;
                textBox1.Text += number.ToString();
                input = int.Parse(textBox1.Text);
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int number = 9;
                textBox1.Text += number.ToString();
                input = int.Parse(textBox1.Text);
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                int number = 0;
                textBox1.Text += number.ToString();
                input = int.Parse(textBox1.Text);
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    input = int.Parse(textBox1.Text);
                    textBox1.Clear();
                    oper = 2;
                    if (positive)
                        textBox2.Text = input.ToString() + "+";
                    else
                        textBox2.Text = "(" + input.ToString() + ")" + "+";
                }
                if (output == 0)
                    output = input;
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    input = int.Parse(textBox1.Text);
                    textBox1.Clear();
                    oper = 1;
                    if (positive)
                        textBox2.Text = input.ToString() + "•";
                    else
                        textBox2.Text = "(" + input.ToString() + ")" + "•";
                }
                if (output == 0)
                    output = input;
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    input = int.Parse(textBox1.Text);
                    textBox1.Clear();
                    oper = 3;
                    if(positive)
                    textBox2.Text = input.ToString() + "⊕";
                    else
                    textBox2.Text = "(" + input.ToString() + ")" + "⊕";
                }
                if (output == 0)
                    output = input;
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            int lenght = textBox1.Text.Length - 1;
            string text = textBox1.Text;
            textBox1.Clear();
            for (int i = 0; i < lenght; i++)
            {
                textBox1.Text = textBox1.Text + text[i];
            }
            input = int.Parse(textBox1.Text);
        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            calculate();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    input = int.Parse(textBox1.Text);
                    textBox1.Text =(~input).ToString();
                    if (!positive)
                        positive = false;
                    else
                        positive = true;
                    input = int.Parse(textBox1.Text);
                }
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    textBox3.Text = Convert.ToString(input, 2);
                    system = 2;
                }
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                   textBox3.Text = Convert.ToString(input, 8);
                   system = 8;
                }
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    textBox3.Text = input.ToString();
                    system = 10;
                }
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
            
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    textBox3.Text = Convert.ToString(input, 16);
                    system = 16;
                }
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private void calculate()
        {
            try
            {
                switch (oper)
                {
                    case 1:
                        if (textBox1.Text != "")
                        {
                            output = output & int.Parse(textBox1.Text);
                            textBox1.Text = output.ToString();
                            oper = 0;
                        }
                        else
                            textBox1.Text = output.ToString();
                        textBox2.Clear();
                        input = int.Parse(textBox1.Text);
                        break;
                    case 2:
                        if (textBox1.Text != "")
                        {
                            output = output | int.Parse(textBox1.Text);
                            textBox1.Text = output.ToString();
                           oper = 0;
                        }
                        else
                            textBox1.Text = output.ToString();
                        textBox2.Clear();
                        input = int.Parse(textBox1.Text);
                        break;
                    case 3:
                        if (textBox1.Text != "")
                        {
                            output = output ^ int.Parse(textBox1.Text);
                            textBox1.Text = output.ToString();
                            oper = 0;
                        }
                        else
                            textBox1.Text = output.ToString();
                        textBox2.Clear();
                        input = int.Parse(textBox1.Text);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }

        }
    }
}
