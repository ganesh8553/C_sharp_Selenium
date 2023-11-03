using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using BenefitPro1.TestRepository;
using BenefitPro1.Utilities;
using System.Reflection;
using OpenQA.Selenium;
using BenefitPro1;

namespace BenefitProApp2
{
    public partial class Form1 : Form
    {
        List<testCaseObj> testCases = new List<testCaseObj>();
        SampleTest s;
        Utilities u;
        List<MethodInfo> testMethods;
        private static ExtentReports extent;
        private static ExtentHtmlReporter htmlReporter;
        private ComboBox browserComboBox;
        public static IWebDriver driver = null;
        public Form1()
        {
            InitializeComponent();
            getInitialData();
            InitializeExtentReports();
            InitializeBrowserComboBox();
        }

        private void InitializeBrowserComboBox()
        {

            browserComboBox = new ComboBox();
            browserComboBox.Name = "browserComboBox";
            browserComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            browserComboBox.Items.AddRange(new string[] { "Chrome", "Edge", "Firefox" });
            browserComboBox.SelectedIndex = 0;
            browserComboBox.Location = new Point(this.Width - browserComboBox.Width - 70, 30);
             browserComboBox.Size = new Size(150, 34); 
            this.Controls.Add(browserComboBox);
        }
        public BrowserType GetSelectedBrowser()
        {
            string selectedBrowser = browserComboBox.SelectedItem as string;

            if (string.IsNullOrEmpty(selectedBrowser))
            {
                MessageBox.Show("Please select a browser.");
                return BrowserType.Chrome; // You can set a default browser type.
            }

            switch (selectedBrowser)
            {
                case "Chrome":
                    return BrowserType.Chrome;
                case "Edge":
                    return BrowserType.Edge;
                case "Firefox":
                    return BrowserType.Firefox;
                default:
                    return BrowserType.Chrome;
            }
        }



