using NUnit.Framework;
using Practice.Core;
using System.Collections.Generic;
using Practice1.Core;

namespace Practice.Tests
{
    public class StringHelperTests
    {
        [TestCase("abcdef", "cbafed")]
        [TestCase("hello", "ollehhello")]
        [TestCase("a", "aa")]
        [TestCase("abcde", "edcbaabcde")]
        public void ReverseProcessTest(string inputString, string expectedOutput)
        {
            var actualOutput = StringHelper.ReverseProcess(inputString);
            
            Assert.That(actualOutput, Is.EqualTo(expectedOutput));
        }

        [TestCase("hello", "ollehhello")]
        [TestCase("aeiou", "uoieaaeiou")]
        [TestCase("ouia", "uoai")]
        public void FindLongestVowelSubstringTest(string inputString, string expectedOutput)
        {
            var result = StringHelper.ReverseProcess(inputString);
            var actualOutput = StringHelper.FindLongestVowelSubstring(result);
            
            Assert.That(actualOutput, Is.EqualTo(expectedOutput));
        }

        [TestCase("hello", true, "")]
        [TestCase("1234567890", false, "1234567890")]
        [TestCase("aeiou", true, "")]
        [TestCase("o_uia", false, "_")]
        [TestCase("BCDafg", false, "BCD")]
        public void ValidateStringTest(string inputString, bool expectedIsValid, string expectedInvalidChars)
        {
            var actualIsValid = StringHelper.ValidateString(inputString, out var actualInvalidChars);
            
            Assert.That(actualIsValid, Is.EqualTo(expectedIsValid));
            Assert.That(actualInvalidChars, Is.EqualTo(expectedInvalidChars));
        }

        [TestCase("hello", ExpectedResult = new char[] { 'o', 'o', 'l', 'l', 'l', 'l', 'e', 'e', 'h', 'h' }, TestName = "CountRepeatedCharactersTestTrue")]
        [TestCase("aabbbcc", ExpectedResult = new char[] { 'c', 'c', 'c', 'c', 'b', 'b', 'b', 'b', 'b', 'b', 'a', 'a', 'a', 'a', }, TestName = "CountRepeatedCharactersTrueAgain")]
        public char[] CountRepeatedCharactersTest(string inputString)
        {
            var result = StringHelper.ReverseProcess(inputString);
            var actualResult = StringHelper.CountRepeatedCharacters(result);
            var expectedResult = new List<char>();

            foreach (var pair in actualResult)
            {
                for (int i = 0; i < pair.Value; i++)
                {
                    expectedResult.Add(pair.Key);
                }
            }
            return expectedResult.ToArray();
        }

        [TestCase("hello", "eehhlllloo", "eehhlllloo")]
        [TestCase("aeiou", "aaeeiioouu", "aaeeiioouu")]
        [TestCase("ouia", "aiou", "aiou")]
        public void SortString(string inputString, string expectedOutputQuick, string expectedOutputTree)
        {
            var result = StringHelper.ReverseProcess(inputString);
            var actualOutputQuick = Sort.QuickSort(result);
            var actualOutputTree = Sort.TreeSort(result);

            Assert.That(actualOutputQuick, Is.EqualTo(expectedOutputQuick));
            Assert.That(actualOutputTree, Is.EqualTo(expectedOutputTree));
        }
    }
}