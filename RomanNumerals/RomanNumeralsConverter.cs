using System.Text.RegularExpressions; 

namespace RomanNumerals;
public class RomanNumeralsConverter
{
    public int ConvertNumeral(string romanNumeral){
        if(!IsRomanNumeralValid(romanNumeral)) throw new ArgumentException("Invalid Roman Numeral.");
        return 0;
    }

    private bool IsRomanNumeralValid(string romanNumeral){
        return Regex.IsMatch(romanNumeral, "^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$", RegexOptions.IgnoreCase);
    }

}
