using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.micro_machines
{
    public class SquareSurface : IKnowMyBoundaries, IKnowWhereMicroObjectsAre
    {
        public SquareSurface(int size)
        {
            this.size = size;
        }

        public bool includes(IKnowMyPosition position)
        {
            IEnumerable<NamedCoordinate> coordinates = position.getPosition();
            if ( coordinates == null)
            {
                return false;
            }
            int dimensions = 0;
            bool xWithinRange = false;
            bool yWithinRange = false;
            foreach (NamedCoordinate coordinate in coordinates)
            {
                dimensions++;
                if ( coordinate.name.Equals("X") && Convert.ToInt32(coordinate.value) < size )
                {
                    xWithinRange = true;
                }
                if (coordinate.name.Equals("Y") && Convert.ToInt32(coordinate.value) < size)
                {
                    yWithinRange = true;
                }
            }
            return (dimensions == 2) && xWithinRange && yWithinRange;
        }

        public Enumerable<ICanBeOnASurface> getMicroObjectsAt(IKnowMyPosition position)
        {
            foreach (ICanBeOnASurface microObject in microObjects)
            {
                microObject.getIdentity()
            }
        }

        private int size;
        private HashSet<ICanBeOnSurface> microObjects = new HashSet<ICanBeOnSurface>();
    }
}
