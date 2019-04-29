using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoincRpc;

namespace TestRpc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LastCnt = -1;
            NumTasks = 0;
            GetMWproj();
        }

        int NumTasks = 0;
        int LastCnt = -1;
        private Project pMilkyway;
        private string strPassword = "";
        //private RpcClient rpcClient;

        private async Task GetMWproj()
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
                        pMilkyway = p;
                        await CountMilkyway();
                        break;
                    }
                }
            }
        }

        public async Task SendUpdate()
        {

            using (RpcClient rpcClient = new RpcClient())
            {
                await rpcClient.ConnectAsync("192.168.1.251", 31416);
                bool authorized = await rpcClient.AuthorizeAsync(strPassword);
                if(authorized)
                    await rpcClient.PerformProjectOperationAsync(pMilkyway, ProjectOperation.Update);
                button1.Enabled = true;
            }
        }

        public async Task CountMilkyway()
        {
            NumTasks = 0;

            using (RpcClient rpcClient = new RpcClient())
            {
                await rpcClient.ConnectAsync("192.168.1.251", 31416);
                bool authorized = await rpcClient.AuthorizeAsync(strPassword);
                CoreClientState ccs = await rpcClient.GetStateAsync();
                foreach (Workunit wu in ccs.Workunits)
                {
                    if (wu.ProjectUrl.Contains("milkyway"))
                    {
                        NumTasks++;
                    }

                }
                if (NumTasks == LastCnt) return;
                LastCnt = NumTasks;
                TBoxOutput.Text += NumTasks.ToString() + ", ";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            MWTimer.Enabled = true;
            TBoxOutput.Text += "Starting Timeout " + DateTime.Now.ToLongTimeString() + "\r\n"; ;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
        // goes off once per second but only do rpc ever 2 minutes;
        private void MWTimer_Tick(object sender, EventArgs e)
        {
            pBarTimer.Value++;
            if(pBarTimer.Value >= 119)
            {
                pBarTimer.Value = 0;
                if (NumTasks == 0)
                {
                    MWTimer.Enabled = false;
                    TBoxOutput.Text += "sending update " + DateTime.Now.ToLongTimeString() + "\r\n" ;
                    SendUpdate();
                    return;
                }
                pBarTimer.Value = 0;
                CountMilkyway();
            }
            return;
        }
    }
}
