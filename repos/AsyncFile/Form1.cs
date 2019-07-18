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

namespace AsyncFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            //string filePath = @"C:\Users\shiweitun\Desktop\aaa.txt";
            //string text = "Hello World\r\n";

            //await WriteAsync(filePath, text);
            ProcessWriteMult();
        }

        public async void ProcessWriteMult()
        {
            string folder = @"C:\Users\shiweitun\Desktop\aaa\";
            List<Task> tasks = new List<Task>();
            List<FileStream> sourceStreams = new List<FileStream>();

            try
            {
                for (int index = 1; index <= 10; index++)
                {
                    string text = "In file " + index.ToString() + "\r\n";

                    string fileName = "thefile" + index.ToString("00") + ".txt";
                    string filePath = folder + fileName;

                    if (!File.Exists(filePath))
                    {
                        File.Create(filePath);
                    }
                    byte[] encodedText = Encoding.Unicode.GetBytes(text);

                    FileStream sourceStream = new FileStream(filePath,
                        FileMode.Open, FileAccess.Write, FileShare.None,
                        bufferSize: 4096, useAsync: true);

                    Task theTask = sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
                    sourceStreams.Add(sourceStream);

                    tasks.Add(theTask);
                }

                await Task.WhenAll(tasks);
            }

            finally
            {
                foreach (FileStream sourceStream in sourceStreams)
                {
                    sourceStream.Close();
                }
            }
        }
        private async Task WriteAsync(string path, string text)
        {
            var bytes = Encoding.Unicode.GetBytes(text);
            using (var fileStream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.None,
                bufferSize: 4096, useAsync: true))
            {
                await fileStream.WriteAsync(bytes, 0, bytes.Length);
            }
        }
    }
}
