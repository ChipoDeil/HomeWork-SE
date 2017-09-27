using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EquationSolderTest
{
    [TestClass]
    public class EquationSolderTest
    {
        [TestMethod]
        public void Coefs_IsDicriminantRight()
        {
            //Arrange
            int[] coefs = new int[]{1,3,1};
            int expected = 5;
            //Act
            int dicriminant = EquationSolder.EquationSolder.CalcDiscriminant(coefs);
            //Assert
            Assert.AreEqual(expected, dicriminant);
        }
        [TestMethod]
        public void RightLine_IsParsingCoefsRight()
        {
            //Arrange
            String line = "-6x^2+6x+6=0";
            int[] expected = new int[3] { -6, 6, 6 }; 
            //Act
            int[] arrayOfCoefs = EquationSolder.EquationSolder.ParseString(line);
            //Assert
            Assert.AreEqual(expected[0], arrayOfCoefs[0]);
            Assert.AreEqual(expected[1], arrayOfCoefs[1]);
            Assert.AreEqual(expected[2], arrayOfCoefs[2]);
        }

        [TestMethod]
        public void RightLineWithBigCoefs_IsParsingCoefsRight()
        {
            //Arrange
            String line = "1233x^2+-611x+633=0";
            int[] expected = new int[3] { 1233, -611, 633};
            //Act
            int[] arrayOfCoefs = EquationSolder.EquationSolder.ParseString(line);
            //Assert
            Assert.AreEqual(expected[0], arrayOfCoefs[0]);
            Assert.AreEqual(expected[1], arrayOfCoefs[1]);
            Assert.AreEqual(expected[2], arrayOfCoefs[2]);
        }

        [TestMethod]
        public void WrongLine_IsParsingCorrect()
        {
            //Arrange
            String line = "-6x^3+6x+6=0";
            //Act
            int[] arrayOfCoefs = EquationSolder.EquationSolder.ParseString(line);
            //Assert
            Assert.AreEqual(null, arrayOfCoefs);
        }

        [TestMethod]
        public void RightLine_IsParsingCorrect()
        {
            //Arrange
            String line = "113x^2+43x+12=0";
            //Act
            int[] arrayOfCoefs = EquationSolder.EquationSolder.ParseString(line);
            bool isArrayEmpty = arrayOfCoefs.Length == 0;
            //Assert
            Assert.IsFalse(isArrayEmpty);
        }

        [TestMethod]
        public void NegativeDicriminant_IsValidationRight()
        {
            //Arrange
            int dicriminant = -10;
            //Act
            bool isValid = EquationSolder.EquationSolder.ValidateDiscriminant(dicriminant);
            //Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void PositiveDicriminant_IsValidationRight()
        {
            //Arrange
            int dicriminant = 100;
            //Act
            bool isValid = EquationSolder.EquationSolder.ValidateDiscriminant(dicriminant);
            //Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void ZeroDicriminant_IsValidationRight()
        {
            //Arrange
            int dicriminant = 0;
            //Act
            bool isValid = EquationSolder.EquationSolder.ValidateDiscriminant(dicriminant);
            //Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void DataForCalcingRoot_IsRootRight()
        {
            //Arrange
            int discriminant = 4;
            int[] coefs = new int[3] {-1,12,-35};
            double expectedRoot = 5.0f;
            //Act
            double root = EquationSolder.EquationSolder.CalcRoots(discriminant, coefs, true);
            //Assert
            Assert.AreEqual(expectedRoot, root);
        }


    }
}
