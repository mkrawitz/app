﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.micro_machines
{
    public interface ICanMove
    {
        void moveTo(IKnowMyPosition position);
    }
}
