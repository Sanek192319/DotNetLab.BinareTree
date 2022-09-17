using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLab.BinareTree.TreeRealization.Abstraction.Generic
{
    public interface IBinarTree<T> : ICollection, IEnumerable
    {
        public void Insert(T item);
        public void Remove(T item);
    }
}
