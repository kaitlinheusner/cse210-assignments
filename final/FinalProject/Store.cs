public abstract class Store
{
    private string _storeName;
    private string _storeDescription;
    protected List<Food> _menuItems;

    public Store(string storeName, string storeDescription, List<Food> menuItems)
    {
        _storeName = storeName;
        _storeDescription = storeDescription;
        _menuItems = menuItems;
    }

    public List<Food> GetMenuItems()
    {
        return _menuItems;
    }

    public virtual string GetStoreName()
    {
        return _storeName;
    }

    public virtual string GetStoreDescription()
    {
        return _storeDescription;
    }

    public abstract void DisplayMenu();
}