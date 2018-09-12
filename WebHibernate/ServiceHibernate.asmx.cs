using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using WebHibernate.Controladores;
using WebHibernate.Help;
using WebHibernate.Models;

namespace WebHibernate
{
    /// <summary>
    /// Descripción breve de ServiceHibernate
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ServiceHibernate : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ConsultarId(int id)
        {
           
            var z=Consultas.GetDreams(id);

            return new JavaScriptSerializer().Serialize(z);

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ConsultarUsuario(int id)
        {

            var z = Consultas.GetDatos(id);

            return new JavaScriptSerializer().Serialize(z);

        }

        [WebMethod]
        public String Insertardatos(DateTime fecha_inicio,DateTime fecha_fin,string comentarios,int usuario_id,int tipo_actividad_id,byte automatico,int semaforo_id)
        {

            IList<Dreams> z = Consultas.GetDatos(usuario_id);

            int tipo = Validar.getFlag(z, tipo_actividad_id, fecha_inicio);

            if (tipo == 1)
            {
                try
                {

                    Consultas.setDreams(fecha_inicio, fecha_fin, comentarios, usuario_id, tipo_actividad_id, automatico, semaforo_id);
                    tipo = 1;
                }
                catch (Exception) { tipo = 3; }
            }

            String respuesta = "";

            if(tipo == 1)
            {
                respuesta = "Se agrego correctamente el registro";
            } if (tipo == 2)
            {
                respuesta = "El evento no es inactivo";
            } if (tipo == 3)
            {
                respuesta = "No se pudo acceder a la base de datos";
            } if (tipo == 4)
            {
                respuesta = "Si es diferente que todos";
            } if (tipo == 5)
            {
                respuesta = "Hay que actualizar un dato";
            }

            return respuesta;

            }


    }
}
