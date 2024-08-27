using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tu_Estacionamiento.Models;
using Tu_Estacionamiento_Franco_Ruggiero.Handlers;
using Tu_Estacionamiento_Services.Handlers;
using Tu_Estacionamiento_Services.Services;

namespace Tu_Estacionamiento_Franco_Ruggiero
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }
        LoginService loginService = new LoginService();
        RolesService rolesService = new RolesService();
        LogsService logsService = new LogsService();
        public string id = string.Empty;

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" || txtNombre.Text == "" || txtApellido.Text == "" || txtDni.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Es obligatorio completar todos los campos.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Login login = new Login();
            login.Usuario = txtUsuario.Text;
            login.Password = txtPassword.Text;
            login.Nombre = txtNombre.Text;
            login.Apellido = txtApellido.Text;
            login.Dni = txtDni.Text;
            login.Rol = Convert.ToInt32(cbmRoles.Text);
            login.Active = cmbActive.Text;

            bool respuesta = loginService.CrearUsuario(login);

            if (respuesta)
            {
                string Create_by = DatosGlobales.UsuarioLogeado;
                string Description = "Agregó un nuevo Usuario.";
                string To = login.Usuario;
                string action = "INSERT";
                logsService.CreateLog(Create_by, Description, To, action);
                btnAlert.Text = "Usuario creado correctamente.";
                btnAlert.BackColor = Color.ForestGreen;
                GetUsuarios();
                CleanInputs();
            }
            else
            {
                btnAlert.Text = "Ocurrio un problema al crear el usuario.";
                btnAlert.BackColor = Color.Crimson;
            }

            btnAlert.Visible = true;
        }
        private void GetUsuarios()
        {
            grdDatos.DataSource = loginService.TraerUsuarios();
        }
        private void Basico()
        {
            if (DatosGlobales.RolUsuario == "2")
            {
                btnCrearUsuario.Visible = false;
                btnEditarUsuario.Visible = false;
                grdDatos.Columns["edit"].Visible = false;
                grdDatos.Columns["delete"].Visible = false;
                btnAlert.Text = "Su Rol no permite Crear/Editar usuarios.";
                btnAlert.BackColor = Color.ForestGreen;
                btnAlert.Visible= true;

            }
        }
        private void GetRoles()
        {
            DataTable roles = rolesService.GetRoles();
            cbmRoles.DataSource = roles;
            cbmRoles.DisplayMember = "Id";
            cbmRoles.ValueMember = "Id";
        }
        private void frmUsers_Load(object sender, EventArgs e)
        {
            GetRoles();
            GetUsuarios();
            Basico();
        }

        private void CleanInputs()
        {
            txtUsuario.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtDni.Text = string.Empty;
        }
        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Id = Convert.ToInt32(id);
            login.Usuario = txtUsuario.Text;
            login.Password = EncriptHandler.Base64Encode(txtPassword.Text);
            login.Nombre = txtNombre.Text;
            login.Apellido = txtApellido.Text;
            login.Dni = txtDni.Text;
            login.Active = cmbActive.Text;
            login.Rol = Convert.ToInt32(cbmRoles.Text);

            DialogResult dialogo = MessageBox.Show("¿Desea editar el usuario?", "Importante", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dialogo == DialogResult.OK)
            {
                string Create_by = DatosGlobales.UsuarioLogeado;
                string Description = "Actualizó ";

                string To = login.Usuario;
                string action = "UPDATE";

                Login OldData = loginService.GetUserInfo(id);
                //MessageBox.Show($"-Id: {OldData.Id}, -Usuario: {OldData.Usuario}, -Nombre: {OldData.Nombre},
                //-Apellido: {OldData.Apellido}, -DNI: {OldData.Dni}, -Rol: {OldData.Rol}, -Active: {OldData.Active}.");
                if (OldData.Usuario != login.Usuario)
                {
                    Description += $"- Usuario: {OldData.Usuario} a {login.Usuario}";
                }
                if (OldData.Nombre != login.Nombre)
                {
                    Description += $"- Nombre: {OldData.Nombre} a {login.Nombre}";
                }
                if (OldData.Apellido != login.Apellido)
                {
                    Description += $"- Apellido: {OldData.Apellido} a {login.Apellido}";
                }
                if (OldData.Password != login.Password)
                {
                    Description += $"- Password: {OldData.Password} a {login.Password}";
                }
                if (OldData.Dni != login.Dni)
                {
                    Description += $"- Dni: {OldData.Dni} a {login.Dni}";
                }
                if (OldData.Rol != login.Rol)
                {
                    Description += $"- Rol: {OldData.Rol} a {login.Rol}";
                }
                if (OldData.Active != login.Active)
                {
                    Description += $"- Active: {OldData.Active} a {login.Active}";
                }
                //MessageBox.Show($"{OldData}");
                if (Description.Length > 10)
                {
                    logsService.CreateLog(Create_by, Description, To, action);
                }
                if (loginService.EditarUsuario(login))
                {
                    btnAlert.Text = "Usuario Editado correctamente.";
                    btnAlert.BackColor = Color.ForestGreen;
                    CleanInputs();
                }
                else
                {
                    btnAlert.Text = "Ocurrió un problema al editar el usuario.";
                    btnAlert.BackColor = Color.Crimson;
                }
            }
            btnEditarUsuario.Visible = false;
            btnCrearUsuario.Visible = true;
            GetUsuarios();
        }

        private void grdDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = grdDatos.Rows[e.RowIndex];

            id = row.Cells["Id"].Value.ToString();

            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                //MessageBox.Show("ID seleccionado: " + id.ToString());
                btnEditarUsuario.Visible = true;
                btnCrearUsuario.Visible = false;
                txtUsuario.Text = row.Cells["Usuario"].Value.ToString();
                txtPassword.Text = EncriptHandler.Base64Decode(row.Cells["Password"].Value.ToString());
                txtDni.Text = row.Cells["Dni"].Value.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtApellido.Text = row.Cells["Apellido"].Value.ToString();
                cbmRoles.Text = row.Cells["Rol"].Value.ToString();
                cmbActive.Text = row.Cells["Active"].Value.ToString();

            }

            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                DialogResult dialogo = MessageBox.Show("¿Desea eliminar el usuario?", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                if (dialogo == DialogResult.OK)
                {
                    string Create_by = DatosGlobales.UsuarioLogeado;
                    Login OldData = loginService.GetUserInfo(id);
                    string Description = $"Eliminó al Usuario: -Id: {OldData.Id}, -Usuario: {OldData.Usuario}, -Nombre: {OldData.Nombre}, -Apellido: {OldData.Apellido}, -Password: {OldData.Password}, -DNI: {OldData.Dni}, -Rol: {OldData.Rol}, -Active: {OldData.Active}.";
                    string To = OldData.Usuario;
                    string action = "DELETE";
                    logsService.CreateLog(Create_by, Description, To, action);
                    if (loginService.EliminarUsuario(id))
                    {
                        btnAlert.Text = "Usuario eliminado correctamente.";
                        btnAlert.BackColor = Color.ForestGreen;
                    }
                    else
                    {
                        btnAlert.Text = "Ocurrió un problema al eliminar el usuario.";
                        btnAlert.BackColor = Color.Crimson;
                    }
                    GetUsuarios();
                }

            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            lblChangeUser.Text = txtUsuario.Text;
            if (txtUsuario.Text != "")
            {
                lblChangeUser.Text = txtUsuario.Text;
                lblChangeUser.BackColor = Color.WhiteSmoke;
                lblChangeUser.ForeColor = Color.SkyBlue;
                lblChangeUser.Font = new Font(lblChangeUser.Font.FontFamily, 12, FontStyle.Underline);
            }
            else
            {
                lblChangeUser.BackColor = Color.Empty;
                lblChangeUser.ForeColor = Color.Black;
                lblChangeUser.Text = "";
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            lblChangeName.Text = txtNombre.Text;
            if (txtNombre.Text != "")
            {
                lblChangeName.Text = txtNombre.Text;
                lblChangeName.BackColor = Color.WhiteSmoke;
                lblChangeName.ForeColor = Color.SkyBlue;
                lblChangeName.Font = new Font(lblChangeName.Font.FontFamily, 12, FontStyle.Underline);
            }
            else
            {
                lblChangeName.BackColor = Color.Empty;
                lblChangeName.ForeColor = Color.Black;
                lblChangeName.Text = "";
            }
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            lblChangeSurname.Text = txtApellido.Text;
            if (txtUsuario.Text != "")
            {
                lblChangeSurname.Text = txtApellido.Text;
                lblChangeSurname.BackColor = Color.WhiteSmoke;
                lblChangeSurname.ForeColor = Color.SkyBlue;
                lblChangeSurname.Font = new Font(lblChangeSurname.Font.FontFamily, 12, FontStyle.Underline);
            }
            else
            {
                lblChangeSurname.BackColor = Color.Empty;
                lblChangeSurname.ForeColor = Color.Black;
                lblChangeSurname.Text = "";
            }
        }
    }
}
