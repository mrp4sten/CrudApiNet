using CrudApiSomee.Models;
using System.Collections.Generic;

namespace CrudApiSomee.Services
{
    public class EntityService
    {
        public List<Entity> EntityList()
        {
            List<Entity> list = new List<Entity>();
            Entity entity;
            using (DBModel context = new DBModel() )
            {
                var entityContext = context.Entities;
                foreach (var entityItem in entityContext)
                {
                    entity = new Entity
                    {
                        id = entityItem.id,
                        name = entityItem.name,
          
                    };
                    list.Add(entity);
                }
            }
            return list;
        }
    }
}