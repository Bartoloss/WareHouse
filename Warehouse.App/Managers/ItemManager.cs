using WareHouse.App.Concrete;
using WareHouse.Domain.Entity;


namespace Warehouse.App.Managers
{
    public class ItemManager
    {
        private readonly MenuActionService _actionService;
        private ItemService _itemService;
        public ItemManager(MenuActionService actionService)
        {
            _itemService = new ItemService();
            _actionService = actionService;
        }
        public int AddNewItem()
        {
            var addNewItemMenu = _actionService.GetMenuActionsByMenuName("AddNewItemMenu");
            Console.WriteLine("Please select item type:");
            for (int i = 0; i < addNewItemMenu.Count; i++)
            {
                Console.WriteLine($"{addNewItemMenu[i].Id}. {addNewItemMenu[i].Name}");
            }

            var operation = Console.ReadKey();
            int typeId;
            Int32.TryParse(operation.KeyChar.ToString(), out typeId);
            Console.WriteLine("Please insert name for item:");
            var name = Console.ReadLine();
            var lastId = _itemService.GetLastId();
            Item item = new Item(lastId + 1, name, typeId);
            _itemService.AddItem(item);
            return item.Id;
        }

        public int RemoveItem()
        {
            Console.WriteLine("Please enter id for item you want to remove:");
            var operation = Console.ReadKey();
            int typeId;
            Int32.TryParse(operation.KeyChar.ToString(), out typeId);

            return typeId;
        }

        public void ViewAllItems()
        {
            List<Item> toShow = new List<Item>();
            Console.WriteLine(toShow.ToStringTable(new[] { "Id", "Name" }, a=> a.Id, a=> a.Name));
            
        }
    }
}
