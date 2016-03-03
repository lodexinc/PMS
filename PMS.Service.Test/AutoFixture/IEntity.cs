using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Service.Test
{
    public interface IEntity
    {
        Guid ID { get; }
        string Name { get; }
    }
}
