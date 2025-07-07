public abstract class Store
{
    protected string _storeName;
    protected string _storeDescription;
    protected List<Food> _menuItems;

    public Store(string storeName, string storeDescription, List<Food> menuItems)
    {
        _storeName = storeName;
        _storeDescription = storeDescription;
        _menuItems = menuItems;
    }

    public abstract string GetStoreName();
    public abstract void DisplayMenu();
}