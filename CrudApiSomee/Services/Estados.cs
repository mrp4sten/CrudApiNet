using CrudApiSomee.Models;
using CrudApiSomee.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudApiSomee.Services
{
    public class Estados
    {
        public List<EstadoVM> EstadoList()
        {
            List<EstadoVM> list = new List<EstadoVM>();
            EstadoVM estado;
            using (DBModel contexto = new DBModel() )
            {
                var p1 = contexto.Entities;
                foreach (var p in p1)
                {
                    estado = new EstadoVM
                    {
                        id = p.id,
                        name = p.name,
          
                    };
                    list.Add(estado);
                }
            }
            return list;
        }
    }
}