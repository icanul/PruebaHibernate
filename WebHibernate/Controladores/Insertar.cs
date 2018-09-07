using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebHibernate.Helpers;
using WebHibernate.Models;

namespace WebHibernate.Controladores
{
    public class Insertar
    {
        public Insertar()
        {

        }

        public static Dreams setDreams(int id, DateTime fecha_inicio, DateTime fecha_fin, string comentarios, int usuario_id, int tipo_actividad_id, int sql_id, byte automatico, int semaforo_id)
        {
            IList<Dreams> listadreams;
            using (ISession session = NHibernateSession.openSession())
            {
                try
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {

                     var  lista = 
                        return lista.List<Dreams>;
                    }
                    // getSumaDeDiferencias(dreams);
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.ToString());
                    return null;
                    //errorLog.Error("Error:\n" + e);
                }
                finally
                {
                    session.Close();
                }

            }
        }
    }
}
