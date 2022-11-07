using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CodingTest.LongestRisingSequence.Tests
{
    public class LongestRisingSequenceFinderTests
    {
        private readonly IValidationHelper _validationHelper;
        private readonly ISequenceFinderHelper _sequenceFinderHelper;
        private readonly Mock<ISequenceFinderHelper> _mockSequenceFinderHelper;
        private readonly Mock<IValidationHelper> _mockValidationHelper;

        public LongestRisingSequenceFinderTests()
        {
            _validationHelper = new ValidationHelper();
            _sequenceFinderHelper = new SequenceFinderHelper(_validationHelper);
            _mockValidationHelper = new Mock<IValidationHelper>();
            _mockSequenceFinderHelper = new Mock<ISequenceFinderHelper>();
        }

        [Fact]
        public async void LongestRisingSequenceFinder_Test_Case_One()
        {
            //Arrange
            var input = new List<int> { 9, 6, 4, 5, 2, 0 };
            var expectedResult = new List<int> { 4, 5 };
            _mockValidationHelper.Setup(x => x.IsValidInput(It.IsAny<List<int>>())).Returns(true);
            var longestRisingSequenceFinder = new LongestRisingSequenceFinder(_sequenceFinderHelper, _mockValidationHelper.Object);

            //Act
            var result = await longestRisingSequenceFinder.Find(input);
 
            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async void LongestRisingSequenceFinder_Test_Case_One_Mock()
        {
            //Arrange
            var input = new List<int> { 9, 6, 4, 5, 2, 0 };
            var expectedResult = new List<int> { 4, 5 };

            _mockSequenceFinderHelper.Setup(x => x.GetLongestList(It.IsAny<List<List<int>>>())).Returns(expectedResult);
            _mockValidationHelper.Setup(x => x.IsValidInput(It.IsAny<List<int>>())).Returns(true);
            var longestRisingSequenceFinder = new LongestRisingSequenceFinder(_mockSequenceFinderHelper.Object, _mockValidationHelper.Object);

            //Act
            var result = await longestRisingSequenceFinder.Find(input);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async void LongestRisingSequenceFinder_Test_Case_Two()
        {
            //Arrange
            var input = new List<int> { 4, 6, -3, 3, 7, 9 };
            var expectedResult = new List<int> { -3, 3, 7, 9 };
            _mockValidationHelper.Setup(x => x.IsValidInput(It.IsAny<List<int>>())).Returns(true);
            var longestRisingSequenceFinder = new LongestRisingSequenceFinder(_sequenceFinderHelper, _mockValidationHelper.Object);

            //Act
            var result = await longestRisingSequenceFinder.Find(input);
            
            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async void LongestRisingSequenceFinder_Test_Case_Two_Mock()
        {
            //Arrange
            var input = new List<int> { 4, 6, -3, 3, 7, 9 };
            var expectedResult = new List<int> { -3, 3, 7, 9 };

            _mockSequenceFinderHelper.Setup(x => x.GetLongestList(It.IsAny<List<List<int>>>())).Returns(expectedResult);
            _mockValidationHelper.Setup(x => x.IsValidInput(It.IsAny<List<int>>())).Returns(true);
            var longestRisingSequenceFinder = new LongestRisingSequenceFinder(_mockSequenceFinderHelper.Object, _mockValidationHelper.Object);

            //Act
            var result = await longestRisingSequenceFinder.Find(input);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async void LongestRisingSequenceFinder_Return_Empty_List_For_Empty_Input()
        {
            //Arrange
            var input = new List<int> { };
            _mockSequenceFinderHelper.Setup(x => x.GetLongestList(It.IsAny<List<List<int>>>())).Returns(new List<int> {});
            _mockValidationHelper.Setup(x => x.IsValidInput(It.IsAny<List<int>>())).Returns(true);
            var longestRisingSequenceFinder = new LongestRisingSequenceFinder(_mockSequenceFinderHelper.Object, _mockValidationHelper.Object);

            //Act
            var result = await longestRisingSequenceFinder.Find(input);

            //Assert
            Assert.True(result.ToList().Count == 0);
        }

        [Fact]
        public async void LongestRisingSequenceFinder_Return_Empty_List_Null_Input()
        {
            //Arrange
            _mockSequenceFinderHelper.Setup(x => x.GetLongestList(It.IsAny<List<List<int>>>())).Returns(new List<int> { });
            _mockValidationHelper.Setup(x => x.IsValidInput(It.IsAny<List<int>>())).Returns(false);
            var longestRisingSequenceFinder = new LongestRisingSequenceFinder(_mockSequenceFinderHelper.Object, _mockValidationHelper.Object);

            //Act
            var result = await longestRisingSequenceFinder.Find(null);

            //Assert
            Assert.True(result.ToList().Count == 0);
        }

        [Fact]
        public async void LongestRisingSequenceFinder_Return_Empty_List_On_Validation_fail()
        {
            //Arrange
            var input = new List<int>();
            _mockSequenceFinderHelper.Setup(x => x.GetLongestList(It.IsAny<List<List<int>>>())).Returns(new List<int> { });
            _mockValidationHelper.Setup(x => x.IsValidInput(It.IsAny<List<int>>())).Returns(false);
            var longestRisingSequenceFinder = new LongestRisingSequenceFinder(_mockSequenceFinderHelper.Object, _mockValidationHelper.Object);

            //Act
            var result = await longestRisingSequenceFinder.Find(input);

            //Assert
            Assert.True(result.ToList().Count == 0);
        }
    }
}
