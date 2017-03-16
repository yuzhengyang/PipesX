using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;

namespace Anonymous.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write(args[0]);//Client 写入数据，对应 Server 读取数据
            Read(args[0]);//Client 读取数据，对应 Server 写入数据

            Console.WriteLine("Press Enter to Exit.");
            Console.ReadLine();
        }
        static void Read(string handle)
        {
            using (StreamReader sr = new StreamReader(new AnonymousPipeClientStream(PipeDirection.In, handle)))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine("Client Receive: {0}", line);
                }
            }
        }
        static void Write(string handle)
        {
            using (StreamWriter sw = new StreamWriter(new AnonymousPipeClientStream(PipeDirection.Out, handle)))
            {
                sw.AutoFlush = true;
                for (int i = 0; i < 300; i++)
                {
                    //向匿名管道中写入内容
                    sw.WriteLine(DateTime.Now.ToString());
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
