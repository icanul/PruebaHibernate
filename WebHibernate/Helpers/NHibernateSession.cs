﻿using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using WebHibernate.Maps;

namespace WebHibernate.Helpers
{
    public class NHibernateSession
    {


        private static ISessionFactory sessionFactory = null;
        /*
         * El objeto de tipo ISessionFactory se encargara de realizar
         * la conexión a la Base de Datos.
         */

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory == null)
                    CreateSessionFactory();
                return sessionFactory;
            }
        }

        public static void CreateSessionFactory()
        {
            /**
             * Esta funcion se encargara de crear una conexion de caso
             * de que no se tenga una.
             */
            sessionFactory = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2005
            .ConnectionString(c => c.FromConnectionStringWithKey("logsys_dream"))

            ).Mappings(m => m.FluentMappings
                            .AddFromAssemblyOf<DreamsMap>()
                            ).BuildSessionFactory();
        }

        public static ISession openSession()
        {

            return SessionFactory.OpenSession();

        }


    }
}