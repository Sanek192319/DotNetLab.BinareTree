using DotNetLab.BinareTree.TreeRealization.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLab.BinareTree.TreeRealization.Abstraction.Generic
{
    public interface IBinarTree<T> : ICollection, IEnumerable
        where T : IComparable<T>
    {
        public void Insert(T item);
        public void Remove(T item);
        public void TraversePreOrder();
        //public void TraverseInOrder(Node<T> parent);
        //public void TraversePostOrder(Node<T> parent);
        public int GetTreeDepth();
        public bool FindElement(T value);


    }
}
