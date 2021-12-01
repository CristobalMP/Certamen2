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
        [Route("api/v1/Empleado")]
        public Retorno listar(string rut = "")
        {

            Retorno resp = new Retorno();
            try
            {
                List<Empleado> listado = new List<Empleado>();
                EmpleadoEntity clienteData = new EmpleadoEntity();
                DataSet data = rut == "" ? clienteData.listadoEmpleado() : clienteData.listadoEmpleado(rut);
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
                //operacion correcta 
                resp.error = false;
                resp.mensaje = "ok";
                if (listado.Count > 0)
                    resp.data = listado;
                else
                    resp.data = "No se encontro al empleado";
                return resp;
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error:" + e.Message;
                resp.data = null;
                return resp;
            }
        }

        [HttpPost]
        [Route("api/v1/setEmpleado")]
        public Retorno guardar(Empleado empleado)
        {
            Retorno ret = new Retorno();
            try
            {
                EmpleadoEntity emp = new EmpleadoEntity(empleado.rut, empleado.nombre, empleado.apellido, empleado.mail, empleado.telefono);
                int estado = emp.guardar();

                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Cliente ingresado";
                    resp.data = cliente;
                }
                else
                {
                    resp.error = true;
                    resp.mensaje = "No se realizo el ingre";
                    resp.data = null;
                }
                return resp;
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error:" + e.Message;
                resp.data = null;
                return resp;
            }
        }

        [HttpDelete]
        [Route("api/v1/deletecliente")]
        public respuesta eliminar(string rut)
        {
            respuesta resp = new respuesta();
            try
            {

                clienteEntity cli = new clienteEntity();
                cli.Rut = rut;
                int estado = cli.eliminar();

                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Cliente eliminado";
                    resp.data = null;
                }
                else
                {
                    resp.error = true;
                    resp.mensaje = "No se realizo la eliminacion";
                    resp.data = null;
                }
                return resp;
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error:" + e.Message;
                resp.data = null;
                return resp;
            }


        }
}
