namespace MonitoringApp
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
            button_run = new Button();
            label1 = new Label();
            richTextBox1 = new RichTextBox();
            button_domains = new Button();
            openFileDialog1 = new OpenFileDialog();
            groupBox1 = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // button_run
            // 
            button_run.Location = new Point(425, 177);
            button_run.Name = "button_run";
            button_run.Size = new Size(75, 23);
            button_run.TabIndex = 0;
            button_run.Text = "run";
            button_run.UseVisualStyleBackColor = true;
            button_run.Click += button_run_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.ForeColor = Color.DeepSkyBlue;
            label1.Location = new Point(12, 35);
            label1.Name = "label1";
            label1.Size = new Size(230, 19);
            label1.TabIndex = 1;
            label1.Text = "Monitoring dan Evaluasi (Monev)";
            // 
            // richTextBox1
            // 
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Location = new Point(14, 59);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox1.Size = new Size(251, 62);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "digunakan untuk mengamati perkembangan dan menilai kinerja ISP dalam menerapkan response policy zone.";
            // 
            // button_domains
            // 
            button_domains.Location = new Point(12, 177);
            button_domains.Name = "button_domains";
            button_domains.Size = new Size(94, 23);
            button_domains.TabIndex = 3;
            button_domains.Text = "Domains File";
            button_domains.UseVisualStyleBackColor = true;
            button_domains.Click += button_domains_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(271, 35);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(229, 122);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Path Location";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(6, 61);
            label3.Name = "label3";
            label3.Size = new Size(16, 15);
            label3.TabIndex = 1;
            label3.Text = "...";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(6, 37);
            label2.Name = "label2";
            label2.Size = new Size(71, 15);
            label2.TabIndex = 0;
            label2.Text = "Target File :";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 212);
            Controls.Add(groupBox1);
            Controls.Add(button_domains);
            Controls.Add(richTextBox1);
            Controls.Add(label1);
            Controls.Add(button_run);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_run;
        private Label label1;
        private RichTextBox richTextBox1;
        private Button button_domains;
        private OpenFileDialog openFileDialog1;
        private GroupBox groupBox1;
        private Label label2;
        private Label label3;
    }
}
