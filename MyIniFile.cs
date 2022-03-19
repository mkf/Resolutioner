using System.Text;

namespace Resolutioner;

public class MyIniFile
{
    public const string Filename = ".resolutioner.ini";
    public static readonly string Home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    public static readonly string Filepath = Path.Combine(Home, Filename);
    public FileStream FileStream;
    public Config Conf;


    public class Config
    {
        public int ConfMigration;
        public decimal DesiredWidth;
        public decimal DesiredHeight;
        public decimal RestoreWidth;
        public decimal RestoreHeight;
        public bool OnLogin;
        public bool OnLogoff;
        public bool DontDoThings;
        public bool OnSessionUnlock;
        public bool OnSessionLock;
        public bool OnSessionLogon;
        public bool OnSessionLogoff;
        public bool OnConsoleConnect;
        public bool OnConsoleDisconnect;
        public bool OnRemoteConnect;
        public bool OnRemoteDisconnect;
        public bool OnRemoteOn;
        public bool OnRemoteOff;

        public Config(
            int confMigration,
            decimal desiredWidth, decimal desiredHeight, decimal restoreWidth, decimal restoreHeight,
            bool onLogin, bool onLogoff,
            bool dontDoThings,
            bool onSessionUnlock, bool onSessionLock,
            bool onSessionLogon, bool onSessionLogoff,
            bool onConsoleConnect, bool onConsoleDisconnect,
            bool onRemoteConnect, bool onRemoteDisconnect,
            bool onRemoteOn, bool onRemoteOff)
        {
            ConfMigration = confMigration;
            DesiredWidth = desiredWidth;
            DesiredHeight = desiredHeight;
            RestoreWidth = restoreWidth;
            RestoreHeight = restoreHeight;
            OnLogin = onLogin;
            OnLogoff = onLogoff;
            DontDoThings = dontDoThings;
            OnSessionUnlock = onSessionUnlock;
            OnSessionLock = onSessionLock;
            OnSessionLogon = onSessionLogon;
            OnSessionLogoff = onSessionLogoff;
            OnConsoleConnect = onConsoleConnect;
            OnConsoleDisconnect = onConsoleDisconnect;
            OnRemoteConnect = onRemoteConnect;
            OnRemoteDisconnect = onRemoteDisconnect;
            OnRemoteOn = onRemoteOn;
            OnRemoteOff = onRemoteOff;
        }

        public Config(int confMigration)
        {
            ConfMigration = confMigration;
        }

        public Config()
        {
            ConfMigration = 2;
            DesiredWidth = 0;
            DesiredHeight = 0;
            RestoreWidth = 0;
            RestoreHeight = 0;
        }

        public Config(int confMigration, bool allBools)
        {
            ConfMigration = confMigration;
            OnLogin = allBools;
            OnLogoff = allBools;
            DontDoThings = allBools;
            OnSessionUnlock = allBools;
            OnSessionLock = allBools;
            OnSessionLogon = allBools;
            OnConsoleConnect = allBools;
            OnSessionLogoff = allBools;
            OnConsoleDisconnect = allBools;
            OnRemoteConnect = allBools;
            OnRemoteDisconnect = allBools;
            OnRemoteOn = allBools;
            OnRemoteOff = allBools;
        }

        public class Fields
        {
            public const string OnLogin = "On login";

            public const string OnLogoff = "On logoff";

            public const string DontDoThings = "Don't do things.";

            public const string OnSessionUnlock = "On session unlock";

            public const string OnSessionLock = "On session lock";

            public const string OnSessionLogon = "On session logon";

            public const string OnSessionLogoff = "On session logoff";

            public const string OnConsoleConnect = "On console connect";

            public const string OnConsoleDisconnect = "On console disconnect";

            public const string OnRemoteConnect = "On remote connect";

            public const string OnRemoteDisconnect = "On remote disconnect";

            public const string OnRemoteOn = "On remote control on";

            public const string OnRemoteOff = "On remote control off";
        }

        public string BoolsToString()
        {
            StringBuilder sb = new();
            const string format = "\n{0}";
            if (OnLogin) sb.AppendFormat(format, Fields.OnLogin);
            if (OnLogoff) sb.AppendFormat(format, Fields.OnLogoff);
            if (DontDoThings) sb.AppendFormat(format, Fields.DontDoThings);
            if (OnSessionUnlock) sb.AppendFormat(format, Fields.OnSessionUnlock);
            if (OnSessionLock) sb.AppendFormat(format, Fields.OnSessionLock);
            if (OnSessionLogon) sb.AppendFormat(format, Fields.OnSessionLogon);
            if (OnSessionLogoff) sb.AppendFormat(format, Fields.OnSessionLogoff);
            if (OnConsoleConnect) sb.AppendFormat(format, Fields.OnConsoleConnect);
            if (OnConsoleDisconnect) sb.AppendFormat(format, Fields.OnConsoleDisconnect);
            if (OnRemoteConnect) sb.AppendFormat(format, Fields.OnRemoteConnect);
            if (OnRemoteDisconnect) sb.AppendFormat(format, Fields.OnRemoteDisconnect);
            if (OnRemoteOn) sb.AppendFormat(format, Fields.OnRemoteOn);
            if (OnRemoteOff) sb.AppendFormat(format, Fields.OnRemoteOff);
            return sb.ToString();
        }
    }

