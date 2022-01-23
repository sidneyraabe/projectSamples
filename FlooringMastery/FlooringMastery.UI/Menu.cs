﻿using FlooringMastery.UI.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI
{
    public static class Menu
    {
        public static void Start()
        {
            while (true)
            {
                
                Console.Clear();
                UIItems.Separator();
                Console.WriteLine(" Flooring Program\n");
                Console.WriteLine(" (1) Display Orders");
                Console.WriteLine(" (2) Add an Order");
                Console.WriteLine(" (3) Edit an Order");
                Console.WriteLine(" (4) Remove an Order");
                Console.WriteLine(" (5) Quit");
                UIItems.Separator();
                Console.Write(" Enter a selection: ");

                string userinput = Console.ReadLine();

                switch (userinput)
                {
                    case "1":
                        DisplayAllOrdersWorkflow displayWorkflow = new DisplayAllOrdersWorkflow();
                        displayWorkflow.Execute();
                        break;
                    case "2":
                        AddOrderWorkflow addWorkflow = new AddOrderWorkflow();
                        addWorkflow.Execute();
                        break;
                    case "3":
                        EditOrderWorkflow editWorkflow = new EditOrderWorkflow();
                        editWorkflow.Execute();
                        break;
                    case "4":
                        RemoveOrderWorkflow removeWorkflow = new RemoveOrderWorkflow();
                        removeWorkflow.Execute();
                        break;
                    case "5":
                        return;
                    default:
                        break;

                }
            }
        }
    }
}
