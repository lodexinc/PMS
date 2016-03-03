using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Service.Test.Moq
{
    public abstract class ContextSpecification
    {
        protected ContextSpecification()
        {
            EstablishContext();
            Because();
        }

        public abstract void EstablishContext();
        public abstract void Because();
    }
}
