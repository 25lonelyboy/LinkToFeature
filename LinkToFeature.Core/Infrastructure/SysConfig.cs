using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkToFeature.Core.Infrastructure
{
    public static class SysConfig
    {
        static SysConfig()
        {
            AppSettings = new AppSettingPropery();
            Assemblies = AppSettings["Assemblies"];
        }
        public static AppSettingPropery AppSettings { get; private set; }

        public static string Assemblies { get; private set; }
    }

    public class AppSettingPropery : Dictionary<string, string>
    {
        private AppSettingsReader _reader;
        private AppSettingsReader Reader
        {
            get
            {
                return _reader ?? (_reader = new AppSettingsReader());
            }
        }

        public new string this[string key]
        {
            get
            {
                if (!base.Keys.Contains(key))
                {
                    base[key] = Reader.GetValue(key, typeof(string)) as string;
                }
                return base[key];
            }
            set
            {
                base[key] = value;
            }
        }
    }
}
