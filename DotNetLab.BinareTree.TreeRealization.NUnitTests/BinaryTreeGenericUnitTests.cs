using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoBogus;
using DotNetLab.BinareTree.TreeRealization.Common.Args;
using DotNetLab.BinareTree.TreeRealization.Implementation;
using FluentAssertions;
using NUnit.Framework;

namespace DotNetLab.BinareTree.TreeRealization.NUnitTests
{
    public class BinaryTreeGenericUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InsertingInBinaryTree_Value_ReturnsTrue()
        {
            //arrange
            var binaryTree = new BinaryTreeGeneric<int>();
            var itemToInser = AutoFaker.Generate<int>();

            //act
            binaryTree.Insert(itemToInser);

            //assert
            binaryTree.FindElement(itemToInser).Should().BeTrue();

        }

        [Test]
        public void InsertingInAlreadyExistingBinaryTree_AlreadyExistingValue_ReturnsTrue()
        {
            //arrange
            var binaryTree = new BinaryTreeGeneric<int>();
            var itemToInser = new List<int>() { 3, 1 };

            //act
            CreateTree(binaryTree,itemToInser);
            binaryTree.Insert(1);

            //assert
            binaryTree.FindElement(1).Should().BeTrue();

        }

        [Test]
        public void RemovingFromBinaryTree_Value_ReturnsFalse()
        {
            //arrange
            var binaryTree = new BinaryTreeGeneric<int>();
            var itemToInser = AutoFaker.Generate<int>();
            binaryTree.Insert(itemToInser);

            //act

            binaryTree.Remove(itemToInser);
            //assert
            binaryTree.FindElement(itemToInser).Should().BeFalse();
        }

        [Test]
        public void RemovingFromBinaryTree_ValueNotFromTree_ReturnsTrue()
        {
            //arrange
            var binaryTree = new BinaryTreeGeneric<int>();
            var itemToInser = 1;
            binaryTree.Insert(itemToInser);

            //act

            binaryTree.Remove(2);

            //assert
            binaryTree.FindElement(1).Should().BeTrue();
        }

        [Test]
        public void RemovingFromBinaryTreeRoot_3elementsInTree_ReturnsTrue()
        {
            //arrange
            var binaryTree = new BinaryTreeGeneric<int>();
            var items = new List<int>() { 3, 2, 4 };
            CreateTree(binaryTree, items);

            //act

            binaryTree.Remove(3);

            //assert
            binaryTree.FindElement(3).Should().BeFalse();
        }

        [Test]
        public void RemovingFromBinaryTreeRoot_3elementsInTreeRight_ReturnsTrue()
        {
            //arrange
            var binaryTree = new BinaryTreeGeneric<int>();
            var items = new List<int>() { 1, 2, 3 };
            CreateTree(binaryTree, items);

            //act

            binaryTree.Remove(2);

            //assert
            binaryTree.FindElement(2).Should().BeFalse();
        }

        [Test]
        public void RemovingFromBinaryTreeRoot_3elementsInTreeLeft_ReturnsTrue()
        {
            //arrange
            var binaryTree = new BinaryTreeGeneric<int>();
            var items = new List<int>() { 3,2,1};
            CreateTree(binaryTree, items);

            //act

            binaryTree.Remove(2);

            //assert
            binaryTree.FindElement(2).Should().BeFalse();
        }
        private void CreateTree(BinaryTreeGeneric<int> Btree, List<int> list)
        {
            foreach (var item in list)
            {
                Btree.Insert(item);
            }
        }

        [Test]
        public void FindElement_FirstElementOfCollection_ReturnTrue()
        {
            //arrange
            var binaryTree = new BinaryTreeGeneric<int>();
            List<int> collection = AutoFaker.Generate<List<int>>();

            CreateTree(binaryTree, collection);

            //act
            bool result = binaryTree.FindElement(collection[0]);
            //assert
            result.Should().BeTrue();
        }

        [Test]
        public void FindElement_RemovedElementFromTree_ReturnFalse()
        {
            //arrange
            var binaryTree = new BinaryTreeGeneric<int>();
            List<int> collection = AutoFaker.Generate<List<int>>();

            CreateTree(binaryTree, collection);

            //act
            binaryTree.Remove(collection[0]);
            bool result = binaryTree.FindElement(collection[0]);

            //assert
            result.Should().BeFalse();
        }

