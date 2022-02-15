namespace Data2.tree;

public class LeafNode : TreeNode
{
    public LeafNode(TreeNode? parent = null) : base(null, parent)
    {
    }

    public float Min { get; set; }
    public float Max { get; set; }
    public float Avg { get; set; }
    public int EntryCount { get; set; }
    public int Amount { get; set; }
    public float SuggestedPrice { get; set; }
}
