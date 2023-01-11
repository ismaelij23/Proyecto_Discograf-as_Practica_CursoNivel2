namespace Practica_1_BD
{
    partial class FormDiscos
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvDiscos = new System.Windows.Forms.DataGridView();
            this.pictureBoxDisco = new System.Windows.Forms.PictureBox();
            this.lblDiscos = new System.Windows.Forms.Label();
            this.dgvEstilos = new System.Windows.Forms.DataGridView();
            this.lblEstilos = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminarFisico = new System.Windows.Forms.Button();
            this.btnEliminacionLogica = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstilos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDiscos
            // 
            this.dgvDiscos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiscos.Location = new System.Drawing.Point(167, 56);
            this.dgvDiscos.Name = "dgvDiscos";
            this.dgvDiscos.Size = new System.Drawing.Size(536, 209);
            this.dgvDiscos.TabIndex = 0;
            this.dgvDiscos.SelectionChanged += new System.EventHandler(this.dgvDiscos_SelectionChanged);
            // 
            // pictureBoxDisco
            // 
            this.pictureBoxDisco.Location = new System.Drawing.Point(732, 56);
            this.pictureBoxDisco.Name = "pictureBoxDisco";
            this.pictureBoxDisco.Size = new System.Drawing.Size(220, 166);
            this.pictureBoxDisco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxDisco.TabIndex = 1;
            this.pictureBoxDisco.TabStop = false;
            // 
            // lblDiscos
            // 
            this.lblDiscos.AutoSize = true;
            this.lblDiscos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscos.Location = new System.Drawing.Point(355, 19);
            this.lblDiscos.Name = "lblDiscos";
            this.lblDiscos.Size = new System.Drawing.Size(66, 24);
            this.lblDiscos.TabIndex = 2;
            this.lblDiscos.Text = "Discos";
            // 
            // dgvEstilos
            // 
            this.dgvEstilos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstilos.Location = new System.Drawing.Point(732, 288);
            this.dgvEstilos.Name = "dgvEstilos";
            this.dgvEstilos.Size = new System.Drawing.Size(237, 150);
            this.dgvEstilos.TabIndex = 3;
            // 
            // lblEstilos
            // 
            this.lblEstilos.AutoSize = true;
            this.lblEstilos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstilos.Location = new System.Drawing.Point(823, 261);
            this.lblEstilos.Name = "lblEstilos";
            this.lblEstilos.Size = new System.Drawing.Size(64, 24);
            this.lblEstilos.TabIndex = 4;
            this.lblEstilos.Text = "Estilos";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(60, 56);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(101, 33);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(60, 95);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(101, 34);
            this.btnModificar.TabIndex = 6;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminarFisico
            // 
            this.btnEliminarFisico.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarFisico.Location = new System.Drawing.Point(60, 135);
            this.btnEliminarFisico.Name = "btnEliminarFisico";
            this.btnEliminarFisico.Size = new System.Drawing.Size(101, 62);
            this.btnEliminarFisico.TabIndex = 7;
            this.btnEliminarFisico.Text = "Eliminación Física";
            this.btnEliminarFisico.UseVisualStyleBackColor = true;
            this.btnEliminarFisico.Click += new System.EventHandler(this.btnEliminarFisico_Click);
            // 
            // btnEliminacionLogica
            // 
            this.btnEliminacionLogica.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminacionLogica.Location = new System.Drawing.Point(60, 203);
            this.btnEliminacionLogica.Name = "btnEliminacionLogica";
            this.btnEliminacionLogica.Size = new System.Drawing.Size(101, 62);
            this.btnEliminacionLogica.TabIndex = 8;
            this.btnEliminacionLogica.Text = "Eliminación Lógica";
            this.btnEliminacionLogica.UseVisualStyleBackColor = true;
            this.btnEliminacionLogica.Click += new System.EventHandler(this.btnEliminacionLogica_Click);
            // 
            // FormDiscos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 450);
            this.Controls.Add(this.btnEliminacionLogica);
            this.Controls.Add(this.btnEliminarFisico);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lblEstilos);
            this.Controls.Add(this.dgvEstilos);
            this.Controls.Add(this.lblDiscos);
            this.Controls.Add(this.pictureBoxDisco);
            this.Controls.Add(this.dgvDiscos);
            this.Name = "FormDiscos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Discos";
            this.Load += new System.EventHandler(this.FormDiscos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstilos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDiscos;
        private System.Windows.Forms.PictureBox pictureBoxDisco;
        private System.Windows.Forms.Label lblDiscos;
        private System.Windows.Forms.DataGridView dgvEstilos;
        private System.Windows.Forms.Label lblEstilos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminarFisico;
        private System.Windows.Forms.Button btnEliminacionLogica;
    }
}

