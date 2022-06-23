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

        BtDepthNodeFinder.Find(binaryTree.Root, _nodeDepths);
        Assert.IsEmpty(_nodeDepths);
    }

    [Test]
    public void FirstLevelNoChildrenReturnsCorrectSequence()
    {
        var binaryTree = new BinaryTree(50);

        BtDepthNodeFinder.Find(binaryTree.Root, _nodeDepths);

        Assert.AreEqual("[50, 0]", string.Join(',', _nodeDepths));
    }

    [Test]
    public void SecondLevelNoChildrenReturnsCorrectSequence()
    {
        var binaryTree = new BinaryTree(50);
        BtValueInserter.InsertNode(25, binaryTree.Root);
        BtValueInserter.InsertNode(75, binaryTree.Root);

        BtDepthNodeFinder.Find(binaryTree.Root, _nodeDepths);

        Assert.AreEqual("[25, 1],[75, 1]", string.Join(',', _nodeDepths));
    }

    [Test]
    public void ThirdLevelNoChildrenReturnsCorrectSequence()
    {
        BinaryTreeInitialSetupWithThreeLevels();

        BtDepthNodeFinder.Find(_binaryTree.Root, _nodeDepths);

        Assert.AreEqual("[15, 2],[40, 2],[65, 2],[90, 2]", string.Join(',', _nodeDepths));
    }

    [Test]
    public void ThirdLevelLeftChildrenReturnsCorrectSequence()
    {
        BinaryTreeInitialSetupWithThreeLevels();
        BtValueInserter.InsertNode(12, _binaryTree.Root);
        BtValueInserter.InsertNode(30, _binaryTree.Root);
        BtValueInserter.InsertNode(60, _binaryTree.Root);
        BtValueInserter.InsertNode(80, _binaryTree.Root);

        BtDepthNodeFinder.Find(_binaryTree.Root, _nodeDepths);

        Assert.AreEqual("[12, 3],[30, 3],[60, 3],[80, 3]", string.Join(',', _nodeDepths));
    }

    [Test]
    public void ThirdLevelRightChildrenReturnsCorrectSequence()
    {
        BinaryTreeInitialSetupWithThreeLevels();
        BtValueInserter.InsertNode(20, _binaryTree.Root);
        BtValueInserter.InsertNode(45, _binaryTree.Root);
        BtValueInserter.InsertNode(70, _binaryTree.Root);
        BtValueInserter.InsertNode(100, _binaryTree.Root);

        BtDepthNodeFinder.Find(_binaryTree.Root, _nodeDepths);

        Assert.AreEqual("[20, 3],[45, 3],[70, 3],[100, 3]", string.Join(',', _nodeDepths));
    }

    [Test]
    public void ThirdLevelLeftRightNullChildrenReturnsCorrectSequence()
    {
        BinaryTreeInitialSetupWithThreeLevels();
        BtValueInserter.InsertNode(12, _binaryTree.Root);
        BtValueInserter.InsertNode(45, _binaryTree.Root);
        BtValueInserter.InsertNode(70, _binaryTree.Root);
        BtValueInserter.InsertNode(80, _binaryTree.Root);

        BtDepthNodeFinder.Find(_binaryTree.Root, _nodeDepths);

        Assert.AreEqual("[12, 3],[45, 3],[70, 3],[80, 3]", string.Join(',', _nodeDepths));
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

        BtDepthNodeFinder.Find(_binaryTree.Root, _nodeDepths);

        Assert.AreEqual(1, _nodeDepths.Count());
        Assert.That(_nodeDepths[leaf] == 3);
    }

    [Test]
    public void RightLeftRightLeftReturnsOneNode()
    {
        var binaryTree = new BinaryTree(50);
        BtValueInserter.InsertNode(75, binaryTree.Root);
        BtValueInserter.InsertNode(65, binaryTree.Root);
        BtValueInserter.InsertNode(70, binaryTree.Root);
        BtValueInserter.InsertNode(66, binaryTree.Root);

        BtDepthNodeFinder.Find(binaryTree.Root, _nodeDepths);

        Assert.AreEqual("[66, 4]", string.Join(',', _nodeDepths));
    }

    [Test]
    public void TestChallengeNumberOneExample()
    {
        var binaryTree = new BinaryTree(12);
        BtValueInserter.InsertNode(11, binaryTree.Root);
        BtValueInserter.InsertNode(90, binaryTree.Root);
        BtValueInserter.InsertNode(82, binaryTree.Root);
        BtValueInserter.InsertNode(7, binaryTree.Root);
        BtValueInserter.InsertNode(9, binaryTree.Root);

        BtDepthNodeFinder.Find(binaryTree.Root, _nodeDepths);
        Assert.AreEqual("[9, 3]", string.Join(',', _nodeDepths));
    }

    [Test]
    public void TestChallengeNumberTwoExample()
    {
        var binaryTree = new BinaryTree(26);
        BtValueInserter.InsertNode(82, binaryTree.Root);
        BtValueInserter.InsertNode(16, binaryTree.Root);
        BtValueInserter.InsertNode(92, binaryTree.Root);
        BtValueInserter.InsertNode(33, binaryTree.Root);

        BtDepthNodeFinder.Find(binaryTree.Root, _nodeDepths);
        Assert.AreEqual("[92, 2],[33, 2]", string.Join(',', _nodeDepths));
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
