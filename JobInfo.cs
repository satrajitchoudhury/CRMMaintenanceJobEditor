using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Pfe.Xrm.Utils.ScaleGroupJobEditor
{
    public class JobInfo
    {
        public bool NextRunDateEditable;

        public bool NextRunTimeEditable;

        public bool ReccurrenceEditable;

        public int JobTypeCode { get; }

        public string Name { get; }

        
        public JobInfo(string name, int jobTypeCode, bool allowNextRunDateEdit, bool allowNextRunTimeEdit, bool allowReccurrenceEdit)
        {
            this.Name = name;
            this.JobTypeCode = jobTypeCode;
            this.NextRunDateEditable = allowNextRunDateEdit;
            this.NextRunTimeEditable = allowNextRunTimeEdit;
            this.ReccurrenceEditable = allowReccurrenceEdit;
        }
    }
}
