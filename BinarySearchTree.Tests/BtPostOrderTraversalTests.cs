using NUnit.Framework;

namespace BinarySearchTree.Tests;

[TestFixture]
public class BtPostOrderTraversalTests
{
    private List<int> _postOrderedValues;
    private BinaryTree _binaryTree;

    [SetUp]
    public void Setup()
    {
        _postOrderedValues = new List<int>();

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

        BtTraversal.TraversePostOrder(binaryTree.Root, _postOrderedValues);

        Assert.IsEmpty(_postOrderedValues);
    }
    [Test]
    public void ThirdLevelNoChildrenReturnsCorrectSequence()
    {
        BtTraversal.TraversePostOrder(_binaryTree.Root, _postOrderedValues);

        Assert.AreEqual("15,40,25,65,90,75,50", string.Join(',', _postOrderedValues));
    }

    [Test]
    public void ThirdLevelLeftChildrenReturnsCorrectSequence()
    {
        BtValueInserter.InsertNode(12, _binaryTree.Root);
        BtValueInserter.InsertNode(30, _binaryTree.Root);
        BtValueInserter.InsertNode(60, _binaryTree.Root);
        BtValueInserter.InsertNode(80, _binaryTree.Root);

        BtTraversal.TraversePostOrder(_binaryTree.Root, _postOrderedValues);

        Assert.AreEqual("12,15,30,40,25,60,65,80,90,75,50", string.Join(',', _postOrderedValues));
    }

    [Test]
    public void ThirdLevelRightChildrenReturnsCorrectSequence()
    {
        BtValueInserter.InsertNode(20, _binaryTree.Root);
        BtValueInserter.InsertNode(45, _binaryTree.Root);
        BtValueInserter.InsertNode(70, _binaryTree.Root);
        BtValueInserter.InsertNode(100, _binaryTree.Root);

        BtTraversal.TraversePostOrder(_binaryTree.Root, _postOrderedValues);

        Assert.AreEqual("20,15,45,40,25,70,65,100,90,75,50", string.Join(',', _postOrderedValues));
    }

    [Test]
    public void ThirdLevelLeftRightNullChildrenReturnsCorrectSequence()
    {
        BtValueInserter.InsertNode(12, _binaryTree.Root);
        BtValueInserter.InsertNode(45, _binaryTree.Root);
        BtValueInserter.InsertNode(70, _binaryTree.Root);
        BtValueInserter.InsertNode(80, _binaryTree.Root);

        BtTraversal.TraversePostOrder(_binaryTree.Root, _postOrderedValues);

        Assert.AreEqual("12,15,45,40,25,70,65,80,90,75,50", string.Join(',', _postOrderedValues));
    }
}
