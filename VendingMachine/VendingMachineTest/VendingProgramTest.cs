using NUnit.Framework;
using VendingMachine;

namespace VendingMachineTest
{
    public class VendingProgramTest
    {
        private int returnTwoMockFunction()
        {
            return 2;
        }

        [Test]
        public void CheckForIntegerTestPositive()
        {
            //Arrange
            var choice = "3";
            //Act
            var t1 = Utils.CheckForInteger(choice, returnTwoMockFunction);

            //Assert
            Assert.AreEqual(t1, 3);

        }

        [Test]
        public void CheckForIntegerTestNegative()
        {
            //Arrange
            var choice = "a";
            //Act
            var t1 = Utils.CheckForInteger(choice, returnTwoMockFunction);

            //Assert
            Assert.AreEqual(t1, 2);

        }

        [Test]
        public void CheckChoicePositiveTest()
        {
            //Arrange
            var choice = 1;
            var numOfChoices = 2;
            //Act
            var t1 = Utils.CheckChoice(choice,numOfChoices, returnTwoMockFunction);

            //Assert
            Assert.AreEqual(t1, 1);

        }

        [Test]
        public void CheckChoicePositiveTestScnerio2()
        {
            //Arrange
            var choice = 1;
            var numOfChoices = 1;
            //Act
            var t1 = Utils.CheckChoice(choice, numOfChoices, returnTwoMockFunction);

            //Assert
            Assert.AreEqual(t1, 1);

        }

        [Test]
        public void CheckChoiceNegativeTest()
        {
            //Arrange
            var choice = 3;
            var numOfChoices = 1;
            //Act
            var t1 = Utils.CheckChoice(choice, numOfChoices, returnTwoMockFunction);

            //Assert
            Assert.AreEqual(t1, 2);

        }

    }
}