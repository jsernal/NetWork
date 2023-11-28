namespace NetWork.Vista
{
    partial class FormHistorialClientes
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
            this.dtgCliente = new System.Windows.Forms.DataGridView();
            this.CodigoReservas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumHabitacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoHabitacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtbCliente = new System.Windows.Forms.TextBox();
            this.btnCliente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFecha1 = new System.Windows.Forms.DateTimePicker();
            this.dtpFecha2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgCliente
            // 
            this.dtgCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoReservas,
            this.NumHabitacion,
            this.FechaEntrada,
            this.FechaSalida,
            this.NombreCliente,
            this.TipoHabitacion});
            this.dtgCliente.Location = new System.Drawing.Point(77, 230);
            this.dtgCliente.Name = "dtgCliente";
            this.dtgCliente.Size = new System.Drawing.Size(644, 150);
            this.dtgCliente.TabIndex = 0;
            this.dtgCliente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCliente_CellContentClick);
            // 
            // CodigoReservas
            // 
            this.CodigoReservas.DataPropertyName = "CodigoReservas";
            this.CodigoReservas.HeaderText = "CodigoReservas";
            this.CodigoReservas.Name = "CodigoReservas";
            // 
            // NumHabitacion
            // 
            this.NumHabitacion.DataPropertyName = "NumHabitacion";
            this.NumHabitacion.HeaderText = "NumHabitacion";
            this.NumHabitacion.Name = "NumHabitacion";
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
            // NombreCliente
            // 
            this.NombreCliente.DataPropertyName = "NombreCliente";
            this.NombreCliente.HeaderText = "NombreCliente";
            this.NombreCliente.Name = "NombreCliente";
            // 
            // TipoHabitacion
            // 
            this.TipoHabitacion.DataPropertyName = "DescripcionTipoHabitacion";
            this.TipoHabitacion.HeaderText = "TipoHabitacion";
            this.TipoHabitacion.Name = "TipoHabitacion";
            // 
            // txtbCliente
            // 
            this.txtbCliente.Location = new System.Drawing.Point(296, 136);
            this.txtbCliente.Name = "txtbCliente";
            this.txtbCliente.Size = new System.Drawing.Size(100, 20);
            this.txtbCliente.TabIndex = 1;
            this.txtbCliente.TextChanged += new System.EventHandler(this.txtbCliente_TextChanged);
            // 
            // btnCliente
            // 
            this.btnCliente.Location = new System.Drawing.Point(419, 134);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(75, 23);
            this.btnCliente.TabIndex = 2;
            this.btnCliente.Text = "Buscar";
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Introduce el Codigo del cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(264, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Introducir los rangos de la fecha para la nueva reserva";
            // 
            // dtpFecha1
            // 
            this.dtpFecha1.Location = new System.Drawing.Point(344, 184);
            this.dtpFecha1.Name = "dtpFecha1";
            this.dtpFecha1.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha1.TabIndex = 5;
            // 
            // dtpFecha2
            // 
            this.dtpFecha2.Location = new System.Drawing.Point(550, 184);
            this.dtpFecha2.Name = "dtpFecha2";
            this.dtpFecha2.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(291, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Historial de Clientes\r\n";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormHistorialClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpFecha2);
            this.Controls.Add(this.dtpFecha1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCliente);
            this.Controls.Add(this.txtbCliente);
            this.Controls.Add(this.dtgCliente);
            this.Name = "FormHistorialClientes";
            this.Text = "FormHistorialClientes";
            this.Load += new System.EventHandler(this.FormHistorialClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgCliente;
        private System.Windows.Forms.TextBox txtbCliente;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoReservas;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumHabitacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoHabitacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFecha1;
        private System.Windows.Forms.DateTimePicker dtpFecha2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}