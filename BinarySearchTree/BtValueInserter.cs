namespace BinarySearchTree;

public static class BtValueInserter
{
    public static bool InsertNode(int value, Node node)
    {
        while (true)
        {
            if (value == node.Value)
                return false;

            if (value < node.Value)
            {
                if (node.LeftNode == null)
                {
                    node.LeftNode = new Node(value);
                    return true;
                }

                node = node.LeftNode;
                continue;
            }

            if (node.RightNode != null)
            {
                node = node.RightNode;
                continue;
            }

            node.RightNode = new Node(value);
            return true;
        }
    }
}