        [Test]
        public void GetTreeDepth_AddThreeElems_Return3()
        {
            //arrange
            var binaryTree = new BinaryTreeGeneric<int>();
            List<int> collection = new List<int>() { 1, 2, 3 };

            CreateTree(binaryTree, collection);

            //act
            int depth = binaryTree.GetTreeDepth();
            //assert
            depth.Should().Be(3);
        }
        [Test]
        public void GetTreeDepth_NoElements_Return0()
        {
            //arrange
            var binaryTree = new BinaryTreeGeneric<int>();
            List<int> collection = new List<int>();

            CreateTree(binaryTree, collection);

            //act
            int depth = binaryTree.GetTreeDepth();
            //assert
            depth.Should().Be(0);
        }
        [Test]
        public void GetTreeDepth_NoElements_Return2()
        {
            //arrange
            var binaryTree = new BinaryTreeGeneric<int>();
            List<int> collection = new List<int>() { 5, 4, 10 };

            CreateTree(binaryTree, collection);

            //act
            int depth = binaryTree.GetTreeDepth();
            //assert
            depth.Should().Be(2);
        }

        [Test]
        public void CopyTo_Array3Elems_ReturnTrue()
        {
            //arrange
            var binaryTree = new BinaryTreeGeneric<int>();
            List<int> collection = new List<int>() { 5, 4, 10 };

            CreateTree(binaryTree, collection);

            //act
            int[] array = new int[3];
            binaryTree.CopyTo(array, 0);

            //assert
            array.Count().Should().Be(3);
        }

        [Test]
        public void GetEnumerator_Array3Elems_ReturnTrue()
        {
            //arrange

            var binaryTree = new BinaryTreeGeneric<int>();
            List<int> collection = new List<int>() { 5, 4, 10 };
            CreateTree(binaryTree, collection);

            //act

            var Array = new int[3];
            int i = 0;
            foreach (var item in binaryTree)
            {
                Array[i] = (int)item;
                i++;
            }

            //assert


            Array.Should().Equal(new[] { 5, 4, 10 });

        }


        [Test]
        public void NotifyRemoveFailed_ElementNotFromArray_ReturnTrue()
        {
            //arrange
            var binaryTree = new BinaryTreeGeneric<int>();
            List<int> collection = new List<int>() { 5, 4, 10 };

            CreateTree(binaryTree, collection);
            var wascalled = false;
            //act
            binaryTree.NotifyRemoveFailed += delegate (object sender, BinaryTreeEventArgs e) { wascalled = true; };
            binaryTree.Remove(11);
            //assert
            wascalled.Should().Be(true);

        }

        [Test]
        public void InsertNotify_Element11_ReturnTrue()
        {
            //arrange
            var binaryTree = new BinaryTreeGeneric<int>();
            List<int> collection = new List<int>() { 5, 4, 10 };

            CreateTree(binaryTree, collection);
            var wascalled = false;
            //act
            binaryTree.InsertNotify += delegate (object sender, BinaryTreeInsertEventArgs<int> e) { wascalled = true; };
            binaryTree.Insert(11);
            //assert
            wascalled.Should().Be(true);

        }


        [Test]
        public void RemoveNotify_ElementNotFromArray_ReturnTrue()
        {
            //arrange
            var binaryTree = new BinaryTreeGeneric<int>();
            List<int> collection = new List<int>() { 5, 4, 10 };

            CreateTree(binaryTree, collection);
            var wascalled = false;
            //act
            binaryTree.RemoveNotify += delegate (object sender, BinaryTreeRemoveEventArgs<int> e) { wascalled = true; };
            binaryTree.Remove(5);
            //assert
            wascalled.Should().Be(true);

        }


        [Test]
        public void AnyTree_ReturnFalse()
        {
            var tree = new BinaryTreeGeneric<int>();

            tree.IsSynchronized.Should().BeFalse();
        }



            [Test]
            public void AnyTree_ReturnNull()
            {
            var tree = new BinaryTreeGeneric<int>();

            tree.SyncRoot.Should().BeNull();
            }

            [Test]
            public void AnyTreeCount_ReturnNull()
            {
                var tree = new BinaryTreeGeneric<int>();

                tree.Count.Should().Be(0);
            }

    }
}