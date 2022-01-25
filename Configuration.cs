using System.Configuration;

namespace Resolutioner
{
    internal class Configuration : ConfigurationSection
    {
        [ConfigurationProperty("desired_width")]
        public decimal DesiredWidth { get; set; }
        
        [ConfigurationProperty("desired_height")]
        public decimal DesiredHeight { get; set; }

        [ConfigurationProperty("restore_width")]
        public decimal RestoreWidth { get; set; }

        [ConfigurationProperty("restore_height")]
        public decimal RestoreHeight { get; set; }

        [ConfigurationProperty("on_login")]
        public bool OnLogin { get; set; }

        [ConfigurationProperty("on_switch")]
        public bool OnSwitch { get; set; }

        [ConfigurationProperty("on_logoff")]
        public bool OnLogoff { get; set; }

        [ConfigurationProperty("dont_do_things")]
        public bool DontDoThings { get; set; }
    }
}
