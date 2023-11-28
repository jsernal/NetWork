namespace NetWork.Vista
{
    partial class FormRetrasoReservas
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
            this.dGWRetraso = new System.Windows.Forms.DataGridView();
            this.CodigoReservas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnVerRes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGWRetraso)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(255, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Consultar reservas con retraso";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dGWRetraso
            // 
            this.dGWRetraso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGWRetraso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoReservas,
            this.FechaEntrada,
            this.Cliente,
            this.Telefono});
            this.dGWRetraso.Location = new System.Drawing.Point(183, 177);
            this.dGWRetraso.Name = "dGWRetraso";
            this.dGWRetraso.Size = new System.Drawing.Size(444, 150);
            this.dGWRetraso.TabIndex = 1;
            this.dGWRetraso.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGWRetraso_CellContentClick);
            // 
            // CodigoReservas
            // 
            this.CodigoReservas.DataPropertyName = "CodigoReservas";
            this.CodigoReservas.HeaderText = "CodigoReservas";
            this.CodigoReservas.Name = "CodigoReservas";
            // 
            // FechaEntrada
            // 
            this.FechaEntrada.DataPropertyName = "FechaEntrada";
            this.FechaEntrada.HeaderText = "FechaEntrada";
            this.FechaEntrada.Name = "FechaEntrada";
            // 
            // Cliente
            // 
            this.Cliente.DataPropertyName = "NombreCliente";
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            // 
            // Telefono
            // 
            this.Telefono.DataPropertyName = "TelefonoCliente";
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.Name = "Telefono";
            // 
            // btnVerRes
            // 
            this.btnVerRes.Location = new System.Drawing.Point(358, 118);
            this.btnVerRes.Name = "btnVerRes";
            this.btnVerRes.Size = new System.Drawing.Size(75, 23);
            this.btnVerRes.TabIndex = 2;
            this.btnVerRes.Text = "Verificar Reservas";
            this.btnVerRes.UseVisualStyleBackColor = true;
            this.btnVerRes.Click += new System.EventHandler(this.btnVerRes_Click);
            // 
            // FormRetrasoReservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVerRes);
            this.Controls.Add(this.dGWRetraso);
            this.Controls.Add(this.label1);
            this.Name = "FormRetrasoReservas";
            this.Text = "FormRetrasoReservas";
            this.Load += new System.EventHandler(this.FormRetrasoReservas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGWRetraso)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dGWRetraso;
        private System.Windows.Forms.Button btnVerRes;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoReservas;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
    }
}