using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace WebApi.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CountRepeatedCharacters_InputString_ReturnsExpectedDictionary()
        {
            // Arrange
            string inputString = "Hello, World!";
            Dictionary<char, int> expected = new Dictionary<char, int>()
            {
                {'H', 1},
                {'e', 1},
                {'l', 3},
                {'o', 2},
                {',', 1},
                {' ', 1},
                {'W', 1},
                {'r', 1},
                {'d', 1},
                {'!', 1},
            };

            // Act
            Dictionary<char, int> actual = CharacterCounter.CountRepeatedCharacters(inputString);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
