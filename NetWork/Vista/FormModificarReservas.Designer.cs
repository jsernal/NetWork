namespace NetWork.Vista
{
    partial class FormModificarReservas
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
            System.Windows.Forms.Button btnGuardarCambios;
            this.label1 = new System.Windows.Forms.Label();
            this.textboxCodigoReserva = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNumHab = new System.Windows.Forms.TextBox();
            this.textBoxNifCliente = new System.Windows.Forms.TextBox();
            this.dateTimePickerFechaReserva = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.EmailUsuario = new System.Windows.Forms.Label();
            btnGuardarCambios = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardarCambios
            // 
            btnGuardarCambios.Location = new System.Drawing.Point(206, 200);
            btnGuardarCambios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btnGuardarCambios.Name = "btnGuardarCambios";
            btnGuardarCambios.Size = new System.Drawing.Size(179, 35);
            btnGuardarCambios.TabIndex = 29;
            btnGuardarCambios.Text = "Guardar cambios";
            btnGuardarCambios.UseVisualStyleBackColor = true;
            btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 32.25F);
            this.label1.Location = new System.Drawing.Point(197, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(407, 51);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gestión de reservas";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textboxCodigoReserva
            // 
            this.textboxCodigoReserva.Location = new System.Drawing.Point(173, 107);
            this.textboxCodigoReserva.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textboxCodigoReserva.Name = "textboxCodigoReserva";
            this.textboxCodigoReserva.Size = new System.Drawing.Size(212, 26);
            this.textboxCodigoReserva.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Código reserva";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(440, 113);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "NIF cliente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 146);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Fecha";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(422, 147);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "Nº habitación";
            // 
            // textBoxNumHab
            // 
            this.textBoxNumHab.Location = new System.Drawing.Point(533, 146);
            this.textBoxNumHab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxNumHab.Name = "textBoxNumHab";
            this.textBoxNumHab.Size = new System.Drawing.Size(212, 26);
            this.textBoxNumHab.TabIndex = 25;
            // 
            // textBoxNifCliente
            // 
            this.textBoxNifCliente.Location = new System.Drawing.Point(533, 110);
            this.textBoxNifCliente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxNifCliente.Name = "textBoxNifCliente";
            this.textBoxNifCliente.Size = new System.Drawing.Size(212, 26);
            this.textBoxNifCliente.TabIndex = 26;
            // 
            // dateTimePickerFechaReserva
            // 
            this.dateTimePickerFechaReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dateTimePickerFechaReserva.Location = new System.Drawing.Point(173, 146);
            this.dateTimePickerFechaReserva.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePickerFechaReserva.Name = "dateTimePickerFechaReserva";
            this.dateTimePickerFechaReserva.Size = new System.Drawing.Size(212, 20);
            this.dateTimePickerFechaReserva.TabIndex = 27;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(43, 258);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(702, 260);
            this.dataGridView1.TabIndex = 28;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(426, 200);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(168, 35);
            this.btnEliminar.TabIndex = 30;
            this.btnEliminar.Text = "Eliminar reserva";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(322, 544);
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
            // FormModificarReservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 609);
            this.Controls.Add(this.EmailUsuario);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(btnGuardarCambios);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimePickerFechaReserva);
            this.Controls.Add(this.textBoxNifCliente);
            this.Controls.Add(this.textBoxNumHab);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textboxCodigoReserva);
            this.Controls.Add(this.label1);
            this.Name = "FormModificarReservas";
            this.Text = "FormModificarReservas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textboxCodigoReserva;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxNumHab;
        private System.Windows.Forms.TextBox textBoxNifCliente;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaReserva;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label EmailUsuario;
    }
}