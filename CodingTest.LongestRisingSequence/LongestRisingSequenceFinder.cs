using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingTest.LongestRisingSequence
{
    internal class LongestRisingSequenceFinder : ILongestRisingSequenceFinder
    {
        private readonly ISequenceFinderHelper _sequenceFinderHelper;
        private readonly IValidationHelper _validationHelper;
        public LongestRisingSequenceFinder(ISequenceFinderHelper sequenceFinderHelper, IValidationHelper validationHelper)
        {
            _sequenceFinderHelper = sequenceFinderHelper;
            _validationHelper = validationHelper;
        }

        public Task<IEnumerable<int>> Find(IEnumerable<int> numbers) => Task.Run(() =>
        {
            var result = new List<int>();

            if (!_validationHelper.IsValidInput(numbers))
                return result.AsEnumerable();

            var resultSet = new List<List<int>>();
            var subset = new List<int>();

            foreach (var number in numbers)
            {
                if (subset.Count == 0)
                {
                    subset.Add(number);
                    continue;
                }

                if(subset.Count > 0 && number > subset[subset.Count - 1])
                {
                    subset.Add(number);
                    continue;
                }

                if (subset.Count > 0 && number < subset[subset.Count - 1])
                {
                    resultSet.Add(subset);
                    subset = new List<int>
                    {
                        number
                    };
                }
            }
            resultSet.Add(subset);
            result = _sequenceFinderHelper.GetLongestList(resultSet).ToList();
            return result.AsEnumerable();
        });
    }
}
