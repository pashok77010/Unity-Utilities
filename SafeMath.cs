using System;

public static class SafeMath
{
    public static float SafeAdd(float a, float b)
    {
        try
        {
            return checked(a + b);
        }
        catch (OverflowException)
        {
            return float.MaxValue;
        }
    }

    public static float SafeMultiply(float a, float b)
    {
        try
        {
            return checked(a * b);
        }
        catch (OverflowException)
        {
            return float.MaxValue;
        }
    }
}
