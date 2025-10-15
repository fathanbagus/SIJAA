namespace SIJA
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnMaterTeacher = new System.Windows.Forms.Button();
            this.btnMasterStudent = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(630, 67);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 50);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnMaterTeacher
            // 
            this.btnMaterTeacher.Location = new System.Drawing.Point(155, 155);
            this.btnMaterTeacher.Name = "btnMaterTeacher";
            this.btnMaterTeacher.Size = new System.Drawing.Size(458, 51);
            this.btnMaterTeacher.TabIndex = 1;
            this.btnMaterTeacher.Text = "Master Teacher";
            this.btnMaterTeacher.UseVisualStyleBackColor = true;
            // 
            // btnMasterStudent
            // 
            this.btnMasterStudent.Location = new System.Drawing.Point(155, 233);
            this.btnMasterStudent.Name = "btnMasterStudent";
            this.btnMasterStudent.Size = new System.Drawing.Size(458, 47);
            this.btnMasterStudent.TabIndex = 2;
            this.btnMasterStudent.Text = "Master Student";
            this.btnMasterStudent.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(268, 71);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(260, 32);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Welcome, {name}!";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnMasterStudent);
            this.Controls.Add(this.btnMaterTeacher);
            this.Controls.Add(this.btnLogout);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnMaterTeacher;
        private System.Windows.Forms.Button btnMasterStudent;
        private System.Windows.Forms.Label lblName;
    }
}