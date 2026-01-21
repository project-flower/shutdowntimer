using System;
using System.Windows.Forms;

namespace shutdowntimer
{
    public partial class FormMain : Form
    {
        #region Private Fields

        private bool waitfor = true;
        private DateTime fireingTime = DateTime.MaxValue;
        private double remain = double.MaxValue;

        private System.Timers.Timer timer = new System.Timers.Timer()
        {
            AutoReset = false,
        };

        #endregion

        #region Public Methods

        public FormMain()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            timer.SynchronizingObject = this;
            timer.Elapsed += timer_Elapsed;
            TurnAwait();
        }

        #endregion

        #region Private Methods

        private void NotifyShutDown()
        {
            var formNotify = new FormNotify();

            if (formNotify.ShowDialog() != DialogResult.OK)
            {
                TurnAwait();
                return;
            }

            try
            {
                var shutDownSwitch = (ShutdownEngine.ShutDownSwitch)(comboBoxShutdownSwitch.SelectedItem);
                ShutdownEngine.DoShutdown(shutDownSwitch);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                TurnAwait();
                return;
            }

            Close();
        }

        private void SetRemain()
        {
            DateTime currentTime = DateTime.Now;
            remain = (fireingTime - currentTime).TotalMilliseconds;
            // System.Windows.Forms.Timerを使用した場合
            // timer1.Interval = ((remain > int.MaxValue) ? int.MaxValue : (int)remain);
            timer.Interval = (remain > 0 ? remain : 1);
        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer.Stop();

            if (fireingTime < DateTime.Now)
            {
                NotifyShutDown();
            }
            else
            {
                SetRemain();
                timer.Start();
            }
        }

        private void TurnAwait()
        {
            timer.Stop();
            waitfor = !waitfor;
            dateTimePicker.Enabled = !waitfor;
            comboBoxShutdownSwitch.Enabled = !waitfor;

            if (waitfor)
            {
                fireingTime = dateTimePicker.Value;
                SetRemain();
                buttonSet.Text = "Stop(&S)";
                timer.Start();
                return;
            }

            buttonSet.Text = "Set(&S)";
        }

        #endregion

        // Designer's Methods

        private void buttonSet_Click(object sender, EventArgs e)
        {
            if (!waitfor)
            {
                DateTime value = dateTimePicker.Value;
                dateTimePicker.Value = new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, 0);
            }

            TurnAwait();
        }

        private void load(object sender, EventArgs e)
        {
            ComboBox.ObjectCollection items = comboBoxShutdownSwitch.Items;
            items.Add(ShutdownEngine.ShutDownSwitch.PowerOff);
            items.Add(ShutdownEngine.ShutDownSwitch.Reboot);
            items.Add(ShutdownEngine.ShutDownSwitch.Logoff);
            items.Add(ShutdownEngine.ShutDownSwitch.Hibernate);
            items.Add(ShutdownEngine.ShutDownSwitch.StandBy);
            comboBoxShutdownSwitch.SelectedIndex = 0;
        }
    }
}
