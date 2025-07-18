public class IndianFood : Food
{
    public IndianFood(string name, string description, int quantity) : base(name, description, quantity)
    {
    }

    public override string GetFoodDetailsForOrder()
    {
        return $"{GetName()}  —  {GetDescription()} — Qty: {GetQuantity()}";
    }
}