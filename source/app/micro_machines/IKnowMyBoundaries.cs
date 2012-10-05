using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.micro_machines
{
    public interface IKnowMyBoundaries
    {
        public bool includes(IKnowMyPosition position)
    }
}
