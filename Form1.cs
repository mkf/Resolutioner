namespace Resolutioner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) Hide();
            else if (WindowState == FormWindowState.Maximized) WindowState = FormWindowState.Normal;
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            switch (WindowState)
            {
                case FormWindowState.Minimized:
                    Show();
                    this.WindowState = FormWindowState.Normal;
                    break;
                case FormWindowState.Normal:
                case FormWindowState.Maximized:
                    Hide();
                    this.WindowState = FormWindowState.Minimized;
                    break;
            }
            
        }

        private static readonly int WM_QUERYENDSESSION = 0x11;
        private static bool _logoffOrShutdown = false;
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == WM_QUERYENDSESSION)
            {
                _logoffOrShutdown = true;
            }
            base.WndProc(ref m);

        }

        private static bool _reallyClose = false;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_reallyClose) e.Cancel = false;
            else if (!_logoffOrShutdown)
            {
                e.Cancel = true;
                Hide();
                this.WindowState = FormWindowState.Minimized;
            }
            else if (logoffCheckBox.Checked || shutdownCheckBox.Checked)
            {
                Show();
                Restore();
                e.Cancel = false;
            }
        }

        private void Restore()
        {
            DoResolution(restoreWidthField.Value, restoreHeightField.Value);
        }

        private void Desire()
        {
            DoResolution(desiredWidthField.Value, desiredHeightField.Value);
        }

        private void DoResolution(decimal width, decimal height)
        {
            if(!dontDoThingsCheckBox.Checked) {}
        }

        private void endProgramButton_Click(object sender, EventArgs e)
        {
            _reallyClose = true;
            this.Close();
        }

        private void nowRestoreButton_Click(object sender, EventArgs e)
        {
            Restore();
        }

        private void nowDesiredButton_Click(object sender, EventArgs e)
        {
            Desire();
        }

        private void swapResolutionsButton_Click(object sender, EventArgs e)
        {
            decimal desiredWidth = desiredWidthField.Value;
            decimal desiredHeight = desiredHeightField.Value;
            decimal restoreWidth = restoreWidthField.Value;
            decimal restoreHeight = restoreHeightField.Value;
            desiredWidthField.Value = restoreWidth;
            desiredHeightField.Value = restoreHeight;
            restoreWidthField.Value = desiredWidth;
            restoreHeightField.Value = desiredHeight;
        }
    }
}