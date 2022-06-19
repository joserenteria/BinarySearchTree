using NUnit.Framework;

namespace BinarySearchTree.Tests;

[TestFixture]
public class BtPreOrderTraversalTests
{
    private List<int> _preOrderedValues;
    private BinaryTree _binaryTree;

    [SetUp]
    public void Setup()
    {
        _preOrderedValues = new List<int>();

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

        BtTraversal.TraversePreOrder(binaryTree.Root, _preOrderedValues);

        Assert.IsEmpty(_preOrderedValues);
    }

    [Test]
    public void ThirdLevelNoChildrenReturnsCorrectSequence()
    {
        BtTraversal.TraversePreOrder(_binaryTree.Root,_preOrderedValues);

        Assert.AreEqual("50,25,15,40,75,65,90", string.Join(',',_preOrderedValues));
    }

    [Test]
    public void ThirdLevelLeftChildrenReturnsCorrectSequence()
    {
        BtValueInserter.InsertNode(12, _binaryTree.Root);
        BtValueInserter.InsertNode(30, _binaryTree.Root);
        BtValueInserter.InsertNode(60, _binaryTree.Root);
        BtValueInserter.InsertNode(80, _binaryTree.Root);

        BtTraversal.TraversePreOrder(_binaryTree.Root,_preOrderedValues);

        Assert.AreEqual("50,25,15,12,40,30,75,65,60,90,80", string.Join(',',_preOrderedValues));
    }

    [Test]
    public void ThirdLevelRightChildrenReturnsCorrectSequence()
    {
        BtValueInserter.InsertNode(20, _binaryTree.Root);
        BtValueInserter.InsertNode(45, _binaryTree.Root);
        BtValueInserter.InsertNode(70, _binaryTree.Root);
        BtValueInserter.InsertNode(100, _binaryTree.Root);

        BtTraversal.TraversePreOrder(_binaryTree.Root,_preOrderedValues);

        Assert.AreEqual("50,25,15,20,40,45,75,65,70,90,100", string.Join(',',_preOrderedValues));
    }

    [Test]
    public void ThirdLevelLeftRightNullChildrenReturnsCorrectSequence()
    {
        BtValueInserter.InsertNode(12, _binaryTree.Root);
        BtValueInserter.InsertNode(45, _binaryTree.Root);
        BtValueInserter.InsertNode(70, _binaryTree.Root);
        BtValueInserter.InsertNode(80, _binaryTree.Root);

        BtTraversal.TraversePreOrder(_binaryTree.Root,_preOrderedValues);

        Assert.AreEqual("50,25,15,12,40,45,75,65,70,90,80", string.Join(',',_preOrderedValues));
    }
}
