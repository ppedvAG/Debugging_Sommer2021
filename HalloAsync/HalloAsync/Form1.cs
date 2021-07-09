using System;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalloAsync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                progressBar1.Value = i;
                Thread.Sleep(1000);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;

            Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    Thread.Sleep(100);
                    progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Value = i; });

                    //WPF  progressBar1.Dispatcher.Invoke(()=> progressBar1.Value = i; );

                    //progressBar1.Value = i;
                }
                this.Invoke((MethodInvoker)delegate { button2.Enabled = true; });
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            var ts = TaskScheduler.FromCurrentSynchronizationContext(); //ui-thread einsammeln
            cts = new CancellationTokenSource();

            Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    Thread.Sleep(100);

                    int ii = i;
                    Task.Factory.StartNew(() => progressBar1.Value = ii, cts.Token, TaskCreationOptions.None, ts);

                    if (cts.IsCancellationRequested)
                    {
                        //clean
                        break;
                    }
                }
                this.Invoke((MethodInvoker)delegate { button3.Enabled = true; });
            });

        }

        CancellationTokenSource cts = null;

        private void button4_Click(object sender, EventArgs e)
        {
            cts?.Cancel();

            //if (cts != null)
            //    cts.Cancel();
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            button5.Enabled = !true;
            for (int i = 0; i <= 100; i++)
            {
                progressBar1.Value = i;
                await Task.Delay(100);
            }
            button5.Enabled = !!!!!!!!!!!!true;
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            using (var sr = new StreamReader(@"..\..\..\Form1.cs"))
            {
                var src = await sr.ReadToEndAsync();
                MessageBox.Show(src.Substring(0, 1000));
            }

            try
            {

                using (var sqlCon = new SqlConnection("Server=timbuktu;Database=IsNotThere;Connect Timeout=3;"))
                {

                    // sqlCon.Open(); //blockt UI
                    await sqlCon.OpenAsync();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erwarteter Fehler beim Verbinden zu einer nicht vorhandenen Datenbank," +
                    " aber wir mussten auf den TimeOut warten");
            }
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Test: " + AltUndLangsam(4).ToString());
            MessageBox.Show("Test: " + (await AltUndLangsamAsync(4)).ToString());
        }

        public Task<long> AltUndLangsamAsync(int para1)
        {
            return Task.Run(() => AltUndLangsam(para1));
        }

        public long AltUndLangsam(int para1)
        {
            Thread.Sleep(5000);
            return 43587984357 * para1;
        }
    }
}

