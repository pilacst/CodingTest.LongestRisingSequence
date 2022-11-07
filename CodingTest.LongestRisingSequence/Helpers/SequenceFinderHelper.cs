using System.Collections.Generic;
using System.Linq;

namespace CodingTest.LongestRisingSequence
{
    public class SequenceFinderHelper : ISequenceFinderHelper
    {
        private readonly IValidationHelper _validationHelper;
        public SequenceFinderHelper(IValidationHelper validationHelper)
        {
            _validationHelper = validationHelper;
        }

        public IList<int> GetLongestList(List<List<int>> results)
        {
            if (!_validationHelper.IsValidInput(results))
                return new List<int>();

            return results.OrderByDescending(item => item.Count).First();
        }
    }
}
