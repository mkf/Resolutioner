using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32;
using Windows.Win32.UI.WindowsAndMessaging;
using Microsoft.Win32;
using Resolutioner.Properties;

//#define DOTNETCONF //instead of the new ini files thing

namespace Resolutioner
{
    public partial class Form1 : Form
    {
#if DOTNETCONF
        Settings conf = Properties.Settings.Default;
#else
        private MyIniFile myIni = new();
        private MyIniFile.Config conf;
#endif
        private static Screen srn = Screen.PrimaryScreen;

        private System.EventHandler stateConfigSavedCheckbox_EventHandler;
        public Form1()
        {

            stateConfigSavedCheckbox_EventHandler = stateConfigSavedCheckBox_CheckedChanged;
#if DOTNETCONF
#else
            conf = myIni.Conf; // let it have it
#endif
            Console.WriteLine("Hello");
            InitializeComponent();
            loadConfig();
            if(loginCheckBox.Checked) Desire();
            SystemEvents.SessionSwitch += SystemEventsOnSessionSwitch; 
        }

        private void SystemEventsOnSessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            switch (e.Reason)
            {
                case SessionSwitchReason.ConsoleConnect:
                    if(onConsoleConnectBox.Checked) Desire();
                    break;
                case SessionSwitchReason.RemoteConnect:
                    if(onRemoteConnectBox.Checked) Desire();
                    break;
                case SessionSwitchReason.SessionLogon:
                    if(onSessionLogonBox.Checked) Desire();
                    break;
                case SessionSwitchReason.SessionUnlock:
                    if(onSessionUnlockBox.Checked) Desire();
                    break;
                case SessionSwitchReason.ConsoleDisconnect:
                    if(onConsoleDisconnectBox.Checked) Restore();
                    break;
                case SessionSwitchReason.RemoteDisconnect:
                    if(onRemoteDisconnectBox.Checked) Restore();
                    break;
                case SessionSwitchReason.SessionLock:
                    if(onSessionLockBox.Checked) Restore();
                    break;
                case SessionSwitchReason.SessionLogoff:
                    if(onSessionLogoffBox.Checked) Restore();
                    break;
                case SessionSwitchReason.SessionRemoteControl:
#pragma warning disable CS0436 // Typ powoduje konflikt z zaimportowanym typem
                    var gsm = PInvoke.GetSystemMetrics(
#pragma warning restore CS0436 // Typ powoduje konflikt z zaimportowanym typem
                        /* Wa¿noœæ	Kod	Opis	Projekt	Plik	Wiersz	Stan pominiêcia
                           B³¹d	CS1503	Argument „1”: nie mo¿na przekonwertowaæ z „int” na „Windows.Win32.UI.WindowsAndMessaging.SYSTEM_METRICS_INDEX”	Resolutioner	C:\Users\Mika Feiler\source\repos\Resolutioner\Form1.cs	41	Aktywne
                            */
                        (Windows.Win32.UI.WindowsAndMessaging.SYSTEM_METRICS_INDEX) 0x1000 /* SM_REMOTESESSION */);
                    switch (gsm)
                    {
                        case 0:
                            if(onRemoteControlOnBox.Checked) Desire();
                            break;
                        default:
                            if(onRemoteControlOffBox.Checked) Restore();
                            break;
                    }
                    break;
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
            Console.WriteLine("Changing resolution to %d %d", (int) width, (int) height);
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
#if DOTNETCONF
            conf.Upgrade();
#else
            conf = myIni.Conf; //just in case
#endif
            inhibitChangeChecked = true;
            if(conf.DesiredWidth!=0) desiredWidthField.Value = conf.DesiredWidth;
            if(conf.DesiredHeight!=0) desiredHeightField.Value = conf.DesiredHeight;
            if(conf.RestoreWidth!=0) restoreWidthField.Value = conf.RestoreWidth;
            if(conf.RestoreHeight!=0) restoreHeightField.Value = conf.RestoreHeight;
            loginCheckBox.Checked = conf.OnLogin;
            // switchCheckBox.Checked = conf.OnSwitch;
            bool yeah = true;
#if DOTNETCONF
            try
            {
                if (conf.confMigration == 0 && (conf["OnSwitch"] as bool? ?? false))
                {
                    onSessionLockBox.Checked = true;
                    onSessionUnlockBox.Checked = true;
                    onConsoleConnectBox.Checked = true;
                    onConsoleDisconnectBox.Checked = true;
                    onRemoteConnectBox.Checked = true;
                    onRemoteDisconnectBox.Checked = true;
                    onRemoteControlOnBox.Checked = true;
                    onRemoteControlOffBox.Checked = true;
                    onSessionLogonBox.Checked = true;
                    onSessionLogoffBox.Checked = true;
                    yeah = false;
                }
            } catch (System.Configuration.SettingsPropertyNotFoundException) {}
#endif
            if(yeah)
            {
#if DOTNETCONF
                onSessionLockBox.Checked = conf.onSessionLock;
                onSessionUnlockBox.Checked = conf.onSessionUnlock;
                onConsoleConnectBox.Checked = conf.onConsoleConnect;
                onConsoleDisconnectBox.Checked = conf.onConsoleDisconnect;
                onRemoteConnectBox.Checked = conf.onRemoteConnect;
                onRemoteDisconnectBox.Checked = conf.onRemoteDisconnect;
                onRemoteControlOnBox.Checked = conf.onRemoteOn;
                onRemoteControlOffBox.Checked = conf.onRemoteOff;
                onSessionLogonBox.Checked = conf.onSessionLogon;
                onSessionLogoffBox.Checked = conf.onSessionLogoff;
#else
                onSessionLockBox.Checked = conf.OnSessionLock;
                onSessionUnlockBox.Checked = conf.OnSessionUnlock;
                onConsoleConnectBox.Checked = conf.OnConsoleConnect;
                onConsoleDisconnectBox.Checked = conf.OnConsoleDisconnect;
                onRemoteConnectBox.Checked = conf.OnRemoteConnect;
                onRemoteDisconnectBox.Checked = conf.OnRemoteDisconnect;
                onRemoteControlOnBox.Checked = conf.OnRemoteOn;
                onRemoteControlOffBox.Checked = conf.OnRemoteOff;
                onSessionLogonBox.Checked = conf.OnSessionLogon;
                onSessionLogoffBox.Checked = conf.OnSessionLogoff;
#endif
            }
            logoffCheckBox.Checked = conf.OnLogoff;
            dontDoThingsCheckBox.Checked = conf.DontDoThings;
            //weChangeChecked = true;
            stateConfigSavedCheckBox.Checked = true;
            inhibitChangeChecked = false;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Style nazewnictwa", Justification = "<Oczekuj¹ce>")]
        private void saveConfig()
        {
#if DOTNETCONF
            conf.confMigration = 1;
#endif
            conf.DesiredWidth = desiredWidthField.Value;
            conf.DesiredHeight = desiredHeightField.Value;
            conf.RestoreWidth = restoreWidthField.Value;
            conf.RestoreHeight = restoreHeightField.Value;
            conf.OnLogin = loginCheckBox.Checked;
#if DOTNETCONF
            // conf.OnSwitch = switchCheckBox.Checked;
            try
            {
                if (conf["OnSwitch"] as bool? ?? false)
                    conf["OnSwitch"] = false;
            } catch (System.Configuration.SettingsPropertyNotFoundException) {}

            conf.onSessionLock = onSessionLockBox.Checked;
            conf.onSessionUnlock = onSessionUnlockBox.Checked;
            conf.onConsoleDisconnect = onConsoleDisconnectBox.Checked;
            conf.onConsoleConnect = onConsoleConnectBox.Checked;
            conf.onRemoteConnect = onRemoteConnectBox.Checked;
            conf.onRemoteDisconnect = onRemoteDisconnectBox.Checked;
            conf.onRemoteOn = onRemoteControlOnBox.Checked;
            conf.onRemoteOff = onRemoteControlOffBox.Checked;
            conf.onSessionLogon = onSessionLogonBox.Checked;
            conf.onSessionLogoff = onSessionLogoffBox.Checked;
#else
            conf.OnSessionLock = onSessionLockBox.Checked;
            conf.OnSessionUnlock = onSessionUnlockBox.Checked;
            conf.OnConsoleDisconnect = onConsoleDisconnectBox.Checked;
            conf.OnConsoleConnect = onConsoleConnectBox.Checked;
            conf.OnRemoteConnect = onRemoteConnectBox.Checked;
            conf.OnRemoteDisconnect = onRemoteDisconnectBox.Checked;
            conf.OnRemoteOn = onRemoteControlOnBox.Checked;
            conf.OnRemoteOff = onRemoteControlOffBox.Checked;
            conf.OnSessionLogon = onSessionLogonBox.Checked;
            conf.OnSessionLogoff = onSessionLogoffBox.Checked;
#endif
            conf.OnLogoff = logoffCheckBox.Checked;
            conf.DontDoThings = dontDoThingsCheckBox.Checked;
#if DOTNETCONF
            conf.Save();
#else
            myIni.Write(conf);
#endif
        }

        //private bool weChangeChecked = true; // because apparently CheckedChanged happens at startup
        private bool inhibitChangeChecked = false;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Style nazewnictwa", Justification = "<Oczekuj¹ce>")]
        private void stateConfigSavedCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (inhibitChangeChecked) return;
            //if (!weChangeChecked)
            //{
            if (stateConfigSavedCheckBox.Checked)
            {
                saveConfig();
            }
            else
            {
#if DOTNETCONF
#else
                myIni.Read();
#endif
                loadConfig();
            }
            //}
            //else weChangeChecked = false;
        }
        /*
        private void InhibitCheckedChanged()
        {
            stateConfigSavedCheckBox.CheckedChanged -= stateConfigSavedCheckBox_CheckedChanged;
        }

        private void UnInhibitCheckedChanged()
        {
            stateConfigSavedCheckBox.CheckedChanged += stateConfigSavedCheckBox_CheckedChanged;
        }
        */

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Style nazewnictwa",
            Justification = "It's in the designer as handler, like the belows, and refactoring may fail")]
        private void onValuesChanged()
        {
            inhibitChangeChecked = true;
            stateConfigSavedCheckBox.Checked = false;
            inhibitChangeChecked = false;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Style nazewnictwa", Justification = "<Oczekuj¹ce>")]
        private void desiredWidthField_ValueChanged(object sender, EventArgs e)
        {
            onValuesChanged();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Style nazewnictwa", Justification = "<Oczekuj¹ce>")]
        private void desiredHeightField_ValueChanged(object sender, EventArgs e)
        {
            onValuesChanged();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Style nazewnictwa", Justification = "<Oczekuj¹ce>")]
        private void restoreWidthField_ValueChanged(object sender, EventArgs e)
        {
            onValuesChanged();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Style nazewnictwa", Justification = "<Oczekuj¹ce>")]
        private void restoreHeightField_ValueChanged(object sender, EventArgs e)
        {
            onValuesChanged();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Style nazewnictwa", Justification = "<Oczekuj¹ce>")]
        private void loginCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            onValuesChanged();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Style nazewnictwa", Justification = "<Oczekuj¹ce>")]
        private void logoffCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            onValuesChanged();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Style nazewnictwa", Justification = "<Oczekuj¹ce>")]
        private void dontDoThingsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            onValuesChanged();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Style nazewnictwa", Justification = "<Oczekuj¹ce>")]
        private void onSessionUnlockBox_CheckedChanged(object sender, EventArgs e)
        {
            onValuesChanged();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Style nazewnictwa", Justification = "<Oczekuj¹ce>")]
        private void onSessionLockBox_CheckedChanged(object sender, EventArgs e)
        {
            onValuesChanged();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Style nazewnictwa", Justification = "<Oczekuj¹ce>")]
        private void onSessionLogon_CheckedChanged(object sender, EventArgs e)
        {
            onValuesChanged();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Style nazewnictwa", Justification = "<Oczekuj¹ce>")]
        private void onSessionLogoff_CheckedChanged(object sender, EventArgs e)
        {
            onValuesChanged();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Style nazewnictwa", Justification = "<Oczekuj¹ce>")]
        private void onConsoleConnectBox_CheckedChanged(object sender, EventArgs e)
        {
            onValuesChanged();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Style nazewnictwa", Justification = "<Oczekuj¹ce>")]
        private void onConsoleDisconnectBox_CheckedChanged(object sender, EventArgs e)
        {
            onValuesChanged();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Style nazewnictwa", Justification = "<Oczekuj¹ce>")]
        private void onRemoteConnectBox_CheckedChanged(object sender, EventArgs e)
        {
            onValuesChanged();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Style nazewnictwa", Justification = "<Oczekuj¹ce>")]
        private void onRemoteDisconnectBox_CheckedChanged(object sender, EventArgs e)
        {
            onValuesChanged();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Style nazewnictwa", Justification = "<Oczekuj¹ce>")]
        private void onRemoteControlOn_CheckedChanged(object sender, EventArgs e)
        {
            onValuesChanged();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Style nazewnictwa", Justification = "<Oczekuj¹ce>")]
        private void onRemoteControlOff_CheckedChanged(object sender, EventArgs e)
        {
            onValuesChanged();
        }
    }
}