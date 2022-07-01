using CrudApiSomee.Models;
using CrudApiSomee.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudApiSomee.Services
{
    public class MunicipioService
    {
        public List<MunicipiosVm> EstadoList()
        {
            List<MunicipiosVm> list = new List<MunicipiosVm>();
            MunicipiosVm municipio;
            using (DBModel contexto = new DBModel())
            {
                var p1 = contexto.Municipalities;
                foreach (var p in p1)
                {
                    municipio = new MunicipiosVm
                    {
                        id = p.id,
                        name = p.name,
                        estadoM = new EstadoVM()
                        {
                            id = (int)p.id,
                            name = p.Entity1.name,
                        }
                    };
                    list.Add(municipio);
                }
            }
            return list;
        }



    }
}