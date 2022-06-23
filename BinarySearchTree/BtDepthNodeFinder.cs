namespace BinarySearchTree;

public static class BtDepthNodeFinder
{
    public static void Find(Node rootNode, Dictionary<int, int> nodeDepths, int depth = 0)
    {
        if (rootNode != null)
        {
            if (rootNode.LeftNode == null && rootNode.RightNode == null)
                nodeDepths.Add(rootNode.Value, depth);
            depth += 1;

            if (nodeDepths.Any())
                RemoveLessThanMaxDepthNodes(nodeDepths);

            Find(rootNode.LeftNode, nodeDepths, depth);
            Find(rootNode.RightNode, nodeDepths, depth);
        }
    }

    private static void RemoveLessThanMaxDepthNodes(Dictionary<int, int> nodeDepths)
    {
        var maxDepth = nodeDepths.MaxBy(x => x.Value).Value;

        var nodesLessThanMax = nodeDepths.Where(x => x.Value < maxDepth)
                                                               .Select(x => x);

        foreach (var nodeFound in nodesLessThanMax)
            nodeDepths.Remove(nodeFound.Key);
    }
}
