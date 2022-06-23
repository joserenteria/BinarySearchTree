namespace BinarySearchTree;

public static class BtDeleter
{
    public static bool DeleteValue(int value, BinaryTree binaryTree)
    {
        if (binaryTree.Root.Value == value)
        {
            binaryTree.Root = null;
            return true;
        }

        var currentNode = binaryTree.Root;
        var parentNode = currentNode;

        while (true)
        {
            if (value == currentNode.Value)
            {
                //NodeToDelete both children are null
                if (currentNode.LeftNode == null && currentNode.RightNode == null)
                {
                    if (parentNode.LeftNode == currentNode)
                        parentNode.LeftNode = null;
                    else
                        parentNode.RightNode = null;
                }
                //NodeToDelete one or the other of the children are null
                if (currentNode.RightNode != null)
                {
                    if (parentNode.LeftNode == currentNode)
                        parentNode.LeftNode = currentNode.RightNode;
                    else
                        parentNode.RightNode = currentNode.RightNode;
                }
                else
                {
                    if (parentNode.LeftNode == currentNode)
                        parentNode.LeftNode = currentNode.LeftNode;
                    else
                        parentNode.RightNode = currentNode.LeftNode;
                }
                //NodeToDelete both children have values
                if (currentNode.LeftNode != null && currentNode.RightNode != null)
                {
                    if (parentNode.LeftNode == currentNode)
                    {
                        currentNode.RightNode.LeftNode = currentNode.LeftNode;
                        parentNode.LeftNode = currentNode.RightNode;
                    }
                    else
                    {
                        currentNode.LeftNode.RightNode = currentNode.RightNode;
                        parentNode.RightNode = currentNode.LeftNode;
                    }
                }
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
