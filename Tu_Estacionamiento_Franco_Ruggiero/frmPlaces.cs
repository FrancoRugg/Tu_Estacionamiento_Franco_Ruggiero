using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tu_Estacionamiento.Models;
using Tu_Estacionamiento_Franco_Ruggiero.Handlers;
using Tu_Estacionamiento_Services.Services;

namespace Tu_Estacionamiento_Franco_Ruggiero
{
    public partial class frmPlaces : Form
    {
        public frmPlaces()
        {
            InitializeComponent();
        }
        PlacesService placesService = new PlacesService();
        LoginService loginService = new LoginService();
        LogsService logsService = new LogsService();
        private void frmPlaces_Load(object sender, EventArgs e)
        {
            GetPlaces();
            GetClients();
            Basico();
            for (int i = 1; i <= 12; i++)
            {
                Button btn = (Button)this.Controls.Find($"btnPlace_{i}", true).FirstOrDefault();
                if (btn != null)
                {
                    btn.Click += new EventHandler(btnPlace_Click);
                }
            }
        }

        private void btnPlace_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                string buttonName = clickedButton.Name;
                string placeNumber = buttonName.Split('_')[1];

                GetPlace(placeNumber);
            }
        }
        private void Basico()
        {
            if(DatosGlobales.RolUsuario == "2")
            {
                for (int i = 1; i <= 12; i++)
                {
                    Button btn = (Button)this.Controls.Find($"btnPlace_{i}", true).FirstOrDefault();
                    if (btn != null)
                    {
                        btn.Enabled = false;
                        btn.BackgroundImage = Properties.Resources._0__41_;
                        btn.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                }
            }
        }
        private void GetPlaces()
        {
            List<Places> places = placesService.TraerLugares();

            for (int i = 0; i < places.Count && i < 12; i++)
            {
                TextBox txtPlateNumber = (TextBox)this.Controls.Find($"txtPlate_number{i + 1}", true).FirstOrDefault();
                TextBox txtPay_day = (TextBox)this.Controls.Find($"txtPay_day{i + 1}", true).FirstOrDefault();
                TextBox txtActive = (TextBox)this.Controls.Find($"txtActive{i + 1}", true).FirstOrDefault();
                //Label lblUser = (Label)this.Controls.Find($"lblUser{i + 1}", true).FirstOrDefault();
                if (txtPlateNumber != null)
                {
                    txtPlateNumber.Text = places[i].Plate_number;
                    txtPay_day.Text = places[i].Pay_day;
                    //lblUser.Text = places[1].Usuario;
                    string place = places[i].Plate_number;
                    if(place == "-")
                    {
                        txtActive.Text = "Libre";
                        txtActive.BackColor = Color.GreenYellow;
                    }
                    else
                    {
                        txtActive.Text = "Ocupado";
                        txtActive.BackColor = Color.Red;
                    }
                }
                //MessageBox.Show($"Id: {places[i].Id}, Place Number: {places[i].Place_number}, Client Id: {places[i].Client_id}, Plate Number: {places[i].Plate_number}, Pay Day: {places[i].Pay_day}, Observation: {places[i].Observation}, Active: {places[i].Active}");
            }
        }

        private void GetPlace(string place)
        {
            Places lugar = placesService.TraerLugar(place);
            if (lugar != null)
            {
                pnlPanel.Visible = true;

                TextBox txtPlateNumber = (TextBox)this.Controls.Find($"txtPlate_number{lugar.Place_number}", true).FirstOrDefault();
                if (txtPlateNumber != null)
                {
                    txtPlateNumber.Text = lugar.Plate_number;
                }

                //MessageBox.Show($"Id: {lugar.Id}, Place Number: {lugar.Place_number}, Client Id: {lugar.Client_id}, Plate Number: {lugar.Plate_number}, Pay Day: {lugar.Pay_day}, Observation: {lugar.Observation}, Active: {lugar.Active}");

                txtPlace_number.Text = lugar.Place_number.ToString();
                if(lugar.Active.ToString() == "0")
                {
                    cmbActive.SelectedIndex = 1;
                }
                else
                {
                    cmbActive.SelectedIndex = 0;
                }
                txtPlate_number.Text = lugar.Plate_number;
                txtPay_day.Text = lugar.Pay_day.ToString();
                txtObservation.Text = lugar.Observation.ToString();
                
                cmbClient.SelectedValue = lugar.Client_id;

            }
            else
            {
                MessageBox.Show("No se encontró información para el lugar especificado.");
            }
        }

        private void GetClients()
        {
            //pnlPanel.Visible = true;
            cmbClient.DataSource = loginService.TraerUsuarios();
            cmbClient.DisplayMember = "Usuario";
            cmbClient.ValueMember = "Id";
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            pnlPanel.Visible = false;
            btnAlert.Visible = false;
            btnAlert.Text = string.Empty;
        }

        private void cmdActualizarDatos_Click(object sender, EventArgs e)
        {
            Places places = new Places();

            places.Place_number = Convert.ToInt32(txtPlace_number.Text);
            places.Client_id = Convert.ToInt32(cmbClient.SelectedIndex.ToString());
            places.Plate_number = txtPlate_number.Text;
            places.Pay_day = txtPay_day.Text;
            places.Observation = txtObservation.Text;
            places.Active = cmbActive.Text.ToString();

            DialogResult result = MessageBox.Show("¿Quieres realizar esta acción?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string Create_by = DatosGlobales.UsuarioLogeado;
                string Description = "Actualizó ";

                int Client_id = places.Client_id;
                string To = loginService.GetUserById(Client_id);
                string action = "UPDATE";

                Places OldData = placesService.GetOldChanges(places.Place_number);
                //MessageBox.Show($"Id: {OldData.Id}, Place Number: {OldData.Place_number}, Client Id: {OldData.Client_id}, Plate Number: {OldData.Plate_number}, Pay Day: {OldData.Pay_day}, Observation: {OldData.Observation}, Active: {OldData.Active}");
                if(OldData.Place_number != places.Place_number)
                {
                    Description += $"- Place_number: {OldData.Place_number} a {places.Place_number}";
                }
                if(OldData.Client_id != places.Client_id)
                {
                    Description += $"- Client_id: {OldData.Client_id} a {places.Client_id}";
                }
                if (OldData.Plate_number != places.Plate_number)
                {
                    Description += $"- Plate_number: {OldData.Plate_number} a {places.Plate_number}";
                }
                if (OldData.Pay_day != places.Pay_day)
                {
                    Description += $"- Pay_day: {OldData.Pay_day} a {places.Pay_day}";
                }
                if (OldData.Observation != places.Observation)
                {
                    Description += $"- Observation: {OldData.Observation} a {places.Observation}";
                }
                if (OldData.Active != places.Active)
                {
                    Description += $"- Active: {OldData.Active} a {places.Active}";
                }
                //MessageBox.Show($"{OldData}");
                if(Description.Length > 10)
                {
                    logsService.CreateLog(Create_by, Description, To, action);
                }
                btnAlert.Visible = true;
                if (placesService.EditarLugar(places))
                {
                    btnAlert.Text = "Editado correctamente.";
                    btnAlert.BackColor = Color.ForestGreen;
                }
                else
                {
                    btnAlert.Text = "Ocurrió un problema al editar.";
                    btnAlert.BackColor = Color.Crimson;
                }
            }
            else
            {
                btnAlert.Text = "Acción cancelada.";
                btnAlert.BackColor = Color.Crimson;
                //MessageBox.Show("Acción cancelada.");
            }

            GetPlaces();
        }
    }
}
