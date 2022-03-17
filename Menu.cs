using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMenu
{
    struct SubMenu
    {
        public string Value;
        public ConsoleColor TextColor ;

        public SubMenu(string value)
        {
            Value = value;
            TextColor = ConsoleColor.White;
        }

        public SubMenu(string value,ConsoleColor textColor)
        {
            Value = value;
            TextColor = textColor;

        }


    }
    class Menu
    {
        public string Title;
        public List<SubMenu> MenuOptions;
        public int currentSelected = 0;
        public bool enabled = true;
        public ConsoleColor PrimaryColor = ConsoleColor.Blue;
        public ConsoleColor SeccondaryColor = ConsoleColor.Black;
        public Menu(string title, List<SubMenu> subMenu)
        {
            Console.CursorVisible = false;
            Title = title;
            MenuOptions = subMenu;


        }
        public Menu(string title, List<SubMenu> subMenu,ConsoleColor primaryColor)
        {
            Console.CursorVisible = false;
            Title = title;
            MenuOptions = subMenu;
            PrimaryColor = primaryColor;
        }

        public Menu(string title, List<SubMenu> subMenu, ConsoleColor primaryColor, ConsoleColor seccondaryColor)
        {
            Console.CursorVisible = false;
            Title = title;
            MenuOptions = subMenu;
            PrimaryColor = primaryColor;
            SeccondaryColor = seccondaryColor;
        }

 
        public void startMenu()
        {
            Console.clear();
            ListMenu();
            while (enabled)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (key != ConsoleKey.Enter)
                {
                    updatePos(key);
                }
                else
                {
                    enabled = false;
                    getCurrentSelectedValue();
                    Console.BackgroundColor = ConsoleColor.Black;

                    Console.Clear();
                }
            }
        }

        private void ListMenu()
        {
            if (enabled)
            {
                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < MenuOptions.Count; i++) 
                {
                    Console.ForegroundColor = MenuOptions[i].TextColor;
                    if (currentSelected == i)
                    {
                        Console.BackgroundColor = PrimaryColor;

                        Console.WriteLine(MenuOptions[i].Value.PadRight(10));
                        Console.BackgroundColor = SeccondaryColor;
                    }
                    else
                    {
                        Console.WriteLine(MenuOptions[i].Value.PadRight(10));
                    }
                }
                
                Console.SetCursorPosition(0, currentSelected);
            }
            
        }
        public string getCurrentSelectedValue()
        {
            return MenuOptions[currentSelected].Value;
        }
        public void updatePos(ConsoleKey key)
        {
            if (key == (ConsoleKey.UpArrow))
            {
                if (currentSelected > 0)
                {
                    currentSelected = currentSelected - 1;
                }
                
            }
            else if (key == (ConsoleKey.DownArrow))
            {
                if (currentSelected < MenuOptions.Count - 1)
                {
                     currentSelected = currentSelected + 1;
                }
            }
           
            Console.SetCursorPosition(0, currentSelected);
            ListMenu();
            




        }

        
           
    }
}
