using NUnit.Framework;

namespace BinarySearchTree.Tests;

[TestFixture]
public class BtDepthNodeFinderTests
{
    private static BinaryTree _binaryTree;
    private Dictionary<int, int> _nodeDepths = new Dictionary<int, int>();
    private int depth;

    [SetUp]
    public void Setup()
    {
        _nodeDepths = new Dictionary<int, int>();
        depth = 0;
    }

    [Test]
    public void EmptyBinaryTreeReturnsEmptyList()
    {
        var binaryTree = new BinaryTree(12);
        binaryTree.Root = null;

        BtDepthNodeFinder.Finder(binaryTree.Root, _nodeDepths, depth);
        Assert.IsEmpty(_nodeDepths);
    }

    [Test]
    public void FirstLevelNoChildrenReturnsCorrectSequence()
    {
        var binaryTree = new BinaryTree(50);

        BtDepthNodeFinder.Finder(binaryTree.Root, _nodeDepths, depth);

        Assert.AreEqual("[50, 1]", string.Join(',', _nodeDepths));
    }

    [Test]
    public void SecondLevelNoChildrenReturnsCorrectSequence()
    {
        var binaryTree = new BinaryTree(50);
        BtValueInserter.InsertNode(25, binaryTree.Root);
        BtValueInserter.InsertNode(75, binaryTree.Root);

        BtDepthNodeFinder.Finder(binaryTree.Root, _nodeDepths, depth);

        Assert.AreEqual("[25, 2],[75, 2]", string.Join(',', _nodeDepths));
    }

    [Test]
    public void ThirdLevelNoChildrenReturnsCorrectSequence()
    {
        BinaryTreeInitialSetupWithThreeLevels();

        BtDepthNodeFinder.Finder(_binaryTree.Root, _nodeDepths, depth);

        Assert.AreEqual("[15, 3],[40, 3],[65, 3],[90, 3]", string.Join(',', _nodeDepths));
    }


    [Test]
    public void ThirdLevelLeftChildrenReturnsCorrectSequence()
    {
        BinaryTreeInitialSetupWithThreeLevels();
        BtValueInserter.InsertNode(12, _binaryTree.Root);
        BtValueInserter.InsertNode(30, _binaryTree.Root);
        BtValueInserter.InsertNode(60, _binaryTree.Root);
        BtValueInserter.InsertNode(80, _binaryTree.Root);

        BtDepthNodeFinder.Finder(_binaryTree.Root, _nodeDepths, depth);

        Assert.AreEqual("[12, 4],[30, 4],[60, 4],[80, 4]", string.Join(',', _nodeDepths));
    }

    [Test]
    public void ThirdLevelRightChildrenReturnsCorrectSequence()
    {
        BinaryTreeInitialSetupWithThreeLevels();
        BtValueInserter.InsertNode(20, _binaryTree.Root);
        BtValueInserter.InsertNode(45, _binaryTree.Root);
        BtValueInserter.InsertNode(70, _binaryTree.Root);
        BtValueInserter.InsertNode(100, _binaryTree.Root);

        BtDepthNodeFinder.Finder(_binaryTree.Root, _nodeDepths, depth);

        Assert.AreEqual("[20, 4],[45, 4],[70, 4],[100, 4]", string.Join(',', _nodeDepths));
    }

    [Test]
    public void ThirdLevelLeftRightNullChildrenReturnsCorrectSequence()
    {
        BinaryTreeInitialSetupWithThreeLevels();
        BtValueInserter.InsertNode(12, _binaryTree.Root);
        BtValueInserter.InsertNode(45, _binaryTree.Root);
        BtValueInserter.InsertNode(70, _binaryTree.Root);
        BtValueInserter.InsertNode(80, _binaryTree.Root);

        BtDepthNodeFinder.Finder(_binaryTree.Root, _nodeDepths, depth);

        Assert.AreEqual("[12, 4],[45, 4],[70, 4],[80, 4]", string.Join(',', _nodeDepths));
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
        BinaryTreeInitialSetupWithThreeLevels();
        BtValueInserter.InsertNode(leaf, _binaryTree.Root);

        BtDepthNodeFinder.Finder(_binaryTree.Root, _nodeDepths, depth);

        Assert.AreEqual(4, _nodeDepths.Count());
        Assert.That(_nodeDepths[leaf] == 4);
    }

    private static void BinaryTreeInitialSetupWithThreeLevels()
    {
        _binaryTree = new BinaryTree(50);
        BtValueInserter.InsertNode(25, _binaryTree.Root);
        BtValueInserter.InsertNode(75, _binaryTree.Root);
        BtValueInserter.InsertNode(15, _binaryTree.Root);
        BtValueInserter.InsertNode(40, _binaryTree.Root);
        BtValueInserter.InsertNode(65, _binaryTree.Root);
        BtValueInserter.InsertNode(90, _binaryTree.Root);
    }
}
