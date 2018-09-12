using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebHibernate.Models
{
    public class Fechas
    {
        public virtual int id { get; set; }
        public virtual DateTime fecha_fin { get; set; }
    }
}