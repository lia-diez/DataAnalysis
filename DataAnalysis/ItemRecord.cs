namespace DataAnalysis;

public class ItemRecord
{
    public ItemRecord(string name, int field1, int field2)
    {
        Name = name;
        Field1 = field1;
        Field2 = field2;
    }

    public string Name { get; set; }
    public int Field1 { get; set; }
    public int Field2 { get; set; }

    public override string ToString()
    {
        return $"{Name}, {Field1}, {Field2}";
    }
}

