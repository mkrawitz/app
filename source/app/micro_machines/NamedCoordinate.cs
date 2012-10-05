using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.micro_machines
{
    public class NamedCoordinate
    {
        public string name { get; set; }
        public double value { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // TODO: write your implementation of Equals() here
            NamedCoordinate otherCoordinate = (NamedCoordinate) obj;
            return (name.Equals(otherCoordinate.name) && (value == otherCoordinate.value);

        }

        public override int GetHashCode()
        {
            return name.GetHashCode() ^ value.GetHashCode();
        }
    }
}
