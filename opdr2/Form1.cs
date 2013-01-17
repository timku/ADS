using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            //System.Windows.Forms.MessageBox.Show("mult: " + palindrome("po0op"));
            //progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;

        }
        private int mult(int x, int y)
        {
            if (1 > y) return 0;
            else return x + mult(x, --y);
        }
        private void print(string s, int pos)
        {
            if (s.Length > pos){
                char[] array = s.ToCharArray();
                //Console.print("" + array[(s.Length - 1) - pos]);
                print(s, ++pos);
            }
        }
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            string fileName = "";
            string name;
            //int Count = 0;//set count to 0 to interate through file line by line for linear search
            OpenFileDialog OpenFile = new OpenFileDialog();//declare variable
            OpenFile.Filter = "Dictionary files (*.dic)|*.dic|All files (*.*) | *.*"; //filter by these file types
            OpenFile.FilterIndex = 0;//show first file type?
            fileName = OpenFile.FileName;//declare variable

            if (OpenFile.ShowDialog() == DialogResult.OK)//if file found then display results to screen
            {
                woorden.Items.Clear();
                foreach (string file in OpenFile.FileNames)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    long fileSize = fileInfo.Length;
                    long fileSizeDone = 0;
                    progressBar.Maximum = (int)(float)fileSize;
                    //System.Windows.Forms.MessageBox.Show("Filesize: " + );
                    TextReader sr = new StreamReader(file);//read file using streamreader

                    while ((name = sr.ReadLine()) != null)//read textreader variable line by line
                    {
                        woorden.Items.Add(name);
                        fileSizeDone += name.Length;
                        progressBar.Increment(name.Length);
                        //progressBar.Value = (int)((float)(100 / fileSize) * fileSizeDone);
                    }
                    sr.Close();
                }
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            int itemsCount = woorden.Items.Count;
            string[] items = new string[itemsCount];
            for (int i = 0; i < itemsCount; i++)
                items[i] = woorden.Items[i].ToString();

            woorden.Items.Clear();
            int wordsfound = 0;
            for (int i = 0; i < itemsCount; i++)
            {
                if (palindrome(items[i]))
                {
                    wordsfound++;
                    woorden.Items.Add(items[i]);
                    //woorden.Items.Remove(woorden.Items[i]);
                }

            }
            woorden.Refresh();
            System.Windows.Forms.MessageBox.Show("Words found: " + wordsfound);
        }
        private bool palindrome(string word)
        {
            return palindrome(GetBytes(word), 0);
        }
        private bool palindrome(byte[] word, int pos)
        {
            if (word.Length / 2 >= pos){
                if (word[pos] != word[(word.Length - 1) - pos])
                    return false;
                else if(!palindrome(word, ++pos))
                    return false;
            }
            return true;
        }
        private byte[] GetBytes(string str)
        {
            return Encoding.ASCII.GetBytes(str);
        }

    }
}
