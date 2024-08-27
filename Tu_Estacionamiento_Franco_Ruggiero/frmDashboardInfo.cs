using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Tu_Estacionamiento_Services.Services;

namespace Tu_Estacionamiento_Franco_Ruggiero
{
    public partial class frmDashboardInfo : Form
    {
        public frmDashboardInfo()
        {
            InitializeComponent();
        }
        LoginService loginService = new LoginService();
        PlacesService placesService = new PlacesService();
        private void frmDashboardInfo_Load(object sender, EventArgs e)
        {
            CountUser();
            CountDisp();
            CountOcup();
            ConfigurarGraficoTorta();
            ConfigurarGraficoRoles();
        }
        private void CountUser()
        {
            string total = loginService.CountUsers();
            lblTotalUsers.Text = $"Cantidad Usuarios: {total}";
        }
        private void CountDisp()
        {
            string total = placesService.CountLibre();
            lblDisponibles.Text = $"Cocheras Disponibles: {total}/12";
        }
        private void CountOcup()
        {
            string total = placesService.CountOcupados();
            lblOcupados.Text = $"Cocheras Ocupadas: {total}/12";
        }
        private void ConfigurarGraficoTorta()
        {
            crtLugares.Series.Clear();
            crtLugares.Titles.Clear();

            Series series = new Series
            {
                Name = "series1",
                IsVisibleInLegend = true,
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = false
            };
            string totalDisp = placesService.CountLibre();
            string totalOcup = placesService.CountOcupados();

            //series.Points.AddXY("Disponibles ", totalDisp + "%"); // 30%
            //series.Points.AddXY("Ocupadas ", totalOcup + "%"); // 20%
            series.Points.Add(new DataPoint(0, totalOcup) { LegendText = $"Ocupadas {totalOcup}"});
            series.Points.Add(new DataPoint(0, totalDisp) { LegendText = $"Disponibles {totalDisp}"});

            //foreach (DataPoint point in series.Points)
            //{
            //    point.Label = "";
            //}
            crtLugares.Series.Add(series);

            //crtLugares.Palette = ChartColorPalette.BrightPastel;

            foreach (DataPoint point in series.Points)
            {
                point.BorderDashStyle = ChartDashStyle.DashDotDot;
                point.BorderWidth = 20;
                point.BackHatchStyle = ChartHatchStyle.SmallConfetti;
                point.LabelBackColor = Color.White;
            }
            Title chartTitle = new Title
            {
                Text = "Gráfico de Lugares Porcentual",
                BackColor = Color.White, 
                ForeColor = Color.Black, 
                Font = new Font("Arial", 14, FontStyle.Regular), 
                Alignment = ContentAlignment.MiddleCenter 
            };
            crtLugares.Titles.Add(chartTitle);

            crtLugares.Legends[0].Enabled = true;

            series.Label = "#PERCENT{P0}"; // Formato de porcentaje
            //series.Label = "";
            series.LegendText = "#VALX"; // Mostrar el nombre de la categoría en la leyenda
        }
        private void ConfigurarGraficoRoles()
        {
            crtRoles.Series.Clear();
            crtRoles.Titles.Clear();

            Series series = new Series
            {
                Name = "series1",
                IsVisibleInLegend = true,
                ChartType = SeriesChartType.Pyramid,
                IsValueShownAsLabel = false
            };

            string CountAdmin = loginService.CountAdmin();
            string CountBasic = loginService.CountBasic();

            series.Points.Add(new DataPoint(0, CountAdmin) { LegendText = $"Admin {CountAdmin}" });
            series.Points.Add(new DataPoint(0, CountBasic) { LegendText = $"Basico {CountBasic}" });

            //foreach (DataPoint point in series.Points)
            //{
            //    point.Label = "";
            //}
            crtRoles.Series.Add(series);

            crtRoles.Palette = ChartColorPalette.SeaGreen;

            foreach (DataPoint point in series.Points)
            {
                point.BorderDashStyle = ChartDashStyle.DashDotDot;
                point.BorderWidth = 20;
                point.BackHatchStyle = ChartHatchStyle.SolidDiamond;
            }
            Title chartTitle = new Title
            {
                Text = "Gráfico de Roles Porcentual",
                BackColor = Color.White, 
                ForeColor = Color.Black, 
                Font = new Font("Arial", 14, FontStyle.Regular), 
                Alignment = ContentAlignment.MiddleCenter 
            };
            crtRoles.Titles.Add(chartTitle);

            crtRoles.Legends[0].Enabled = true;

            series.Label = "#PERCENT{P0}";
            //series.Label = "";
            series.LegendText = "#VALX"; // Mostrar el nombre de la categoría en la leyenda
        }
    }
}
