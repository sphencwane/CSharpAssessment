using NUnit.Framework;
using Question2;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CSharpAssessmentTest
{
    public class Question2Tests
    {
        [Test]
        public void GivenStringData_Using_GetDuplicatedCharacters_ResultReturnedAreEqual()
        {
            //Arrange
            var data = "Lorem ipsumm dolor sit amet";
            List<StringPosition> expectedResult = new List<StringPosition>();
            expectedResult.Add(new StringPosition() { DuplicatedLetter = 'm', DuplicatedPosition = 10 });

            //Act
            var actualResult = Program.GetDuplicatedCharacters(data);

            //Assert
            Assert.AreEqual(expectedResult[0].DuplicatedLetter, actualResult[0].DuplicatedLetter);
            Assert.AreEqual(expectedResult[0].DuplicatedPosition, actualResult[0].DuplicatedPosition);
        }

        [Test]
        public void GivenStringData_Using_GetDuplicatedCharacters_ResultReturnedAreNotEqual()
        {
            //Arrange
            var data = "Lorem ipsumm dolor sit amet";
            List<StringPosition> expectedResult = new List<StringPosition>();
            expectedResult.Add(new StringPosition { DuplicatedLetter = 'n', DuplicatedPosition = 25 });

            //Act
            var actualResult = Program.GetDuplicatedCharacters(data);

            //Assert
            Assert.AreNotEqual(expectedResult[0].DuplicatedLetter, actualResult[0].DuplicatedLetter);
            Assert.AreNotEqual(expectedResult[0].DuplicatedPosition, actualResult[0].DuplicatedPosition);
        }
    }
}