using NUnit.Framework;

namespace BinarySearchTree.Tests;

[TestFixture]
public class TreeHeightTests
{
    [Test]
    public void TreeWithNoRootReturnsZero()
    {
        var binaryTree = new BinaryTree(12);
        binaryTree.Root = null;

        Assert.AreEqual(0, BtTraversal.TreeHeight(binaryTree.Root));
    }

    [Test]
    public void TreeWithOnlyRootReturnsOne()
    {
        var binaryTree = new BinaryTree(12);

        Assert.AreEqual(1, BtTraversal.TreeHeight(binaryTree.Root));
    }

    [Test]
    public void TreeWithTwoLevelReturnsTwo()
    {
        var binaryTree = new BinaryTree(50);
        BtValueInserter.InsertNode(25, binaryTree.Root);
        BtValueInserter.InsertNode(75, binaryTree.Root);

        Assert.AreEqual(2, BtTraversal.TreeHeight(binaryTree.Root));
    }

    [Test]
    public void TreeWithThreeLevelsReturnsThree()
    {
        var binaryTree = new BinaryTree(50);
        BtValueInserter.InsertNode(25, binaryTree.Root);
        BtValueInserter.InsertNode(75, binaryTree.Root);
        BtValueInserter.InsertNode(15, binaryTree.Root);
        BtValueInserter.InsertNode(40, binaryTree.Root);
        BtValueInserter.InsertNode(65, binaryTree.Root);
        BtValueInserter.InsertNode(90, binaryTree.Root);

        Assert.AreEqual(3, BtTraversal.TreeHeight(binaryTree.Root));
    }

    [TestCase(12)]
    [TestCase(20)]
    [TestCase(30)]
    [TestCase(45)]
    [TestCase(60)]
    [TestCase(70)]
    [TestCase(80)]
    [TestCase(100)]
    public void LopsidedTreeWithFourLevelsReturnsFour(int leaf)
    {
        var binaryTree = new BinaryTree(50);
        BtValueInserter.InsertNode(25, binaryTree.Root);
        BtValueInserter.InsertNode(75, binaryTree.Root);
        BtValueInserter.InsertNode(15, binaryTree.Root);
        BtValueInserter.InsertNode(40, binaryTree.Root);
        BtValueInserter.InsertNode(65, binaryTree.Root);
        BtValueInserter.InsertNode(90, binaryTree.Root);
        BtValueInserter.InsertNode(leaf, binaryTree.Root);

        Assert.AreEqual(4, BtTraversal.TreeHeight(binaryTree.Root));
    }

    [Test]
    public void OnlyLeftSubtreeLopsidedWithFourLevelsReturnsFour()
    {
        var binaryTree = new BinaryTree(50);
        BtValueInserter.InsertNode(25, binaryTree.Root);
        BtValueInserter.InsertNode(15, binaryTree.Root);
        BtValueInserter.InsertNode(12, binaryTree.Root);
        BtValueInserter.InsertNode(10, binaryTree.Root);
        BtValueInserter.InsertNode(9, binaryTree.Root);
        BtValueInserter.InsertNode(8, binaryTree.Root);
        BtValueInserter.InsertNode(7, binaryTree.Root);

        Assert.AreEqual(8, BtTraversal.TreeHeight(binaryTree.Root));
    }

    [Test]
    public void OnlyRightSubtreeLopsidedWithFourLevelsReturnsFour()
    {
        var binaryTree = new BinaryTree(50);
        BtValueInserter.InsertNode(75, binaryTree.Root);
        BtValueInserter.InsertNode(90, binaryTree.Root);
        BtValueInserter.InsertNode(100, binaryTree.Root);
        BtValueInserter.InsertNode(101, binaryTree.Root);
        BtValueInserter.InsertNode(102, binaryTree.Root);
        BtValueInserter.InsertNode(103, binaryTree.Root);
        BtValueInserter.InsertNode(104, binaryTree.Root);

        Assert.AreEqual(8, BtTraversal.TreeHeight(binaryTree.Root));
    }

    [Test]
    public void LeftRightLeftRightReturnsFive()
    {
        var binaryTree = new BinaryTree(50);
        BtValueInserter.InsertNode(25, binaryTree.Root);
        BtValueInserter.InsertNode(40, binaryTree.Root);
        BtValueInserter.InsertNode(30, binaryTree.Root);
        BtValueInserter.InsertNode(31, binaryTree.Root);
        BtValueInserter.InsertNode(102, binaryTree.Root);
        BtValueInserter.InsertNode(103, binaryTree.Root);
        BtValueInserter.InsertNode(104, binaryTree.Root);

        Assert.AreEqual(5, BtTraversal.TreeHeight(binaryTree.Root));
    }

    [Test]
    public void RightLeftRightLeftReturnsFive()
    {
        var binaryTree = new BinaryTree(50);
        BtValueInserter.InsertNode(75, binaryTree.Root);
        BtValueInserter.InsertNode(65, binaryTree.Root);
        BtValueInserter.InsertNode(70, binaryTree.Root);
        BtValueInserter.InsertNode(66, binaryTree.Root);
        BtValueInserter.InsertNode(25, binaryTree.Root);
        BtValueInserter.InsertNode(15, binaryTree.Root);
        BtValueInserter.InsertNode(12, binaryTree.Root);

        Assert.AreEqual(5, BtTraversal.TreeHeight(binaryTree.Root));
    }
}
