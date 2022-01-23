using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Inventory.Items.Containers.Restrictions
{
    // Decides whether the bag is full or not
    public class CapacityRestriction : IItemRestriction
    {
        public AddItemStatus AddItem(Item itemToAdd, Container container)
        {
            if (container.Capacity == container.CurrentIndex)
            {
                return AddItemStatus.ContainerFull;
            }
            else
            {
                return AddItemStatus.Ok;
            }
        }
    }
}
