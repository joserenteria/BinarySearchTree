using NUnit.Framework;

namespace BinarySearchTree.Tests;

[TestFixture]
public class BtInOrderTraversalTests
{
    private List<int> _InOrderedValues;
    private BinaryTree _binaryTree;

    [SetUp]
    public void Setup()
    {
        _InOrderedValues = new List<int>();

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

        BtTraversal.TraverseInOrder(binaryTree.Root, _InOrderedValues);

        Assert.IsEmpty(_InOrderedValues);
    }
    [Test]
    public void ThirdLevelNoChildrenReturnsCorrectSequence()
    {
        BtTraversal.TraverseInOrder(_binaryTree.Root, _InOrderedValues);

        Assert.AreEqual("15,25,40,50,65,75,90", string.Join(',', _InOrderedValues));
    }

    [Test]
    public void ThirdLevelLeftChildrenReturnsCorrectSequence()
    {
        BtValueInserter.InsertNode(12, _binaryTree.Root);
        BtValueInserter.InsertNode(30, _binaryTree.Root);
        BtValueInserter.InsertNode(60, _binaryTree.Root);
        BtValueInserter.InsertNode(80, _binaryTree.Root);

        BtTraversal.TraverseInOrder(_binaryTree.Root, _InOrderedValues);

        Assert.AreEqual("12,15,25,30,40,50,60,65,75,80,90", string.Join(',', _InOrderedValues));
    }

    [Test]
    public void ThirdLevelRightChildrenReturnsCorrectSequence()
    {
        BtValueInserter.InsertNode(20, _binaryTree.Root);
        BtValueInserter.InsertNode(45, _binaryTree.Root);
        BtValueInserter.InsertNode(70, _binaryTree.Root);
        BtValueInserter.InsertNode(100, _binaryTree.Root);

        BtTraversal.TraverseInOrder(_binaryTree.Root, _InOrderedValues);

        Assert.AreEqual("15,20,25,40,45,50,65,70,75,90,100", string.Join(',', _InOrderedValues));
    }

    [Test]
    public void ThirdLevelLeftRightNullChildrenReturnsCorrectSequence()
    {
        BtValueInserter.InsertNode(12, _binaryTree.Root);
        BtValueInserter.InsertNode(45, _binaryTree.Root);
        BtValueInserter.InsertNode(70, _binaryTree.Root);
        BtValueInserter.InsertNode(80, _binaryTree.Root);

        BtTraversal.TraverseInOrder(_binaryTree.Root, _InOrderedValues);

        Assert.AreEqual("12,15,25,40,45,50,65,70,75,80,90", string.Join(',', _InOrderedValues));
    }
}
