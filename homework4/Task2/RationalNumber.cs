using Microsoft.VisualBasic.CompilerServices;

namespace Task2;

public sealed class RationalNumber : IComparable<RationalNumber>
{
    public int Numerator { get; init; }
    public uint Denominator { get; init; }
    public RationalNumber(int numerator, uint denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentNullException(paramName: nameof(denominator),"Wrong value.");
        }

        var gcd = Gcd(Math.Abs(numerator), (int)denominator);
        Numerator = numerator/gcd;
        Denominator = denominator/(uint)gcd;
    }

    public int CompareTo(RationalNumber? otherNum)
    {
        if (otherNum is null)
        {
            throw new ArgumentNullException(nameof(otherNum), "Wrong parameter.");
        }
        var thisValue = (double)Numerator / Denominator;
        var otherValue = (double)otherNum.Numerator / otherNum.Denominator;

        if (thisValue < otherValue)
            return -1;
        return thisValue > otherValue ? 1 : 0;
    }

    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is RationalNumber number)
        {
            return (number.Numerator.Equals(Numerator) && number.Denominator.Equals(Denominator));
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Numerator.GetHashCode() + Denominator.GetHashCode();
    }

    public static RationalNumber operator +(RationalNumber left, RationalNumber right)
    {
        if (left.Denominator == right.Denominator)
        {
            return new RationalNumber(left.Numerator + right.Numerator, left.Denominator);
        }
        var generalDenominator = (uint)(left.Denominator * right.Denominator / Gcd((int)left.Denominator, (int)right.Denominator));
        return new RationalNumber(left.Numerator * (int)(generalDenominator / left.Denominator) + 
                                  right.Numerator * (int)(generalDenominator / right.Denominator), generalDenominator);
    }

    public static RationalNumber operator -(RationalNumber left, RationalNumber right)
    {
        if (left.Denominator == right.Denominator)
        {
            return new RationalNumber(left.Numerator - right.Numerator, left.Denominator);
        }
        var generalDenominator = (uint)(left.Denominator * right.Denominator / Gcd((int)left.Denominator, (int)right.Denominator));
        return new RationalNumber(left.Numerator * (int)(generalDenominator / left.Denominator) -
                                  right.Numerator * (int)(generalDenominator / right.Denominator), generalDenominator);
    }

    public static RationalNumber operator *(RationalNumber left, RationalNumber right)
    {
        return new RationalNumber(left.Numerator * right.Numerator, left.Denominator * right.Denominator);
    }

    public static RationalNumber operator /(RationalNumber left, RationalNumber right)
    {
        if (right.Denominator == 0) throw new InvalidOperationException("Cant divide these numbers");
        return new RationalNumber(left.Numerator*(int)right.Denominator, left.Denominator*(uint)right.Numerator);
    }

    public static implicit operator RationalNumber(int num)
    {
        return new RationalNumber(num, 1);
    }

    public static explicit operator double(RationalNumber num)
    {
        return (double)num.Numerator/num.Denominator;
    }

    //Наибольший общий делитель
    private static int Gcd(int num1, int num2)
    {
        while (num2 != 0)
        {
            var temp = num2;
            num2 = num1 % num2;
            num1 = temp;
        }
        return num1;
    }
}