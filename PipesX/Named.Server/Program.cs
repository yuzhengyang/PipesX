using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Named.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write();
            //Read();
            AsyncWrite();
            Console.WriteLine("Press Enter to Exit.");
            Console.ReadLine();
        }
        static void Read()
        {
            using (NamedPipeServerStream pipeStream = new NamedPipeServerStream("testpipe"))
            {
                pipeStream.WaitForConnection();
                //在client读取server端写的数据
                using (StreamReader rdr = new StreamReader(pipeStream))
                {
                    string temp;
                    while ((temp = rdr.ReadLine()) != "stop" && pipeStream.IsConnected)
                    {
                        Console.WriteLine("{0}:{1}", DateTime.Now, temp);
                    }
                }
            }
        }
        static void Write()
        {
            using (NamedPipeServerStream pipeStream = new NamedPipeServerStream("testpipe"))
            {
                pipeStream.WaitForConnection();
                using (StreamWriter writer = new StreamWriter(pipeStream))
                {
                    writer.AutoFlush = true;
                    string temp;

                    while ((temp = Console.ReadLine()) != "stop")
                    {
                        writer.WriteLine(temp);
                    }
                }
            }
        }

        static int bufferSize = 16;
        static byte[] buffer = new byte[bufferSize];
        static void AsyncWrite()
        {
            using (NamedPipeServerStream pipeStream = new NamedPipeServerStream("testpipe"))
            {
                Console.WriteLine("异步发送 准备连接");
                pipeStream.WaitForConnection();
                Console.WriteLine("已连接");
                Console.WriteLine("Read:" + pipeStream.CanRead + " / Write:" + pipeStream.CanRead + " / Async:" + pipeStream.IsAsync);

                byte[] exp = new byte[] { 90, 66, 67, 68, 69, 70 };
                string temp;
                while ((temp = Console.ReadLine()) != "stop")
                {
                    exp[0]++;
                    pipeStream.Write(exp, 0, exp.Length);
                }
            }
        }
    }
}
