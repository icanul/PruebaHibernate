using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebHibernate.Controladores;
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
            int[] ids = new int[lista.Count];
            String[] comentarios = new string[lista.Count];
            int[] usuario_id = new int[lista.Count];
            int[] sql_id = new int[lista.Count];
            int[] tipo_actividad_id = new int[lista.Count];
            byte[] automatico = new byte[lista.Count];
            int[] semaforo = new int[lista.Count];
            int a = 0;

            for (int i = 0; i < lista.Count; i++)
            {

                ids[i] = lista[i].id;
                dateTimei[i] = lista[i].fecha_inicio;
                dateTimef[i] = lista[i].fecha_fin;
                comentarios[i] = lista[i].comentarios;
                usuario_id[i] = lista[i].usuario_id;
                tipo_actividad_id[i] = lista[i].tipo_actividad_id;
                sql_id[i] = lista[i].sql_id;
                automatico[i] = lista[i].automatico;
                semaforo[i] = lista[i].semaforo_id;
            }

            if (actividad == 4) {

               
                for(int i = 0; i<dateTimei.Length;i++)
                {

                    if (dateTimei[i] < fecha_inicio && dateTimef[i]>fecha_inicio)
                    {

                        Consultas.updateData(ids, dateTimei, fecha_inicio,i);

                    }
                    a = 1;

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