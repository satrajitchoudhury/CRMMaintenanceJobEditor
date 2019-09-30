using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Pfe.Xrm.Utils.ScaleGroupJobEditor
{
    public class frequencyVals
    {
        public string _FriendlyName;

        public string _ActualName;

        public string actualName
        {
            get
            {
                return this._ActualName;
            }
            set
            {
                this._ActualName = value;
            }
        }

        public string friendlyName
        {
            get
            {
                return this._FriendlyName;
            }
            set
            {
                this._FriendlyName = value;
            }
        }

        public frequencyVals(string FriendlyName, string ActualName)
        {
            this._FriendlyName = FriendlyName;
            this._ActualName = ActualName;
        }
    }
}
