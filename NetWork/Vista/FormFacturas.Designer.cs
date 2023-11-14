namespace NetWork.Vista
{
    partial class FormFacturas
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNifCliente = new System.Windows.Forms.TextBox();
            this.dateTimePickerFecha = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.EmailUsuario = new System.Windows.Forms.Label();
            this.genFactura = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textTotal = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 32.25F);
            this.label1.Location = new System.Drawing.Point(267, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 51);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gestión de facturas";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Buscar por NIF cliente:";
            // 
            // textBoxNifCliente
            // 
            this.textBoxNifCliente.Location = new System.Drawing.Point(49, 161);
            this.textBoxNifCliente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxNifCliente.Name = "textBoxNifCliente";
            this.textBoxNifCliente.Size = new System.Drawing.Size(194, 26);
            this.textBoxNifCliente.TabIndex = 26;
            this.textBoxNifCliente.TextChanged += new System.EventHandler(this.textBoxNifCliente_TextChanged);
            // 
            // dateTimePickerFecha
            // 
            this.dateTimePickerFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dateTimePickerFecha.Location = new System.Drawing.Point(678, 542);
            this.dateTimePickerFecha.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePickerFecha.Name = "dateTimePickerFecha";
            this.dateTimePickerFecha.Size = new System.Drawing.Size(212, 20);
            this.dateTimePickerFecha.TabIndex = 27;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(49, 195);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(847, 330);
            this.dataGridView1.TabIndex = 28;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 548);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 35);
            this.button1.TabIndex = 31;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EmailUsuario
            // 
            this.EmailUsuario.AutoSize = true;
            this.EmailUsuario.Location = new System.Drawing.Point(39, 42);
            this.EmailUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EmailUsuario.Name = "EmailUsuario";
            this.EmailUsuario.Size = new System.Drawing.Size(103, 20);
            this.EmailUsuario.TabIndex = 32;
            this.EmailUsuario.Text = "EmailUsuario";
            // 
            // genFactura
            // 
            this.genFactura.Location = new System.Drawing.Point(396, 141);
            this.genFactura.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.genFactura.Name = "genFactura";
            this.genFactura.Size = new System.Drawing.Size(168, 46);
            this.genFactura.TabIndex = 36;
            this.genFactura.Text = "Generar factura";
            this.genFactura.UseVisualStyleBackColor = true;
            this.genFactura.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(680, 136);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "Total €";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textTotal
            // 
            this.textTotal.Location = new System.Drawing.Point(684, 161);
            this.textTotal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textTotal.Name = "textTotal";
            this.textTotal.Size = new System.Drawing.Size(212, 26);
            this.textTotal.TabIndex = 38;
            this.textTotal.TextChanged += new System.EventHandler(this.textTotal_TextChanged);
            // 
            // FormFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 615);
            this.Controls.Add(this.textTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.genFactura);
            this.Controls.Add(this.EmailUsuario);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimePickerFecha);
            this.Controls.Add(this.textBoxNifCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "FormFacturas";
            this.Text = "FormModificarReservas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNifCliente;
        private System.Windows.Forms.DateTimePicker dateTimePickerFecha;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label EmailUsuario;
        private System.Windows.Forms.Button genFactura;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textTotal;
    }
}