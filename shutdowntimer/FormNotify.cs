using System.Windows.Forms;

namespace shutdowntimer
{
    public partial class FormNotify : Form
    {
        // ローカル フィールド
        #region LocalFields

        int remain = 10;
        
        #endregion

        // デザイナ メソッド
        #region DesignerMethods

        public FormNotify()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void shown(object sender, System.EventArgs e)
        {
            setNotifyMessage();
        }

        private void timer_Tick(object sender, System.EventArgs e)
        {
            --remain;

            if (remain < 1)
            {
                timer.Stop();
                DialogResult = DialogResult.OK;
            }

            setNotifyMessage();
        }

        #endregion

        // ローカル メソッド
        #region LocalMethods

        void setNotifyMessage()
        {
            labelNotify.Text = string.Format("This Operating System will be shutdown at {0} seconds later.", remain);
        }

        #endregion
    }
}
