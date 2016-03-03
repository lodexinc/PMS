using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PMS.Common
{
    public interface iBaseEntity
    {
        Guid Id { get; set; }
    }
}
