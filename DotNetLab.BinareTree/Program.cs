using DotNetLab.BinareTree.TreeRealization.Implementation;
using DotNetLab.BinareTree.TreeRealization.Common;
using System;
using DotNetLab.BinareTree.TreeRealization.Common.Args;

namespace DotNetLab.BinareTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTreeGeneric<int> binaryTree = new BinaryTreeGeneric<int>();
            //binaryTree.Insert(1);
            //binaryTree.Insert(3);
            //binaryTree.Insert(4);
            //binaryTree.Insert(2);
            void DisplayMessage(object sender, BinaryTreeEventArgs e) => Console.WriteLine(e.Message);
            
            binaryTree.Notify += DisplayMessage;

           // EventHandler<BinaryTreeEventArgs> handler = (sender, e) => Console.WriteLine(e.Message);

           // binaryTree.Notify += handler;


            binaryTree.Insert(2);
            binaryTree.Insert(7);
            binaryTree.Insert(3);
            binaryTree.Insert(10);
            binaryTree.Insert(5);
            binaryTree.Insert(4);
            binaryTree.Insert(1);
            //binaryTree.Insert(1);

            bool node = binaryTree.FindElement(5);
            if(node)
            {
                Console.WriteLine("Element found");
            }
            else
            {
                Console.WriteLine("No such element");
            }
            int depth = binaryTree.GetTreeDepth();

            Console.WriteLine("PreOrder Traversal:");
            binaryTree.TraversePreOrder();
            Console.WriteLine();

            Console.WriteLine("Output tree");
            foreach (var item in binaryTree)
            {
                Console.WriteLine(item.ToString());
            }
            binaryTree.Remove(144);
            //binaryTree.Remove(7);
            //binaryTree.Remove(8);
            int _depth = binaryTree.GetTreeDepth();
            Console.WriteLine("depth: ");
            Console.WriteLine(_depth);
            Console.WriteLine("PreOrder Traversal After Removing Operation:");
            binaryTree.TraversePreOrder();
            Console.WriteLine();

            Console.ReadLine();
        }
         
    }
}
