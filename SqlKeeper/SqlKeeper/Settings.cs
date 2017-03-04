using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlKeeper
{
    [Serializable]
    public class Settings
    {
        public string BackupString { get; set; }
        public string DBIP { get; set; }
        public string DBName { get; set; }
        public string DBAcc { get; set; }
        public string DBPwd { get; set; }
        public string ConnStr
        {
            get
            {
                return $"User Id={DBAcc};Password={DBPwd};Data Source={DBIP}/{DBName};";
            }
        }
    }
}
