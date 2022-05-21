using System.Text.RegularExpressions;

namespace RomanNumerals;
public class RomanNumeralsConverter
{
    private static Dictionary<char, int> RomanMap = new Dictionary<char, int>()
    {
        {'I', 1},
        {'V', 5},
        {'X', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'M', 1000}
    };
    public int ConvertNumeral(string romanNumeral)
    {
        if (!IsRomanNumeralValid(romanNumeral)) throw new ArgumentException("Invalid Roman Numeral.");
        int number = 0;
        int thousandCount = 0;
        for (int i = 0; i < romanNumeral.Length; i++)
        {
            if(thousandCount==3 && romanNumeral.Length>3) throw new ArgumentException("Roman numeral greater than 3000");
            if(romanNumeral[i]=='M') thousandCount++;
            if (i + 1 < romanNumeral.Length && RomanMap[romanNumeral[i]] < RomanMap[romanNumeral[i + 1]])
            {
                number -= RomanMap[romanNumeral[i]];
            }
            else
            {
                number += RomanMap[romanNumeral[i]];
            }
        }
        return number;
    }


    private bool IsRomanNumeralValid(string romanNumeral)
    {
        return Regex.IsMatch(romanNumeral, "^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$", RegexOptions.IgnoreCase);
    }

}
