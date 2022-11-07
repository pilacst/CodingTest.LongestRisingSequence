using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodingTest.LongestRisingSequence
{
    public interface ILongestRisingSequenceFinder {
        Task<IEnumerable<int>> Find(IEnumerable<int> numbers);
    }
}