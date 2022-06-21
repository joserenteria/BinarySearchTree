using NUnit.Framework;

namespace BinarySearchTree.Tests;

[TestFixture]
public class BtBreadthFirstTraversalTests
{
    private List<int> _breadthFirstValues;
    private BinaryTree _binaryTree;

    [SetUp]
    public void Setup()
    {
        _breadthFirstValues = new List<int>();

        _binaryTree = new BinaryTree(50);
        BtValueInserter.InsertNode(25, _binaryTree.Root);
        BtValueInserter.InsertNode(75, _binaryTree.Root);
        BtValueInserter.InsertNode(15, _binaryTree.Root);
        BtValueInserter.InsertNode(40, _binaryTree.Root);
        BtValueInserter.InsertNode(65, _binaryTree.Root);
        BtValueInserter.InsertNode(90, _binaryTree.Root);
    }

    [Test]
    public void EmptyBinaryTreeReturnsEmptyList()
    {
        var binaryTree = new BinaryTree(12);
        binaryTree.Root = null;

        BtTraversal.TraverseBreadthFirst(binaryTree.Root, _breadthFirstValues);

        Assert.IsEmpty(_breadthFirstValues);
    }

    [Test]
    public void ThirdLevelNoChildrenReturnsCorrectSequence()
    {
        BtTraversal.TraverseBreadthFirst(_binaryTree.Root, _breadthFirstValues);

        Assert.AreEqual("50,25,75,15,40,65,90", string.Join(',', _breadthFirstValues));
    }

    [Test]
    public void ThirdLevelLeftChildrenReturnsCorrectSequence()
    {
        BtValueInserter.InsertNode(12, _binaryTree.Root);
        BtValueInserter.InsertNode(30, _binaryTree.Root);
        BtValueInserter.InsertNode(60, _binaryTree.Root);
        BtValueInserter.InsertNode(80, _binaryTree.Root);

        BtTraversal.TraverseBreadthFirst(_binaryTree.Root, _breadthFirstValues);

        Assert.AreEqual("50,25,75,15,40,65,90,12,30,60,80", string.Join(',', _breadthFirstValues));
    }

    [Test]
    public void ThirdLevelRightChildrenReturnsCorrectSequence()
    {
        BtValueInserter.InsertNode(20, _binaryTree.Root);
        BtValueInserter.InsertNode(45, _binaryTree.Root);
        BtValueInserter.InsertNode(70, _binaryTree.Root);
        BtValueInserter.InsertNode(100, _binaryTree.Root);

        BtTraversal.TraverseBreadthFirst(_binaryTree.Root, _breadthFirstValues);

        Assert.AreEqual("50,25,75,15,40,65,90,20,45,70,100", string.Join(',', _breadthFirstValues));
    }

    [Test]
    public void ThirdLevelLeftRightNullChildrenReturnsCorrectSequence()
    {
        BtValueInserter.InsertNode(12, _binaryTree.Root);
        BtValueInserter.InsertNode(45, _binaryTree.Root);
        BtValueInserter.InsertNode(70, _binaryTree.Root);
        BtValueInserter.InsertNode(80, _binaryTree.Root);

        BtTraversal.TraverseBreadthFirst(_binaryTree.Root, _breadthFirstValues);

        Assert.AreEqual("50,25,75,15,40,65,90,12,45,70,80", string.Join(',', _breadthFirstValues));
    }
}
