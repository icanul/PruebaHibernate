using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebHibernate.Helpers;
using WebHibernate.Models;

namespace WebHibernate.Controladores
{
    public class Consultas
    {

        public Consultas()
        {

        }

        public static Dreams GetDreams(int aidi)
        {
            using (ISession session = NHibernateSession.openSession())
            {
                try
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        var lista = session.QueryOver<Dreams>().Where(x => x.id == aidi).List().ToList().First();
                        return lista;
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

        public static void setDreams(DateTime fecha_inicio, DateTime fecha_fin, string comentarios, int usuario_id, int tipo_actividad_id, byte automatico, int semaforo_id)
        {

            using (ISession session = NHibernateSession.openSession())
            {
                try
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        Dreams ob = new Dreams();

                        ob.fecha_inicio = fecha_inicio;
                        ob.fecha_fin = fecha_fin;
                        ob.comentarios = comentarios;
                        ob.usuario_id = usuario_id;
                        ob.tipo_actividad_id = tipo_actividad_id;
                        ob.automatico = automatico;
                        ob.semaforo_id = semaforo_id;

                        session.Save(ob);
                        transaction.Commit();
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

    }
}