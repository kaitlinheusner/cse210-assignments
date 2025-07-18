public class ArabianFood : Food
{
    public ArabianFood(string name, string description, int quantity) : base(name, description, quantity)
    {
    }

    public override string GetFoodDetailsForOrder()
    {
        return $"{GetName()} | {GetDescription()} | Qty: {GetQuantity()}";
    }
}