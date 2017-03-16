using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Named.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read();
            //Write();
            AsyncRead();
            Console.WriteLine("Press Enter to Exit.");
            Console.ReadLine();
        }
        static void Read()
        {
            using (NamedPipeClientStream pipeStream = new NamedPipeClientStream("testpipe"))
            {
                Console.WriteLine("等待连接");
                pipeStream.Connect();
                Console.WriteLine("已连接");
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
            using (NamedPipeClientStream pipeStream = new NamedPipeClientStream("testpipe"))
            {
                pipeStream.Connect();
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

        static int bufferSize = 6;
        static byte[] buffer = new byte[bufferSize];
        static NamedPipeClientStream pipeStream;
        static async void AsyncRead()
        {
            pipeStream = new NamedPipeClientStream("testpipe");
            Console.WriteLine("异步接收 等待连接");
            pipeStream.Connect();
            Console.WriteLine("已连接");
            Console.WriteLine("Read:" + pipeStream.CanRead + " / Write:" + pipeStream.CanRead + " / Async:" + pipeStream.IsAsync);

            int a = await pipeStream.ReadAsync(buffer, 0, bufferSize);
            buffer.ToList().ForEach(x =>
            {
                Console.Write(x + " ");
            });
            int b = await pipeStream.ReadAsync(buffer, 0, bufferSize);
            buffer.ToList().ForEach(x =>
            {
                Console.Write(x + " ");
            });
            int c = await pipeStream.ReadAsync(buffer, 0, bufferSize);
            buffer.ToList().ForEach(x =>
            {
                Console.Write(x + " ");
            });
            int d = await pipeStream.ReadAsync(buffer, 0, bufferSize);
            buffer.ToList().ForEach(x =>
            {
                Console.Write(x + " ");
            });
            Console.WriteLine("读取结束");
        }
    }
}
