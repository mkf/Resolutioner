using System.Runtime.CompilerServices;
using Microsoft.Win32;
using Resolutioner.Properties;

namespace Resolutioner
{
    public partial class Form1 : Form
    {
        Settings conf = Properties.Settings.Default;
        private static Screen srn = Screen.PrimaryScreen;
        public Form1()
        {
            InitializeComponent();
            loadConfig();
            if(loginCheckBox.Checked) Desire();
            SystemEvents.SessionSwitch += SystemEventsOnSessionSwitch; 
        }

        private void SystemEventsOnSessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            if (switchCheckBox.Checked)
            {
                switch(e.Reason)
                {
                    case SessionSwitchReason.ConsoleConnect:
                    case SessionSwitchReason.RemoteConnect:
                    case SessionSwitchReason.SessionLogon:
                    case SessionSwitchReason.SessionUnlock:
                        Desire();
                        break;
                    case SessionSwitchReason.ConsoleDisconnect:
                    case SessionSwitchReason.RemoteDisconnect:
                    case SessionSwitchReason.SessionLock:
                    case SessionSwitchReason.SessionLogoff:
                        Restore();
                        break;
                    case SessionSwitchReason.SessionRemoteControl:
                        break;
                }
            }
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
            if (_reallyClose)
            {
                SystemEvents.SessionSwitch -= SystemEventsOnSessionSwitch;
                e.Cancel = false;
            }
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
            if (!dontDoThingsCheckBox.Checked)
            {
                ActuallyChangingResolution.ChangeDisplaySettings((int) width, (int) height);
            }
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

        private static Tuple<decimal, decimal> fetchRes()
        {
            return new Tuple<decimal,decimal>(srn.Bounds.Width, srn.Bounds.Height);
        }

        private void fetchIntoRestore_Click(object sender, EventArgs e)
        {
            var fetch = fetchRes();
            if (desiredWidthField.Value != fetch.Item1 || desiredHeightField.Value != fetch.Item2)
            {
                restoreWidthField.Value = fetch.Item1;
                restoreHeightField.Value = fetch.Item2;
            }
            else
            {
                swapResolutionsButton.Focus();
            }
        }

        private void fetchIntoDesired_Click(object sender, EventArgs e)
        {
            var fetch = fetchRes();
            if (restoreWidthField.Value != fetch.Item1 || restoreHeightField.Value != fetch.Item2)
            {
                desiredWidthField.Value = fetch.Item1;
                desiredHeightField.Value = fetch.Item2;
            }
            else
            {
                swapResolutionsButton.Focus();
            }
        }

        private void loadConfig()
        {
            if(conf.DesiredWidth!=0) desiredWidthField.Value = conf.DesiredWidth;
            if(conf.DesiredHeight!=0) desiredHeightField.Value = conf.DesiredHeight;
            if(conf.RestoreWidth!=0) restoreWidthField.Value = conf.RestoreWidth;
            if(conf.RestoreHeight!=0) restoreHeightField.Value = conf.RestoreHeight;
            loginCheckBox.Checked = conf.OnLogin;
            switchCheckBox.Checked = conf.OnSwitch;
            logoffCheckBox.Checked = conf.OnLogoff;
            dontDoThingsCheckBox.Checked = conf.DontDoThings;
        }

        private void saveConfig()
        {
            conf.DesiredWidth = desiredWidthField.Value;
            conf.DesiredHeight = desiredHeightField.Value;
            conf.RestoreWidth = restoreWidthField.Value;
            conf.RestoreHeight = restoreHeightField.Value;
            conf.OnLogin = loginCheckBox.Checked;
            conf.OnSwitch = switchCheckBox.Checked;
            conf.OnLogoff = logoffCheckBox.Checked;
            conf.DontDoThings = dontDoThingsCheckBox.Checked;
            conf.Save();
        }

        private bool weChangeChecked = false;
        private void stateConfigSavedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!weChangeChecked)
            {
                if (stateConfigSavedCheckBox.Checked)
                {
                    saveConfig();
                }
                else
                {
                    loadConfig();
                }
            }
            else weChangeChecked = false;
        }

        private void onValuesChanged()
        {
            weChangeChecked = true;
            stateConfigSavedCheckBox.Checked = false;
        }

        private void desiredWidthField_ValueChanged(object sender, EventArgs e)
        {
            onValuesChanged();
        }

        private void desiredHeightField_ValueChanged(object sender, EventArgs e)
        {
            onValuesChanged();
        }

        private void restoreWidthField_ValueChanged(object sender, EventArgs e)
        {
            onValuesChanged();
        }

        private void restoreHeightField_ValueChanged(object sender, EventArgs e)
        {
            onValuesChanged();
        }

        private void loginCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            onValuesChanged();
        }

        private void switchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            onValuesChanged();
        }

        private void logoffCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            onValuesChanged();
        }

        private void dontDoThingsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            onValuesChanged();
        }
    }
}