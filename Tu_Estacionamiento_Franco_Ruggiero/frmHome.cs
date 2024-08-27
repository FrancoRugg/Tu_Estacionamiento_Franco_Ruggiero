using System;
using System.Windows.Forms;
using Tu_Estacionamiento_Franco_Ruggiero.Handlers;
using Tu_Estacionamiento_Services.Services;

namespace Tu_Estacionamiento_Franco_Ruggiero
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        LogsService logsService = new LogsService();

        private void LlenarContenedor(Form form)
        {
            pnlContainer.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(form);
            form.Show();
        }
        private void MostrarVistaSiPermitida(string vistaNombre, Form form)
        {
            //if (DatosGlobales.VistasPermitidas.Contains(vistaNombre))
            //{
                LlenarContenedor(form);
            //}
            //else
            //{
            //    MessageBox.Show("No tienes permiso para acceder a esta vista.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private void tsbLugares_Click(object sender, EventArgs e)
        {
            string Create_by = DatosGlobales.UsuarioLogeado;
            string Description = "Ingresó a la Configuración de Lugares.";
            string To = "-";
            string action = "CLICK";
            logsService.CreateLog(Create_by,Description,To,action);
            MostrarVistaSiPermitida("frmPlaces", new frmPlaces());
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            //DatosGlobales.RolUsuario = "2";
            //DatosGlobales.UsuarioLogeado = "Franco_Ruggiero";

            //MessageBox.Show("Rol: " + DatosGlobales.RolUsuario);
            lblUser.Text = $"Usuario Logueado: {DatosGlobales.UsuarioLogeado}";
            if (DatosGlobales.RolUsuario == "1")
            {
                lblRol.Text = "Rol: Admin";
            }
            else if(DatosGlobales.RolUsuario == "2")
            {
                lblRol.Text = "Rol: Basico";
            }
        }

        private void tsbUsuarios_Click(object sender, EventArgs e)
        {
            string Create_by = DatosGlobales.UsuarioLogeado;
            string Description = "Ingresó al ABM de Usuarios.";
            string To = "-";
            string action = "CLICK";
            logsService.CreateLog(Create_by, Description, To, action);
            MostrarVistaSiPermitida("frmUsers", new frmUsers());
        }

        private void tsbDashboard_Click(object sender, EventArgs e)
        {
            string Create_by = DatosGlobales.UsuarioLogeado;
            string Description = "Ingresó al Dashboard Informativo.";
            string To = "-";
            string action = "CLICK";
            logsService.CreateLog(Create_by, Description, To, action);
            MostrarVistaSiPermitida("frmDashboardInfo", new frmDashboardInfo());
        }
        //tsbLogs.Visible = = false;
        private void tsbLogs_Click(object sender, EventArgs e)
        {
            if (DatosGlobales.RolUsuario == "2")
            {
                MessageBox.Show("No tienes permiso para acceder a esta vista.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string Create_by = DatosGlobales.UsuarioLogeado;
                string Description = "Ingresó al módulo de Logs.";
                string To = "-";
                string action = "CLICK";
                logsService.CreateLog(Create_by, Description, To, action);
                MostrarVistaSiPermitida("frmLogs", new frmLogs());
            }
        }

        private void tsbGarage_Click(object sender, EventArgs e)
        {
            if (DatosGlobales.RolUsuario == "2")
            {
                MessageBox.Show("No tienes permiso para acceder a esta vista.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string Create_by = DatosGlobales.UsuarioLogeado;
                string Description = "Ingresó al módulo de Datos del Garage.";
                string To = "-";
                string action = "CLICK";
                logsService.CreateLog(Create_by, Description, To, action);
                MostrarVistaSiPermitida("frmGarage", new frmGarage());
            }
        }
    }
}
