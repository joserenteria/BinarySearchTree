using NUnit.Framework;

namespace BinarySearchTree.Tests;

[TestFixture]
public class BtSearcherTests
{
    private BinaryTree _binaryTree;
    private Node _rootNode;

    [SetUp]
    public void Setup()
    {
        _binaryTree = new BinaryTree(8);
        _rootNode = _binaryTree.Root;
        Assert.IsTrue(BtValueInserter.InsertNode(3, _rootNode));
        Assert.IsTrue(BtValueInserter.InsertNode(10, _rootNode));
        Assert.IsTrue(BtValueInserter.InsertNode(1, _rootNode));
        Assert.IsTrue(BtValueInserter.InsertNode(6, _rootNode));
        Assert.IsTrue(BtValueInserter.InsertNode(4, _rootNode));
    }

    [Test]
    public void RootIsFound()
    {
        Assert.AreEqual(new Node(8).Value, BtSearcher.GetValue(8, _rootNode).Value);
    }

    [Test]
    public void FirstLevelGreaterThanRootFound()
    {
        Assert.AreEqual(new Node(10).Value, BtSearcher.GetValue(10, _rootNode).Value);
    }

    [Test]
    public void DescendantLessThanOthersFound()
    {
        Assert.AreEqual(new Node(1).Value, BtSearcher.GetValue(1, _rootNode).Value);
    }

    [Test]
    public void LastDescendantWithLessAndGreaterParentsFound()
    {
        Assert.AreEqual(new Node(4).Value, BtSearcher.GetValue(4, _rootNode).Value);
    }

    [TestCase(12)]
    [TestCase(5)]
    [TestCase(30)]
    [TestCase(0)]
    public void NotFoundReturnsNull(int value)
    {
        Assert.IsNull(BtSearcher.GetValue(value, _rootNode));
    }
}
