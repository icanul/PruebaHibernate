using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebHibernate.Models;

namespace WebHibernate.Help
{
    public class Validar
    {

        public Validar()
        {

        }

        public static int getFlag(IList<Dreams> lista, int actividad, DateTime fecha_inicio)
        {

            DateTime[] dateTimei = new DateTime[lista.Count];
            DateTime[] dateTimef = new DateTime[lista.Count];
            int a = 0;

            for (int i = 0; i < lista.Count; i++)
            {

                dateTimei[i] = lista[i].fecha_inicio;
                dateTimef[i] = lista[i].fecha_fin;

            }

            if (actividad == 4) {

               
                for(int i = 0; i<dateTimei.Length;i++)
                {

                    if (dateTimei[i] < fecha_inicio && dateTimef[i]>fecha_inicio)
                    {

                        a = 4;

                    } else {

                        a = 5;

                    }

                }
                //a = 1; el que ejecuta el insert

            } else
            {

                a = 2;

            }


            return a;
        }

    }
}