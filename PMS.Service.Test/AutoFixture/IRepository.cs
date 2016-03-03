using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Service.Test
{
    public abstract class IRepository<TEntity> where TEntity : IEntity
    {
        public ICollection<TEntity> Data;
        public IRepository()
        {
            Data = new List<TEntity>();
        }

        public void Add(TEntity entity)
        {
            Data.Add(entity);
        }

        public TEntity Get()
        {
            return Data.First<TEntity>();
        }

        internal void Exists(Guid iD)
        {
            throw new NotImplementedException();
        }
    }
}
