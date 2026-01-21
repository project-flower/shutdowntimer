using System.Windows.Forms;

namespace shutdowntimer
{
    public partial class FormNotify : Form
    {
        #region Private Fields

        private int remain = 10;

        #endregion

        #region Public Methods

        public FormNotify()
        {
            InitializeComponent();
        }

        #endregion

        // Designer's Methods

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void SetNotifyMessage()
        {
            labelNotify.Text = $"This Operating System will be shutdown at {remain} seconds later.";
        }

        private void shown(object sender, System.EventArgs e)
        {
            remain = 10;
            SetNotifyMessage();
        }

        private void timer_Tick(object sender, System.EventArgs e)
        {
            --remain;

            if (remain < 1)
            {
                timer.Stop();
                DialogResult = DialogResult.OK;
            }

            SetNotifyMessage();
        }
    }
}
