using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Named.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Read();
            //Write();
            Console.WriteLine("Press Enter to Exit.");
            Console.ReadLine();
        }
        static void Read()
        {
            using (NamedPipeClientStream pipeStream = new NamedPipeClientStream("testpipe"))
            {
                pipeStream.Connect();
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
    }
}
