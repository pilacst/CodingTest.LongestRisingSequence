using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CodingTest.LongestRisingSequence.Tests
{
    public class ValidationHelperTest
    {
        private readonly IValidationHelper _validationHelper;

        public ValidationHelperTest()
        {
            _validationHelper = new ValidationHelper();
        }

        [Theory]
        [InlineData(null)]
        public void ValidationHelper_Retrun_False_For_Null_Input(IEnumerable<int> input)
        {
            //Act
            var result = _validationHelper.IsValidInput(input);

            //Assert
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData(null)]
        public void ValidationHelper_Retrun_False_For_Null_List_Of_List(List<List<int>> input)
        {
            //Act
            var result = _validationHelper.IsValidInput(input);

            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ValidationHelper_Retrun_False_For_Empty_Input()
        {
            //Arrange
            var input = new List<int>();

            //Act
            var result = _validationHelper.IsValidInput(input);

            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ValidationHelper_Retrun_False_For_Empty_Input_For_List_Of_List()
        {
            //Arrange
            var input = new List<List<int>>();

            //Act
            var result = _validationHelper.IsValidInput(input);

            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ValidationHelper_Retrun_False_For_Null_Second_List_Input_For_List_Of_List()
        {
            //Arrange
            List<int> input1 = null;
            List<int> input2 = null;
            List<List<int>> inputCollection = new List<List<int>> { input1, input2 };

            //Act
            var result = _validationHelper.IsValidInput(inputCollection);

            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ValidationHelper_Retrun_False_For_Empty_Second_List_Input_For_List_Of_List()
        {
            //Arrange
            List<int> input1 = new List<int>();
            List<int> input2 = new List<int>();
            List<List<int>> inputCollection = new List<List<int>> { input1, input2 };

            //Act
            var result = _validationHelper.IsValidInput(inputCollection);

            //Assert
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData(new[] {1, 2, 3 })]
        public void ValidationHelper_Retrun_True_For_Valid_Input(IEnumerable<int> input)
        {
            //Act
            var result = _validationHelper.IsValidInput(input);

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ValidationHelper_Retrun_True_For_Valid_Input_For_List_Of_List()
        {
            //Arrange
            var input1 = new List<int> { 1, 2, 3, 4, 5 };
            var input2 = new List<int> { 4, 5, 8, 2, 1, 1 };
            var input3 = new List<int> { 4, 5 };
            var listOfInput = new List<List<int>> { input1, input2, input3 };

            //Act
            var result = _validationHelper.IsValidInput(listOfInput);

            //Assert
            result.Should().BeTrue();
        }
    }
}
