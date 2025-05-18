using System.Collections;
using System.Text;

namespace MB14
{
  public class HashTable<TKey, TValue> : IEnumerable<Pair<TKey, TValue>>
  {
    private ArrayList<Pair<TKey, TValue>>[] buckets;

    private const int defaultCapacity = 10;

    public int Capacity 
    { 
      get
      { 
        return buckets.Length; 
      } 
    }

    public double LoadFactor
    {
      get
      {
        return 0.0;
      }

    }

    public double OccupationFactor
    {
      get
      {
        return 0.0;
      }
    }

    public int Count { get; private set; }

    public HashTable(int capacity = defaultCapacity)
    {
      var length = CalcPrimeLength(capacity);
      buckets = new ArrayList<Pair<TKey, TValue>>[length];
    }

    public void Add(TKey key, TValue value)
    {

      if (ContainsKey(key))
      {
        throw new ArgumentException($"An item with the same key has already been added. Key {key}");
      }

      var index = GetIndex(key);

      if (buckets[index] == null)
      {
        buckets[index] = new ArrayList<Pair<TKey, TValue>>();
      }

      buckets[index].Add(new Pair<TKey, TValue>(key, value));
      Count++;
    }

    public bool Remove(TKey key)
    {
      if (ContainsKey(key))
      {
        var index = GetIndex(key);

        foreach(var pair in buckets[index])
        {
          if(Equals(pair.Key, key))
          {
            var isRemoved = buckets[index].Remove(pair);

            if(isRemoved)
            {
              Count--;
              return true;
            }
          }
        }
      }

      return false;
    }

    public void Clear()
    {
      buckets = new ArrayList<Pair<TKey, TValue>>[CalcPrimeLength(defaultCapacity)];
      Count = 0;
    }

    public bool ContainsKey(TKey key)
    {
      var index = GetIndex(key);

      if (buckets[index] != null)
      {
        foreach (var pair in buckets[index])
        {
          if (Equals(pair.Key, key))
          {
            return true;
          }
        }
      }

      return false;
    }

    public Pair<TKey,TValue> this[TKey key]
    {
      get
      {
        var index = GetIndex(key);

        foreach (var pair in buckets[index])
        {
          if(Equals(pair.Key, key))
          {
            return pair;
          }
        }

        return default!;
      }
    }

    private int GetIndex(TKey key)
    {
      return Math.Abs(key!.GetHashCode() %  buckets.Length);
    }

    private int CalcPrimeLength(int length)
    {
      while (!IsPrime(++length))
        ;

      return length;
    }

    private bool IsPrime(int number)
    {
      for (int i = 2; i <= number / 2; i++)
        if (number % i == 0)
          return false;

      return true;
    }

    public override string ToString()
    {
      var sb = new StringBuilder();

      for (int i = 0; i < buckets.Length; i++)
      {
        sb.AppendLine($"bucket[{i}]:");

        if( buckets[i] != null )
        {
          foreach (var pair in buckets[i])
          {
            sb.Append($"| Key: {pair.Key} - Value: {pair.Value}");
          }
          sb.Append(" |");
          sb.AppendLine().AppendLine();
        }
      }

      return sb.ToString();
    }

    public IEnumerator<Pair<TKey, TValue>> GetEnumerator()
    {
      foreach(var bucket in buckets)
      {
        foreach (var pair in bucket)
        {
          yield return pair;
        }
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}
