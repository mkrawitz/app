using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.micro_machines
{
    public interface IKnowMyPosition
    {
        IEnumerable<NamedCoordinate> getPosition();
    }
}
