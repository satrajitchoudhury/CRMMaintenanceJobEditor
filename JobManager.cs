using CRMMaintenanceJobEditor.Properties;
using Microsoft.Crm.Admin.AdminService;
using Microsoft.Pfe.Xrm.Utils.ScaleGroupJobEditor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Pfe.Xrm.Utils.ScaleGroupJobEditor
{
    public static class JobManager
    {

        public static List<JobInfo> AvailableJobs
        {
            get
            {
                List<JobInfo> jobInfos = new List<JobInfo>();
                ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(CRMMaintenanceJobEditor.frmMain));
                jobInfos.Add(new JobInfo(componentResourceManager.GetString("jobNameDeletionService"), 14, true, true, true));
                jobInfos.Add(new JobInfo(componentResourceManager.GetString("jobNameIndexManagement"), 15, false, true, false));
                jobInfos.Add(new JobInfo(componentResourceManager.GetString("jobNameReindexAll"), 30, true, true, true));
                jobInfos.Add(new JobInfo(componentResourceManager.GetString("jobNameCleanupWorkflows"), 32, false, false, false));
                jobInfos.Add(new JobInfo(componentResourceManager.GetString("jobNameCreateAuditPartition"), 41, false, false, false));
                jobInfos.Add(new JobInfo(componentResourceManager.GetString("jobNameCheckforLanguageUpdates"), 42, true, true, false));
                jobInfos.Add(new JobInfo(componentResourceManager.GetString("jobNameRefreshReadSharingSnapshots"), 47, true, true, false));
                jobInfos.Add(new JobInfo(componentResourceManager.GetString("jobNameRefreshRowCountSnapshots"), 46, true, true, false));
                jobInfos.Add(new JobInfo(componentResourceManager.GetString("jobNameCheckFullTextIndexColumnStatusOperation"), 61, true, true, false));
                return jobInfos;
            }
        }

        public static JobInfo getJob(OrganizationMaintenanceJobData JobInstance)
        {
            return (from A_0 in JobManager.AvailableJobs where A_0.JobTypeCode == JobInstance.OperationType select A_0).First<JobInfo>();
        }

    }
}
