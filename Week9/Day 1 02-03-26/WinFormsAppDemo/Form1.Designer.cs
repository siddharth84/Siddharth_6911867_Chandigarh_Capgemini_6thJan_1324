namespace WinformAppDemo
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtEmpId;
        private System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.TextBox txtEmpDesig;
        private System.Windows.Forms.TextBox txtEmpDOJ;
        private System.Windows.Forms.TextBox txtEmpSal;
        private System.Windows.Forms.TextBox txtEmpDept;

        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnFind;

        private System.Windows.Forms.DataGridView dataGridView1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtEmpId = new System.Windows.Forms.TextBox();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.txtEmpDesig = new System.Windows.Forms.TextBox();
            this.txtEmpDOJ = new System.Windows.Forms.TextBox();
            this.txtEmpSal = new System.Windows.Forms.TextBox();
            this.txtEmpDept = new System.Windows.Forms.TextBox();

            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();

            this.dataGridView1 = new System.Windows.Forms.DataGridView();

            this.SuspendLayout();

            // TextBox positions
            txtEmpId.Location = new System.Drawing.Point(20, 20);
            txtEmpName.Location = new System.Drawing.Point(20, 50);
            txtEmpDesig.Location = new System.Drawing.Point(20, 80);
            txtEmpDOJ.Location = new System.Drawing.Point(20, 110);
            txtEmpSal.Location = new System.Drawing.Point(20, 140);
            txtEmpDept.Location = new System.Drawing.Point(20, 170);

            // Buttons
            btnInsert.Text = "Insert";
            btnInsert.Location = new System.Drawing.Point(200, 20);
            btnInsert.Click += new System.EventHandler(this.btnInsert_Click);

            btnUpdate.Text = "Update";
            btnUpdate.Location = new System.Drawing.Point(200, 60);
            btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            btnDelete.Text = "Delete";
            btnDelete.Location = new System.Drawing.Point(200, 100);
            btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            btnFind.Text = "Find";
            btnFind.Location = new System.Drawing.Point(200, 140);
            btnFind.Click += new System.EventHandler(this.btnFind_Click);

            // DataGridView
            dataGridView1.Location = new System.Drawing.Point(20, 220);
            dataGridView1.Size = new System.Drawing.Size(500, 200);

            // Form
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(txtEmpId);
            this.Controls.Add(txtEmpName);
            this.Controls.Add(txtEmpDesig);
            this.Controls.Add(txtEmpDOJ);
            this.Controls.Add(txtEmpSal);
            this.Controls.Add(txtEmpDept);
            this.Controls.Add(btnInsert);
            this.Controls.Add(btnUpdate);
            this.Controls.Add(btnDelete);
            this.Controls.Add(btnFind);
            this.Controls.Add(dataGridView1);

            this.Load += new System.EventHandler(this.Form1_Load);

            this.ResumeLayout(false);
        }
    }
}