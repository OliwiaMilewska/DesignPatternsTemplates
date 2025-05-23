using Iterator;

var root = new TreeNode<string>("A");
var b = new TreeNode<string>("B");
var c = new TreeNode<string>("C");
var d = new TreeNode<string>("D");
var e = new TreeNode<string>("E");
var f = new TreeNode<string>("F");

root.AddChild(b);
root.AddChild(c);
b.AddChild(d);
b.AddChild(e);
c.AddChild(f);

Console.WriteLine("Tree structure:");
root.PrintTree();

Console.WriteLine("DFS:");
foreach (var item in root.GetDfsEnumerable())
    Console.WriteLine(item);

Console.WriteLine("\nBFS:");
foreach (var item in root.GetBfsEnumerable())
    Console.WriteLine(item);

Console.ReadKey();