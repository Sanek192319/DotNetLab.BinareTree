//using DotNetLab.BinareTree.TreeRealization.Abstraction;
//using DotNetLab.BinareTree.TreeRealization.Common;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DotNetLab.BinareTree.TreeRealization.Implementation
//{
//    public class BinaryTree : IBinarTree
//    {
//        private Node<object> _root;
//        private int _count = 0;
//        public int Count => throw new NotImplementedException();

//        public bool IsSynchronized => throw new NotImplementedException();

//        public object SyncRoot => throw new NotImplementedException();

//        public void CopyTo(Array array, int index)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerator GetEnumerator()
//        {
//            throw new NotImplementedException();
//        }

//        public void Insert(object data)
//        {
//            //Node<object> newNode = new Node<object>()
//            //{
//            //    Data = data
//            //};

//            //if (_root == null)
//            //{
//            //    _root = newNode;

//            //}
//            //_count++;
//            Node<object> before = null, after = this.Root;

//            while (after != null)
//            {
//                before = after;
//                if (data < after.Data) //Is new node in left tree? 
//                    after = after.LeftNode;
//                else if (data > after.Data) //Is new node in right tree?
//                    after = after.RightNode;
//                else
//                {
//                    //Exist same value
//                    return false;
//                }
//            }

//            Node newNode = new Node();
//            newNode.Data = value;

//            if (this.Root == null)//Tree ise empty
//                this.Root = newNode;
//            else
//            {
//                if (data < before.Data)
//                    before.LeftNode = newNode;
//                else
//                    before.RightNode = newNode;
//            }

//            return true;
//        }

//        public void Remove(object data)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
