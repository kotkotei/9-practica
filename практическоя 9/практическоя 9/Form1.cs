using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace практическоя_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Вы не выброли что удалять ");
            }
            else
            {
                int k = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(k);
                if (listBox1.Items.Count == 0)
                {
                    button4.Enabled = false;
                }
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }
       
    

                
                   

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            //f.Show();
            if (f.ShowDialog() == DialogResult.OK)
            {
                string info = f.textBox1.Text;
                int s = Convert.ToInt32(f.textBox2.Text);
                double v = Convert.ToDouble(f.textBox3.Text);
                sklad p = new sklad();
                p.info = info;
                p.stoimist = s;
                p.obiom = v;
                listBox1.Items.Add(p);
                f.textBox1.Text = "";
                f.textBox2.Text = "";
                f.textBox3.Text = "";

                button4.Enabled = false;



            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбрано ");
            }
            else
            {
                int k = listBox1.SelectedIndex;
                sklad p = listBox1.Items[k] as sklad;
                Form2 f = new Form2();
                f.textBox1.Text = p.info;
                f.textBox2.Text = p.stoimist.ToString();
                f.textBox3.Text = p.obiom.ToString();
                if (f.ShowDialog() == DialogResult.OK)
                {

                    p.info = f.textBox1.Text;
                    p.stoimist = Convert.ToInt32(f.textBox2.Text);
                    p.obiom = Convert.ToDouble(f.textBox3.Text);
                    listBox1.Items[k] = p;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                sklad p = listBox1.Items[i] as sklad;
                sum += p.stoimist;
            }
            MessageBox.Show((sum * 1.0 / listBox1.Items.Count).ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                while (!sr.EndOfStream)
                {
                    sklad p = new sklad();
                    p.info = sr.ReadLine();
                    p.stoimist = Convert.ToInt32(sr.ReadLine());
                    p.obiom = Convert.ToDouble(sr.ReadLine());
                    listBox1.Items.Add(p);
                }
                sr.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    sklad p = listBox1.Items[i] as sklad;
                    sw.WriteLine(p.info);
                    sw.WriteLine(p.stoimist);
                    sw.WriteLine(p.obiom);

                }
                sw.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }

        }
    }
}
    

