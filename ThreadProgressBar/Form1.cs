using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadProgressBar
{
    public partial class Form1 : Form
    {

        CancellationTokenSource cts;

        BackgroundWorker bw = new BackgroundWorker();
        Task task;
        protected Thread thread;
        protected ThreadSum ts;
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;

            DoWorkEventHandler d = new DoWorkEventHandler(DoWork);
            ProgressChangedEventHandler p = new ProgressChangedEventHandler(ProgressChanged);

            bw.DoWork += d;
            bw.ProgressChanged += p;
            bw.WorkerReportsProgress = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            task = new Task(new Action(ProgressBarMethod));
            task.Start();
            //bw.RunWorkerAsync(); //3
            //thread = new Thread(ProgressBarMethod); //1
            //thread.Start(); //1
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cts.Cancel();

            if (task.IsCompleted)
            {
                button1.Enabled = true;
                button2.Enabled = false;
            }

            //thread.Abort();
            //if (thread.ThreadState == ThreadState.Aborted)
            //{
            //    thread = null;
            //    button1.Enabled = true;
            //    button2.Enabled = false;
            //}
        }

        private void ProgressBarMethod()
        {
            cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;

            int count = 0;

            while (true)
            {
                for (int i = 0; i < 100; i++)
                {
                    try
                    {
                        
                        progressBar1.Invoke((Action<int>)((value) => { progressBar1.Value = value % progressBar1.Maximum; }), i);
                        Thread.Sleep(100);
                        ct.ThrowIfCancellationRequested();
                    }
                    //catch (ThreadAbortException)//1
                    catch (OperationCanceledException)
                    {
                        //if (count == 0)
                        //{
                        //    Thread.ResetAbort();
                        //}
                        if (count == 1)
                            return;
                    }
                }
                
                count = 1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ts = new ThreadSum(new List<int> { 10, 10 }, new List<int> { 20, 20 });

            thread = new Thread(ts.Sum);

            thread.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ToDo Join
            if (thread.ThreadState == ThreadState.Stopped)
            {
                MessageBox.Show(string.Format("{0}", ts.Result));
            }
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            {
                int count = 0;

                while (true)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        bw.ReportProgress(i % 100);
                        Thread.Sleep(10);
                    }
                    count = 1;
                }
            }
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Invoke((Action<int>)((value) => { progressBar1.Value = value; }), e.ProgressPercentage);
        }

    }
}
