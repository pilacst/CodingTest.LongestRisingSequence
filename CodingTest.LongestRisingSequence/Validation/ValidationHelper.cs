using System.Collections.Generic;
using System.Linq;

namespace CodingTest.LongestRisingSequence
{
    public class ValidationHelper: IValidationHelper
    {
        public bool IsValidInput(IEnumerable<int> input)
        {
            if (input is null)
                return false;

            if (input.Count() <= 0)
                return false;

            return true;
        }

        public bool IsValidInput(List<List<int>> input)
        {
            if (input is null)
                return false;

            if (input.Count() <= 0)
                return false;

            if (input.Count() >= 0 && input.Where(item => item == null).Count() == input.Count)
                return false;

            if (input.Count() >= 0 && input.Where(item => item?.Count <= 0).Count() == input.Count)
                return false;

            return true;
        }
    }
}
