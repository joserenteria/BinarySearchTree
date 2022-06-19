namespace BinarySearchTree;

public static class BtDeleter
{
    public static bool DeleteValue(int value, BinaryTree binaryTree)
    {
        var currentNode = binaryTree.Root;
        var parentNode = currentNode;

        while (true)
        {
            if (value == currentNode.Value)
            {
                if (binaryTree.Root == currentNode)
                    binaryTree.Root = null;

                if (parentNode.LeftNode == currentNode)
                    parentNode.LeftNode = null;
                else
                    parentNode.RightNode = null;

                return true;
            }

            if (value < currentNode.Value)
            {
                if (currentNode.LeftNode == null)
                    return false;

                parentNode = currentNode;
                currentNode = currentNode.LeftNode;
                continue;
            }

            if (value > currentNode.Value)
            {
                if (currentNode.RightNode == null)
                    return false;

                parentNode = currentNode;
                currentNode = currentNode.RightNode;
                continue;
            }

            return false;
        }
    }
}
