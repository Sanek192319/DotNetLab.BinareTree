using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoBogus;
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
            List<int> collection = new List<int>(){1,2,3};

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
            List<int> collection = new List<int>(){5,4,10};

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
            var test = binaryTree.GetEnumerator();
            //assert
            test.Should().Be(new [] { 5, 4, 10 });



        }
    }
}