namespace WindowsApplication133
{
    partial class Form1
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
            this.cGridControl1 = new CGrid.CGridControl();
            this.cGridView1 = new CGrid.CGridView();
            this.cGridView2 = new CGrid.CGridView();
            ((System.ComponentModel.ISupportInitialize)(this.cGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // cGridControl1
            // 
            this.cGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cGridControl1.EmbeddedNavigator.Name = "";
            this.cGridControl1.Location = new System.Drawing.Point(0, 0);
            this.cGridControl1.MainView = this.cGridView1;
            this.cGridControl1.Name = "cGridControl1";
            this.cGridControl1.Size = new System.Drawing.Size(292, 266);
            this.cGridControl1.TabIndex = 0;
            this.cGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.cGridView1,
            this.cGridView2});
            // 
            // cGridView1
            // 
            this.cGridView1.GridControl = this.cGridControl1;
            this.cGridView1.Name = "cGridView1";
            // 
            // cGridView2
            // 
            this.cGridView2.GridControl = this.cGridControl1;
            this.cGridView2.Name = "cGridView2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.cGridControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.cGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CGrid.CGridControl cGridControl1;
        private CGrid.CGridView cGridView1;
        private CGrid.CGridView cGridView2;

    }
}

