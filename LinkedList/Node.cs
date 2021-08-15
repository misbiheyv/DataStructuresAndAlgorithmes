public class Node
{
    public Node Next;
    public object Data { get; } = null;

    public Node(object data = null)
        => Data = data;

    public override string ToString()
    {
        if (Data == null)
        {
            return "";
        }
        return Data.ToString();
    }
}
