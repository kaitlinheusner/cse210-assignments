public class ArabianFood : Food
{
    public ArabianFood(string name, string description, int quantity) : base(name, description, quantity)
    {
    }

    public override string GetFoodDetailsForOrder()
    {
        return $"{_name} -- {_description} -- x {_quantity}";
    }

    public override string GetFoodDetailsForMenu()
    {
        return $"{_name} -- {_description}";
    }

    public override void ShowFoodDetailsForOrder()
    {
        Console.WriteLine(GetFoodDetailsForOrder());
    }

    public override void ShowFoodDetailsForMenu()
    {
        Console.WriteLine(GetFoodDetailsForMenu());
    }
}