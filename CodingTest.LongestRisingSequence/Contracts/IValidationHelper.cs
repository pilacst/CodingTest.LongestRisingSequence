using System.Collections.Generic;

namespace CodingTest.LongestRisingSequence
{
    public interface IValidationHelper
    {
        bool IsValidInput(IEnumerable<int> input);

        bool IsValidInput(List<List<int>> input);
    }
}
