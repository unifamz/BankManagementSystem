namespace bank
{
    partial class detail
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 24;
            this.listBox1.Items.AddRange(new object[] {
            "                  minimum amount for deposit is Rs. 2000",
            "",
            "",
            "if you deposit for a 5 year then",
            "interest rate is 2%",
            "",
            "if you deposit for a 10 year then",
            "interest rate is 5%",
            "",
            "",
            "if you deposit for a 15 year then",
            "interest rate is 8%",
            "",
            "",
            "if you deposit for a 20 year then",
            "interest rate is 10%",
            "",
            "",
            "if you want to fixed depoit then first fill the form ...",
            "then choose a plan for fixed depoosit and ",
            "then submit the form.........."});
            this.listBox1.Location = new System.Drawing.Point(518, 40);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(617, 532);
            this.listBox1.TabIndex = 1;
            // 
            // detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1568, 824);
            this.Controls.Add(this.listBox1);
            this.Name = "detail";
            this.Text = "w";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.detail_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;

    }
}