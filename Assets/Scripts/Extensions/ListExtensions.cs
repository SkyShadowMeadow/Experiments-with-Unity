using System.Collections.Generic;

namespace Extensions
{
    public static class ListExtensions
    {
        public static float Average(this List<float> list)
        {
            float sum = 0f;
            foreach (var number in list)
            {
                sum += number;
            }

            return sum / list.Count;
        }
    }
}
