﻿using NUnit.Framework;

namespace BinarySearchTree.Tests
{
    [TestFixture]
    public class BinaryTreeTests
    {
        private BinaryTree _binaryTree;

        [SetUp]
        public void Setup()
        {
            _binaryTree = new BinaryTree(12);
        }

        [Test]
        public void CreateEmptyTree()
        {
            Assert.IsNotNull(_binaryTree.Root);
            Assert.IsNull(_binaryTree.Root.LeftNode);
            Assert.IsNull(_binaryTree.Root.RightNode);
            Assert.AreEqual(12, _binaryTree.Root.Value);
        }

        [Test]
        public void InsertOneLeftNode()
        {
            Assert.IsTrue(_binaryTree.InsertNode(5, _binaryTree.Root));
            Assert.AreEqual(5, _binaryTree.Root.LeftNode.Value);
        }

        [Test]
        public void InsertMultipleLeftNodes()
        {
            Assert.IsTrue(_binaryTree.InsertNode(9, _binaryTree.Root));
            Assert.IsTrue(_binaryTree.InsertNode(6, _binaryTree.Root));
            Assert.IsTrue(_binaryTree.InsertNode(5, _binaryTree.Root));
            Assert.IsTrue(_binaryTree.InsertNode(2, _binaryTree.Root));

            var firstLevelNode = _binaryTree.Root.LeftNode;
            var secondLevelNode = firstLevelNode.LeftNode;
            var thirdLevelNode = secondLevelNode.LeftNode;
            var fourthLevelNode = thirdLevelNode.LeftNode;

            Assert.AreEqual(9, firstLevelNode.Value);
            Assert.AreEqual(6, secondLevelNode.Value);
            Assert.AreEqual(5, thirdLevelNode.Value);
            Assert.AreEqual(2, fourthLevelNode.Value);
        }

        [Test]
        public void InsertOneRightNode()
        {
            Assert.IsTrue(_binaryTree.InsertNode(14, _binaryTree.Root));
            Assert.AreEqual(14, _binaryTree.Root.RightNode.Value);
        }

        [Test]
        public void InsertMultipleRightNodes()
        {
            Assert.IsTrue(_binaryTree.InsertNode(14, _binaryTree.Root));
            Assert.IsTrue(_binaryTree.InsertNode(19, _binaryTree.Root));
            Assert.IsTrue(_binaryTree.InsertNode(22, _binaryTree.Root));
            Assert.IsTrue(_binaryTree.InsertNode(30, _binaryTree.Root));

            var firstLevelNode = _binaryTree.Root.RightNode;
            var secondLevelNode = firstLevelNode.RightNode;
            var thirdLevelNode = secondLevelNode.RightNode;
            var fourthLevelNode = thirdLevelNode.RightNode;

            Assert.AreEqual(14, firstLevelNode.Value);
            Assert.AreEqual(19, secondLevelNode.Value);
            Assert.AreEqual(22, thirdLevelNode.Value);
            Assert.AreEqual(30, fourthLevelNode.Value);
        }

        [Test]
        public void InsertNodesCorrectlyForBst()
        {
            _binaryTree = new BinaryTree(8);

            Assert.IsTrue(_binaryTree.InsertNode(3, _binaryTree.Root));
            Assert.IsTrue(_binaryTree.InsertNode(10, _binaryTree.Root));
            Assert.IsTrue(_binaryTree.InsertNode(1, _binaryTree.Root));
            Assert.IsTrue(_binaryTree.InsertNode(6, _binaryTree.Root));
            Assert.IsTrue(_binaryTree.InsertNode(4, _binaryTree.Root));

            var rootRight = _binaryTree.Root.RightNode;
            var rootLeft = _binaryTree.Root.LeftNode;

            var rootLeftleft = _binaryTree.Root.LeftNode.LeftNode;
            var rootleftRight = _binaryTree.Root.LeftNode.RightNode;

            var rootLeftRightLeft = _binaryTree.Root.LeftNode.RightNode.LeftNode;

            Assert.AreEqual(8, _binaryTree.Root.Value);

            Assert.AreEqual(3, rootLeft.Value);
            Assert.AreEqual(10, rootRight.Value);

            Assert.AreEqual(1, rootLeftleft.Value);
            Assert.AreEqual(6, rootleftRight.Value);

            Assert.AreEqual(4, rootLeftRightLeft.Value);
        }
    }
}
