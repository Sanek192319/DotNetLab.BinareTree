using DotNetLab.BinareTree.TreeRealization.Implementation;
using DotNetLab.BinareTree.TreeRealization.Common;
using System;

namespace DotNetLab.BinareTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTreeGeneric<int> binaryTree = new BinaryTreeGeneric<int>();
            binaryTree.Insert(1);
            binaryTree.Insert(3);
            binaryTree.Insert(4);
            binaryTree.Insert(2);

            //binaryTree.Insert(2);
            //binaryTree.Insert(7);
            //binaryTree.Insert(3);
            //binaryTree.Insert(10);
            //binaryTree.Insert(5);
            //binaryTree.Insert(8);

            Node<int> node = binaryTree.Find(5);
            int depth = binaryTree.GetTreeDepth();

            Console.WriteLine("PreOrder Traversal:");
            binaryTree.TraversePreOrder(binaryTree._root);
            Console.WriteLine();
            binaryTree.Remove(3);
            //binaryTree.Remove(7);
            //binaryTree.Remove(8);

            Console.WriteLine("PreOrder Traversal After Removing Operation:");
            binaryTree.TraversePreOrder(binaryTree._root);
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
