using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebHibernate.Models;

namespace WebHibernate.Maps
{
    public class DreamsMap:ClassMap<Dreams>
    {

        public DreamsMap()
        {
            Table("Dreams");
            Schema("Dream");
            Id(x => x.id).Column("id");
            Map(x => x.fecha_inicio).Column("fecha_inicio");
            Map(x => x.fecha_fin).Column("fecha_fin");
            Map(x => x.comentarios).Column("comentarios");
            Map(x => x.usuario_id).Column("usuario_id");
            Map(x => x.tipo_actividad_id).Column("tipo_actividad_id");
            Map(x => x.sql_id).Column("sql_id");
            Map(x => x.automatico).Column("automatico");
            Map(x => x.semaforo_id).Column("semaforo_id");

        }

    }
}