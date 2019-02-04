// https://github.com/LarsVomMars/Checkboxes
using System;
using System.Collections;
using System.Collections.Generic;

namespace Checkbox
{
    public class Checkbox
    {
        private int index, selectedIndex = -1;
        private bool multi, error, req = true;
        private ConsoleKey k, prevK = ConsoleKey.D9;      
        private List<ArrayList> options = new List<ArrayList>();
            
        
        /// <summary>
        ///     processes given options
        /// </summary>
        /// <param name="opts">all options to display</param>       
        public Checkbox(params string[] opts)
        {
            int i = 0;
            foreach (string opt in opts)
                // structure: option:string; selected:bool; hover:bool; index:int;
                options.Add(new ArrayList {opt, false, false, i++});
            
            options[index][2] = true;
        }
        
        
        /// <summary>
        ///     processes given options
        /// </summary>
        /// <param name="multiMode">allow multiple options to be selected</param>
        /// <param name="opts">all options to display</param>
        public Checkbox(bool multiMode, params string[] opts)
        {
            multi = multiMode;
            int i = 0;
            foreach (string opt in opts)
                // structure: option:string; selected:bool; hover:bool; index:int;
                options.Add(new ArrayList {opt, false, false, i++});
            
            options[index][2] = true;
        }
        
        
        /// <summary>
        ///     processes given options
        /// </summary>
        /// <param name="multiMode">allow multiple options to be selected</param>
        /// <param name="opts">all options to display</param>
        /// <param name="required">is at least one checkbox required to be checked</param>
        public Checkbox(bool multiMode, bool required, params string[] opts)
        {
            req = required;
            multi = multiMode;
            int i = 0;
            foreach (string opt in opts)
                // structure: option:string; selected:bool; hover:bool; index:int;
                options.Add(new ArrayList {opt, false, false, i++});
            
            options[index][2] = true;
        }              
        
        
        /// <summary>
        ///     displays the different options 
        /// </summary>
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("Select {0}one of the options below", multi ? "at least ":"");
            Console.WriteLine("(Use Arrow keys to navigate up and down, Space bar to select and Enter to submit)");
            foreach (var opt in options)
            {
                Console.ForegroundColor = (bool)opt[2] ? ConsoleColor.DarkBlue : (bool)opt[1] ? ConsoleColor.White : ConsoleColor.Gray;
                Console.WriteLine(((bool)opt[1] ? "[*]" : "[ ]") + $" {opt[0]}");
            }
            Console.ResetColor();
            if(error) Console.WriteLine("\nAt least one checkbox has to be checked");
        }

        
        /// <summary>
        ///     switch between the options and select them
        /// </summary>
        public void Select()
        {
            bool end = false;
            // TODO: select and deselect (single)
            // TODO: required
            do
            {
                k = Console.KeyAvailable ? Console.ReadKey(true).Key : ConsoleKey.D9;
                if (k == prevK) continue;

                options[index][2] = false;
                switch (k)
                {
                    case ConsoleKey.UpArrow:
                        index = index - 1 < 0 ? options.Count - 1 : index - 1;
                        break;                    
                    case ConsoleKey.DownArrow:
                        index = index + 1 > options.Count - 1 ? 0 : index + 1;
                        break;                    
                    case ConsoleKey.Spacebar:
                        options[index][1] = !(bool) options[index][1];
                        if (!multi)
                        {
                            if (selectedIndex > -1 && index != selectedIndex) options[selectedIndex][1] = false;
                            selectedIndex = index;
                        }

                        error = false;
                        break;                    
                    case ConsoleKey.Enter:
                        if (req)
                        {                            
                            foreach (var al in options)
                            {
                                if (!(bool) al[1]) continue;
                                end = true;
                                break;
                            }

                            if (!end) error = true;
                        }
                        else end = true;                             
                        break;
                }

                options[index][2] = true;
                Show();

                prevK = k;
            } while (!end);
        }

        
        /// <summary>
        ///     returns selected values
        /// </summary>
        /// <returns>
        ///     all indices and options of selected options as List of ArrayLists
        /// </returns>
        public List<ArrayList> GetStatus()
        {
            List<ArrayList> ret = new List<ArrayList>();

            foreach (var al in options)
                if((bool)al[1]) 
                    ret.Add(new ArrayList {(string)al[0], (int)al[3]});
            
            return ret;
        }
    }
}