using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Decoder decoder = Encoding.UTF8.GetDecoder();
            Byte[] bytes = new Byte[10];
            Char[] chars = new Char[10];
            using (NamedPipeClientStream pipeStream = new NamedPipeClientStream("messagepipe"))
            {
                pipeStream.Connect();
                pipeStream.ReadMode = PipeTransmissionMode.Message;
                int numBytes;
                do
                {
                    string message = "";
                    do
                    {
                        numBytes = pipeStream.Read(bytes, 0, bytes.Length);
                        int numChars = decoder.GetChars(bytes, 0, numBytes, chars, 0);
                        message += new String(chars, 0, numChars);
                    } while (!pipeStream.IsMessageComplete);

                    decoder.Reset();
                    Console.WriteLine(message);
                } while (numBytes != 0);
            }

            Console.WriteLine("Press Enter to Exit.");
            Console.ReadLine();
        }
    }
}
