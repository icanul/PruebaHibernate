﻿using NHibernate;
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

        public static Boolean updateData(int[] aidi,DateTime[] dateTimei, DateTime date, int posicion)
        {
            using (ISession session = ConsultaSession.openSession())
            {
                try
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        try
                        {
                            var lista = session.QueryOver<Fechas>().Where(x => x.id == aidi[posicion]).SingleOrDefault();

                            var r = session.Load<Fechas>(aidi[posicion]);

                            r.fecha_fin = date;

                            session.Update(r);

                            transaction.Commit();

                        }

                        catch (Exception i)
                        {

                            Console.WriteLine("erroe", i);
                        }
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
            return true;
        }

        public static IList<Dreams> GetDatos(int aidi_user)
        {
            using (ISession session = NHibernateSession.openSession())
            {
                try
                {
                    using (ITransaction transaction = session.BeginTransaction())
                        return NewMethod(aidi_user, session);
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

        private static IList<Dreams> NewMethod(int aidi_user, ISession session)
        {
            DateTime dia;
            var diaanterior = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd HH:mm:ss");

            dia = DateTime.Parse(diaanterior);

            var lista = session.QueryOver<Dreams>().Where(x => x.usuario_id == aidi_user).And(x => x.fecha_inicio > dia).List().ToList();
            return lista;
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