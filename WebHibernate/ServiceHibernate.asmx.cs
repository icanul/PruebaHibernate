using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using WebHibernate.Controladores;
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
        public string Insertardatos(int id, DateTime fecha_inicio,DateTime fecha_fin,string comentarios,int usuario_id,int tipo_actividad_id,int sql_id,byte automatico,int semaforo_id)
        {

            Insertar x = new Insertar();
            x.setDreams(id,fecha_inicio,fecha_fin,comentarios,usuario_id,tipo_actividad_id,sql_id, automatico,semaforo_id);
            return "t";

        }


    }
}
