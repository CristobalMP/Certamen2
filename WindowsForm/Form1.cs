using EmpleadoLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class Form1 : Form
    {

        EmpleadoEntity empleado = new EmpleadoEntity();


        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           empleado.Rut = txtRut.Text;
           empleado.Nombre = txtNombre.Text;
           empleado.Apellido = txtApellido.Text;
           empleado.Mail = txtMail.Text;
           empleado.Telefono = txtTelefono.Text;

           if (empleado.validarut())
           {
             int x = empleado.guardar(empleado);
             if (x == 1)
             {
                 MessageBox.Show("Empleado Registrado", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             else
             {
                 MessageBox.Show("Error en Registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
           }
           else
           {
             MessageBox.Show("Rut ya registrado. Ingrese Nuevamente al Empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }

                txtRut.Clear();
                txtNombre.Clear();
                txtApellido.Clear();
                txtMail.Clear();
                txtTelefono.Clear();
                txtRut.Focus();
        }
    }
}
