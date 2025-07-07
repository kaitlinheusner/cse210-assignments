public abstract class Food
{
    protected string _name;
    protected string _description;
    protected int _quantity;

    public Food(string name, string description, int quantity)
    {
        _name = name;
        _description = description;
        _quantity = quantity;
    }
    public void AddToOrder(int desiredQuantity)
        {
            _quantity = desiredQuantity;
        } 

    public abstract string GetFoodDetailsForOrder();
    public abstract string GetFoodDetailsForMenu();
    public abstract void ShowFoodDetailsForOrder();
    public abstract void ShowFoodDetailsForMenu();
}