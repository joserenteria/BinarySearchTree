// See https://aka.ms/new-console-template for more information

using BinarySearchTree;

Console.WriteLine("Binary Search Tree app has started.\r\n");
Console.WriteLine("Type 'exit' to stop the application.\r\n");
Console.WriteLine("Please enter a list of comma delimited integers to build the Binary Search Tree. e.g. '50,25,75,...'\r\n");
string? consoleInput = string.Empty;

var binarySearchTreeIntegers = InitializeBinarySearchTreeIntegers();

BinarySearchTreeManipulation(binarySearchTreeIntegers);

int[] InitializeBinarySearchTreeIntegers()
{
    int[] ints;
    while (true)
    {
        consoleInput = Console.ReadLine();

        if (string.Equals("exit", consoleInput, StringComparison.OrdinalIgnoreCase))
            Environment.Exit(0);

        try
        {
            ints = Array.ConvertAll(consoleInput.Split(','), x => int.Parse(x));
            Console.WriteLine($"Your Binary Search Tree numbers are: {string.Join('-', ints)}. \r\n\r\n");
            break;
        }
        catch (Exception e)
        {
            Console.WriteLine("Your last input failed to parse as a list.'\r\n");
            Console.WriteLine("Please enter a list of comma delimited integers to build the Binary Search Tree. e.g. '50,25,75,...'\r\n\r\n");
        }
    }

    return ints;
}

void BinarySearchTreeManipulation(int[] binarySearchTreeIntegers)
{
    string? consoleInput1;
    var binarySearchTree = new BinaryTree(binarySearchTreeIntegers[0]);
    for (var i = 1; i < binarySearchTreeIntegers.Length; i++)
        BtValueInserter.InsertNode(binarySearchTreeIntegers[i], binarySearchTree.Root);

    while (true)
    {
        Console.WriteLine("Which of the following actions would you like to perform on your Binary Search Tree?\r\n");
        Console.WriteLine("1:Insert, 2:Delete, 3:Search, 4:PreOrderTraversal, 5:InOrderTraversal, 6:PostOrderTraversal\r\n");
        Console.WriteLine("7:BreadthFirstTraversal, 8:TreeHeight, 9:last leaf node(s) with it's value and level\r\n");
        Console.WriteLine("10:Reset BST with new values\r\n");
        consoleInput1 = Console.ReadLine();

        if (string.Equals("exit", consoleInput1, StringComparison.OrdinalIgnoreCase))
            Environment.Exit(0);

        switch (consoleInput1)
        {
            case "1":
                Console.WriteLine("Enter Integer value to insert:\r\n");
                consoleInput1 = Console.ReadLine();
                BtValueInserter.InsertNode(int.Parse(consoleInput1), binarySearchTree.Root);
                Console.WriteLine($"Integer {consoleInput1} was inserted:\r\n\r\n");
                break;
            case "2":
                Console.WriteLine("Enter Integer value to delete:\r\n");
                consoleInput1 = Console.ReadLine();
                Console.WriteLine(BtDeleter.DeleteValue(int.Parse(consoleInput1), binarySearchTree)
                    ? $"Integer {consoleInput1} was deleted:\r\n\r\n"
                    : $"Integer {consoleInput1} was NOT found to be deleted:\r\n\r\n");
                break;
            case "3":
                Console.WriteLine("Enter Integer value to search:\r\n");
                consoleInput1 = Console.ReadLine();
                var nodeFound = BtSearcher.GetValue(int.Parse(consoleInput1), binarySearchTree.Root);
                Console.WriteLine(nodeFound == null
                    ? $"Value {consoleInput1} was not found.\r\n\r\n"
                    : $"Value {consoleInput1} was found.\r\n\r\n");
                break;
            case "4":
                Console.WriteLine("These are the values in Pre-Order Traversal.\r\n");
                var preOrderedValues = new List<int>();
                BtTraversal.TraversePreOrder(binarySearchTree.Root, preOrderedValues);
                Console.WriteLine($"Pre-Ordered values: {string.Join(',', preOrderedValues)}\r\n\r\n");
                break;
            case "5":
                Console.WriteLine("These are the values in In-Order Traversal.\r\n");
                var inOrderedValues = new List<int>();
                BtTraversal.TraverseInOrder(binarySearchTree.Root, inOrderedValues);
                Console.WriteLine($"Pre-Ordered values: {string.Join(',', inOrderedValues)}\r\n\r\n");
                break;
            case "6":
                Console.WriteLine("These are the values in Post-Order Traversal.\r\n");
                var postOrderedValues = new List<int>();
                BtTraversal.TraversePostOrder(binarySearchTree.Root, postOrderedValues);
                Console.WriteLine($"Pre-Ordered values: {string.Join(',', postOrderedValues)}\r\n\r\n");
                break;
            case "7":
                Console.WriteLine("These are the values in Breadth-First Traversal.\r\n");
                var breadthFirstValues = new List<int>();
                BtTraversal.TraverseBreadthFirst(binarySearchTree.Root, breadthFirstValues);
                Console.WriteLine($"Breadth first values: {string.Join(',', breadthFirstValues)}\r\n\r\n");
                break;
            case "8":
                var treeHeight = BtTraversal.TreeHeight(binarySearchTree.Root);
                Console.WriteLine($"The Binary Search Tree height is: {treeHeight}\r\n\r\n");
                break;
            case "9":
                Console.WriteLine("The deepest node(s) found with their depth level are:\r\n");
                var nodesFoundWithDepth = new Dictionary<int, int>();
                BtDepthNodeFinder.Find(binarySearchTree.Root, nodesFoundWithDepth);
                if (nodesFoundWithDepth.Count > 0)
                    Console.WriteLine(
                        $"Deepest: {string.Join(',', nodesFoundWithDepth.Select(x => x.Key))} " +
                        $"- Depth: {nodesFoundWithDepth.First().Value}\r\n\r\n");
                else
                    Console.WriteLine("Binary Search Tree was empty.\r\n\r\n");
                break;
            case "10":
                try
                {
                    Console.WriteLine("Please enter a NEW list of comma delimited integers to build a new Binary Search Tree. e.g. '50,25,75,...'\r\n");
                    consoleInput = Console.ReadLine();

                    if (string.Equals("exit", consoleInput1, StringComparison.OrdinalIgnoreCase))
                        Environment.Exit(0);

                    var ints = Array.ConvertAll(consoleInput.Split(','), x => int.Parse(x));
                    binarySearchTree = new BinaryTree(binarySearchTreeIntegers[0]);
                    for (var i = 1; i < binarySearchTreeIntegers.Length; i++)
                        BtValueInserter.InsertNode(binarySearchTreeIntegers[i], binarySearchTree.Root);

                    Console.WriteLine($"Your Binary Search Tree numbers are: {string.Join('-', ints)}. \r\n\r\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Your last input failed to parse as a list.'\r\n");
                    Console.WriteLine("Please Select option 10 again and enter a new list of comma delimited integers to build the Binary Search Tree. e.g. '50,25,75,...'\r\n\r\n");
                }
                break;
            default:
                continue;
        }
    }
}
