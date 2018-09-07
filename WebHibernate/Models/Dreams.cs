using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebHibernate.Models
{
    public class Dreams
    {
        public virtual int id { get; set; }
        public virtual DateTime fecha_inicio { get; set; }
        public virtual DateTime fecha_fin { get; set; }
        public virtual String comentarios { get; set; }
        public virtual int usuario_id { get; set; }
        public virtual int tipo_actividad_id { get; set; }
        public virtual int sql_id { get; set; }
        public virtual Byte automatico { get; set; }
        public virtual int semaforo_id { get; set; }

    }
}