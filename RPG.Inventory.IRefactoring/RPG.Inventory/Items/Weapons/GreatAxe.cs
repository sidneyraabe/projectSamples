using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Inventory.Items.Weapons
{
    public class GreatAxe : Item
    {
        public GreatAxe()
        {
            Name = "Great Axe";
            Description = "Heavy weapon, hits with great force";
            Weight = 6;
            Type = ItemType.Weapon;
        }
    }
}
