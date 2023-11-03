using BenefitPro.Administration;
using NUnitLite;
using System.Diagnostics;
using System.Reflection;


namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        private TextBox filePathTextBox;
        private UserManagement userManagement;
        //UserManagement s ;
        //Utilities u;

        List<MethodInfo> testMethods;
        public Form1()
        {
            InitializeComponent();
            userManagement = new UserManagement();
            //getInitialData();
        }
        //public void getInitialData()
        //{
        //    s=new UserManagement();
        //    u= new Utilities();
        //    testMethods = u.GetAllTestMethodsFromTestProject();
        //}

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                // Do something with the selected file path, e.g., display it in a textbox or process the file.
                filePathTextBox.Text = selectedFilePath;
            }
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void openFileDialog2_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) // Replace 'yourTestMethodColumnIndex' with the actual column index where you want to display test methods.
            {
                // Get the MethodInfo corresponding to the clicked cell's row index
                MethodInfo method = testMethods[e.RowIndex];

                // Display the method's name in the cell
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = method.Name;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // Type type = typeof(UserManagement);
            // MethodInfo methodInfo = type.GetMethod("AddUsers");
            //methodInfo.Invoke(s,null);
            userManagement.AddUsers();

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
