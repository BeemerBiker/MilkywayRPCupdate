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
        static void Main(string[] args)
        {

            GetMWproj();
            var t = Task.Run(async delegate
            {
                await Task.Delay(500);
            });
            Console.WriteLine("Waiting:1\n");
            t.Wait();
            Console.WriteLine("Waiting:2\n");

        }

        static string strPassword = "";


        static async Task GetMWproj()
        {

            using (RpcClient rpcClient = new RpcClient())
            {
                await rpcClient.ConnectAsync("192.168.1.251", 31416);
                bool authorized = await rpcClient.AuthorizeAsync(strPassword);
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
