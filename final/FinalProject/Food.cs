public abstract class Food
{
    private string _name;
    private string _description;
    private int _quantity;

    public Food(string name, string description, int quantity)
    {
        _name = name;
        _description = description;
        _quantity = quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetQuantity()
    {
        return _quantity;
    }

    public void SetQuantity(int quantity)
    {
        _quantity = quantity;
    }

    public abstract string GetFoodDetailsForOrder();

    public virtual string GetFoodDetailsForMenu()
    {
        return $"{_name} -- {_description}";
    }

    public virtual void ShowFoodDetailsForOrder()
    {
        Console.WriteLine(GetFoodDetailsForOrder());
    }

    public virtual void ShowFoodDetailsForMenu()
    {
        Console.WriteLine(GetFoodDetailsForMenu());
    }
}