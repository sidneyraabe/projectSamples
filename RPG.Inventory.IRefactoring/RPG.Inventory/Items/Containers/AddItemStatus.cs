using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Inventory.Items.Containers
{
    public enum AddItemStatus
    {
        Ok,
        ContainerFull,
        ItemWrongType,
        ContainerOverweight
    }

}
