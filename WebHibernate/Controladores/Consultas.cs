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


    }
}