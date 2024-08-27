namespace Tu_Estacionamiento_Franco_Ruggiero
{
    partial class frmDashboardInfo
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblTotalUsers = new System.Windows.Forms.Label();
            this.lblDisponibles = new System.Windows.Forms.Label();
            this.lblOcupados = new System.Windows.Forms.Label();
            this.crtLugares = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.crtRoles = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.crtLugares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crtRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotalUsers
            // 
            this.lblTotalUsers.AutoSize = true;
            this.lblTotalUsers.BackColor = System.Drawing.Color.Aqua;
            this.lblTotalUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalUsers.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTotalUsers.Location = new System.Drawing.Point(12, 9);
            this.lblTotalUsers.Name = "lblTotalUsers";
            this.lblTotalUsers.Size = new System.Drawing.Size(167, 24);
            this.lblTotalUsers.TabIndex = 0;
            this.lblTotalUsers.Text = "Cantidad Usuarios:";
            // 
            // lblDisponibles
            // 
            this.lblDisponibles.AutoSize = true;
            this.lblDisponibles.BackColor = System.Drawing.Color.Lime;
            this.lblDisponibles.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisponibles.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDisponibles.Location = new System.Drawing.Point(12, 74);
            this.lblDisponibles.Name = "lblDisponibles";
            this.lblDisponibles.Size = new System.Drawing.Size(199, 24);
            this.lblDisponibles.TabIndex = 1;
            this.lblDisponibles.Text = "Cocheras Disponibles:";
            // 
            // lblOcupados
            // 
            this.lblOcupados.AutoSize = true;
            this.lblOcupados.BackColor = System.Drawing.Color.Red;
            this.lblOcupados.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOcupados.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblOcupados.Location = new System.Drawing.Point(12, 133);
            this.lblOcupados.Name = "lblOcupados";
            this.lblOcupados.Size = new System.Drawing.Size(193, 24);
            this.lblOcupados.TabIndex = 2;
            this.lblOcupados.Text = "Cocheras Ocupadas: ";
            // 
            // crtLugares
            // 
            this.crtLugares.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crtLugares.BackColor = System.Drawing.Color.Transparent;
            this.crtLugares.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Top;
            this.crtLugares.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.crtLugares.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.crtLugares.Legends.Add(legend1);
            this.crtLugares.Location = new System.Drawing.Point(26, 36);
            this.crtLugares.Name = "crtLugares";
            series1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.SmallConfetti;
            series1.BackImageTransparentColor = System.Drawing.Color.Transparent;
            series1.BackSecondaryColor = System.Drawing.Color.Transparent;
            series1.BorderColor = System.Drawing.Color.Transparent;
            series1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDotDot;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Color = System.Drawing.Color.Transparent;
            series1.LabelAngle = 1;
            series1.LabelBackColor = System.Drawing.Color.Transparent;
            series1.Legend = "Legend1";
            series1.LegendText = "%";
            series1.Name = "Series1";
            series1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
            series1.ShadowOffset = 1;
            this.crtLugares.Series.Add(series1);
            this.crtLugares.Size = new System.Drawing.Size(762, 167);
            this.crtLugares.TabIndex = 4;
            // 
            // crtRoles
            // 
            this.crtRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crtRoles.BackColor = System.Drawing.Color.Transparent;
            this.crtRoles.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Top;
            this.crtRoles.BorderlineColor = System.Drawing.Color.Transparent;
            this.crtRoles.BorderlineWidth = 3;
            chartArea2.Name = "ChartArea1";
            this.crtRoles.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.crtRoles.Legends.Add(legend2);
            this.crtRoles.Location = new System.Drawing.Point(26, 228);
            this.crtRoles.Name = "crtRoles";
            series2.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.SmallConfetti;
            series2.BackImageTransparentColor = System.Drawing.Color.Transparent;
            series2.BackSecondaryColor = System.Drawing.Color.Transparent;
            series2.BorderColor = System.Drawing.Color.Transparent;
            series2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDotDot;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Color = System.Drawing.Color.Transparent;
            series2.LabelAngle = 1;
            series2.LabelBackColor = System.Drawing.Color.Transparent;
            series2.Legend = "Legend1";
            series2.LegendText = "%";
            series2.Name = "Series1";
            series2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
            series2.ShadowOffset = 1;
            this.crtRoles.Series.Add(series2);
            this.crtRoles.Size = new System.Drawing.Size(738, 220);
            this.crtRoles.TabIndex = 5;
            // 
            // frmDashboardInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Tu_Estacionamiento_Franco_Ruggiero.Properties.Resources.difuminado;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblOcupados);
            this.Controls.Add(this.lblDisponibles);
            this.Controls.Add(this.lblTotalUsers);
            this.Controls.Add(this.crtRoles);
            this.Controls.Add(this.crtLugares);
            this.Name = "frmDashboardInfo";
            this.Text = "frmDashboardInfo";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.frmDashboardInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.crtLugares)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crtRoles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotalUsers;
        private System.Windows.Forms.Label lblDisponibles;
        private System.Windows.Forms.Label lblOcupados;
        private System.Windows.Forms.DataVisualization.Charting.Chart crtLugares;
        private System.Windows.Forms.DataVisualization.Charting.Chart crtRoles;
    }
}