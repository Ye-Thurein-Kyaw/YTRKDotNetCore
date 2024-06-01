namespace YTRKDotNetCore.WinFormsApp
{
    partial class FrmBlog
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
            txtAuthor = new TextBox();
            txtTitle = new TextBox();
            txtContent = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            saveBtn = new Button();
            cancelBtn = new Button();
            btnUpdate = new Button();
            SuspendLayout();
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(104, 94);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(336, 25);
            txtAuthor.TabIndex = 1;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(104, 31);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(336, 25);
            txtTitle.TabIndex = 2;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(104, 158);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(336, 85);
            txtContent.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(104, 9);
            label1.Name = "label1";
            label1.Size = new Size(41, 19);
            label1.TabIndex = 4;
            label1.Text = "Title :";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(104, 72);
            label2.Name = "label2";
            label2.Size = new Size(59, 19);
            label2.TabIndex = 5;
            label2.Text = "Author :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(104, 136);
            label3.Name = "label3";
            label3.Size = new Size(66, 19);
            label3.TabIndex = 6;
            label3.Text = "Content :";
            label3.Click += label3_Click;
            // 
            // saveBtn
            // 
            saveBtn.BackColor = Color.FromArgb(0, 192, 0);
            saveBtn.FlatAppearance.BorderSize = 0;
            saveBtn.FlatStyle = FlatStyle.Flat;
            saveBtn.ForeColor = Color.White;
            saveBtn.Location = new Point(207, 253);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(86, 33);
            saveBtn.TabIndex = 7;
            saveBtn.Text = "&Save";
            saveBtn.UseVisualStyleBackColor = false;
            saveBtn.Click += saveBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.BackColor = Color.Gray;
            cancelBtn.FlatAppearance.BorderSize = 0;
            cancelBtn.FlatStyle = FlatStyle.Flat;
            cancelBtn.ForeColor = Color.White;
            cancelBtn.Location = new Point(104, 253);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(86, 33);
            cancelBtn.TabIndex = 8;
            cancelBtn.Text = "&Cancel";
            cancelBtn.UseVisualStyleBackColor = false;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.DeepSkyBlue;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(207, 253);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(86, 33);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "&Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Visible = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // FrmBlog
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 510);
            Controls.Add(btnUpdate);
            Controls.Add(cancelBtn);
            Controls.Add(saveBtn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtContent);
            Controls.Add(txtTitle);
            Controls.Add(txtAuthor);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "FrmBlog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blog";
            Load += FrmBlog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtAuthor;
        private TextBox txtTitle;
        private TextBox txtContent;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button saveBtn;
        private Button cancelBtn;
        private Button btnUpdate;
    }
}
