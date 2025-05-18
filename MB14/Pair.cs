namespace MB14
{
  public class Pair<TKey, TValue>
  {
    public TKey Key { get; private set; }

    public TValue Value { get; set; }

    public Pair(TKey key, TValue value)
    {
      Key = key;
      Value = value;
    }
  }
}
