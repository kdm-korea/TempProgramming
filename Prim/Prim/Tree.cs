using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prim
{
    class Tree
    {
        public int parent;
        public int child;
        public int weight;

        public Tree(int root, int node, int weight) {
            this.parent = root;
            this.child = node;
            this.weight = weight;
        }
    }
}
