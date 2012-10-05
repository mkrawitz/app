using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.micro_machines
{
    public interface IKnowWhereMicroObjectsAre
    {
        public Enumerable<ICanBeOnASurface> getMicroObjectsAt(IKnowMyPosition position);
    }
}
