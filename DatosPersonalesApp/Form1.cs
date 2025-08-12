using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatosPersonalesApp
{
    public partial class Formulario : Form
    {
        public Formulario()
        {
            //Constructor del formulario
            InitializeComponent();
        }

        //Evento del boton aceptar para validar los campos y mostrar los datos ingresados
        private void button1_Click(object sender, EventArgs e)
        {
            // Convertir todo a mayúsculas
            txtApellido.Text = txtApellido.Text.ToUpper();
            txtNombre.Text = txtNombre.Text.ToUpper();
            txtEdad.Text = txtEdad.Text.ToUpper();
            txtDireccion.Text = txtDireccion.Text.ToUpper();

            // Limitar caracteres (esto también deberías establecer en el diseñador si querés)
            txtApellido.MaxLength = 30;
            txtNombre.MaxLength = 30;
            txtEdad.MaxLength = 3;
            txtDireccion.MaxLength = 50;

            // Limpiar colores previos
            txtApellido.BackColor = Color.White;
            txtNombre.BackColor = Color.White;
            txtEdad.BackColor = Color.White;
            txtDireccion.BackColor = Color.White;

            bool hayError = false;

            // Validar campos vacíos
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                txtApellido.BackColor = Color.Red;
                hayError = true;
            }
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                txtNombre.BackColor = Color.Red;
                hayError = true;
            }
            if (string.IsNullOrWhiteSpace(txtEdad.Text))
            {
                txtEdad.BackColor = Color.Red;
                hayError = true;
            }
            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                txtDireccion.BackColor = Color.Red;
                hayError = true;
            }

            // Validar que Edad tenga solo números
            if (!int.TryParse(txtEdad.Text, out int edad))
            {
                txtEdad.BackColor = Color.Red;
                hayError = true;
            }

            // Si hay error, no continuar
            if (hayError)
            {
                MessageBox.Show("Por favor complete correctamente todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Mostrar datos en el TextBox multilinea
            txtResultado.Text = $"Apellido y Nombre: {txtApellido.Text} {txtNombre.Text}\r\n" +
                                $"Edad: {txtEdad.Text}\r\n" +
                                $"Dirección: {txtDireccion.Text}";
        }

        //Evento del boton cancelar para salir de la aplicación
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Evento para validar que solo se ingresen números en el campo Edad
        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla
            }
        }

        private void Formulario_Load(object sender, EventArgs e)
        {

        }
    }
}
