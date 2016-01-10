using System;
using System.Windows.Forms;

namespace shutdowntimer
{
    public partial class FormMain : Form
    {
        bool waitfor = true;
        DateTime fireingTime = DateTime.MaxValue;
        double remain = double.MaxValue;

        System.Timers.Timer timer = new System.Timers.Timer()
        {
            AutoReset = false,
        };

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer.Stop();

            if (fireingTime < DateTime.Now)
            {
                notifyShutDown();
            }
            else
            {
                setRemain();
                timer.Start();
            }
        }

        void notifyShutDown()
        {
            var formNotify = new FormNotify();

            if (formNotify.ShowDialog() != DialogResult.OK)
            {
                turnAwait();
                return;
            }

            try
            {
                var shutDownSwitch = (ShutdownEngine.ShutDownSwitch)(comboBoxShutdownSwitch.SelectedItem);
                ShutdownEngine.ShutDown(shutDownSwitch);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                turnAwait();
                return;
            }

            Close();
        }

        void setRemain()
        {
            DateTime currentTime = DateTime.Now;
            remain = (fireingTime - currentTime).TotalMilliseconds;
            // System.Windows.Forms.Timerを使用した場合
            // timer1.Interval = ((remain > int.MaxValue) ? int.MaxValue : (int)remain);
            timer.Interval = (remain > 0 ? remain : 1);
        }

        void turnAwait()
        {
            timer.Stop();
            waitfor = !waitfor;
            dateTimePicker.Enabled = !waitfor;

            if (waitfor)
            {
                fireingTime = dateTimePicker.Value;
                setRemain();
                buttonSet.Text = "Stop(&S)";
                timer.Start();
                return;
            }

            buttonSet.Text = "Set(&S)";
        }

        public FormMain()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            timer.SynchronizingObject = this;
            timer.Elapsed += timer_Elapsed;
            turnAwait();
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            if (!waitfor)
            {
                DateTime value = dateTimePicker.Value;
                dateTimePicker.Value = new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, 0);
            }

            turnAwait();
        }

        private void load(object sender, EventArgs e)
        {
            comboBoxShutdownSwitch.Items.Add(ShutdownEngine.ShutDownSwitch.PowerOff);
            comboBoxShutdownSwitch.Items.Add(ShutdownEngine.ShutDownSwitch.Reboot);
            comboBoxShutdownSwitch.Items.Add(ShutdownEngine.ShutDownSwitch.LogOff);
            comboBoxShutdownSwitch.Items.Add(ShutdownEngine.ShutDownSwitch.Hibernate);
            comboBoxShutdownSwitch.Items.Add(ShutdownEngine.ShutDownSwitch.StandBy);
            comboBoxShutdownSwitch.SelectedIndex = 0;
        }
    }
}
