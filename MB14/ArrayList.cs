namespace MB14
{
  using System.Collections;
  using System.Text;

  public class ArrayList<T> : IEnumerable<T>
  {
    protected T[] items;

    private int initLength = 4;

    public int Count { get; private set; }

    public ArrayList()
    {
      items = new T[initLength];
    }

    public virtual void Add(T item)
    {
      Grow();

      items[Count] = item;

      Count++;
    }

    public virtual void AddRange(T[] items)
    {
      foreach (T item in items)
      {
        Add(item);
      }
    }

    private void Grow()
    {
      if (items.Length >= Count + 1)
        return;

      Array.Resize(ref items, items.Length * 2);
    }

    public bool Contains(T item)
    {
      return Find(item) != null;
    }

    public virtual bool Remove(T item)
    {
      //var index = 0;
      //foreach(object element in items)
      //{
      //  if(element.Equals(item))
      //  {
      //    RemoveByIndex(index);
      //  }
      //  index++;
      //}
      for (var i = 0; i < items.Length; i++)
      {
        if (items[i] != null && Equals(items[i], item))
        {
          RemoveByIndex(i);
          return true;
        }
      }
      return false;
    }

    public T Find(T item)
    {
      foreach (T element in items)
      {
        if (element != null && Equals(element, item))
        {
          return element;
        }
      }
      return default(T)!;
    }

    public virtual T this[int index]
    {
      get 
      { 
        if(index < 0 || index >= items.Length)
        {
          throw new IndexOutOfRangeException("Index was out of range.");
        }

        return items[index];
      }

      set
      {
        if (index < 0 || index >= items.Length)
        {
          throw new IndexOutOfRangeException("Index was out of range.");
        }

        items[index] = value;
      }
    }

    private void RemoveByIndex(int index)
    {
      int destinationIndex = index;
      int sourceIndex = destinationIndex + 1;
      int elementCount = items.Length - sourceIndex;

      /*
       * Count = 7
       * RemoveAt 3
       * sourceIndex = 3
       * destinationIndex = 4
       * elementCount = 7 - (3 + 1) = 3
       * +----+----+----+----+----+----+----+
       * | 23 | 12 |  7 | 8  | 10 | 0  | 2  |
       * +----+----+----+----+----+----+----+
       *   0    1    2    3    4    5    6
       *   
       * +----+----+----+----+----+----+----+
       * | 23 | 12 |  7 |  <-- 10 | 0  | 2  |
       * +----+----+----+----+----+----+----+
       *   0    1    2    3    4    5    6
       *   
       *   
       */

      Array.Copy(items, sourceIndex, items, destinationIndex, elementCount);
      Count--;
      items[Count] = default(T);
    }

    public override string ToString()
    {
      var sb  = new StringBuilder();

      sb.Append(string.Join(string.Empty, Enumerable.Repeat($"+----", items.Length)));
      sb.AppendLine("+");
      for (var i = 0; i < items.Length; i++)
      {
        sb.Append($"| {items[i],2} ");

      }
      sb.AppendLine("|");
      sb.Append(string.Join(string.Empty, Enumerable.Repeat($"+----", items.Length)));
      sb.AppendLine("+");
      return sb.ToString();
    }

    public IEnumerator<T> GetEnumerator()
    {
      for(var i = 0; i < Count; i++)
      {
        yield return items[i];
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}
