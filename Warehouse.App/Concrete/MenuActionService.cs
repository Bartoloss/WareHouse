using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.App.Common;
using WareHouse.Domain.Entity;

namespace WareHouse.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService()
        {
            Initialize();
        }
        
        public List<MenuAction> GetMenuActionsByMenuName (string menuName)
        {
            List<MenuAction> result = new List<MenuAction>();
            foreach (var menuAction in Items)
            {
                if (menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
            }
            return result;
        }


        private void Initialize()
        {
            AddItem(new MenuAction(1, "Add item", "Main"));
            AddItem(new MenuAction(2, "Remove item", "Main"));
            AddItem(new MenuAction(3, "Show details", "Main"));
            AddItem(new MenuAction(4, "List of Items", "Main"));

            AddItem(new MenuAction(1, "Tshirts", "AddNewItemMenu"));
            AddItem(new MenuAction(2, "Hoodies", "AddNewItemMenu"));
            AddItem(new MenuAction(3, "Gadgets", "AddNewItemMenu"));
        
        }
    }
}
