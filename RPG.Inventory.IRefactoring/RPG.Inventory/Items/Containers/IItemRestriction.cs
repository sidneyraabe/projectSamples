using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Inventory.Items.Containers
{
    public interface IItemRestriction
    {
        AddItemStatus AddItem(Item itemToAdd, Container container);
    }
}
