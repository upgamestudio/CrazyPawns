using System.Collections.Generic;

namespace Code.Common.Extensions
{
    public static class CollectionExtensions
    {
        private static readonly System.Random random = new System.Random();
        
        public static void Shuffle<T>(this List<T> list)
        {
            var n = list.Count;
        
            while (n > 1)
            {
                n--;
                var k = random.Next(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }
    }
}