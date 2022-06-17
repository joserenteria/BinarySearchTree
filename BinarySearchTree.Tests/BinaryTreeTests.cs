using NUnit.Framework;

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
    }
}
