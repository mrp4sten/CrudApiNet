using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudApiSomee.ViewModels
{
    public class MunicipiosVm
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual EstadoVM estadoM { get; set; }
    }
}