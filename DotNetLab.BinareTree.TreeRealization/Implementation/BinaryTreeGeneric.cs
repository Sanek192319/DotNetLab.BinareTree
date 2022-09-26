using DotNetLab.BinareTree.TreeRealization.Abstraction.Generic;
using DotNetLab.BinareTree.TreeRealization.Common;
using DotNetLab.BinareTree.TreeRealization.Common.Args;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DotNetLab.BinareTree.TreeRealization.Implementation
{
    public class BinaryTreeGeneric<T> : IBinarTree<T> where T : IComparable<T>
    {
        private int _count = 0;
        private Node<T> _root;

        public event EventHandler<BinaryTreeEventArgs> Notify;

        public int Count
        {
            get => _count;
        }

        public bool IsSynchronized { get; set; }

        public object SyncRoot { get; set;}

        public void CopyTo(Array array, int index)
        {
            List<T> elements = new List<T>();
            elements = MakeArray(_root, elements);
            
            foreach(var element in elements)
            {
                array.SetValue(element, index);
                index++;
            }
        }

        public bool FindElement(T value)
        {
            if (Find(value, _root) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerator GetEnumerator()
        {
           int n = TotalNodes(_root);
            T[] mass = new T[n];
            CopyTo(mass, 0);
            foreach (var item in mass)
            {
                yield return item;
            }
        }
        public int GetTreeDepth()
        {
            return GetTreeDepth(_root);
        }

        public void TraversePreOrder()
        {
            TraversePreOrder(_root);
        }

        public void Insert(T item)
        {
            Node<T> before = null, after = this._root;
            while (after != null)
            {
                before = after;
                if (after.Data.CompareTo(item) > 0)
                {
                    after = after.LeftNode;
                }
                else if (after.Data.CompareTo(item) < 0)
                {
                    after = after.RightNode;
                }
                else
                {
                    return;
                }
            }

            Node<T> newNode = new Node<T>();
            newNode.Data = item;

            if (_root == null)
            {
                _root = newNode;
                return;
            }

            if (before.Data.CompareTo(item) > 0)
            {
                before.LeftNode = newNode;
            }
            else
            {
                before.RightNode = newNode;
            }
        }

        public void Remove(T value)
        {
            _root = Remove(_root, value);
        }

        private int left_height(Node<T> node)
        {
            int ht = 0;
            while (node != null)
            {
                ht++;
                node = node.LeftNode;
            }
            return ht;
        }

        private int right_height(Node<T> node)
        {
            int ht = 0;
            while (node != null)
            {
                ht++;
                node = node.RightNode;
            }
            return ht;
        }

        private int TotalNodes(Node<T> root)
        {
            // Base Case
            if (root == null)
            {
                return 0;
            }
            int lh = left_height(root);
            int rh = right_height(root);
            if (lh == rh)
            {
                return (1 << lh) - 1;
            }
            return 1 + TotalNodes(root.LeftNode)
                   + TotalNodes(root.RightNode);
        }

        private Node<T> Remove(Node<T> parent, T key)
        {

            if (parent == null)
            {
                var args = new BinaryTreeEventArgs()
                {
                    Message = "No such element to remove"
                };
                Notify?.Invoke(this, args);
                return parent;
            }
            if (parent.Data.CompareTo(key) > 0)
            {
                parent.LeftNode = Remove(parent.LeftNode, key);
            }
            
            else if (parent.Data.CompareTo(key) < 0)
            {
                parent.RightNode = Remove(parent.RightNode, key);
            }


            else
            {
                if (parent.LeftNode == null)
                {
                    return parent.RightNode;
                }
                
                else if (parent.RightNode == null)
                {
                    return parent.LeftNode;
                }


                parent.Data = MinValue(parent.RightNode);

                parent.RightNode = Remove(parent.RightNode, parent.Data);
            }

            return parent;
        }

        private List<T> MakeArray(Node<T> parent, List<T> arr)
        {
            if (parent != null)
            {
                arr.Add(parent.Data);
                MakeArray(parent.LeftNode, arr);
                MakeArray(parent.RightNode, arr);
            }
            return arr;
        }

        private T MinValue(Node<T> node)
        {
            var minv = node.Data;

            while (node.LeftNode != null)
            {
                minv = node.LeftNode.Data;
                node = node.LeftNode;
            }

            return minv;
        }
        
        private void TraversePreOrder(Node<T> parent)
        {
            if (parent != null)
            {
                Console.Write(parent.Data + " ");
                TraversePreOrder(parent.LeftNode);
                TraversePreOrder(parent.RightNode);
            }
        }

        private int GetTreeDepth(Node<T> parent)
        {
            return parent == null ? 0 : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;
        }

        private Node<T> Find(T value, Node<T> parent)
        {
            if (parent == null)
            {
                return null;
            }
            
            if (parent.Data.CompareTo(value) == 0)
            {
                return parent;
            }
            
            if (parent.Data.CompareTo(value) > 0)
            {
                return Find(value, parent.LeftNode);
            }
          
            else
            {
                return Find(value, parent.RightNode);
            }
        }
    }

}
