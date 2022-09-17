using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLab.BinareTree.TreeRealization.Common
{
    internal class  Node<T>
    {
        public Node<T> LeftNode { get; set; }
        public Node<T> RightNode { get; set; }
        public Node<T> ParentNode { get; set; }
        public T Data { get; set; }

    }
}
