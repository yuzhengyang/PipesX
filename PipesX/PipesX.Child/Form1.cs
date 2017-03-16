using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PipesX.Child
{
    public partial class Form1 : Form
    {
        string PipeName;
        bool IsStart = false;
        object LockPipe = new object();
        NamedPipeClientStream PipeStream;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void BtGo_Click(object sender, EventArgs e)
        {
            PipeName = TbPipeName.Text.Trim();
            if (PipeName != "")
            {
                Go2(PipeName);
            }
            else
            {
                Print("管道名称不能为空！");
            }
        }
        private void BtSend_Click(object sender, EventArgs e)
        {
            Send(TbMsg.Text.Trim());
        }
        private void Print(string s)
        {
            BeginInvoke(new Action(() =>
            {
                TbTxt.Text = s + Environment.NewLine + TbTxt.Text;
            }));
        }
        private void ChangeStatus(bool isGo)
        {
            BeginInvoke(new Action(() =>
            {
                if (isGo)
                {
                    BtGo.BackColor = SystemColors.ActiveCaption;
                }
                else
                {
                    BtGo.BackColor = SystemColors.Control;
                }
            }));
        }
        private void Go(string pipeName)
        {
            Task.Factory.StartNew(() =>
            {
                if (!IsStart)
                {
                    lock (LockPipe)
                    {
                        if (!IsStart)
                        {
                            IsStart = true;
                            PipeStream = new NamedPipeClientStream(pipeName);
                            Print("准备连接");
                            PipeStream.Connect();
                            Print("已连接");

                            //PipeStream.BeginRead();
                            using (StreamReader sr = new StreamReader(PipeStream))
                            {
                                string temp;
                                while ((temp = sr.ReadLine()) != null)
                                {
                                    Print(temp);
                                }
                                Print("已停止");
                            }
                        }
                    }
                }
            });
        }
        private void Go2(string pipeName)
        {
            if (!IsStart)
            {
                lock (LockPipe)
                {
                    if (!IsStart)
                    {
                        IsStart = true;

                        Task.Factory.StartNew(() =>
                        {
                            PipeStream = new NamedPipeClientStream(pipeName);
                            Print("准备连接");
                            PipeStream.Connect();
                            Print("已连接");
                            using (StreamWriter sw = new StreamWriter(PipeStream))
                            {
                                sw.AutoFlush = true;
                                while (IsStart)
                                {
                                    string s = DateTime.Now.ToString();
                                    sw.WriteLine(s);
                                    Print("Send: " + s);
                                    Thread.Sleep(1000);
                                }
                            }
                            IsStart = false;
                            PipeStream.Dispose();
                        });
                        Task.Factory.StartNew(() =>
                        {
                            using (StreamReader sr = new StreamReader(PipeStream))
                            {
                                string temp;
                                while ((temp = sr.ReadLine()) != null)
                                {
                                    Print(temp);
                                }
                                Print("已停止");
                            }
                        });
                    }
                }
            }
        }
        private void Send(string s)
        {
            Task.Factory.StartNew(() =>
            {
                if (IsStart && PipeStream.IsConnected)
                {
                    using (StreamWriter sw = new StreamWriter(PipeStream))
                    {
                        sw.AutoFlush = true;
                        sw.WriteLine(s);
                        Print("Send: " + s);
                    }
                }
                else
                {
                    Print("未连接");
                }
            });
        }
    }
}