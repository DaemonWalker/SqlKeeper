using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlKeeper
{
    [Serializable]
    public class MpSqlDto
    {
        public string SqlID { get; set; }
        public string CompnentName { get; set; }
        public string KindLv1Name { get; set; }
        public string KindLv2Name { get; set; }
        public string ValidState { get; set; }
        public string SqlType { get; set; }
        public string SqlValue { get; set; }
    }
}
