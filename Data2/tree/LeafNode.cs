namespace Data2.tree;

public class LeafNode : TreeNode
{
    public LeafNode(TreeNode? parent = null) : base(null, parent)
    {
    }

    public int Min { get; set; }
    public int Max { get; set; }
    public float Avg { get; set; }
    public int EntryCount { get; set; }
    public int Amount { get; set; }
    public int SuggestedPrice { get; set; }
}
