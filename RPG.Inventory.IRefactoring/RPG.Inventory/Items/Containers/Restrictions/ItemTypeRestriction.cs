using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Inventory.Items.Containers.Restrictions
{
    public class ItemTypeRestriction : IItemRestriction
    {
        private ItemType _typeToRestrict;

        public ItemTypeRestriction(ItemType typeToRestrict)
        {
            _typeToRestrict = typeToRestrict;
        }
        public AddItemStatus AddItem(Item itemToAdd, Container container)
        {
            if(itemToAdd.Type != _typeToRestrict)
            {
                return AddItemStatus.ItemWrongType;
            }

            else
            {
                return AddItemStatus.Ok;
            }
        }
    }
}
