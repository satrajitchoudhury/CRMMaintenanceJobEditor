using Microsoft.Crm.Admin.AdminService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Pfe.Xrm.Utils.ScaleGroupJobEditor
{
    public class myOrgSorter : IComparer
    {
        public myOrgSorter()
        {

        }

        public int Compare(object x, object y)
        {
            if (!(x is OrganizationData))
            {
                throw new ArgumentException("Object is not of type OrganizationData.");
            }

            OrganizationData organizationDatum = x as OrganizationData;

            if (!(y is OrganizationData))
            {
                throw new ArgumentException("Object is not of type OrganizationData.");
            }

            OrganizationData organizationDatum1 = y as OrganizationData;

            return organizationDatum.FriendlyName.ToUpper().CompareTo(organizationDatum1.FriendlyName);
        }
    }
}
