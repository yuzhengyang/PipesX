using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PipesX.Server
{
    public partial class ServerForm : Form
    {
        public string PipeName = "pipex.pipe";
        public NamedPipeServerStream NamedPipe;
        public ServerForm()
        {
            InitializeComponent();
        }

        #region UI 输出
        private void UITbSend(string s)
        {
            BeginInvoke(new Action(() =>
            {
                //发送信息输出
                TbSend.Text += Environment.NewLine;
                TbSend.Text += "S: " + s;
                TbSend.Select(TbSend.Text.Length, 0);
                TbSend.ScrollToCaret();
            }));
        }
        private void UITbReceive(string s)
        {
            BeginInvoke(new Action(() =>
            {
                TbReceive.Text += Environment.NewLine;
                TbReceive.Text += "R: " + s;
                TbReceive.Select(TbReceive.Text.Length, 0);
                TbReceive.ScrollToCaret();
            }));
        }
        private void UITbCmd(string s)
        {
            BeginInvoke(new Action(() =>
            {
                //命令信息输出
                TbCmd.Text += Environment.NewLine;
                TbCmd.Text += "C: " + s;
                TbCmd.Select(TbCmd.Text.Length, 0);
                TbCmd.ScrollToCaret();
            }));
        }
        #endregion

        private void BtConnect_Click(object sender, EventArgs e)
        {
            NamedPipe = new NamedPipeServerStream(PipeName);
            UITbCmd("等待客户端连接");
            NamedPipe.WaitForConnection();
            UITbCmd("客户端已连接");
        }

        static int bufferSize = 20;
        static byte[] buffer = new byte[bufferSize];
        private void BtReceive_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                List<byte> box = new List<byte>();
                while (NamedPipe.IsConnected)
                {
                    try
                    {
                        byte[] recByte = new byte[10];
                        int recLength = NamedPipe.Read(recByte, 0, recByte.Length);
                        for (int k = 0; k < recLength; k++)
                        {
                            box.Add(recByte[k]);
                        }

                        if (box.Count > 6 && box[0] == 0x4A && box[1] == 0x50)
                        {
                            int msgBodyLength = BitConverter.ToInt32(new byte[] { box[2], box[3], box[4], box[5] }, 0);
                            if (box.Count >= 6 + msgBodyLength)
                            {
                                byte[] body = box.GetRange(6, msgBodyLength).ToArray();
                                string bodyToGBK = Encoding.GetEncoding("GBK").GetString(body);
                                if (bodyToGBK.Length > 0)
                                {
                                    //收到信息输出
                                    //Console.WriteLine("Receive:" + body.Length + "B,[" + bodyToGBK + "]");
                                    UITbReceive(bodyToGBK);
                                }
                                box.RemoveRange(0, 6 + msgBodyLength);
                            }
                        }
                        else
                        {
                            box.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        break;
                    }
                }
            });
        }

        private void BtSend_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                while (NamedPipe.IsConnected)
                {
                    try
                    {
                        string msg = "Server " + DateTime.Now.ToString("fff");
                        byte[] msgHead = new byte[] { 0x4A, 0x50 };
                        byte[] msgBody = Encoding.GetEncoding("GBK").GetBytes(msg);
                        byte[] msgBodyLength = BitConverter.GetBytes(msgBody.Length);

                        byte[] content = new byte[msgHead.Length + msgBodyLength.Length + msgBody.Length];
                        msgHead.CopyTo(content, 0);
                        msgBodyLength.CopyTo(content, msgHead.Length);
                        msgBody.CopyTo(content, content.Length - msgBody.Length);
                        NamedPipe.Write(content, 0, content.Count());

                        UITbSend(msg);
                    }
                    catch (Exception ex)
                    {
                        break;
                    }
                    Thread.Sleep(1000);
                }
            });
        }
    }
}
