public class Node<TKey, TValue> 
{
    public TKey Key { get; set; }

    public TValue Value { get; set; }

    public Node(){ }
    
    public Node(TKey key, TValue value)
    {
        Key = key;
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public override int GetHashCode()
    {
        return Key.GetHashCode();
    }
}