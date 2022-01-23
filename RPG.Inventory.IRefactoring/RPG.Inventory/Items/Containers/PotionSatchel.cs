using RPG.Inventory.Items.Containers.Restrictions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Inventory.Items.Containers
{
    public class PotionSatchel : Container
    {
        public PotionSatchel() : base(4)
        {
            Name = "A small potion satchel";
            Description = "This container has small lopps for a few potions.";
            Type = ItemType.Container;
            Weight = 1;

            AddRestriction(new CapacityRestriction());
            AddRestriction(new ItemTypeRestriction(ItemType.Potion));
        }
    }
}
