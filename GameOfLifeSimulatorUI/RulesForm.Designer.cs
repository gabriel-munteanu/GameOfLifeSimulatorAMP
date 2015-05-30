namespace GameOfLifeSimulatorUI
{
    partial class RulesForm
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
            this.txt_Born = new System.Windows.Forms.TextBox();
            this.lbl_Born = new System.Windows.Forms.Label();
            this.lbl_Survive = new System.Windows.Forms.Label();
            this.txt_Survive = new System.Windows.Forms.TextBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_Born
            // 
            this.txt_Born.Location = new System.Drawing.Point(37, 12);
            this.txt_Born.Name = "txt_Born";
            this.txt_Born.Size = new System.Drawing.Size(72, 20);
            this.txt_Born.TabIndex = 0;
            // 
            // lbl_Born
            // 
            this.lbl_Born.AutoSize = true;
            this.lbl_Born.Location = new System.Drawing.Point(6, 15);
            this.lbl_Born.Name = "lbl_Born";
            this.lbl_Born.Size = new System.Drawing.Size(29, 13);
            this.lbl_Born.TabIndex = 1;
            this.lbl_Born.Text = "Born";
            // 
            // lbl_Survive
            // 
            this.lbl_Survive.AutoSize = true;
            this.lbl_Survive.Location = new System.Drawing.Point(122, 15);
            this.lbl_Survive.Name = "lbl_Survive";
            this.lbl_Survive.Size = new System.Drawing.Size(43, 13);
            this.lbl_Survive.TabIndex = 3;
            this.lbl_Survive.Text = "Survive";
            // 
            // txt_Survive
            // 
            this.txt_Survive.Location = new System.Drawing.Point(165, 12);
            this.txt_Survive.Name = "txt_Survive";
            this.txt_Survive.Size = new System.Drawing.Size(72, 20);
            this.txt_Survive.TabIndex = 2;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(186, 39);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(54, 23);
            this.btn_OK.TabIndex = 4;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(125, 39);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(54, 23);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // RulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 74);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.lbl_Survive);
            this.Controls.Add(this.txt_Survive);
            this.Controls.Add(this.lbl_Born);
            this.Controls.Add(this.txt_Born);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RulesForm";
            this.Text = "RulesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Born;
        private System.Windows.Forms.Label lbl_Born;
        private System.Windows.Forms.Label lbl_Survive;
        private System.Windows.Forms.TextBox txt_Survive;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
    }
}