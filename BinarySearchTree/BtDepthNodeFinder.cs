namespace BinarySearchTree;

public static class BtDepthNodeFinder
{
    private static int _depth = 0;

    public static void Finder(Node rootNode, Dictionary<int, int> nodeDepths, int depth)
    {
        if (rootNode != null)
        {
            depth += 1;
            if (rootNode.LeftNode == null && rootNode.RightNode == null)
                nodeDepths.Add(rootNode.Value, depth);

            Finder(rootNode.LeftNode, nodeDepths, depth);
            Finder(rootNode.RightNode, nodeDepths, depth);
        }
    }
}
