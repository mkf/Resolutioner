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

        private static int WM_QUERYENDSESSION = 0x11;
        private static bool logoffOrShutdown = false;
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == WM_QUERYENDSESSION)
            {
                logoffOrShutdown = true;
            }
            base.WndProc(ref m);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            this.WindowState = FormWindowState.Minimized;
        }
    }
}