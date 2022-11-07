using Moq;
using System.Collections.Generic;
using Xunit;

namespace CodingTest.LongestRisingSequence.Tests
{
    public class SequenceFinderHelperTest
    {
        private readonly IValidationHelper _validationHelper;
        private readonly ISequenceFinderHelper _isequenceFinderHelper;
        private readonly Mock<IValidationHelper> _mockValidationHelper;

        public SequenceFinderHelperTest()
        {
            _validationHelper = new ValidationHelper();
            _isequenceFinderHelper = new SequenceFinderHelper(_validationHelper);
            _mockValidationHelper = new Mock<IValidationHelper>();
        }

        [Fact]
        public void SequenceFinderHelper_Return_Not_Empty_List_Result()
        {
            //Arrange
            var input1 = new List<int> { 1, 2, 3, 4, 5 };
            var input2 = new List<int> { 4, 5, 8, 2, 1, 1 };
            var input3 = new List<int> { 4, 5 };
            var listOfInput = new List<List<int>> { input1, input2, input3 };
            _mockValidationHelper.Setup(x => x.IsValidInput(It.IsAny<List<List<int>>>())).Returns(true);
            var isequenceFinderHelper = new SequenceFinderHelper(_mockValidationHelper.Object);

            //Act
            var result = isequenceFinderHelper.GetLongestList(listOfInput);

            //Assert
            Assert.True(result.Count > 0);
        }

        [Fact]
        public void SequenceFinderHelper_Return_Empty_List_For_Null_Input()
        {
            //Arrange
            var listOfInput = new List<List<int>> { };
            _mockValidationHelper.Setup(x => x.IsValidInput(It.IsAny<List<List<int>>>())).Returns(false);
            var isequenceFinderHelper = new SequenceFinderHelper(_mockValidationHelper.Object);

            //Act
            var result = isequenceFinderHelper.GetLongestList(listOfInput);

            //Assert
            Assert.True(result.Count == 0);
        }

        [Fact]
        public void SequenceFinderHelper_Return_Empty_List_For_Empty_Internal_List()
        {
            //Arrange
            var input1 = new List<int>();
            var input2 = new List<int>();
            var inputCollection = new List<List<int>> { input1, input2 };
            _mockValidationHelper.Setup(x => x.IsValidInput(It.IsAny<List<List<int>>>())).Returns(true);
            var isequenceFinderHelper = new SequenceFinderHelper(_mockValidationHelper.Object);

            //Act
            var result = isequenceFinderHelper.GetLongestList(inputCollection);

            //Assert
            Assert.True(result.Count == 0);
        }

        [Fact]
        public void SequenceFinderHelper_Return_Empty_List_For_Null_Internal_List()
        {
            //Arrange
            List<int> input1 = null;
            List<int> input2 = null;
            var inputCollection = new List<List<int>> { input1, input2 };
            _mockValidationHelper.Setup(x => x.IsValidInput(It.IsAny<List<List<int>>>())).Returns(false);
            var isequenceFinderHelper = new SequenceFinderHelper(_mockValidationHelper.Object);

            //Act
            var result = isequenceFinderHelper.GetLongestList(inputCollection);

            //Assert
            Assert.True(result.Count == 0); ;
        }

        [Fact]
        public void SequenceFinderHelper_Return_Result()
        {
            //Arrange
            var input1 = new List<int> { 1, 2, 3, 4, 5 };
            var input2 = new List<int> { 4, 5, 8, 2, 1, 1 };
            var input3 = new List<int> { 4, 5 };
            var listOfInput = new List<List<int>> { input1, input2, input3 };
            _mockValidationHelper.Setup(x => x.IsValidInput(It.IsAny<List<List<int>>>())).Returns(true);
            var isequenceFinderHelper = new SequenceFinderHelper(_mockValidationHelper.Object);

            //Act
            var result = isequenceFinderHelper.GetLongestList(listOfInput);

            //Assert
            Assert.True(result.Count > 0);
        }
    }
}
