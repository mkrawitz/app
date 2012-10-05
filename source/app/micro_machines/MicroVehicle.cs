using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.micro_machines
{
    public class MicroVehicle : ICanBeOnASurface, ICanMove
    {
        private string identity;
        private string formattedName;
        private IEnumerable<NamedCoordinate> coordinates;
        
        public MicroVehicle(String identity, String formattedName, IKnowMyPosition position)
        {
            this.identity = identity;
            this.formattedName = formattedName;
            this.coordinates = position.getPosition();
        }

        public string getIdentity()
        {
            return this.identity;
        }

        public string getFormattedName()
        {
            return this.formattedName;
        }

        public IKnowMyPosition getPosition()
        {
            return new Position(this.coordinates);
        }

        public void moveTo(IKnowMyPosition position)
        {
            this.coordinates = position.getPosition();
        }
}
