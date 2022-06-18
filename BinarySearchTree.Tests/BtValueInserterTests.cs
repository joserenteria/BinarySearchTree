using NUnit.Framework;

namespace BinarySearchTree.Tests
{
    [TestFixture]
    public class BtValueInserterTests
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
            Assert.IsTrue(BtValueInserter.InsertNode(5, _binaryTree.Root));
            Assert.AreEqual(5, _binaryTree.Root.LeftNode.Value);
        }

        [Test]
        public void InsertMultipleLeftNodes()
        {
            Assert.IsTrue(BtValueInserter.InsertNode(9, _binaryTree.Root));
            Assert.IsTrue(BtValueInserter.InsertNode(6, _binaryTree.Root));
            Assert.IsTrue(BtValueInserter.InsertNode(5, _binaryTree.Root));
            Assert.IsTrue(BtValueInserter.InsertNode(2, _binaryTree.Root));

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
            Assert.IsTrue(BtValueInserter.InsertNode(14, _binaryTree.Root));
            Assert.AreEqual(14, _binaryTree.Root.RightNode.Value);
        }

        [Test]
        public void InsertMultipleRightNodes()
        {
            Assert.IsTrue(BtValueInserter.InsertNode(14, _binaryTree.Root));
            Assert.IsTrue(BtValueInserter.InsertNode(19, _binaryTree.Root));
            Assert.IsTrue(BtValueInserter.InsertNode(22, _binaryTree.Root));
            Assert.IsTrue(BtValueInserter.InsertNode(30, _binaryTree.Root));

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
        public void DoesNotInsertDuplicates()
        {
            Assert.IsTrue(BtValueInserter.InsertNode(14, _binaryTree.Root));
            Assert.IsFalse(BtValueInserter.InsertNode(14, _binaryTree.Root));

            Assert.AreEqual(12, _binaryTree.Root.Value);
            Assert.AreEqual(14, _binaryTree.Root.RightNode.Value);
            Assert.IsNull(_binaryTree.Root.LeftNode);
            Assert.IsNull(_binaryTree.Root.RightNode.RightNode);
            Assert.IsNull(_binaryTree.Root.RightNode.LeftNode);

            Assert.IsTrue(BtValueInserter.InsertNode(10, _binaryTree.Root));
            Assert.IsFalse(BtValueInserter.InsertNode(10, _binaryTree.Root));

            Assert.AreEqual(12, _binaryTree.Root.Value);
            Assert.AreEqual(14, _binaryTree.Root.RightNode.Value);
            Assert.AreEqual(10, _binaryTree.Root.LeftNode.Value);

            Assert.IsNull(_binaryTree.Root.RightNode.RightNode);
            Assert.IsNull(_binaryTree.Root.RightNode.LeftNode);

            Assert.IsNull(_binaryTree.Root.LeftNode.RightNode);
            Assert.IsNull(_binaryTree.Root.LeftNode.LeftNode);
        }

        [Test]
        public void InsertNodesCorrectlyForBst()
        {
            _binaryTree = new BinaryTree(8);

            Assert.IsTrue(BtValueInserter.InsertNode(3, _binaryTree.Root));
            Assert.IsTrue(BtValueInserter.InsertNode(10, _binaryTree.Root));
            Assert.IsTrue(BtValueInserter.InsertNode(1, _binaryTree.Root));
            Assert.IsTrue(BtValueInserter.InsertNode(6, _binaryTree.Root));
            Assert.IsTrue(BtValueInserter.InsertNode(4, _binaryTree.Root));

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
