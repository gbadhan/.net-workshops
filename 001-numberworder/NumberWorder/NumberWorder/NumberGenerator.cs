using System;
using System.Collections.Generic;

namespace NumberWorder
{
    public class NumberGenerator
    {
        private Dictionary<int, string> numberWords;
        public NumberGenerator()
        {
            numberWords = new Dictionary<int, string>();
            numberWords.Add(0, "ZERO");
            numberWords.Add(1, "ONE");
            numberWords.Add(2, "TWO");
            numberWords.Add(3, "THREE");
            numberWords.Add(4, "FOUR");
            numberWords.Add(5, "FIVE");
            numberWords.Add(6, "SIX");
            numberWords.Add(7, "SEVEN");
            numberWords.Add(8, "EIGHT");
            numberWords.Add(9, "NINE");
        }
        private string GetWord(long number)
        {            
            return numberWords[(int)number];
        }

        public string[] GetConvertedNumberArray(long number, string[] numberArray, int index)
        {
            numberArray[index] = GetWord(number % 10);
            if (number <= 9)
            {
                return numberArray;
            }

            return GetConvertedNumberArray(number / 10, numberArray, index - 1);
        }
    }
}
