using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadoLibrary
{
    public class EmpleadoEntity
    {

        private string rut;
        private string nombre;
        private string apellido;
        private string mail;
        private string telefono;

        Datos data = new Datos();

        public string Rut { get => rut; set => rut = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Telefono { get => telefono; set => telefono = value; }

        public EmpleadoEntity()
        {

        }
        public EmpleadoEntity(string rut, string nombre, string apellido, string mail, string telefono)
        {
            this.rut = rut;
            this.nombre = nombre;
            this.apellido = apellido;
            this.mail = mail;
            this.telefono = telefono;
        }


        public DataSet listadoEmpleado()
        {
            return data.listado("SELECT * FROM EMPLEADO");
        }

        public DataSet listadoEmpleado(string rut)
        {
            return data.listado("SELECT * FROM EMPLEADO WHERE rut = '" + rut + "'");
        }

        public int guardar(EmpleadoEntity empleado)
        {
            return data.ejecutar("Insert into EMPLEADO(rut, nombre, apellido, mail, telefono) values('" + empleado.Rut + "','" + empleado.Nombre + "','" + empleado.Apellido + "','" + empleado.Mail + "','" + empleado.Telefono + "')");
        }
        
        public int guardar()
        {
            return data.ejecutar("Insert into EMPLEADO(rut, nombre, apellido, mail, telefono) values('" + this.rut + "','" + this.nombre + "','" + this.apellido + "','" + this.mail + "','" + this.telefono + "')");
        }
       
        public int eliminar()
        {
            return data.ejecutar("DELETE FROM EMPLEADO WHERE rut = '" + this.rut + "'");
        }

        public bool validarut()
        {
            DataTable dt = new DataTable();
            dt = data.listado("SELECT * FROM EMPLEADO WHERE rut = '" + rut + "'").Tables[0];
            bool respuesta = true;
            if (dt.Rows.Count >= 1)
            {
                respuesta = false;
            }

            return respuesta;
        }

        public int editar(EmpleadoEntity empleado)
        {
            return data.ejecutar("UPDATE EMPLEADO SET nombre= '" + empleado.Nombre + "', apellido='" + empleado.Apellido + "', mail='" + empleado.Mail + "', telefono='" + empleado.Telefono + "' WHERE rut = '" + empleado.Rut + "'");
        }

        public int editar()
        {
            return data.ejecutar("UPDATE EMPLEADO SET nombre= '" + this.nombre + "', apellido='" + this.apellido + "', mail='" + this.mail + "', telefono='" + this.telefono + "' WHERE rut = '" + this.rut + "'");
        }

    }
}