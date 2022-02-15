namespace Data2.tree;

public class TreeNode
{
    public TreeNode(string? value = null, TreeNode? parent = null)
    {
        Value = value;
        Parent = parent;
        Children = new List<TreeNode>();
    }

    public TreeNode? Parent { get; set; }
    public string? Value { get; set; }

    public List<TreeNode> Children;

    public void AddChildren(TreeNode node)
    {
        Children.Add(node);
        node.Parent = this;
    }
}