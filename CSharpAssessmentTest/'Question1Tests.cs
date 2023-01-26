using NUnit.Framework;
using Question1;
using System;
using System.Globalization;

namespace CSharpAssessmentTest
{
    public class Question1Tests
    {
        [Test]
        public void GivenStringIDNumber_Using_ExtractDateOfBirth_ResultReturnedAreEqual()
        {
            //Arrange
            var idNumber = "7508305802089";
            DateTime expectedResult = DateTime.ParseExact("750830", "yyMMdd", CultureInfo.InvariantCulture);

            //Act
            var actualResult = Program.ExtractDateOfBirth(idNumber);

            //Assert
            Assert.AreEqual(expectedResult,actualResult);
        }

        [Test]
        public void GivenStringIDNumber_Using_ExtractGender_ResultReturnedAreEqual()
        {
            //Arrange
            var idNumber = "7508305802089";
            var expectedResult = "Male";

            //Act
            var actualResult = Program.ExtractGender(idNumber);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GivenStringIDNumber_Using_ExtractGender_ResultReturnedAreNotEqual()
        {
            //Arrange
            var idNumber = "7508303802089";
            var expectedResult = "Male";

            //Act
            var actualResult = Program.ExtractGender(idNumber);

            //Assert
            Assert.AreNotEqual(expectedResult, actualResult);
        }

        [Test]
        public void GivenStringIDNumber_Using_IsSouthAfricanCitizen_ResultReturnedTrue()
        {
            //Arrange
            var idNumber = "7508305802089";

            //Act
            var actualResult = Program.IsValidIDNumber(idNumber);

            //Assert
            Assert.IsTrue(actualResult);
        }

        [Test]
        public void GivenStringIDNumber_Using_IsSouthAfricanCitizen_ResultReturnedFalse()
        {
            //Arrange
            var idNumber = "7508305802389";

            //Act
            var actualResult = Program.IsValidIDNumber(idNumber);

            //Assert
            Assert.IsFalse(actualResult);
        }

        [Test]
        public void GivenStringIDNumber_Using_IsValidIDNumber_ResultReturnedTrue()
        {
            //Arrange
            var idNumber = "7508305802089";

            //Act
            var actualResult = Program.IsValidIDNumber(idNumber);

            //Assert
            Assert.IsTrue(actualResult);
        }

        [Test]
        public void GivenStringIDNumber_Using_IsValidIDNumber_ResultReturnedFalse()
        {
            //Arrange
            var idNumber = "750830580208912";

            //Act
            var actualResult = Program.IsValidIDNumber(idNumber);

            //Assert
            Assert.IsFalse(actualResult);
        }
    }
}