namespace BenefitProApp2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            tbTestFileInput = new TextBox();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            dgvTestCases = new DataGridView();
            button2 = new Button();
            label3 = new Label();
            browseBtn = new Button();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTestCases).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(62, 39);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 0;
            label1.Text = "Test File :";
            label1.Click += label1_Click;
            // 
            // tbTestFileInput
            // 
            tbTestFileInput.Location = new Point(142, 37);
            tbTestFileInput.Name = "tbTestFileInput";
            tbTestFileInput.Size = new Size(500, 23);
            tbTestFileInput.TabIndex = 3;
            tbTestFileInput.TextChanged += tbTestFileInput_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(26, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1195, 630);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label2
            // 
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 0;
            // 
            // dgvTestCases
            // 
            dgvTestCases.AllowUserToAddRows = false;
            dgvTestCases.AllowUserToDeleteRows = false;
            dgvTestCases.AllowUserToResizeRows = false;
            dgvTestCases.BackgroundColor = SystemColors.ControlLightLight;
            dgvTestCases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTestCases.GridColor = SystemColors.ControlLightLight;
            dgvTestCases.Location = new Point(62, 75);
            dgvTestCases.Name = "dgvTestCases";
            dgvTestCases.ReadOnly = true;
            dgvTestCases.RowHeadersVisible = false;
            dgvTestCases.RowHeadersWidth = 51;
            dgvTestCases.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvTestCases.ShowCellToolTips = false;
            dgvTestCases.Size = new Size(1143, 530);
            dgvTestCases.TabIndex = 6;
            dgvTestCases.Text = "dataGridView1";
            dgvTestCases.CellClick += dgvTestCases_CellClick;
            dgvTestCases.CellContentClick += dgvTestCases_CellContentClick;
            dgvTestCases.CellFormatting += dgvTestCases_CellFormatting;
            dgvTestCases.DataBindingComplete += dgvTestCases_DataBindingComplete;
            // 
            // button2
            // 
            button2.Location = new Point(592, 611);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 1;
            button2.Text = "RUN";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(1224, 9);
            label3.Name = "label3";
            label3.Size = new Size(20, 21);
            label3.TabIndex = 6;
            label3.Text = "X";
            label3.Visible = false;
            label3.Click += label3_Click;
            // 
            // browseBtn
            // 
            browseBtn.Location = new Point(648, 35);
            browseBtn.Name = "browseBtn";
            browseBtn.Size = new Size(94, 34);
            browseBtn.TabIndex = 2;
            browseBtn.Text = "Browse";
            browseBtn.UseVisualStyleBackColor = true;
            browseBtn.Click += browseBtn_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.2F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(848, 28);
            label4.Name = "label4";
            label4.Size = new Size(240, 17);
            label4.TabIndex = 5;
            label4.Text = "Please select browser to run the test :";
            label4.Click += label4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1265, 686);
            Controls.Add(label4);
            Controls.Add(browseBtn);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(tbTestFileInput);
            Controls.Add(dgvTestCases);
            Controls.Add(pictureBox1);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Benefit Pro";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTestCases).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private PictureBox pictureBox1;
        private DataGridView dgvTestCases;
        private TextBox tbTestFileInput;
        private Label label1;
        private Label label2;
        private Button button2;
        private Label label3;
        private Button browseBtn;
        private Label label4;
    }
}