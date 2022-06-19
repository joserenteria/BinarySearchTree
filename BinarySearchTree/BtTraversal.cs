namespace BinarySearchTree;

public static class BtTraversal
{
    //parent -> left child -> right child
    public static void TraversePreOrder(Node rootNode, List<int> preOrderedValues)
    {
        if (rootNode != null)
        {
            preOrderedValues.Add(rootNode.Value);
            TraversePreOrder(rootNode.LeftNode, preOrderedValues);
            TraversePreOrder(rootNode.RightNode, preOrderedValues);
        }
    }
}
