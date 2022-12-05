using SharpAdbClient;
using System;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AdbServer server = new AdbServer();
            AdbClient client = new AdbClient();
            var result = server.StartServer(@"C:\adb\adb.exe", restartServerIfNewer: true);
            var devices = client.GetDevices();
            var device = client.GetDevices().First();
            var receiver = new ConsoleOutputReceiver();
            client.ExecuteRemoteCommand("service call ate.service 1 s16 android_command s16 ProductId", device, receiver);
            Console.WriteLine("The device responded:");
            Console.WriteLine(receiver.ToString());
        }
    }
}