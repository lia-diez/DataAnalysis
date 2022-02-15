namespace Data2.tree;

public class Tree
{
    public TreeNode Root { get; set; }
    public TreeNode Head { get; set; }

    public List<LeafNode> LeafNodes { get; set; }

    public Tree()
    {
        Root = new TreeNode();
        Head = Root;
    }

    public void NextLevel(TreeNode node)
    {
        Head.AddChildren(node);
        Head = node;
        if (node is LeafNode leafNode)
        {
            LeafNodes.Add(leafNode);
        }
    }

    public void PreviousLevel()
    {
        Head = Head.Parent ?? throw new Exception("корень сирота...");
    }

    public string[][] GetRecords()
    {
        throw new NotImplementedException();
    }
}