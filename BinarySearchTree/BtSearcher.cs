namespace BinarySearchTree;

public static class BtSearcher
{
    public static Node GetValue(int value, Node node)
    {
        if (node == null)
            return null;

        while (true)
        {
            if (node.Value == value)
                return node;

            if (value < node.Value && node.LeftNode != null)
            {
                node = node.LeftNode;
                continue;
            }

            if (value > node.Value && node.RightNode != null)
            {
                node = node.RightNode;
                continue;
            }

            return null;
        }
    }
}
