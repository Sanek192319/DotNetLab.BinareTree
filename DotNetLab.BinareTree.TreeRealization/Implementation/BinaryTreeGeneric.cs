using DotNetLab.BinareTree.TreeRealization.Abstraction.Generic;
using DotNetLab.BinareTree.TreeRealization.Common;
using System;
using System.Collections;

namespace DotNetLab.BinareTree.TreeRealization.Implementation
{
    public class BinaryTreeGeneric<T> : IBinarTree<T> where T : IComparable<T>
    {
        public Node<T> _root;
        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

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

        public void Insert(T item)
        {
            Node<T> before = null, after = this._root;

            while (after != null)
            {
                before = after;
                if (after.Data.CompareTo(item) > 0)
                    after = after.LeftNode;
                else if (after.Data.CompareTo(item) < 0)
                    after = after.RightNode;
                else
                {
                    return;
                }
            }

            Node<T> newNode = new Node<T>();
            newNode.Data = item;

            if (this._root == null)
            {
                this._root = newNode;
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

            return;
        }


        public void Remove(T value)
        {
            _root = Remove(this._root, value);
        }
        private Node<T> Remove(Node<T> parent, T key)
        {
            if (parent == null) return parent;

            if (parent.Data.CompareTo(key) > 0) parent.LeftNode = Remove(parent.LeftNode, key);
            else if (parent.Data.CompareTo(key) < 0)
                parent.RightNode = Remove(parent.RightNode, key);


            else
            {
                if (parent.LeftNode == null)
                    return parent.RightNode;
                else if (parent.RightNode == null)
                    return parent.LeftNode;


                parent.Data = MinValue(parent.RightNode);


                parent.RightNode = Remove(parent.RightNode, parent.Data);
            }

            return parent;
        }
        private Node<T> Find(T value, Node<T> parent)
        {
            if (parent == null)
            {
                return null;
            }

            if (parent.Data.CompareTo(value) == 0) return parent;
            if (parent.Data.CompareTo(value) > 0)
                return Find(value, parent.LeftNode);
            else
                return Find(value, parent.RightNode);
        }
        public Node<T> Find(T value)
        {
            return this.Find(value, this._root);
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
        public int GetTreeDepth()
        {
            return this.GetTreeDepth(this._root);
        }

        private int GetTreeDepth(Node<T> parent)
        {
            return parent == null ? 0 : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;
        }

        public void TraversePreOrder(Node<T> parent)
        {
            if (parent != null)
            {
                Console.Write(parent.Data + " ");
                TraversePreOrder(parent.LeftNode);
                TraversePreOrder(parent.RightNode);
            }
        }

        public void TraverseInOrder(Node<T> parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.LeftNode);
                Console.Write(parent.Data + " ");
                TraverseInOrder(parent.RightNode);
            }
        }

        public void TraversePostOrder(Node<T> parent)
        {
            if (parent != null)
            {
                TraversePostOrder(parent.LeftNode);
                TraversePostOrder(parent.RightNode);
                Console.Write(parent.Data + " ");
            }
        }


    }
}
