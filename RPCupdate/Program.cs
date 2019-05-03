using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoincRpc;
// note to myself:  the above only works if one used "add" to add the reference to "BoincRpc"

namespace RPCupdate
{
    class Program
    {

        static string strIP = "";
        static string strPW = "";
        static int bPort = 31416;

        static void Main(string[] args)
        {

            if(args.Length < 1)
            {
                Console.WriteLine("usage: <ipaddress> <password>\nExample: RPCupdate \"192.168.1.225\"");
                Console.WriteLine("or -  RPCupdate \"192.168.1.225\" \"your password\"");
                Console.WriteLine("use quotes if space in password");
            }
            if(args.Length > 0)
            {
                strIP = args[0];
            }
            if(args.Length > 1)
            {
                strPW = args[1];
            }
            //Console.WriteLine(strIP);
            //Console.WriteLine(strPW);
            GetMWproj();
            var t = Task.Run(async delegate
            {
                await Task.Delay(500);
            });
            Console.WriteLine("Waiting:1\n");
            t.Wait();
            Console.WriteLine("Waiting:2\n");

        }


        static async Task GetMWproj()
        {

            using (RpcClient rpcClient = new RpcClient())
            {
                await rpcClient.ConnectAsync(strIP, bPort);
                bool authorized = await rpcClient.AuthorizeAsync(strPW);
                CoreClientState ccs = await rpcClient.GetStateAsync();
                foreach (Project p in ccs.Projects)
                {
                    if (p.ProjectName == "Milkyway@Home")
                    {
                        await rpcClient.PerformProjectOperationAsync(p, ProjectOperation.Update);
                    Console.WriteLine("Sent Update\n");
                        break;
                    }
                }
            }
        }
    }
}
