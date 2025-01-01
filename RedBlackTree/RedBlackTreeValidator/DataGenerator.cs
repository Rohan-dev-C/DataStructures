using System.Collections;

namespace RedBlackTreeValidator
{
    public class DataGenerator : IEnumerable<object[]>
    {
        public int Number; 
        List<int> numbers = new List<int>();
        static Random rand= new Random(42);
        private readonly List<object[]> _data = new List<object[]>
        {
            Enumerable.Repeat(0, 20).Select(x => (object)rand.Next(0, 200)).ToArray()
        };


        
        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}