using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadoLibrary
{
    class EmpleadoEntity
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
        public EmpleadoEntity(string rut, string nombre, string apellido, string telefono)
        {
            this.rut = rut;
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
        }


        public DataSet listadoClientes()
        {
            return data.listado("SELECT * FROM CLIENTES");
        }

        public DataSet listadoClientes(string rut)
        {
            return data.listado("SELECT * FROM CLIENTES WHERE RUT = '" + rut + "'");
        }

        public int guardar(clienteEntity cliente)
        {
            return data.ejecutar("Insert into CLIENTES(rut, nombre, apellido, telefono) values('" + cliente.Rut + "','" + cliente.Nombre + "','" + cliente.Apellido + "','" + cliente.Telefono + "')");
        }
        public int guardar()
        {
            return data.ejecutar("Insert into CLIENTES(rut, nombre, apellido, telefono) values('" + this.rut + "','" + this.nombre + "','" + this.apellido + "','" + this.telefono + "')");
        }
        public int eliminar()
        {
            return data.ejecutar("DELETE FROM CLIENTES WHERE RUT= '" + this.rut + "'");
        }
    }
}