using System;
using System.Drawing;
using System.Windows.Forms;
using Tu_Estacionamiento.Models.DTO;
using Tu_Estacionamiento_Franco_Ruggiero.Handlers;
using Tu_Estacionamiento_Services.Handlers;
using Tu_Estacionamiento_Services.Services;

namespace Tu_Estacionamiento_Franco_Ruggiero
{
    public partial class frmUserLogin : Form
    {
        public frmUserLogin()
        {
            InitializeComponent();
        }
        LoginService loginService = new LoginService();
        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void btnUserLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "" || txtPassword.Text == "")
            {
                btnAlert.Visible = true;
                btnAlert.Text = "¡Es necesario completar ambos campos para ingresar a este Amazing Spiderman sistema!";
                btnAlert.BackColor = Color.Crimson;
                return;
            }

            UserDTO loginDTO = new UserDTO();
            loginDTO.Usuario = txtUser.Text;
            loginDTO.Password = EncriptHandler.Base64Encode(txtPassword.Text);

            bool result = loginService.Login(loginDTO);

            if (result)
            {

                string UsuarioLogeado = txtUser.Text;
                string GetUserRol = loginService.GetUserRol(UsuarioLogeado);

                DatosGlobales.RolUsuario = GetUserRol;
                DatosGlobales.UsuarioLogeado = UsuarioLogeado;

                frmHome home = new frmHome();
                home.Shown += (s, args) => this.Hide();
                home.FormClosed += (s, args) => this.Close();
                home.ShowDialog();
            }
            else
            {
                btnAlert.Visible = true;
                btnAlert.Text = "Las credenciales ingresadas son incorrectas (* ￣︿￣).- *";
                btnAlert.BackColor = Color.Crimson;
            }
        }

        private void frmUserLogin_Load(object sender, EventArgs e)
        {
            btnAlert.Visible = false;
        }
    }
}
