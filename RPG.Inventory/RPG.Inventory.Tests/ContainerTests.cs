using NUnit.Framework;
using RPG.Inventory.Items;
using RPG.Inventory.Items.Containers;
using RPG.Inventory.Items.Potions;
using RPG.Inventory.Items.Weapons;

namespace RPG.Inventory.Tests
{
    public class Tests
    {
        [TestFixture]
        public class ContainerTests
        {
            [Test]
            public void CanAddItemToBackpack()
            {
                Backpack b = new Backpack();
                HealthPotion p = new HealthPotion();

                AddItemStatus actual = b.AddItem(p);
                Assert.AreEqual(AddItemStatus.Success, actual);
            }
            [Test]
            public void CannotAddItemToFullBackpack()
            {
                Backpack b = new Backpack();
                GreatAxe axe = new GreatAxe();

                b.AddItem(axe);
                b.AddItem(axe);
                b.AddItem(axe);
                b.AddItem(axe);

                AddItemStatus actual = b.AddItem(axe);
                Assert.AreEqual(AddItemStatus.BagIsFull, actual);
            }


            [Test]
            public void CanRemoveItemFromBackpack()
            {
                Backpack b = new Backpack();
                HealthPotion p = new HealthPotion();

                b.AddItem(p);

                Item actual = b.RemoveItem();

                //do these two variables reference the same object
                Assert.AreEqual(p, actual);
            }

            [Test]
            public void EmptyBagReturnsNull()
            {
                Backpack b = new Backpack();
                Item item = b.RemoveItem();

                Assert.IsNull(item);
            }

            [Test]
            public void PotionSatchelOnlyAllowsPotions()
            {
                PotionSatchel satchel = new PotionSatchel();
                GreatAxe axe = new GreatAxe();

                AddItemStatus result = satchel.AddItem(axe);
                Assert.AreEqual(AddItemStatus.ItemNotRightType, result);

                HealthPotion potion = new HealthPotion();
                result = satchel.AddItem(potion);
                Assert.AreEqual(AddItemStatus.Success, result);
            }

            [Test]
            public void WeightRestrictedBagRestrictsWeight()
            {
                WetPaperSack sack = new WetPaperSack();
                HealthPotion potion = new HealthPotion();

                Assert.AreEqual(AddItemStatus.Success, sack.AddItem(potion));

                Sword sword = new Sword();
                Assert.AreEqual(AddItemStatus.ItemTooHeavy, sack.AddItem(sword));

                Item item = sack.RemoveItem();
                Assert.AreEqual(AddItemStatus.Success, sack.AddItem(sword));
            }
        }
    }
}