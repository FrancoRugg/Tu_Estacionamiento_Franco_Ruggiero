namespace Tu_Estacionamiento_Franco_Ruggiero
{
    partial class frmHome
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbLugares = new System.Windows.Forms.ToolStripButton();
            this.tsbUsuarios = new System.Windows.Forms.ToolStripButton();
            this.tsbDashboard = new System.Windows.Forms.ToolStripButton();
            this.tsbLogs = new System.Windows.Forms.ToolStripButton();
            this.tsbGarage = new System.Windows.Forms.ToolStripButton();
            this.lblRol = new System.Windows.Forms.Label();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLugares,
            this.tsbUsuarios,
            this.tsbDashboard,
            this.tsbLogs,
            this.tsbGarage});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbLugares
            // 
            this.tsbLugares.Image = global::Tu_Estacionamiento_Franco_Ruggiero.Properties.Resources.edit;
            this.tsbLugares.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLugares.Name = "tsbLugares";
            this.tsbLugares.Size = new System.Drawing.Size(162, 22);
            this.tsbLugares.Text = "Configuracion de lugares";
            this.tsbLugares.ToolTipText = "Configuracion de lugares";
            this.tsbLugares.Click += new System.EventHandler(this.tsbLugares_Click);
            // 
            // tsbUsuarios
            // 
            this.tsbUsuarios.Image = global::Tu_Estacionamiento_Franco_Ruggiero.Properties.Resources._0__5_;
            this.tsbUsuarios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUsuarios.Name = "tsbUsuarios";
            this.tsbUsuarios.Size = new System.Drawing.Size(119, 22);
            this.tsbUsuarios.Text = "ABM de Usuarios";
            this.tsbUsuarios.Click += new System.EventHandler(this.tsbUsuarios_Click);
            // 
            // tsbDashboard
            // 
            this.tsbDashboard.Image = global::Tu_Estacionamiento_Franco_Ruggiero.Properties.Resources.linea;
            this.tsbDashboard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDashboard.Name = "tsbDashboard";
            this.tsbDashboard.Size = new System.Drawing.Size(151, 22);
            this.tsbDashboard.Text = "Dashboard Informativo";
            this.tsbDashboard.Click += new System.EventHandler(this.tsbDashboard_Click);
            // 
            // tsbLogs
            // 
            this.tsbLogs.Image = global::Tu_Estacionamiento_Franco_Ruggiero.Properties.Resources._0__14_;
            this.tsbLogs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLogs.Name = "tsbLogs";
            this.tsbLogs.Size = new System.Drawing.Size(98, 22);
            this.tsbLogs.Text = "Logs de Usos";
            this.tsbLogs.Click += new System.EventHandler(this.tsbLogs_Click);
            // 
            // tsbGarage
            // 
            this.tsbGarage.Image = global::Tu_Estacionamiento_Franco_Ruggiero.Properties.Resources._0__49_;
            this.tsbGarage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGarage.Name = "tsbGarage";
            this.tsbGarage.Size = new System.Drawing.Size(118, 22);
            this.tsbGarage.Text = "Datos del Garage";
            this.tsbGarage.Click += new System.EventHandler(this.tsbGarage_Click);
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblRol.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRol.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRol.Location = new System.Drawing.Point(12, 25);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(26, 16);
            this.lblRol.TabIndex = 0;
            this.lblRol.Text = "Rol:";
            // 
            // pnlContainer
            // 
            this.pnlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContainer.BackColor = System.Drawing.Color.White;
            this.pnlContainer.BackgroundImage = global::Tu_Estacionamiento_Franco_Ruggiero.Properties.Resources.car;
            this.pnlContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlContainer.Controls.Add(this.textBox2);
            this.pnlContainer.Controls.Add(this.pictureBox2);
            this.pnlContainer.Location = new System.Drawing.Point(2, 40);
            this.pnlContainer.Margin = new System.Windows.Forms.Padding(2);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(794, 405);
            this.pnlContainer.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.CausesValidation = false;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox2.Enabled = false;
            this.textBox2.ForeColor = System.Drawing.Color.Gray;
            this.textBox2.Location = new System.Drawing.Point(3, 342);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(791, 60);
            this.textBox2.TabIndex = 12;
            this.textBox2.Text = "\r\n\r\n© 2024 Franco Ruggiero. Todos los derechos de desarrollo del código son propi" +
    "edad de Franco Ruggiero. Todos los derechos reservados.\r\n";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::Tu_Estacionamiento_Franco_Ruggiero.Properties.Resources.OtroLogo;
            this.pictureBox2.Location = new System.Drawing.Point(0, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(794, 41);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.WaitOnLoad = true;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.Turquoise;
            this.lblUser.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblUser.Location = new System.Drawing.Point(95, 24);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(102, 16);
            this.lblUser.TabIndex = 5;
            this.lblUser.Text = "Usuario Logueado:";
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pnlContainer);
            this.Name = "frmHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tu Estacionamiento";
            this.Load += new System.EventHandler(this.frmHome_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbLugares;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.ToolStripButton tsbUsuarios;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ToolStripButton tsbDashboard;
        private System.Windows.Forms.ToolStripButton tsbLogs;
        private System.Windows.Forms.ToolStripButton tsbGarage;
        private System.Windows.Forms.Label lblUser;
    }
}

