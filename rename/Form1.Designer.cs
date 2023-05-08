namespace rename
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
            BtnChange = new Button();
            label1 = new Label();
            label2 = new Label();
            txtPath = new TextBox();
            groupRpt = new GroupBox();
            TxtNew = new TextBox();
            label4 = new Label();
            TxtOld = new TextBox();
            label3 = new Label();
            groupAdd = new GroupBox();
            txtAddStr = new TextBox();
            LabelAddStr = new Label();
            comboBox1 = new ComboBox();
            groupRpt.SuspendLayout();
            groupAdd.SuspendLayout();
            SuspendLayout();
            // 
            // BtnChange
            // 
            BtnChange.Location = new Point(152, 188);
            BtnChange.Name = "BtnChange";
            BtnChange.Size = new Size(103, 23);
            BtnChange.TabIndex = 0;
            BtnChange.Text = "一键改名";
            BtnChange.UseVisualStyleBackColor = true;
            BtnChange.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Enabled = false;
            label1.Location = new Point(19, 19);
            label1.Name = "label1";
            label1.Size = new Size(68, 17);
            label1.TabIndex = 2;
            label1.Text = "重命名类型";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Enabled = false;
            label2.Location = new Point(19, 49);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(56, 17);
            label2.TabIndex = 3;
            label2.Text = "改名目录";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtPath
            // 
            txtPath.Location = new Point(93, 46);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(277, 23);
            txtPath.TabIndex = 5;
            // 
            // groupRpt
            // 
            groupRpt.Controls.Add(TxtNew);
            groupRpt.Controls.Add(label4);
            groupRpt.Controls.Add(TxtOld);
            groupRpt.Controls.Add(label3);
            groupRpt.Location = new Point(19, 75);
            groupRpt.Name = "groupRpt";
            groupRpt.Size = new Size(351, 112);
            groupRpt.TabIndex = 7;
            groupRpt.TabStop = false;
            groupRpt.Visible = false;
            // 
            // TxtNew
            // 
            TxtNew.Location = new Point(73, 53);
            TxtNew.Name = "TxtNew";
            TxtNew.Size = new Size(271, 23);
            TxtNew.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Enabled = false;
            label4.Location = new Point(5, 56);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.Yes;
            label4.Size = new Size(56, 17);
            label4.TabIndex = 8;
            label4.Text = "替换字符";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // TxtOld
            // 
            TxtOld.Location = new Point(74, 22);
            TxtOld.Name = "TxtOld";
            TxtOld.Size = new Size(271, 23);
            TxtOld.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Enabled = false;
            label3.Location = new Point(6, 25);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(56, 17);
            label3.TabIndex = 6;
            label3.Text = "原字符串";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // groupAdd
            // 
            groupAdd.Controls.Add(txtAddStr);
            groupAdd.Controls.Add(LabelAddStr);
            groupAdd.Location = new Point(19, 75);
            groupAdd.Name = "groupAdd";
            groupAdd.Size = new Size(351, 112);
            groupAdd.TabIndex = 10;
            groupAdd.TabStop = false;
            groupAdd.Visible = false;
            // 
            // txtAddStr
            // 
            txtAddStr.Location = new Point(74, 22);
            txtAddStr.Name = "txtAddStr";
            txtAddStr.Size = new Size(271, 23);
            txtAddStr.TabIndex = 7;
            // 
            // LabelAddStr
            // 
            LabelAddStr.AutoSize = true;
            LabelAddStr.Enabled = false;
            LabelAddStr.Location = new Point(6, 25);
            LabelAddStr.Name = "LabelAddStr";
            LabelAddStr.RightToLeft = RightToLeft.Yes;
            LabelAddStr.Size = new Size(32, 17);
            LabelAddStr.TabIndex = 6;
            LabelAddStr.Text = "前缀";
            LabelAddStr.TextAlign = ContentAlignment.MiddleRight;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(93, 16);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(277, 25);
            comboBox1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(394, 221);
            Controls.Add(groupAdd);
            Controls.Add(comboBox1);
            Controls.Add(groupRpt);
            Controls.Add(txtPath);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(BtnChange);
            Name = "Form1";
            Text = "一键改名";
            groupRpt.ResumeLayout(false);
            groupRpt.PerformLayout();
            groupAdd.ResumeLayout(false);
            groupAdd.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnChange;
        private Label label1;
        private Label label2;
        private TextBox txtPath;
        private GroupBox groupRpt;
        private ComboBox comboBox1;
        private TextBox TxtOld;
        private Label label3;
        private TextBox TxtNew;
        private Label label4;
        private GroupBox groupAdd;
        private TextBox txtAddStr;
        private Label LabelAddStr;
    }
}