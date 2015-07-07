namespace GovDataForm
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
            this.outputRTB = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxRep = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inputZ = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // outputRTB
            // 
            this.outputRTB.Location = new System.Drawing.Point(169, 22);
            this.outputRTB.Name = "outputRTB";
            this.outputRTB.ReadOnly = true;
            this.outputRTB.Size = new System.Drawing.Size(308, 466);
            this.outputRTB.TabIndex = 1;
            this.outputRTB.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(88, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxRep
            // 
            this.comboBoxRep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRep.FormattingEnabled = true;
            this.comboBoxRep.Items.AddRange(new object[] {
            "Address, City, State, Zip",
            "Zip"});
            this.comboBoxRep.Location = new System.Drawing.Point(12, 30);
            this.comboBoxRep.Name = "comboBoxRep";
            this.comboBoxRep.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRep.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Find by...";
            // 
            // inputZ
            // 
            this.inputZ.Location = new System.Drawing.Point(12, 59);
            this.inputZ.Name = "inputZ";
            this.inputZ.Size = new System.Drawing.Size(148, 20);
            this.inputZ.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(166, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Results";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 491);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.inputZ);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxRep);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.outputRTB);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Get Senator and Representative Data by Area";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox outputRTB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxRep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputZ;
        private System.Windows.Forms.Label label4;
    }
}

