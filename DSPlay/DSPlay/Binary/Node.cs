using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPlay.Binary
{
    public class Node
    {
        public int key;
        public Node left, right;

        public Node()
        {
            this.key = 0;
            left = right = null;
        }
        public Node(int item)
        {
            this.key = item;
            left = right = null;
        }

    }
}
