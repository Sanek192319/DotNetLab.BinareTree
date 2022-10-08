using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLab.BinareTree.TreeRealization.Common.Args
{
    public class BinaryTreeInsertEventArgs<T> : EventArgs
    {
        public string Message { get; set; }
        public T RemovedItem { get; set; }
    }
}
