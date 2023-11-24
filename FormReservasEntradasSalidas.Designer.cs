namespace NetWork.Vista
{
    partial class FormReservasEntradasSalidas
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
            this.btnEntrSal = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FechaEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoReservas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumHabitacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoReserva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtbFirmar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFirmar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEntrSal
            // 
            this.btnEntrSal.Location = new System.Drawing.Point(312, 162);
            this.btnEntrSal.Name = "btnEntrSal";
            this.btnEntrSal.Size = new System.Drawing.Size(164, 23);
            this.btnEntrSal.TabIndex = 0;
            this.btnEntrSal.Text = "Consultar entradas y salidas";
            this.btnEntrSal.UseVisualStyleBackColor = true;
            this.btnEntrSal.Click += new System.EventHandler(this.btnEntrSal_Click_1);
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(351, 24);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(96, 23);
            this.btnMenu.TabIndex = 2;
            this.btnMenu.Text = "Menu principal";
            this.btnMenu.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FechaEntrada,
            this.FechaSalida,
            this.CodigoReservas,
            this.NombreCliente,
            this.IdCliente,
            this.NumHabitacion,
            this.EstadoReserva});
            this.dataGridView1.Location = new System.Drawing.Point(45, 208);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(743, 150);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // FechaEntrada
            // 
            this.FechaEntrada.DataPropertyName = "FechaEntrada";
            this.FechaEntrada.HeaderText = "FechaEntrada";
            this.FechaEntrada.Name = "FechaEntrada";
            // 
            // FechaSalida
            // 
            this.FechaSalida.DataPropertyName = "FechaSalida";
            this.FechaSalida.HeaderText = "FechaSalida";
            this.FechaSalida.Name = "FechaSalida";
            // 
            // CodigoReservas
            // 
            this.CodigoReservas.DataPropertyName = "CodigoReservas";
            this.CodigoReservas.HeaderText = "CodigoReservas";
            this.CodigoReservas.Name = "CodigoReservas";
            // 
            // NombreCliente
            // 
            this.NombreCliente.DataPropertyName = "NombreCliente";
            this.NombreCliente.HeaderText = "NombreCliente";
            this.NombreCliente.Name = "NombreCliente";
            // 
            // IdCliente
            // 
            this.IdCliente.DataPropertyName = "IdCliente";
            this.IdCliente.HeaderText = "IdCliente";
            this.IdCliente.Name = "IdCliente";
            // 
            // NumHabitacion
            // 
            this.NumHabitacion.DataPropertyName = "NumHabitacion";
            this.NumHabitacion.HeaderText = "NumHabitacion";
            this.NumHabitacion.Name = "NumHabitacion";
            // 
            // EstadoReserva
            // 
            this.EstadoReserva.DataPropertyName = "EstadoReservaTexto";
            this.EstadoReserva.HeaderText = "EstadoReserva";
            this.EstadoReserva.Name = "EstadoReserva";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(293, 107);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // txtbFirmar
            // 
            this.txtbFirmar.Location = new System.Drawing.Point(351, 393);
            this.txtbFirmar.Name = "txtbFirmar";
            this.txtbFirmar.Size = new System.Drawing.Size(100, 20);
            this.txtbFirmar.TabIndex = 5;
            this.txtbFirmar.TextChanged += new System.EventHandler(this.txtbFirmar_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 396);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Introduce la reserva a firmar";
            // 
            // btnFirmar
            // 
            this.btnFirmar.Location = new System.Drawing.Point(469, 391);
            this.btnFirmar.Name = "btnFirmar";
            this.btnFirmar.Size = new System.Drawing.Size(75, 23);
            this.btnFirmar.TabIndex = 7;
            this.btnFirmar.Text = "Firmar";
            this.btnFirmar.UseVisualStyleBackColor = true;
            this.btnFirmar.Click += new System.EventHandler(this.btnFirmar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(304, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Entradas y salidas\r\n";
            // 
            // FormReservasEntradasSalidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFirmar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbFirmar);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnEntrSal);
            this.Name = "FormReservasEntradasSalidas";
            this.Text = "FormReservasEntradasSalidas";
            this.Load += new System.EventHandler(this.FormRecepcionista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEntrSal;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtbFirmar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFirmar;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoReservas;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumHabitacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoReserva;
        private System.Windows.Forms.Label label2;
    }
}