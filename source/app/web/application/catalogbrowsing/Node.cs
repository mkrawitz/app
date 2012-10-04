using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.web.application.catalogbrowsing
{
    public class Node
    {
        private IEnumerable<Node> children = new List<Node>();

        public IEnumerable<Node> GetChildren()
        {
            return children;
        }

        public Node parent { get; set; }
    }
}
