using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrowseFolderPrac
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Label label1 = new Label();
            label1.Text = "Label 1";
            Button activeBrowse = new Button();
            activeBrowse.Text = "Browse for windows";


        }

        private void folderPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dia = new OpenFileDialog();
            dia.InitialDirectory = "C://";
            DialogResult result = dia.ShowDialog();
            if (result.ToString() ==                "OK")
                label1.Text = dia.FileName;

            //if (folderBrowserDialog1.ShowDialog() == DialogResult)
            //this.label1.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label1.Text != "Label 1") {
                StreamReader reader = new StreamReader(label1.Text);
                var builder = new StringBuilder();
                while (!reader.EndOfStream) {
                    builder.Append(reader.ReadLine());
                }
                FileStuff.Text = builder.ToString();
            }
        }
    }
}
