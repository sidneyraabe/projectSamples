using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Inventory.Items.Weapons
{
    public class Sword : Item
    {
        public Sword()
        {
            Name = "A wooden sword";
            Description = "It's dangerous to go alone... take this!";
            Weight = 3;
            Type = ItemType.Weapon;
        }
    }
}
