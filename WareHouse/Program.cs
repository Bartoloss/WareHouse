
using Warehouse.App.Abstract;
using Warehouse.App.Managers;
using WareHouse;
using WareHouse.App.Concrete;
using WareHouse.Domain.Entity;

namespace Warehouse
{
    public class Program
    {
        private static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();
            ItemService itemService = new ItemService();
            ItemManager itemManager = new ItemManager(actionService);


            Console.WriteLine("Welcome to warehouse app!");
            while (true)
            {
                Console.WriteLine("Please let me know what you want to do:");
                var mainMenu = actionService.GetMenuActionsByMenuName("Main");
                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
                }

                var operation = Console.ReadKey();
                switch (operation.KeyChar)
                {
                    case '1':
                        var newId = itemManager.AddNewItem();
                        break;
                    case '2':
                        var removeId = itemManager.RemoveItem();
                        break;
                    //case '3':
                    //    var detailId = itemService.ItemDetailSelectionView();
                    //    itemService.ItemDetailView(detailId);
                    //    break;
                    //case '4':
                    //    var typeId = itemService.ItemTypeSelectionView();
                    //    itemService.ItemsByTypeIdView(typeId);
                    //    break;
                    default:
                        Console.WriteLine("Action you entered does not exist");
                        break;
                }
            }
        }
    }
}