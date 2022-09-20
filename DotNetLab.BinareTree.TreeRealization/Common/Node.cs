using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLab.BinareTree.TreeRealization.Common
{
    public class  Node<T> where T : IComparable<T>
    {
        public Node<T> LeftNode { get; set; }
        public Node<T> RightNode { get; set; }
        public Node<T> Root { get; set; }
        public T Data { get; set; }

    }
}
