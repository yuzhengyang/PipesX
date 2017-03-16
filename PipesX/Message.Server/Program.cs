using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            string message1 = "Named Pipe Message Example.";
            string message2 = "Another Named Pipe Message Example.";
            Byte[] bytes;
            using (NamedPipeServerStream pipeStream = new NamedPipeServerStream("messagepipe", PipeDirection.InOut, 1, PipeTransmissionMode.Message, PipeOptions.None))
            {
                pipeStream.WaitForConnection();

                // Let’s send two messages.
                bytes = encoding.GetBytes(message1);
                pipeStream.Write(bytes, 0, bytes.Length);
                bytes = encoding.GetBytes(message2);
                pipeStream.Write(bytes, 0, bytes.Length);

                string line;
                while((line = Console.ReadLine()) != "stop")
                {
                    bytes = encoding.GetBytes(line);
                    pipeStream.Write(bytes, 0, bytes.Length);
                }

            }

            Console.WriteLine("Press Enter to Exit.");
            Console.ReadLine();
        }
    }
}
