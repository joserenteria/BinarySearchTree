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

    //left child -> parent ->  right child
    public static void TraverseInOrder(Node rootNode, List<int> inOrderedValues)
    {
        if (rootNode != null)
        {
            TraverseInOrder(rootNode.LeftNode, inOrderedValues);
            inOrderedValues.Add(rootNode.Value);
            TraverseInOrder(rootNode.RightNode, inOrderedValues);
        }
    }

    //left child -> right child -> parent
    public static void TraversePostOrder(Node rootNode, List<int> postOrderedValues)
    {
        if (rootNode != null)
        {
            TraversePostOrder(rootNode.LeftNode, postOrderedValues);
            TraversePostOrder(rootNode.RightNode, postOrderedValues);
            postOrderedValues.Add(rootNode.Value);
        }
    }

    //Parent(s)-> left child -> right child
    public static void TraverseBreadthFirst(Node rootNode, List<int> breadthFirstValues)
    {
        var nodes = new Queue<Node>();

        if (rootNode != null)
            nodes.Enqueue(rootNode);

        while (nodes.Count > 0)
        {
            var tempNode = nodes.Dequeue();
            breadthFirstValues.Add(tempNode.Value);

            if (tempNode.LeftNode != null)
                nodes.Enqueue(tempNode.LeftNode);
            if (tempNode.RightNode != null)
                nodes.Enqueue(tempNode.RightNode);
        }
    }

    public static int TreeHeight(Node node)
    {
        if (node == null)
            return -1;

        return 1 + Math.Max(TreeHeight(node.LeftNode), TreeHeight(node.RightNode));
    }
}
