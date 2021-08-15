public class LinkedList
{
    private Node _root;

    public Node First => _root;
    
    public int Count { get; set; } = 0;

    public Node Last 
    { 
        get
        {
            Node cur = _root;

            if (cur == null)
                return null;
            
            while (cur.Next != null)
                cur = cur.Next;

            return cur;
        }
    }

    public void Append(object o)
    {
        Node n = new Node(data: o);

        if (_root == null)
            _root = n;
        else
            Last.Next = n;
        Count++;
    }

    public void Delete(object value)
    {

        if (_root.Data == value)
        {
            _root = _root.Next;
             Count--;
        }
        else
        {
            Node cur = _root.Next;
            Node prev = _root;

            while (cur != null)
            {
                if (cur.Data == value)
                {
                    prev.Next = cur.Next;
                    cur.Next = null;
                     Count--;
                    break;
                }

                prev = cur;
                cur = cur.Next;
            }
        }
    }

    public void ShowList()
    {
        Node cur = _root;


        System.Console.WriteLine($"Lenght = {Count}");
        while (cur != null)
        {
            System.Console.WriteLine(cur.Data);
            cur = cur.Next;
        }
    }

    public void Add(int position, object value)
    {
        Node cur = _root;
        position--;

        for (int i = 0; i <= position; i++)
        {
            if (i == position)
            {
                var next = cur.Next;
                cur.Next = new Node( data: value ){ Next = next };
            }

            if (cur.Next != null)
                cur = cur.Next;
        }

        Count++;
    }
}