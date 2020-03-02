namespace Content
{
    public interface Iterator
    {
        bool HasNext();
        string MoveNext();
        void Reset();
    }
}
