using CrudApiSomee.Models;
using System.Collections.Generic;

namespace CrudApiSomee.Services
{
    public class MunicipalityService
    {
        public List<Municipality> EntityList()
        {
            List<Municipality> list = new List<Municipality>();
            Municipality municipality;
            using (DBModel context = new DBModel())
            {
                var municipalityContext = context.Municipalities;
                foreach (var municipalityItem in municipalityContext)
                {
                    municipality = new Municipality
                    {
                        id = municipalityItem.id,
                        name = municipalityItem.name,
                        entity = municipalityItem.entity,
                    };
                    list.Add(municipality);
                }
            }
            return list;
        }



    }
}