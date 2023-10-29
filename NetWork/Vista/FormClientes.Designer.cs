namespace NetWork.Vista
{
    partial class FormClientes
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textdni = new System.Windows.Forms.TextBox();
            this.textnombre = new System.Windows.Forms.TextBox();
            this.texttelefono = new System.Windows.Forms.TextBox();
            this.textemail = new System.Windows.Forms.TextBox();
            this.btnregistrar = new System.Windows.Forms.Button();
            this.combtipo = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnxml = new System.Windows.Forms.Button();
            this.btnabrirXml = new System.Windows.Forms.Button();
            this.ColumnIdCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTelef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "DNI: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Telefono: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tipo Cliente: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(194, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Email: ";
            // 
            // textdni
            // 
            this.textdni.Location = new System.Drawing.Point(306, 93);
            this.textdni.Name = "textdni";
            this.textdni.Size = new System.Drawing.Size(100, 20);
            this.textdni.TabIndex = 5;
            // 
            // textnombre
            // 
            this.textnombre.Location = new System.Drawing.Point(306, 119);
            this.textnombre.Name = "textnombre";
            this.textnombre.Size = new System.Drawing.Size(100, 20);
            this.textnombre.TabIndex = 6;
            // 
            // texttelefono
            // 
            this.texttelefono.Location = new System.Drawing.Point(306, 145);
            this.texttelefono.Name = "texttelefono";
            this.texttelefono.Size = new System.Drawing.Size(100, 20);
            this.texttelefono.TabIndex = 7;
            // 
            // textemail
            // 
            this.textemail.Location = new System.Drawing.Point(306, 197);
            this.textemail.Name = "textemail";
            this.textemail.Size = new System.Drawing.Size(100, 20);
            this.textemail.TabIndex = 9;
            // 
            // btnregistrar
            // 
            this.btnregistrar.Location = new System.Drawing.Point(306, 255);
            this.btnregistrar.Name = "btnregistrar";
            this.btnregistrar.Size = new System.Drawing.Size(75, 23);
            this.btnregistrar.TabIndex = 10;
            this.btnregistrar.Text = "Registrar";
            this.btnregistrar.UseVisualStyleBackColor = true;
            this.btnregistrar.Click += new System.EventHandler(this.btnregistrar_Click);
            // 
            // combtipo
            // 
            this.combtipo.FormattingEnabled = true;
            this.combtipo.Location = new System.Drawing.Point(306, 170);
            this.combtipo.Name = "combtipo";
            this.combtipo.Size = new System.Drawing.Size(100, 21);
            this.combtipo.TabIndex = 11;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIdCliente,
            this.ColumnDNI,
            this.ColumnNombre,
            this.ColumnTelef,
            this.ColumnTipo,
            this.ColumnEmail});
            this.dataGridView1.Location = new System.Drawing.Point(138, 349);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(544, 154);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnxml
            // 
            this.btnxml.Location = new System.Drawing.Point(108, 531);
            this.btnxml.Name = "btnxml";
            this.btnxml.Size = new System.Drawing.Size(109, 23);
            this.btnxml.TabIndex = 13;
            this.btnxml.Text = "Generar XML";
            this.btnxml.UseVisualStyleBackColor = true;
            this.btnxml.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnabrirXml
            // 
            this.btnabrirXml.Location = new System.Drawing.Point(556, 531);
            this.btnabrirXml.Name = "btnabrirXml";
            this.btnabrirXml.Size = new System.Drawing.Size(75, 23);
            this.btnabrirXml.TabIndex = 14;
            this.btnabrirXml.Text = "Abrir XML";
            this.btnabrirXml.UseVisualStyleBackColor = true;
            this.btnabrirXml.Click += new System.EventHandler(this.btnabrirXml_Click);
            // 
            // ColumnIdCliente
            // 
            this.ColumnIdCliente.HeaderText = "IdClientes";
            this.ColumnIdCliente.Name = "ColumnIdCliente";
            // 
            // ColumnDNI
            // 
            this.ColumnDNI.HeaderText = "DNI";
            this.ColumnDNI.Name = "ColumnDNI";
            // 
            // ColumnNombre
            // 
            this.ColumnNombre.HeaderText = "Nombre";
            this.ColumnNombre.Name = "ColumnNombre";
            // 
            // ColumnTelef
            // 
            this.ColumnTelef.HeaderText = "Telefono";
            this.ColumnTelef.Name = "ColumnTelef";
            // 
            // ColumnTipo
            // 
            this.ColumnTipo.HeaderText = "TipoCliente";
            this.ColumnTipo.Name = "ColumnTipo";
            // 
            // ColumnEmail
            // 
            this.ColumnEmail.HeaderText = "Email";
            this.ColumnEmail.Name = "ColumnEmail";
            // 
            // FormClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 616);
            this.Controls.Add(this.btnabrirXml);
            this.Controls.Add(this.btnxml);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.combtipo);
            this.Controls.Add(this.btnregistrar);
            this.Controls.Add(this.textemail);
            this.Controls.Add(this.texttelefono);
            this.Controls.Add(this.textnombre);
            this.Controls.Add(this.textdni);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormClientes";
            this.Load += new System.EventHandler(this.FormClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textdni;
        private System.Windows.Forms.TextBox textnombre;
        private System.Windows.Forms.TextBox texttelefono;
        private System.Windows.Forms.TextBox textemail;
        private System.Windows.Forms.Button btnregistrar;
        private System.Windows.Forms.ComboBox combtipo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnxml;
        private System.Windows.Forms.Button btnabrirXml;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIdCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTelef;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEmail;
    }
}