using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLab.BinareTree.TreeRealization.Abstraction
{
    public interface IBinarTree : ICollection, IEnumerable
    {
        public void Insert(object data);
        public void Remove(object data);
    }
}