        private void InitializeExtentReports()
        {
            if (extent == null)
            {
                extent = new ExtentReports();
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string tempFilePath = "C:\\Users\\ganeshs\\source\\repos\\BenefitPro\\BenefitPro1\\BenefitPro Reports\\BenefitProTestReports_" + timestamp + ".html";
                htmlReporter = new ExtentHtmlReporter(tempFilePath);
                extent.AttachReporter(htmlReporter);

            }
        }
        public void getInitialData()
        {
            s = new SampleTest(extent);
            u = new Utilities();
            testMethods = u.GetAllTestMethodsFromTestProject();
            testCaseObj test;
            foreach (MethodInfo m in testMethods)
            {
                test = new testCaseObj();
                test.Test_Case_Name = m.Name;
                test.Tests = m.Name.Replace("_", " ");
                test.Details = "";
                testCases.Add(test);
            }
            dgvTestCases.DataSource = testCases;
            dgvTestCases.ReadOnly = false;
            dgvTestCases.Columns[1].ReadOnly = true;
            dgvTestCases.Columns[2].ReadOnly = true;
            dgvTestCases.Columns[3].ReadOnly = true;

            dgvTestCases.Columns[0].Width = 80;
            dgvTestCases.Columns[1].Width = 300;
            dgvTestCases.Columns[2].Width = 175;
            dgvTestCases.Columns[3].Width = 450;
            dgvTestCases.Columns[4].Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BrowserType selectedBrowserType = GetSelectedBrowser();
            Browser.BrowserInit(selectedBrowserType);
            List<testCaseObj> selectedTests = new List<testCaseObj>();
            int j = 0;
            try
            {
                for (int i = 0; i < testCases.Count; i++)
                {
                    if (testCases[i].Select)
                    {
                        testCases[i].Status = "Pending...";
                        refreshGridView();
                        selectedTests.Add(testCases[i]);
                    }
                    else
                    {
                        testCases[i].Status = "";
                        refreshGridView();
                    }
                }
                for (j = 0; j < selectedTests.Count; j++)
                {
                    s.BeforeTest();

                    for (int z = 0; z < testMethods.Count; z++)
                    {
                        if (testMethods[z].Name.Equals(selectedTests[j].Test_Case_Name))
                        {
                            try
                            {


                                testCases.Find(u => u.Test_Case_Name.Equals(selectedTests[j].Test_Case_Name)).Status = "Executing...";
                                refreshGridView();
                                Type type = typeof(SampleTest);
                                MethodInfo methodInfo = type.GetMethod(testMethods[z].Name);
                                TestCaseStatusObj statusObj = (TestCaseStatusObj)methodInfo.Invoke(s, null);

                                if (!statusObj.status)
                                {
                                    testCases.Find(u => u.Test_Case_Name.Equals(selectedTests[j].Test_Case_Name)).Status = "Failed";
                                    testCases.Find(u => u.Test_Case_Name.Equals(selectedTests[j].Test_Case_Name)).Details = statusObj.Links;

                                }
                                else
                                {
                                    testCases.Find(u => u.Test_Case_Name.Equals(selectedTests[j].Test_Case_Name)).Status = "Passed";
                                    testCases.Find(u => u.Test_Case_Name.Equals(selectedTests[j].Test_Case_Name)).Details = statusObj.Links != null ? statusObj.Links : "";

                                }
                                refreshGridView();
                            }
                            catch (Exception ex)
                            {

                            }

                        }
                    }
                    s.AfterTest();

                }
                extent.Flush();


            }
            catch (Exception ex)
            {
                TestCaseStatusObj obj = s.AfterTestCatchException();
                string ext = obj.Links.Substring(obj.Links.Length - 4, 4);

                for (int i = 0; i < selectedTests.Count; i++)
                {
                    if (j == 0 && i == 0 || j >= 0 && j < selectedTests.Count)
                    {
                        selectedTests[0].Status = "Failed";
                        selectedTests[0].Details = obj.Links;

                    }
                    else if (j > 0)
                    {
                        selectedTests[i].Status = "Cancelled";
                        selectedTests[i].Details = "Exception Occurred while running :" + selectedTests[j].Tests;

                    }
                    else
                    {
                        selectedTests[i].Status = "Canceled";
                    }
                }
                refreshGridView();

            }

        }
        public void refreshGridView()
        {
            dgvTestCases.DataSource = null;
            dgvTestCases.DataSource = testCases;
            dgvTestCases.ReadOnly = false;
            dgvTestCases.Columns[1].ReadOnly = true;
            dgvTestCases.Columns[2].ReadOnly = true;
            dgvTestCases.Columns[3].ReadOnly = true;
            dgvTestCases.Columns[0].Width = 80;
            dgvTestCases.Columns[1].Width = 300;
            dgvTestCases.Columns[2].Width = 175;
            dgvTestCases.Columns[3].Width = 450;
            dgvTestCases.Columns[4].Visible = true;
            foreach (DataGridViewRow r in dgvTestCases.Rows)
            {
                r.Cells["Details"] = new DataGridViewLinkCell();
                DataGridViewLinkCell c = r.Cells["Details"] as DataGridViewLinkCell;
                c.LinkColor = System.Drawing.Color.Black;
            }
            dgvTestCases.AutoResizeColumns();
            dgvTestCases.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        public class testCaseObj
        {
            public bool Select { get; set; }
            public string Tests { get; set; }
            public string Status { get; set; }
            public string Details { get; set; }
            public string Test_Case_Name { get; set; }
            public string Reports { get; set; }

        }
        private void browseBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx", Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    tbTestFileInput.Text = ofd.FileName;
                    FileInfo fileInfo = new FileInfo(tbTestFileInput.Text);
                    File.Copy(tbTestFileInput.Text, Path.Combine(Environment.CurrentDirectory, @"TestFiles\", "TestData.xlsx"), true);
                    s = new SampleTest(extent);
                }
            }
        }
        private void dgvTestCases_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dgvTestCases.Rows)
            {
                if (Convert.ToString(row.Cells["Status"].Value).Equals("Failed"))
                {
                    row.Cells["Status"].Style.ForeColor = Color.Tomato;
                }
                else if (Convert.ToString(row.Cells["Status"].Value).Equals("Passed"))
                {
                    row.Cells["Status"].Style.ForeColor = Color.LimeGreen;
                }
            }
        }

        private void dgvTestCases_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dgvTestCases.Rows)
            {
                r.Cells["Details"] = new DataGridViewLinkCell();
                // Note that if I want a different link colour for example it must go here
                DataGridViewLinkCell c = r.Cells["Details"] as DataGridViewLinkCell;
                c.LinkColor = System.Drawing.Color.Black;

            }
        }
        private void dgvTestCases_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTestCases.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                string filename = dgvTestCases.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                string ext = filename.Substring(dgvTestCases.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Length - 4, 4);
                if (ext.Equals(".png"))
                {
                    pictureBox1.Image = System.Drawing.Image.FromFile(filename);
                    pictureBox1.Visible = true;
                    label3.Visible = true;
                    label1.Visible = false;
                    tbTestFileInput.Visible = false;
                    browseBtn.Visible = false;
                    dgvTestCases.Visible = false;
                    button2.Visible = false;
                }
            }
        }

        private void dgvTestCases_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvTestCases.Rows[e.RowIndex].Cells[3].Value != null && dgvTestCases.Rows[e.RowIndex].Cells[3].Value.ToString().Length > 0 && e.ColumnIndex != 0)
                {
                    string filename = dgvTestCases.Rows[e.RowIndex].Cells[3].Value.ToString();

                    string ext = filename.Substring(dgvTestCases.Rows[e.RowIndex].Cells[3].Value.ToString().Length - 4, 4);

                    if (ext.Equals(".png"))
                    {
                        pictureBox1.Image = System.Drawing.Image.FromFile(filename);
                        pictureBox1.Visible = true;
                        label3.Visible = true;
                        label1.Visible = false;
                        tbTestFileInput.Visible = false;
                        browseBtn.Visible = false;
                        dgvTestCases.Visible = false;
                        button2.Visible = false;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvTestCases_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbTestFileInput_TextChanged(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            label3.Visible = false;
            label1.Visible = true;
            tbTestFileInput.Visible = true;
            browseBtn.Visible = true;
            dgvTestCases.Visible = true;
            button2.Visible = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}