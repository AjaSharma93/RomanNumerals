using NUnit.Framework;
using FluentAssertions;
using Exercises.Models;
using System.Collections.Generic;

namespace RomanNumerals.Tests
{
    public class RomanNumeralsTests
    {
        private RomanNumeralsConverter romanNumeralsConverter;

        [SetUp]
        public void Setup()
        {
            romanNumeralsConverter = new RomanNumeralsHandler();
        }

        [Test]
        public void OneDigitSuccessTests()
        {
            romanNumeralsConverter.ConvertNumeral("").Should().Be(1);
            romanNumeralsConverter.ConvertNumeral("II").Should().Be(2);
            romanNumeralsConverter.ConvertNumeral("III").Should().Be(3);
            romanNumeralsConverter.ConvertNumeral("IV").Should().Be(4);
            romanNumeralsConverter.ConvertNumeral("V").Should().Be(5);
            romanNumeralsConverter.ConvertNumeral("VI").Should().Be(6);
            romanNumeralsConverter.ConvertNumeral("VII").Should().Be(7);
            romanNumeralsConverter.ConvertNumeral("VIII").Should().Be(8);
            romanNumeralsConverter.ConvertNumeral("IX").Should().Be(9);   
        }

        [Test]
        public void TwoDigitSuccessTests()
        {
            romanNumeralsConverter.ConvertNumeral("X").Should().Be(10);
            romanNumeralsConverter.ConvertNumeral("XI").Should().Be(11);
            romanNumeralsConverter.ConvertNumeral("XII").Should().Be(12);
            romanNumeralsConverter.ConvertNumeral("XIII").Should().Be(13);
            romanNumeralsConverter.ConvertNumeral("XIV").Should().Be(14);
            romanNumeralsConverter.ConvertNumeral("XV").Should().Be(15);
            romanNumeralsConverter.ConvertNumeral("XVI").Should().Be(16);
            romanNumeralsConverter.ConvertNumeral("XVII").Should().Be(17);
            romanNumeralsConverter.ConvertNumeral("XVIII").Should().Be(18);
            romanNumeralsConverter.ConvertNumeral("XIX").Should().Be(19);
            romanNumeralsConverter.ConvertNumeral("XX").Should().Be(20);
            romanNumeralsConverter.ConvertNumeral("XXI").Should().Be(21);
            romanNumeralsConverter.ConvertNumeral("XXII").Should().Be(22);
            romanNumeralsConverter.ConvertNumeral("XXIII").Should().Be(23);
            romanNumeralsConverter.ConvertNumeral("XXIV").Should().Be(24);
            romanNumeralsConverter.ConvertNumeral("XXX").Should().Be(30);
            romanNumeralsConverter.ConvertNumeral("XL").Should().Be(40);
            romanNumeralsConverter.ConvertNumeral("L").Should().Be(50);
            romanNumeralsConverter.ConvertNumeral("LX").Should().Be(60);
            romanNumeralsConverter.ConvertNumeral("LXX").Should().Be(70);
            romanNumeralsConverter.ConvertNumeral("LXXX").Should().Be(80);
            romanNumeralsConverter.ConvertNumeral("XC").Should().Be(90);
            romanNumeralsConverter.ConvertNumeral("C").Should().Be(100);

        }

        [Test]
        public void MiscFailedTests()
        {
            Action act = () => romanNumeralsConverter.ConvertNumeral("Hi There!");

            act.Should().Throw<InvalidOperationException>()
                .WithInnerException<ArgumentException>()
                .WithMessage("Invalid Roman Numeral.");

            Action act = () => romanNumeralsConverter.ConvertNumeral("AI");

            act.Should().Throw<InvalidOperationException>()
                .WithInnerException<ArgumentException>()
                .WithMessage("Invalid Roman Numeral.");
        }

        [Test]
        public void LengthGreaterThan3000FailedTests()
        {
            Action act = () => romanNumeralsConverter.ConvertNumeral("MMMM");

            act.Should().Throw<InvalidOperationException>()
                .WithInnerException<ArgumentException>()
                .WithMessage("Roman numeral greater than 3000");
        }

    }
}