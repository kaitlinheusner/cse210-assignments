using System.Diagnostics;

public class Fraction
{
    private int _topNumber;
    private int _bottomNumber;

    public Fraction()
    {
        _topNumber = 1;
        _bottomNumber = 1;
    }

    public Fraction(int wholeNumber)
    {
        _topNumber = wholeNumber;
        _bottomNumber = 1;
    }

    public Fraction(int topNumber, int bottomNumber)
    {
        _topNumber = topNumber;
        _bottomNumber = bottomNumber;
    }

    public int GetTop()
    {
        return _topNumber;
    }

    public void SetTop(int topNumber)
    {
        _topNumber = topNumber;
    }

    public int GetBottom()
    {
        return _bottomNumber;
    }

    public void SetBottom(int bottomNumber)
    {
        _bottomNumber = bottomNumber;
    }

    public string GetFractionString()
    {
        string fractionText = ($"{_topNumber}/{_bottomNumber}");
        return fractionText;
    }

    public double GetDecimalValue()
    {
        return (double)_topNumber/(double) _bottomNumber;
    }

}