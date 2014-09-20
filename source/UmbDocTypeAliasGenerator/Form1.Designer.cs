namespace UmbDocTypeAliasGenerator
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsitebuilderAssembly = new System.Windows.Forms.TextBox();
            this.btnGenUsitebuilder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "usitebuilder assembly:";
            // 
            // txtUsitebuilderAssembly
            // 
            this.txtUsitebuilderAssembly.Location = new System.Drawing.Point(129, 41);
            this.txtUsitebuilderAssembly.Name = "txtUsitebuilderAssembly";
            this.txtUsitebuilderAssembly.Size = new System.Drawing.Size(355, 20);
            this.txtUsitebuilderAssembly.TabIndex = 1;
            this.txtUsitebuilderAssembly.Click += new System.EventHandler(this.txtUsitebuilderAssembly_Click);
            // 
            // btnGenUsitebuilder
            // 
            this.btnGenUsitebuilder.Location = new System.Drawing.Point(496, 38);
            this.btnGenUsitebuilder.Name = "btnGenUsitebuilder";
            this.btnGenUsitebuilder.Size = new System.Drawing.Size(75, 23);
            this.btnGenUsitebuilder.TabIndex = 2;
            this.btnGenUsitebuilder.Text = "Generate";
            this.btnGenUsitebuilder.UseVisualStyleBackColor = true;
            this.btnGenUsitebuilder.Click += new System.EventHandler(this.btnGenUsitebuilder_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 298);
            this.Controls.Add(this.btnGenUsitebuilder);
            this.Controls.Add(this.txtUsitebuilderAssembly);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Umbraco DocTypeAlias Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsitebuilderAssembly;
        private System.Windows.Forms.Button btnGenUsitebuilder;
    }
}

