using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;

namespace Anonymous.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read();//Server 读取数据，对应 Client 写入数据
            Write();//Server 写入数据，对应 Client 读取数据

            Console.WriteLine("Press Enter to Exit.");
            Console.ReadLine();
        }
        static void Write()
        {
            //客户端程序路径
            string clientFile = @"D:\CoCo\GitHub\PipesX\PipesX\Anonymous.Client\bin\Debug\Anonymous.Client.exe";
            Process process = new Process();
            process.StartInfo.FileName = clientFile;
            //创建匿名管道流实例，
            using (AnonymousPipeServerStream pipeStream = new AnonymousPipeServerStream(PipeDirection.Out, HandleInheritability.Inheritable))
            {
                //将句柄传递给子进程
                process.StartInfo.Arguments = pipeStream.GetClientHandleAsString();
                process.StartInfo.UseShellExecute = false;
                process.Start();
                //销毁子进程的客户端句柄？
                pipeStream.DisposeLocalCopyOfClientHandle();

                using (StreamWriter sw = new StreamWriter(pipeStream))
                {
                    string line;
                    while ((line = Console.ReadLine()) != "stop")
                    {
                        sw.AutoFlush = true;
                        //向匿名管道中写入内容
                        sw.WriteLine(line);
                    }
                }
            }
            process.WaitForExit();
            process.Close();
        }
        static void Read()
        {
            //客户端程序路径
            string clientFile = @"D:\CoCo\GitHub\PipesX\PipesX\Anonymous.Client\bin\Debug\Anonymous.Client.exe";
            Process process = new Process();
            process.StartInfo.FileName = clientFile;
            //创建匿名管道流实例，
            using (AnonymousPipeServerStream pipeStream = new AnonymousPipeServerStream(PipeDirection.In, HandleInheritability.Inheritable))
            {
                //将句柄传递给子进程
                process.StartInfo.Arguments = pipeStream.GetClientHandleAsString();
                process.StartInfo.UseShellExecute = false;
                process.Start();
                //销毁子进程的客户端句柄？
                pipeStream.DisposeLocalCopyOfClientHandle();

                using (StreamReader sr = new StreamReader(pipeStream))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine("Server Receive: {0}", line);
                    }
                }
            }
            process.WaitForExit();
            process.Close();
        }
    }
}
