namespace AzsApp.WFEF
{
    partial class StationSearchForm
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
            this.Search2Btn = new System.Windows.Forms.Button();
            this.FuelTypeMTB = new System.Windows.Forms.MaskedTextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.StationIdMTB = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // Search2Btn
            // 
            this.Search2Btn.Location = new System.Drawing.Point(408, 228);
            this.Search2Btn.Name = "Search2Btn";
            this.Search2Btn.Size = new System.Drawing.Size(193, 28);
            this.Search2Btn.TabIndex = 7;
            this.Search2Btn.Text = "Найти по типу топлива";
            this.Search2Btn.UseVisualStyleBackColor = true;
            this.Search2Btn.Click += new System.EventHandler(this.Search2Btn_Click);
            // 
            // FuelTypeMTB
            // 
            this.FuelTypeMTB.Location = new System.Drawing.Point(200, 230);
            this.FuelTypeMTB.Mask = "AA";
            this.FuelTypeMTB.Name = "FuelTypeMTB";
            this.FuelTypeMTB.Size = new System.Drawing.Size(202, 26);
            this.FuelTypeMTB.TabIndex = 6;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Location = new System.Drawing.Point(408, 194);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(193, 28);
            this.SearchBtn.TabIndex = 5;
            this.SearchBtn.Text = "Найти по ID";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // StationIdMTB
            // 
            this.StationIdMTB.Location = new System.Drawing.Point(200, 194);
            this.StationIdMTB.Mask = "99";
            this.StationIdMTB.Name = "StationIdMTB";
            this.StationIdMTB.Size = new System.Drawing.Size(202, 26);
            this.StationIdMTB.TabIndex = 4;
            // 
            // StationSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Search2Btn);
            this.Controls.Add(this.FuelTypeMTB);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.StationIdMTB);
            this.Name = "StationSearchForm";
            this.Text = "Поиск станции";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Search2Btn;
        private MaskedTextBox FuelTypeMTB;
        private Button SearchBtn;
        private MaskedTextBox StationIdMTB;
    }
}