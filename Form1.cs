using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using api;
using Bridge;
using System.IO;

namespace new_tutorial
{
    public partial class Form1 : Form
    {
        Functions funcs = new Functions();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            funcs.Login();
            try
            {
                DirectoryInfo dirinfo = new DirectoryInfo("scripts");
                FileInfo[] Files = dirinfo.GetFiles("*.*");
                foreach (FileInfo file in Files)
                {
                    listBox1.Items.Add(file.Name);
                }
            }
            catch (Exception ex){}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "All Files (*.*)|*.*|Text Files (.txt)|*.txt|Lua Files (.lua)|*.lua";
            save.RestoreDirectory = true;
            if(save.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(save.FileName, richTextBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            funcs.Execute(richTextBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All Files (*.*)|*.*|Text Files (.txt)|*.txt|Lua Files (.lua)|*.lua";
            open.RestoreDirectory = true;
            if (open.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(open.FileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            funcs.Inject();
            funcs.WarnOnInject = true;
        }

        private void executeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcs.Execute(File.ReadAllText($"scripts\\{listBox1.SelectedItem}"));
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = File.ReadAllText($"scripts\\{listBox1.SelectedItem}");
        }
    }
}
