using DotNetLab.BinareTree.TreeRealization.Abstraction;
using DotNetLab.BinareTree.TreeRealization.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLab.BinareTree.TreeRealization.Implementation
{
    public class BinaryTree : IBinarTree
    {
        Node<object> root;
        public int Count => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Insert(object data)
        {
            throw new NotImplementedException();
        }

        public void Remove(object data)
        {
            throw new NotImplementedException();
        }
    }
}