    public MyIniFile()
    {
        try
        {
            FileStream = File.Open(Filepath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        }
        catch (FileNotFoundException)
        {
            FileStream = File.Open(Filepath, FileMode.CreateNew, FileAccess.Write, FileShare.None);
        }
        try
        {
            Read();
        }
        catch (FileFormatException)
        {
            Conf = new Config(2, 0, 0, 0, 0,
                false, false, false, true, false, false, false, false, false, false, false, false, false);
        }
        catch (ArgumentException)
        {
            Conf = new Config(-1);
            throw;
        }

        if (Conf == null) throw new Exception("aaaaaa");
    }

    public void Read()
    {
        if (FileStream.Length != 0)
        {
            try
            {
                var streamReader = new StreamReader(FileStream);
                var line = streamReader.ReadLine();
                var confMigration = Int32.Parse(line ?? throw new InvalidOperationException());
                if (confMigration == 2)
                {
                    var builder = new Config(confMigration, false);
                    do
                    {
                        line = streamReader.ReadLine() ?? throw new Exception("ugh no");
                        var strings = line.Split("/");
                        switch (strings[0])
                        {
                            case "Resolutions":
                                for (int i = 1; i <= 4; i++)
                                {
                                    var x = Int32.Parse(strings[i]);
                                    switch (i)
                                    {
                                        case 1:
                                            builder.DesiredWidth = x;
                                            break;
                                        case 2:
                                            builder.DesiredHeight = x;
                                            break;
                                        case 3:
                                            builder.RestoreWidth = x;
                                            break;
                                        case 4:
                                            builder.RestoreHeight = x;
                                            break;
                                    }
                                }

                                break;
                            case Config.Fields.OnLogin:
                                builder.OnLogin = true;
                                break;
                            case Config.Fields.OnLogoff:
                                builder.OnLogoff = true;
                                break;
                            case Config.Fields.DontDoThings:
                                builder.DontDoThings = true;
                                break;
                            case Config.Fields.OnSessionUnlock:
                                builder.OnSessionUnlock = true;
                                break;
                            case Config.Fields.OnSessionLock:
                                builder.OnSessionLock = true;
                                break;
                            case Config.Fields.OnSessionLogon:
                                builder.OnSessionLogon = true;
                                break;
                            case Config.Fields.OnSessionLogoff:
                                builder.OnSessionLogoff = true;
                                break;
                            case Config.Fields.OnConsoleConnect:
                                builder.OnConsoleConnect = true;
                                break;
                            case Config.Fields.OnConsoleDisconnect:
                                builder.OnConsoleDisconnect = true;
                                break;
                            case Config.Fields.OnRemoteConnect:
                                builder.OnRemoteConnect = true;
                                break;
                            case Config.Fields.OnRemoteDisconnect:
                                builder.OnRemoteDisconnect = true;
                                break;
                            case Config.Fields.OnRemoteOn:
                                builder.OnRemoteOn = true;
                                break;
                            case Config.Fields.OnRemoteOff:
                                builder.OnRemoteOff = true;
                                break;
                            case "":
                                break;
                            default:
                                StringBuilder builder_here = new StringBuilder();
                                foreach (var s in strings)
                                    builder_here.Append(s);
                                throw new ArgumentException(builder_here.ToString());
                        }
                    } while (streamReader.Peek() >= 0);

                    streamReader.Dispose();
                    // FileStream.Seek(0, SeekOrigin.Begin);
                    Conf = builder;
                }
                else
                {
                    streamReader.Dispose();
                    // FileStream.Seek(0, SeekOrigin.Begin);
                    throw new ArgumentException();
                }
            }
            catch (UnauthorizedAccessException)
            {
                throw new ArgumentException();
            }
            finally
            {
                FileStream = File.Open(Filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            }
        }
        else
        {
            throw new FileFormatException();
        }

    }

    public void Write()
    {
        FileStream.Close();
        FileStream = File.Open(Filepath, FileMode.Truncate, FileAccess.Write, FileShare.None);
        StreamWriter streamWriter = new(FileStream);
        streamWriter.WriteLine(Conf.ConfMigration);
        streamWriter.WriteLine("Resolutions/{0}/{1}/{2}/{3}",
            Conf.DesiredWidth, Conf.DesiredHeight, Conf.RestoreWidth, Conf.RestoreHeight);
        streamWriter.Write(Conf.BoolsToString());
        streamWriter.Flush();
        streamWriter.Dispose();
        // FileStream.Seek(0, SeekOrigin.Begin);
        FileStream = File.Open(Filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
    }

    public void Write(Config what)
    {
        Conf = what;
        Write();
    }
}