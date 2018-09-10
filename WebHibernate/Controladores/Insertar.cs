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

        public  void  setDreams(int id, DateTime fecha_inicio, DateTime fecha_fin, string comentarios, int usuario_id, int tipo_actividad_id, int sql_id, byte automatico, int semaforo_id)
        {
          
            using (ISession session = NHibernateSession.openSession())
            {
                try
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        Dreams ob = new Dreams(){ id=id,
                                                  fecha_inicio =fecha_inicio,
                                                  fecha_fin =fecha_fin,
                                                  comentarios =comentarios,
                                                  usuario_id =usuario_id
                                                  ,tipo_actividad_id=tipo_actividad_id
                                                  ,sql_id=sql_id
                                                  ,automatico=automatico
                                                  ,semaforo_id=semaforo_id}
                       ;



                        var lista = session.Save(ob);
                       
                    }
                    // getSumaDeDiferencias(dreams);
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.ToString());
                 
                    //errorLog.Error("Error:\n" + e);
                }
                finally
                {
                    session.Close();
                }

            }
        }

        internal static object setDreams()
        {
            throw new NotImplementedException();
        }
    }
}
