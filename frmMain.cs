using CRMMaintenanceJobEditor.Properties;
using Microsoft.Crm;
using Microsoft.Crm.Admin.AdminService;
using Microsoft.Crm.ConfigurationDatabase;
using Microsoft.Crm.Data;
using Microsoft.Pfe.Xrm.Utils.ScaleGroupJobEditor;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRMMaintenanceJobEditor
{
    internal partial class frmMain : Form
    {
        //a
        private OrganizationMaintenanceJobData organizationMaintenanceJobData=null;
        //b
        private OrganizationData organizationData=null;
        //c
        private ToolTip toolTip;
        //d
        private bool flag;
        //e
        private const string dateTimeFormat = "MM/dd/yyyy  hh:mm tt";
        //f
        private const string timeFormat = "hh:mm tt";
        //g
        private ComponentResourceManager rscMgrTypeFrmMain = new ComponentResourceManager(typeof(Resource));
        //h
        private ComponentResourceManager rscMgrTypeResources = new ComponentResourceManager(typeof(frmMain));
        
        //previously i
        private List<int> operationType1 = new List<int>()
        {
            42,
            14,
            47,
            46,
            30,
            61
        };

        //previously j
        private List<int> operationType2 = new List<int>()
        {
            42,
            14,
            15,
            47,
            46,
            30,
            41,
            61
        };

        //previously k
        private List<int> operationType3 = new List<int>()
        {
            14,
            30
        };

        //l
        private IContainer container;
        
        //m
        private ComboBox comboBox1;
        //o
        private ComboBox comboBox2;
        //p
        private ComboBox comboBox3;
        //aa
        private ComboBox comboBox4;

        //n
        private Label label1;
        //r
        private Label label2;
        //s
        private Label label3;
        //v
        private Label label4;
        //z
        private Label label5;
        //ab
        private Label label6;
        //ag
        private Label label7;
        //ah
        private Label label8;
        //ai
        private Label label9;
        //ak
        private Label label10;


        //q
        private Button button1;
        //t
        private Button button2;
        
        //u
        private DateTimePicker dateTime1;
        //w
        private DateTimePicker dateTime2;
        
        
        //x
        private GroupBox groupBox1;
        //y
        private GroupBox groupBox2;
        
              
        //ac
        private StatusStrip statusStrip1;
        //ad
        private ToolStripStatusLabel ToolStripStatusLabel1;
        //ae
        private ToolStripStatusLabel ToolStripStatusLabel2;
        
        //af
        private CheckBox checkBox;
               
        //aj
        private TextBox textBox1;
        

        //public frmMain()
        //{
        //    this.a() ;
        //}

        private void a(string A_0, OrganizationMaintenanceJobData A_1)
        {
            try
            {
                this.flag = false;

                if (A_1.OperationType == 41)
                {
                    A_1.RecurrencePattern = ((string)this.rscMgrTypeResources.GetObject("OverrideSchedule"));
                }

                Guid scaleGroupId = LocatorService.Instance.GetScaleGroupId();

                (new PropertyBag()).SetValue("Id", A_1.Id);

                using (ConfigurationDatabaseService configurationDatabaseService = new ConfigurationDatabaseService(scaleGroupId))
                {
                    configurationDatabaseService.Update((string)this.rscMgrTypeResources.GetObject("tblScaleGrp"), A_1.Id, A_1.InternalPropertyBag);
                }

                this.label6.Text = (string)this.rscMgrTypeResources.GetObject("StatusUpdateCompleted");
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                throw new Exception(string.Concat((string)this.rscMgrTypeResources.GetObject("StatusUpdateFailed"), exception.Message.ToString()));
            }

        }


        private OrganizationMaintenanceJobData[] a(Guid A_0, int A_1, bool A_2 = false)
        {
            OrganizationMaintenanceJobData[] array;
            Guid scaleGroupId = LocatorService.Instance.GetScaleGroupId();
            Guid a0 = A_0;
            List<OrganizationMaintenanceJobData> organizationMaintenanceJobDatas = new List<OrganizationMaintenanceJobData>();
            PropertyBag propertyBag = null;
            PropertyBagCollection propertyBagCollection = null;
            using (ConfigurationDatabaseService configurationDatabaseService = new ConfigurationDatabaseService(scaleGroupId))
            {
                propertyBag = new PropertyBag();
                propertyBag.SetValue("OrganizationId", a0);
                if (!A_2)
                {
                    propertyBag.SetValue("OperationType", A_1);
                }
                propertyBagCollection = configurationDatabaseService.Retrieve((string)this.rscMgrTypeResources.GetObject("tblScaleGrp"), null, new PropertyBag[] { propertyBag });
                if (propertyBagCollection != null)
                {
                    SortedDictionary<object, PropertyBag>.Enumerator enumerator = propertyBagCollection.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        OrganizationMaintenanceJobData organizationMaintenanceJobDatum = new OrganizationMaintenanceJobData(enumerator.Current.Value);
                        if (!organizationMaintenanceJobDatum.Enabled)
                        {
                            continue;
                        }
                        organizationMaintenanceJobDatas.Add(organizationMaintenanceJobDatum);
                    }
                }
                array = organizationMaintenanceJobDatas.ToArray();
            }
            return array;
        }

        private string a(int A_0)
        {
            if (A_0 > 30)
            {
                if (A_0 == 32)
                {
                    return this.rscMgrTypeResources.GetString("jobNameCleanupWorkflows");
                }
                switch (A_0)
                {
                    case 41:
                        {
                            return this.rscMgrTypeResources.GetString("jobNameCreateAuditPartition");
                        }
                    case 42:
                        {
                            return this.rscMgrTypeResources.GetString("jobNameCheckforLanguageUpdates");
                        }
                    case 43:
                    case 44:
                    case 45:
                        {
                            break;
                        }
                    case 46:
                        {
                            return this.rscMgrTypeResources.GetString("jobNameRefreshRowCountSnapshots");
                        }
                    case 47:
                        {
                            return this.rscMgrTypeResources.GetString("jobNameRefreshReadSharingSnapshots");
                        }
                    default:
                        {
                            if (A_0 == 61)
                            {
                                return this.rscMgrTypeResources.GetString("jobNameCheckFullTextIndexColumnStatusOperation");
                            }
                            break;
                        }
                }
            }
            else
            {
                if (A_0 == 14)
                {
                    return this.rscMgrTypeResources.GetString("jobNameDeletionService");
                }
                if (A_0 == 15)
                {
                    return this.rscMgrTypeResources.GetString("jobNameIndexManagement");
                }
                if (A_0 == 30)
                {
                    return this.rscMgrTypeResources.GetString("jobNameReindexAll");
                }
            }
            return "Unkown";
        }

        private void a(string A_0)
        {

        }

        private void a(OrganizationMaintenanceJobData A_0)
        {
            int lastResultCode = -1;
            try

            {
                this.a("#start: property bag contents:");
                SerializationProperty[] serializationProperties = A_0.InternalPropertyBag.SerializationProperties;

                for (int i = 0; i < (int)serializationProperties.Length; i++)
                {
                    SerializationProperty serializationProperty = serializationProperties[i];

                    this.a(string.Format("Name: {0} - Value: {1}", serializationProperty.Name, serializationProperty.Value));
                }

                this.a("#end: property bag contents:");
                this.a("Trying last result now.");
                lastResultCode = A_0.LastResultCode;
                this.a(string.Concat("last result: ", lastResultCode));
            }

            catch (NullReferenceException)
            {
                this.a("caught system.NullReferenceException");
            }

            catch (MissingMethodException)
            {
                this.a("caught system.MissingMethodException");
            }

            catch (Exception exception1)
            {
                Exception exception = exception1;
                this.a(string.Concat(new object[] { "caught unhandled exception: ", exception.Message, "\r\n", exception.StackTrace, "\r\n", exception.Source, "\r\n", exception.InnerException }));
            }

            if (lastResultCode == 0)
            {
                this.label2.Image = null;
                return;
            }
            int num = 13;
            Label label = this.label2;
            label.Text = string.Concat(label.Text, "      ");
            Image obj = (Image)this.rscMgrTypeResources.GetObject("imgJobError");
            Image bitmap = new Bitmap(num, num);
            Graphics.FromImage(bitmap).DrawImage(obj, 0, 0, num, num);
            this.label2.Image = bitmap;
            this.label2.ImageAlign = ContentAlignment.MiddleRight;
            if (lastResultCode == -1)
            {
                this.toolTip.SetToolTip(this.label2, string.Format("Last result code for job was not available: {0}", lastResultCode));
                return;
            }
            this.toolTip.SetToolTip(this.label2, string.Format("Last job run failed with resultcode: {0}", lastResultCode));
        }


        private void a(OrganizationData A_0)
        {
            string str;
            string str1;
            DateTime localTime;
            Guid id = A_0.Id;
            this.a("###################################");
            this.a(string.Concat("Entering configureUIForSelectedOrgAndJobType(\"", id.ToString(), "\") FriendlyName: ", A_0.FriendlyName));
            if (this.comboBox4.SelectedItem != null)
            {
                JobInfo selectedItem = this.comboBox4.SelectedItem as JobInfo;
                this.a(string.Concat("calling retrieveJobData for job type: ", selectedItem.JobTypeCode));
                OrganizationMaintenanceJobData[] organizationMaintenanceJobDataArray = this.a(id, selectedItem.JobTypeCode, false);
                OrganizationMaintenanceJobData organizationMaintenanceJobDatum = organizationMaintenanceJobDataArray[0];
                this.textBox1.Text = organizationMaintenanceJobDatum.LastResultCode.ToString();
                this.label10.Text = organizationMaintenanceJobDatum.LastResultData ?? "None";
                DateTime dateTime = DateTime.SpecifyKind(organizationMaintenanceJobDatum.NextRuntime, DateTimeKind.Utc);
                DateTime dateTime1 = DateTime.SpecifyKind(organizationMaintenanceJobDatum.RecurrenceStartTime, DateTimeKind.Utc);
                DateTime minValue = DateTime.MinValue;
                try
                {
                    this.toolTip.SetToolTip(this.label3, "");
                    minValue = DateTime.SpecifyKind(organizationMaintenanceJobDatum.LastRuntime, DateTimeKind.Utc);
                    Label label = this.label3;
                    localTime = minValue.ToLocalTime();
                    label.Text = localTime.ToString();
                }
                catch (NullReferenceException nullReferenceException1)
                {
                    NullReferenceException nullReferenceException = nullReferenceException1;
                    this.label3.Text = (string)this.rscMgrTypeResources.GetObject("JobNotRun");
                    this.a(string.Concat(new object[] { "Caught NullReference exception in main DisplayDetailedJobDataMethod: ", nullReferenceException.Message, "\r\n", nullReferenceException.StackTrace, "\r\n", nullReferenceException.Source, "\r\n", nullReferenceException.InnerException }));
                }
                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month;
                localTime = DateTime.Now;
                dateTime1 = new DateTime(year, month, localTime.Day, dateTime1.Hour, dateTime1.Minute, dateTime1.Second, DateTimeKind.Utc);
                if (!selectedItem.NextRunTimeEditable || selectedItem.NextRunDateEditable)
                {
                    this.toolTip.SetToolTip(this.dateTime1, "");
                    this.toolTip.SetToolTip(this.label7, "");
                    this.label7.Text = this.label7.Text.TrimEnd(new char[] { '*' });
                }
                else
                {
                    string str2 = string.Format((string)this.rscMgrTypeResources.GetObject("ToolTipTimeOnly"), new object[0]);
                    this.toolTip.SetToolTip(this.dateTime1, str2);
                    this.toolTip.SetToolTip(this.label7, str2);
                    this.label7.Text = string.Concat(this.label7.Text.TrimEnd(new char[] { '*' }), "*");
                }
                this.dateTime1.Value = dateTime.ToLocalTime();
                object[] value = new object[] { "test dtNextRun.Value: ", this.dateTime1.Value, " Kind: ", null };
                localTime = this.dateTime1.Value;
                value[3] = localTime.Kind;
                this.a(string.Concat(value));
                this.dateTime2.Value = dateTime1.ToLocalTime();
                int length = (int)organizationMaintenanceJobDataArray.Length;
                this.a(string.Concat("retreived ", length.ToString(), " Jobs"));
                this.a(string.Concat(new object[] { "job.LastRuntime (local):         ", minValue.ToLocalTime(), " UTC: ", minValue }));
                this.a(string.Concat(new object[] { "job.NextRuntime (local):         ", dateTime.ToLocalTime(), " UTC: ", dateTime }));
                this.a(string.Concat(new object[] { "job.RecurrenceStartTime (local): ", dateTime1.ToLocalTime(), " UTC: ", dateTime1 }));
                this.a(string.Concat("job.RecurrencePattern:           ", organizationMaintenanceJobDatum.RecurrencePattern));
                this.organizationMaintenanceJobData = organizationMaintenanceJobDatum;
                this.a(this.organizationMaintenanceJobData.RecurrencePattern, out str, out str1);
                int num = 0;
                while (num < this.comboBox2.Items.Count)
                {
                    if (((frequencyVals)this.comboBox2.Items[num])._ActualName != str)
                    {
                        num++;
                    }
                    else
                    {
                        this.comboBox2.SelectedIndex = num;
                        break;
                    }
                }
                this.comboBox3.Text = str1;
            }
        }

        private void a(Guid A_0)
        {
            OrganizationMaintenanceJobData[] organizationMaintenanceJobDataArray = this.a(A_0, 0, true);
            this.comboBox4.Items.Clear();
            foreach (JobInfo availableJob in JobManager.AvailableJobs)
            {
                if ((from A_1 in organizationMaintenanceJobDataArray where A_1.OperationType.Equals(availableJob.JobTypeCode) select A_1).Count<OrganizationMaintenanceJobData>() != 1)
                {
                    continue;
                }
                this.comboBox4.Items.Add(availableJob);
            }
            if (this.comboBox4.Items.Count > 0)
            {
                this.comboBox4.SelectedIndex = 0;
            }
        }

        private OrganizationMaintenanceJobData a(OrganizationMaintenanceJobData A_0, string A_1, DateTime A_2, DateTime A_3)
        {
            DateTime universalTime;
            string str = A_0.OrganizationId.ToString();
            int operationType = A_0.OperationType;
            this.a(string.Concat("Calculating for orgID: ", str, " job type: ", operationType.ToString()));
            if (this.operationType3.Contains(A_0.OperationType))
            {
                this.a(string.Concat("setting Recurrence is allowed, setting pattern to: ", A_1));
                A_0.RecurrencePattern=(A_1);
            }
            if (this.operationType1.Contains(A_0.OperationType) && this.operationType2.Contains(A_0.OperationType))
            {
                object[] kind = new object[] { "Setting NextRun date & time are allowed, setting next run UTC: ", null, null, null };
                universalTime = A_3.ToUniversalTime();
                kind[1] = universalTime.ToString("G");
                kind[2] = " DTKind: ";
                kind[3] = A_3.Kind;
                this.a(string.Concat(kind));
                A_0.NextRuntime=(A_3.ToUniversalTime());
            }
            else if (this.operationType3.Contains(A_0.OperationType))
            {
                universalTime = A_0.NextRuntime;
                this.a(string.Concat("String to parse: ", universalTime.ToShortDateString(), " ", A_3.ToShortTimeString()));
                universalTime = A_0.NextRuntime;
                DateTime dateTime = DateTime.Parse(string.Concat(universalTime.ToShortDateString(), " ", A_3.ToShortTimeString()));
                DateTime.SpecifyKind(dateTime, DateTimeKind.Local);
                object[] objArray = new object[] { "setting NextRun time only is allowed, setting next run UTC: ", null, null, null, null, null };
                universalTime = dateTime.ToUniversalTime();
                objArray[1] = universalTime.ToString("G");
                objArray[2] = " local: ";
                objArray[3] = dateTime.ToString("G");
                objArray[4] = " DTKind: ";
                objArray[5] = A_3.Kind;
                this.a(string.Concat(objArray));
                A_0.NextRuntime=(dateTime.ToUniversalTime());
            }
            A_0.RecurrenceStartTime=(A_2.ToUniversalTime());
            object[] str1 = new object[] { "Calc: job.RecurrenceStartTime [UTC] is now set to: ", null, null, null, null, null };
            universalTime = A_0.RecurrenceStartTime;
            str1[1] = universalTime.ToString("G");
            str1[2] = " Local: ";
            universalTime = A_0.RecurrenceStartTime.ToLocalTime();
            str1[3] = universalTime.ToString("G");
            str1[4] = " DTKind: ";
            str1[5] = A_2.Kind;
            this.a(string.Concat(str1));
            string str2 = A_0.NextRuntime.ToString("G");
            universalTime = A_0.NextRuntime.ToLocalTime();
            this.a(string.Concat("Calc: job.NextRuntime [UTC] is now set to: ", str2, " Local: ", universalTime.ToString("G")));
            this.a(string.Concat("Calc: job.RecurrencePattern set to: ", A_0.RecurrencePattern));
            return A_0;
        }

        private void a(string A_0, out string A_1, out string A_2)
        {
            A_2 = string.Empty;
            A_1 = string.Empty;
            A_0 = A_0.Trim(";".ToCharArray());
            string[] strArrays = A_0.Split(";".ToCharArray());
            if ((int)strArrays.Length > 2)
            {
                throw new Exception((string)this.rscMgrTypeResources.GetObject("ExceptionRecurrenceError"));
            }
            string[] strArrays1 = strArrays;
            for (int i = 0; i < (int)strArrays1.Length; i++)
            {
                string[] strArrays2 = strArrays1[i].Split("=".ToCharArray());
                string str = strArrays2[0];
                string str1 = strArrays2[1];
                if (strArrays2[0] == "FREQ")
                {
                    A_1 = strArrays2[1];
                }
                else if (strArrays2[0] == "INTERVAL")
                {
                    A_2 = strArrays2[1];
                }
            }
            if (A_2 == string.Empty || A_1 == string.Empty)
            {
                throw new Exception((string)this.rscMgrTypeResources.GetObject("ExceptionRecurrencePattern"));
            }
        }

        private void a(object A_0, EventArgs A_1)
        {
            if (((CheckBox)A_0).Checked)
            {
                this.comboBox4.Enabled = false;
                return;
            }
            this.comboBox4.Enabled = true;
        }

        private void a(object A_0, PreviewKeyDownEventArgs A_1)
        {

        }

        private void a(object A_0, MouseEventArgs A_1)
        {
            if (this.organizationMaintenanceJobData.OperationType == 41 && !this.flag)
            {
                DialogResult dialogResult = MessageBox.Show(string.Format("{0}", (string)this.rscMgrTypeResources.GetObject("AuditWarning1")), "ALERT!", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
                if (dialogResult == DialogResult.No)
                {
                    this.button2.Focus();
                    this.d(A_0, A_1);
                    return;
                }
                if (dialogResult == DialogResult.Yes)
                {
                    if (DialogResult.No == MessageBox.Show((string)this.rscMgrTypeResources.GetObject("AuditWarning2"), "ALERT!", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2))
                    {
                        this.button2.Focus();
                        this.d(A_0, A_1);
                        return;
                    }
                    this.flag = true;
                }
            }
        }

        private void a()
        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmMain));

            this.comboBox1 = new ComboBox();           
            this.comboBox2 = new ComboBox();
            this.comboBox3 = new ComboBox();
            this.comboBox4 = new ComboBox();

            this.button1 = new Button();
            this.button2 = new Button();

            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();
            this.label6 = new Label();
            this.label7 = new Label();
            this.label8 = new Label();
            this.label9 = new Label();
            this.label10 = new Label();

            this.dateTime1 = new DateTimePicker();
            this.dateTime2 = new DateTimePicker();

            this.groupBox1 = new GroupBox();
            this.groupBox2 = new GroupBox();

            this.textBox1 = new TextBox();

            
            this.statusStrip1 = new StatusStrip();
            this.ToolStripStatusLabel1 = new ToolStripStatusLabel();
            this.ToolStripStatusLabel2 = new ToolStripStatusLabel();
            this.checkBox = new CheckBox();

            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            base.SuspendLayout();

            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new Point(90, 7);
            this.comboBox1.Name = "cbOrgs";
            this.comboBox1.Size = new Size(179, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new EventHandler(this.f);

            this.label1.AutoSize = true;
            this.label1.Location = new Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Organizations";

            this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new Point(175, 22);
            this.comboBox2.Name = "cbFreq";
            this.comboBox2.Size = new Size(92, 21);
            this.comboBox2.TabIndex = 12;

            this.comboBox3.Enabled = false;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new Point(88, 22);
            this.comboBox3.Name = "cbInterval";
            this.comboBox3.Size = new Size(81, 21);
            this.comboBox3.TabIndex = 11;

            this.button1.Location = new Point(6, 341);
            this.button1.Name = "btnUpdate";
            this.button1.Size = new Size(125, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.e);

            this.label2.AutoSize = true;
            this.label2.Location = new Point(6, 23);
            this.label2.Name = "label6";
            this.label2.Size = new Size(70, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Job Last Ran";

            this.label3.AutoSize = true;
            this.label3.Location = new Point(85, 23);
            this.label3.Name = "lblLastRun";
            this.label3.Size = new Size(57, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "lblLastRun";
            this.label3.TextAlign = ContentAlignment.MiddleLeft;

            this.button2.Location = new Point(145, 341);
            this.button2.Name = "btnClear";
            this.button2.Size = new Size(125, 23);
            this.button2.TabIndex = 26;
            this.button2.Text = "Refresh";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.d);

            this.dateTime1.CustomFormat = "MM/dd/yyyy  hh:mm tt";
            this.dateTime1.Format = DateTimePickerFormat.Custom;
            this.dateTime1.Location = new Point(87, 40);
            this.dateTime1.Name = "dtNextRun";
            this.dateTime1.Size = new Size(179, 20);
            this.dateTime1.TabIndex = 21;
            this.dateTime1.MouseDown += new MouseEventHandler(this.a);
            this.dateTime1.PreviewKeyDown += new PreviewKeyDownEventHandler(this.a);

            this.label4.AutoSize = true;
            this.label4.Location = new Point(6, 52);
            this.label4.Name = "label7";
            this.label4.Size = new Size(82, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Starting At Time";

            this.dateTime2.Checked = false;
            this.dateTime2.CustomFormat = "hh:mm tt";
            this.dateTime2.Format = DateTimePickerFormat.Time;
            this.dateTime2.Location = new Point(88, 48);
            this.dateTime2.Name = "dtRecStartTime";
            this.dateTime2.ShowUpDown = true;
            this.dateTime2.Size = new Size(179, 20);
            this.dateTime2.TabIndex = 14;

            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dateTime2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Location = new Point(3, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(275, 73);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Future Scheduled Jobs";

            this.label6.AutoSize = true;
            this.label6.Location = new Point(6, 25);
            this.label6.Name = "label10";
            this.label6.Size = new Size(76, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Execute Every";

            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dateTime1);
            this.groupBox2.Location = new Point(3, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(275, 174);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Specific Job Data";

            this.textBox1.Enabled = false;
            this.textBox1.Location = new Point(9, 109);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "txtResultData";
            this.textBox1.Size = new Size(255, 59);
            this.textBox1.TabIndex = 30;

            this.label10.AutoSize = true;
            this.label10.Location = new Point(103, 70);
            this.label10.Name = "lblResultCode";
            this.label10.Size = new Size(35, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "label9";

            this.label8.AutoSize = true;
            this.label8.Location = new Point(6, 70);
            this.label8.Name = "label4";
            this.label8.Size = new Size(91, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Last Result Code:";

            this.label9.AutoSize = true;
            this.label9.Location = new Point(6, 93);
            this.label9.Name = "label2";
            this.label9.Size = new Size(92, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Last Result Data: ";

            this.label7.AutoSize = true;
            this.label7.Location = new Point(6, 46);
            this.label7.Name = "lblNextRun";
            this.label7.Size = new Size(72, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Job Next Run";

            this.label5.AutoSize = true;
            this.label5.Location = new Point(3, 33);
            this.label5.Name = "label8";
            this.label5.Size = new Size(51, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Job Type";

            this.comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new Point(90, 34);
            this.comboBox4.Name = "cbJobType";
            this.comboBox4.Size = new Size(179, 21);
            this.comboBox4.TabIndex = 1;
            this.comboBox4.SelectedIndexChanged += new EventHandler(this.c);

            this.statusStrip1.Items.AddRange(new ToolStripItem[] { this.ToolStripStatusLabel1, this.ToolStripStatusLabel2 });
            this.statusStrip1.Location = new Point(0, 371);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new Size(279, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 30;
            this.statusStrip1.Text = "ss1";

            this.ToolStripStatusLabel1.Name = "tssStrip";
            this.ToolStripStatusLabel1.Size = new Size(118, 17);
            this.ToolStripStatusLabel1.Text = "toolStripStatusLabel1";

            this.ToolStripStatusLabel2.ImageAlign = ContentAlignment.MiddleRight;
            this.ToolStripStatusLabel2.Name = "tssLink";
            this.ToolStripStatusLabel2.Size = new Size(118, 17);
            this.ToolStripStatusLabel2.Text = "toolStripStatusLabel1";
            this.ToolStripStatusLabel2.Click += new EventHandler(this.b);

            this.checkBox.AutoSize = true;
            this.checkBox.Location = new Point(18, 316);
            this.checkBox.Name = "chkAllJobs";
            this.checkBox.Size = new Size(244, 17);
            this.checkBox.TabIndex = 22;
            this.checkBox.Text = "Apply Settings To All Jobs In The Organization";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new EventHandler(this.a);

            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(279, 393);

            base.Controls.Add(this.checkBox);
            base.Controls.Add(this.statusStrip1);
            base.Controls.Add(this.comboBox4);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.comboBox1);

            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.Icon = (Icon)rscMgrTypeFrmMain.GetObject("Icon1");
            base.MaximizeBox = false;
            base.Name = "frmMain";
            base.SizeGripStyle = SizeGripStyle.Hide;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "CRM Job Editor";
            base.Load += new EventHandler(this.g);

            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();

            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void b()
        {
            if (this.organizationMaintenanceJobData != null)
            {
                this.comboBox3.Enabled = false;
                this.comboBox2.Enabled = false;
                this.checkBox.Enabled = false;
                this.dateTime1.Enabled = false;

                if (this.operationType2.Contains(this.organizationMaintenanceJobData.OperationType))
                {
                    this.checkBox.Enabled = true;
                    this.dateTime1.Enabled = true;
                }

                if (this.operationType3.Contains(this.organizationMaintenanceJobData.OperationType))
                {
                    this.checkBox.Enabled = true;
                    this.comboBox3.Enabled = true;
                    this.comboBox2.Enabled = true;
                }
            }
        }

        private void b(object A_0, EventArgs A_1)
        {
            ToolStripLabel a0 = (ToolStripLabel)A_0;
            Process.Start(new ProcessStartInfo(a0.Tag.ToString()));
            a0.LinkVisited = true;
        }

        private int c()
        {
            if (this.comboBox4.Text == this.rscMgrTypeResources.GetString("jobNameDeletionService"))
            {
                return 14;
            }
            if (this.comboBox4.Text == this.rscMgrTypeResources.GetString("jobNameIndexManagement"))
            {
                return 15;
            }
            if (this.comboBox4.Text == this.rscMgrTypeResources.GetString("jobNameReindexAll"))
            {
                return 30;
            }
            if (this.comboBox4.Text == this.rscMgrTypeResources.GetString("jobNameCleanupWorkflows"))
            {
                return 32;
            }
            if (this.comboBox4.Text == this.rscMgrTypeResources.GetString("jobNameCreateAuditPartition"))
            {
                return 41;
            }
            if (this.comboBox4.Text == this.rscMgrTypeResources.GetString("jobNameCheckforLanguageUpdates"))
            {
                return 42;
            }
            if (this.comboBox4.Text == this.rscMgrTypeResources.GetString("jobNameRefreshReadSharingSnapshots"))
            {
                return 47;
            }
            if (this.comboBox4.Text == this.rscMgrTypeResources.GetString("jobNameRefreshRowCountSnapshots"))
            {
                return 46;
            }
            if (this.comboBox4.Text == this.rscMgrTypeResources.GetString("jobNameCheckFullTextIndexColumnStatusOperation"))
            {
                return 61;
            }
            return 0;
        }
        private void c(object A_0, EventArgs A_1)
        {
            this.a(this.comboBox1.SelectedItem as OrganizationData);
            this.b();
        }

        private void d()
        {
            try
            {
                ArrayList arrayLists = new ArrayList();
                Guid id = new Guid();
                this.checkBox.Checked = false;

                this.comboBox3.Items.Clear();
                this.comboBox3.Text = "";

                for (int i = 1; i <= 100; i++)
                {
                    this.comboBox3.Items.Add(i);
                }

                this.comboBox3.Enabled = false;

                this.comboBox2.Items.Clear();
                this.comboBox2.Items.Add(new frequencyVals((string)this.rscMgrTypeResources.GetObject("sMinutes"), "MINUTELY"));
                this.comboBox2.Items.Add(new frequencyVals((string)this.rscMgrTypeResources.GetObject("sHours"), "HOURLY"));
                this.comboBox2.Items.Add(new frequencyVals((string)this.rscMgrTypeResources.GetObject("sDays"), "DAILY"));
                this.comboBox2.Items.Add(new frequencyVals((string)this.rscMgrTypeResources.GetObject("sMonths"), "MONTHLY"));
                this.comboBox2.ValueMember = "ActualName";
                this.comboBox2.DisplayMember = "FriendlyName";
                this.comboBox2.Enabled = false;
                this.comboBox2.SelectedIndex = -1;

                this.comboBox1.Items.Clear();

                int count = 0;

            
                PropertyBagCollection enabledOrganizationsIds = LocatorService.Instance.GetEnabledOrganizationsIds();

                if (enabledOrganizationsIds != null)
                {
                    SortedDictionary<object, PropertyBag>.Enumerator enumerator = enabledOrganizationsIds.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        OrganizationData organizationDatum = new OrganizationData(enumerator.Current.Value);
                        organizationDatum.FriendlyName=(LocatorService.Instance.GetOrganizationFriendlyName(organizationDatum.Id));
                        arrayLists.Add(organizationDatum);

                        if (this.organizationData == null || !(organizationDatum.Id == this.organizationData.Id))
                        {
                            continue;
                        }

                        id = this.organizationData.Id;
                    }
                    arrayLists.Sort(new myOrgSorter());

                    foreach (OrganizationData arrayList in arrayLists)
                    {
                        this.comboBox1.Items.Add(arrayList);

                        if (arrayList.Id != id)
                        {
                            continue;
                        }
                        count = this.comboBox1.Items.Count - 1;
                    }
                }

                this.comboBox1.DisplayMember = "FriendlyName";

                if (this.comboBox1.Items.Count > 0)
                {
                    this.comboBox1.SelectedIndex = count;
                }
                this.comboBox2.Enabled = true;
                this.comboBox3.Enabled = true;
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(string.Format("{0}\r\n{1}\r\n{2}", (string)this.rscMgrTypeResources.GetObject("ExceptionAndAppShutdown"), exception.Message, exception.StackTrace), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Application.Exit();
            }
        }

        private void d(object A_0, EventArgs A_1)
        {
            this.flag = false;
            this.d();
            this.ToolStripStatusLabel1.Text = (string)this.rscMgrTypeResources.GetObject("ChangesCleared");
            this.b();
        }

        private DateTime e()
        {
            string location = Assembly.GetCallingAssembly().Location;
            byte[] numArray = new byte[2048];
            Stream fileStream = null;
            try
            {
                fileStream = new FileStream(location, FileMode.Open, FileAccess.Read);
                fileStream.Read(numArray, 0, 2048);
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
            int num = BitConverter.ToInt32(numArray, 60);
            int num1 = BitConverter.ToInt32(numArray, num + 8);
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0);
            dateTime = dateTime.AddSeconds((double)num1);
            TimeSpan utcOffset = TimeZone.CurrentTimeZone.GetUtcOffset(dateTime);
            dateTime = dateTime.AddHours((double)utcOffset.Hours);
            return dateTime;
        }

        private void e(object A_0, EventArgs A_1)
        {
            if (this.comboBox3.Text.ToString().Length > 0 && this.comboBox2.Text.ToString().Length > 0)
            {
                this.a("###################################");
                this.a("Entering btnUpdate_Click()");
                string str = string.Format("FREQ={0};INTERVAL={1};", ((frequencyVals)this.comboBox2.SelectedItem)._ActualName, this.comboBox3.Text.ToString());
                if (this.checkBox.Checked)
                {
                    OrganizationMaintenanceJobData[] organizationMaintenanceJobDataArray = this.a(((OrganizationData)this.comboBox1.SelectedItem).Id, 0, true);
                    for (int i = 0; i < (int)organizationMaintenanceJobDataArray.Length; i++)
                    {
                        OrganizationMaintenanceJobData organizationMaintenanceJobDatum = organizationMaintenanceJobDataArray[i];
                        OrganizationMaintenanceJobData organizationMaintenanceJobDatum1 = this.a(organizationMaintenanceJobDatum, str, this.dateTime2.Value, this.dateTime1.Value);
                        this.a(this.comboBox1.Text.ToString(), organizationMaintenanceJobDatum1);
                    }
                    this.checkBox.Checked = false;
                    return;
                }
                OrganizationMaintenanceJobData organizationMaintenanceJobDatum2 = this.a(this.organizationMaintenanceJobData, str, this.dateTime2.Value, this.dateTime1.Value);
                this.a(this.comboBox1.Text.ToString(), organizationMaintenanceJobDatum2);
                this.f(A_0, A_1);
            }
        }

        private void f()
        {
            using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {

                using (RegistryKey registryKey = hklm.OpenSubKey("Software\\Microsoft\\MSCRM", false))
                {
                    if (registryKey == null)
                    {
                        throw new Exception("Cannot find the subkey: HKLM\\Software\\Microsoft\\MSCRM");
                    }
                    if (registryKey.GetValue("CRM_Server_Serviceability_Version") == null)
                    {
                        throw new Exception("Cannot find registry value CRM_Server_Serviceability_Version");
                    }
                    if (registryKey.GetValue("CRM_Server_InstallDir") == null)
                    {
                        throw new Exception("Cannot find registry value CRM_Server_InstallDir");
                    }

                    string str = string.Concat(registryKey.GetValue("CRM_Server_InstallDir").ToString().TrimEnd(new char[] { '\\' }), "\\Tools");

                    string str1 = Assembly.GetCallingAssembly().Location.Replace(Assembly.GetEntryAssembly().ManifestModule.ToString(), "").TrimEnd(new char[] { '\\' });

                    if (string.Compare(str, str1, CultureInfo.InvariantCulture, CompareOptions.IgnoreCase) != 0)
                    {
                        throw new Exception(string.Format("This assembly must be run from the:\r\n{0}\\ directory.\r\n\r\nThe current location is: {1}\\", str, str1));
                    }

                }
            }
        }

        private void g()
        {
            this.container = new Container();
            this.toolTip = new ToolTip(this.container)
            {
                AutoPopDelay = 30000,
                InitialDelay = 500,
                ReshowDelay = 200
            };
            this.toolTip.SetToolTip(this.dateTime2, (string)this.rscMgrTypeResources.GetObject("ToolTipdtRecStartTime"));
            this.toolTip.SetToolTip(this.checkBox, (string)this.rscMgrTypeResources.GetObject("ToolTipchkAllJobs"));
            this.ToolStripStatusLabel2.ToolTipText = string.Concat((string)this.rscMgrTypeResources.GetObject("ToolTipTssLink"), Application.ProductVersion.ToString());
            this.ToolStripStatusLabel2.AutoToolTip = true;
        }

        private void g(object A_0, EventArgs A_1)
        {
            this.a("###################################");
            this.a("entering frmMain_Load()...");
            this.dateTime1.Format = DateTimePickerFormat.Custom;
            this.dateTime1.CustomFormat = "MM/dd/yyyy  hh:mm tt";
            try
            {
                this.f();
                Application.ProductVersion.ToString();
                DateTime dateTime = this.e();
                string str = string.Format("This utility is used to edit maintenance jobs in CRM. You can set the next run date/time of a job as well as change the jobs automatic schedule.\r\n\r\nYou are currently running an assembly dated: {0} with version {1}. Expect updates posted on CodePlex at: {2} \r\n\r\nNOTE: To force a job run immediately change the jobs next run time to a past date/time. This will trigger the async service to run the job next. This process may take several minutes, if it does not run check to make sure your async maintenance service is running.", dateTime.ToShortDateString(), Application.ProductVersion.ToString(), (string)this.rscMgrTypeResources.GetObject("ProjectUrl"));
                this.g();
                this.ToolStripStatusLabel1.Text = string.Concat("V: ", Application.ProductVersion.ToString());
                this.ToolStripStatusLabel1.Visible = true;

                this.ToolStripStatusLabel2.Text = (string)this.rscMgrTypeResources.GetObject("StatusCheckVersion");
                this.ToolStripStatusLabel2.LinkBehavior = LinkBehavior.HoverUnderline;
                this.ToolStripStatusLabel2.IsLink = true;
                this.ToolStripStatusLabel2.Tag = (string)this.rscMgrTypeResources.GetObject("ProjectUrl");
                this.ToolStripStatusLabel2.Alignment = ToolStripItemAlignment.Right;
                if (this.comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show(str, (string)this.rscMgrTypeResources.GetObject("ProjectTitle"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                this.comboBox4.DisplayMember = "Name";
                this.comboBox4.ValueMember = "JobTypeCode";
                this.d();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "EXCEPTION", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Application.Exit();
            }
        }


        private void f(object A_0, EventArgs A_1)
        {
            OrganizationData item = (OrganizationData)this.comboBox1.Items[this.comboBox1.SelectedIndex];
            this.organizationData = item;
            this.a(item.Id);
            this.a(item);
        }

        
    }
}
