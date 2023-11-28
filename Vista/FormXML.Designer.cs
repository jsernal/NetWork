namespace NetWork.Vista
{
    partial class FormXML
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
            this.visualizarXML = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.visualizarXML)).BeginInit();
            this.SuspendLayout();
            // 
            // visualizarXML
            // 
            this.visualizarXML.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.visualizarXML.Location = new System.Drawing.Point(60, 91);
            this.visualizarXML.Name = "visualizarXML";
            this.visualizarXML.Size = new System.Drawing.Size(700, 241);
            this.visualizarXML.TabIndex = 0;
            this.visualizarXML.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // FormXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.visualizarXML);
            this.Name = "FormXML";
            this.Text = "FormXML";
            this.Load += new System.EventHandler(this.FormXML_Load);
            ((System.ComponentModel.ISupportInitialize)(this.visualizarXML)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView visualizarXML;
    }
}