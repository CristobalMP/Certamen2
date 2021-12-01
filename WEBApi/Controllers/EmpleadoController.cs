using EmpleadoLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBApi.Models;

namespace WEBApi.Controllers
{
    public class EmpleadoController : ApiController
    {
        [HttpGet]
        [Route("api/v1/ListarEmpleado")]
        public Retorno listar(string rut = "")
        {

            Retorno ret = new Retorno();
            try
            {
                List<Empleado> listado = new List<Empleado>();
                EmpleadoEntity EmpleadoData = new EmpleadoEntity();
                DataSet data = rut == "" ? EmpleadoData.listadoEmpleado() : EmpleadoData.listadoEmpleado(rut);
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    Empleado item = new Empleado();
                    item.rut = data.Tables[0].Rows[i].ItemArray[0].ToString();
                    item.nombre = data.Tables[0].Rows[i].ItemArray[1].ToString();
                    item.apellido = data.Tables[0].Rows[i].ItemArray[2].ToString();
                    item.mail = data.Tables[0].Rows[i].ItemArray[3].ToString();
                    item.telefono = data.Tables[0].Rows[i].ItemArray[4].ToString();
                    listado.Add(item);
                }

                ret.error = false;
                ret.mensaje = "ok";
                if (listado.Count > 0)
                    ret.data = listado;
                else
                    ret.data = "No se encontro al empleado";
                return ret;
            }
            catch (Exception e)
            {
                ret.error = true;
                ret.mensaje = "Error:" + e.Message;
                ret.data = null;
                return ret;
            }
        }

        [HttpPost]
        [Route("api/v1/GuardarEmpleado")]
        public Retorno guardar(Empleado empleado)
        {
            Retorno ret = new Retorno();
            try
            {
                EmpleadoEntity emp = new EmpleadoEntity(empleado.rut, empleado.nombre, empleado.apellido, empleado.mail, empleado.telefono);
                int estado = emp.guardar();

                if (estado == 1)
                {
                    ret.error = false;
                    ret.mensaje = "Empleado Registrado";
                    ret.data = empleado;
                }
                else
                {
                    ret.error = true;
                    ret.mensaje = "No se registro el Empleado";
                    ret.data = null;
                }
                return ret;
            }
            catch (Exception e)
            {
                ret.error = true;
                ret.mensaje = "Error:" + e.Message;
                ret.data = null;
                return ret;
            }
        }

        [HttpDelete]
        [Route("api/v1/DeleteEmpleado")]
        public Retorno eliminar(string rut)
        {
            Retorno ret = new Retorno();
            try
            {

                EmpleadoEntity emp = new EmpleadoEntity();
                emp.Rut = rut;
                int estado = emp.eliminar();

                if (estado == 1)
                {
                    ret.error = false;
                    ret.mensaje = "Empleado eliminado";
                    ret.data = null;
                }
                else
                {
                    ret.error = true;
                    ret.mensaje = "No se concluyo la eliminación";
                    ret.data = null;
                }
                return ret;
            }
            catch (Exception e)
            {
                ret.error = true;
                ret.mensaje = "Error:" + e.Message;
                ret.data = null;
                return ret;
            }


        }
    }
}

