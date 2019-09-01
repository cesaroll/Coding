/*using XUnit;
using Coding.Collections.Generics;

public class LinkedListTests<T> where T : IComparable<T>, IEquatable<T>
{
    [Fact]
    public void AddTest()
    {
        var list = new LinkedList<int>();

        list.Remove(0);
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Remove(1);
        list.Add(4);
        list.Remove(3);
        list.Add(5);
        list.Add(6);
        list.Remove(6);

        // Result should be 2,4,5
        var expected = new int[]{2,4,5};
        int idx =0;

        foreach(int item in list){
            //Assert.Equal(item, expected[idx++]);
        }

    }

}
*/