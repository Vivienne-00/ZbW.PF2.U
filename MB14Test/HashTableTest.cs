namespace MB14Test
{
  using MB14;
  using System.Diagnostics;


  [TestClass]
  public class HashTableTest
  {
    [TestMethod]
    public void HashTable_Create_Empty()
    {
      // arrange
      var hashTable = new HashTable<int, string>();

      // act

      // assert
      Assert.AreEqual(0, hashTable.Count);
    }

    [TestMethod]
    public void HashTable_Add_HundredElements()
    {
      // arrange
      var hashTable = CreateHashTable(100);

      // act
      var nineteenNinth = hashTable[99];

      int val = 0;
      foreach (var elem in hashTable)
      {
        // assert
        Assert.AreEqual($"{val}_value", hashTable[val].Value);
        val++;
      }

      Print(hashTable);
    }

    [TestMethod]
    public void HashTable_Remove_ThreeElements()
    {
     // arrange
     var hashTable = CreateHashTable(10);

      // act
      Debug.WriteLine("before remove:");
      Print(hashTable);
      var result = hashTable.Remove(3);

      result = hashTable.Remove(5);
      result = hashTable.Remove(8);

      // assert
      Assert.IsTrue(result);
      Assert.IsFalse(hashTable.ContainsKey(3));
      Debug.WriteLine("after remove:");
      Print(hashTable);
    }

    [TestMethod]
    public void HashTable_Clear_Ok()
    {
      //arrange
     var hashTable = CreateHashTable(50);

      // act
      Debug.WriteLine("before clear:");
      Print(hashTable);
      hashTable.Clear();
      Debug.WriteLine("");
      Debug.WriteLine("after clear:");
      Print(hashTable);

      // assert
      Assert.AreEqual(0, hashTable.Count);
      Assert.AreEqual(11, hashTable.Capacity);

    }


    [TestMethod]
    public void HashTable_Add_TwelveItems()
    {
      // arrange
      var hashTable = new HashTable<int, string>();

      // act
      hashTable.Add(1, "one");
      hashTable.Add(2, "two");
      hashTable.Add(3, "three");
      hashTable.Add(4, "four");
      hashTable.Add(5, "five");
      hashTable.Add(6, "six");
      hashTable.Add(7, "seven");
      hashTable.Add(8, "eight");
      hashTable.Add(9, "nine");
      hashTable.Add(10, "ten");
      hashTable.Add(11, "eleven");
      hashTable.Add(12, "twelve");

      var first = hashTable[1];
      var second = hashTable[2];
      var third = hashTable[3];
      var fourth = hashTable[4];
      var fifth = hashTable[5];
      var sixth = hashTable[6];
      var seventh = hashTable[7];
      var eighth = hashTable[8];
      var nineth = hashTable[9];
      var tenth = hashTable[10];
      var eleventh = hashTable[11];
      var twelvth = hashTable[12];

      Assert.AreEqual("one", first.Value);
      Assert.AreEqual("two", second.Value);
      Assert.AreEqual("three", third.Value);
      Assert.AreEqual("four", fourth.Value);
      Assert.AreEqual("five", fifth.Value);
      Assert.AreEqual("six", sixth.Value);
      Assert.AreEqual("seven", seventh.Value);
      Assert.AreEqual("eight", eighth.Value);
      Assert.AreEqual("nine", nineth.Value);
      Assert.AreEqual("ten", tenth.Value);
      Assert.AreEqual("eleven", eleventh.Value);
      Assert.AreEqual("twelve", twelvth.Value); 

      Print(hashTable);

      // assert
      Assert.AreEqual("twelve", twelvth.Value);
      Assert.AreEqual(12, hashTable.Count);
      Assert.AreEqual(11, hashTable.Capacity);
    }

    private void Print(HashTable<int, string> hashtable)
    {
      Debug.WriteLine(hashtable.ToString());
      Debug.WriteLine($"Count = {hashtable.Count}");
      Debug.WriteLine($"Capacity = {hashtable.Capacity}");
      //Debug.WriteLine($"FillFactor = {(int)(Math.Round(hashtable.FillFactor, 2) * 100)} %");
    }

    private HashTable<int, string> CreateHashTable(int count)
    {
      var hashTable = new HashTable<int, string>();
      int key = 0;

      for (var i = 0; i < count; i++)
      {
        hashTable.Add(key, $"{key}_value");
        key++;
      }

      return hashTable;
    }
  }
}
