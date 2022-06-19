using NUnit.Framework;

namespace BinarySearchTree.Tests;

[TestFixture]
public class BtDeleterTests
{
    private BinaryTree _binaryTree;
    private Node _rootNode;

    [SetUp]
    public void Setup()
    {
        _binaryTree = new BinaryTree(50);
        _rootNode = _binaryTree.Root;
    }

    [Test]
    public void ValueNotFoundReturnsFalse()
    {
        Assert.IsFalse(BtDeleter.DeleteValue(5, _binaryTree));
    }

    [Test]
    public void OneNodeTreeIsDeleted()
    {
        var testValue = 5;
        _binaryTree = new BinaryTree(testValue);
        Assert.AreEqual(testValue, BtSearcher.GetValue(testValue, _binaryTree.Root).Value);
        Assert.IsTrue(BtDeleter.DeleteValue(testValue, _binaryTree));
        Assert.IsNull(BtSearcher.GetValue(testValue, _binaryTree.Root));
    }

    [TestCase(12, 25, 75, 15, 40, 65, 90, 30, 60, 80)]
    [TestCase(30, 25, 75, 15, 40, 65, 90, 12, 60, 80)]
    [TestCase(60, 25, 75, 15, 40, 65, 90, 12, 30, 80)]
    [TestCase(80, 25, 75, 15, 40, 65, 90, 12, 30, 60)]
    public void DeleteLastLeftLeaf(int valueToDelete, params int[] valuesNotDeleted)
    {
        SetUpBinarySearchTree(valueToDelete, valuesNotDeleted);

        Assert.AreEqual(valueToDelete, BtSearcher.GetValue(valueToDelete, _rootNode).Value);
        Assert.IsTrue(BtDeleter.DeleteValue(valueToDelete, _binaryTree));
        Assert.IsNull(BtSearcher.GetValue(valueToDelete, _rootNode));

        foreach (var valueNotDeleted in valuesNotDeleted)
            Assert.AreEqual(valueNotDeleted, BtSearcher.GetValue(valueNotDeleted, _rootNode).Value);
    }

    [TestCase(20, 25, 75, 15, 40, 65, 90, 45, 70, 100)]
    [TestCase(45, 25, 75, 15, 40, 65, 90, 20, 70, 100)]
    [TestCase(70, 25, 75, 15, 40, 65, 90, 20, 45, 100)]
    [TestCase(100, 25, 75, 15, 40, 65, 90, 20, 45, 70)]
    public void DeleteLastRightLeaf(int valueToDelete, params int[] valuesNotDeleted)
    {
        SetUpBinarySearchTree(valueToDelete, valuesNotDeleted);

        Assert.AreEqual(valueToDelete, BtSearcher.GetValue(valueToDelete, _rootNode).Value);
        Assert.IsTrue(BtDeleter.DeleteValue(valueToDelete, _binaryTree));
        Assert.IsNull(BtSearcher.GetValue(valueToDelete, _rootNode));

        foreach (var valueNotDeleted in valuesNotDeleted)
            Assert.AreEqual(valueNotDeleted, BtSearcher.GetValue(valueNotDeleted, _rootNode).Value);
    }

    [TestCase(15, 25, 75, 40, 65, 90, 12, 30, 60, 80)]
    [TestCase(40, 25, 75, 15, 65, 90, 12, 30, 60, 80)]
    [TestCase(65, 25, 75, 15, 40, 90, 12, 30, 60, 80)]
    [TestCase(90, 25, 75, 15, 40, 65, 12, 30, 60, 80)]
    public void NodeDeletedWithOneLeftChildIsShiftedUp(int valueToDelete, params int[] valuesNotDeleted)
    {
        SetUpBinarySearchTree(valueToDelete, valuesNotDeleted);

        Assert.AreEqual(valueToDelete, BtSearcher.GetValue(valueToDelete, _rootNode).Value);
        Assert.IsTrue(BtDeleter.DeleteValue(valueToDelete, _binaryTree));
        Assert.IsNull(BtSearcher.GetValue(valueToDelete, _rootNode));

        foreach (var valueNotDeleted in valuesNotDeleted)
            Assert.AreEqual(valueNotDeleted, BtSearcher.GetValue(valueNotDeleted, _rootNode).Value);
    }

    [TestCase(15, 25, 75, 40, 65, 90, 20, 45, 70, 100)]
    [TestCase(40, 25, 75, 15, 65, 90, 20, 45, 70, 100)]
    [TestCase(65, 25, 75, 15, 40, 90, 20, 45, 70, 100)]
    [TestCase(90, 25, 75, 15, 40, 65, 20, 45, 70, 100)]
    public void NodeDeletedWithOneRightChildIsShiftedUp(int valueToDelete, params int[] valuesNotDeleted)
    {
        SetUpBinarySearchTree(valueToDelete, valuesNotDeleted);

        Assert.AreEqual(valueToDelete, BtSearcher.GetValue(valueToDelete, _rootNode).Value);
        Assert.IsTrue(BtDeleter.DeleteValue(valueToDelete, _binaryTree));
        Assert.IsNull(BtSearcher.GetValue(valueToDelete, _rootNode));

        foreach (var valueNotDeleted in valuesNotDeleted)
            Assert.AreEqual(valueNotDeleted, BtSearcher.GetValue(valueNotDeleted, _rootNode).Value);
    }

    [TestCase(15, 25, 75, 40, 65, 90, 12, 20, 30, 45, 60, 70, 80, 100)]
    [TestCase(40, 25, 75, 15, 65, 90, 12, 20, 30, 45, 60, 70, 80, 100)]
    [TestCase(65, 25, 75, 15, 40, 90, 12, 20, 30, 45, 60, 70, 80, 100)]
    [TestCase(90, 25, 75, 15, 40, 65, 12, 20, 30, 45, 60, 70, 80, 100)]
    public void NodeDeletedWithBothChildrenAreShiftedCorrectly(int valueToDelete, params int[] valuesNotDeleted)
    {
        SetUpBinarySearchTree(valueToDelete, valuesNotDeleted);

        Assert.AreEqual(valueToDelete, BtSearcher.GetValue(valueToDelete, _rootNode).Value);
        Assert.IsTrue(BtDeleter.DeleteValue(valueToDelete, _binaryTree));
        Assert.IsNull(BtSearcher.GetValue(valueToDelete, _rootNode));

        foreach (var valueNotDeleted in valuesNotDeleted)
            Assert.AreEqual(valueNotDeleted, BtSearcher.GetValue(valueNotDeleted, _rootNode).Value);
    }

    private void SetUpBinarySearchTree(int valueToDelete, int[] valuesNotDeleted)
    {
        foreach (var valueNotDeleted in valuesNotDeleted)
            BtValueInserter.InsertNode(valueNotDeleted, _rootNode);

        BtValueInserter.InsertNode(valueToDelete, _rootNode);
    }
}
