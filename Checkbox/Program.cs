using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Checkbox
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Console settings
            Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            // string input array
            string[] options = {"first option", "second option", "third option", "fourth option", "fifth option"};

            ////////////////////////////////////////////////////////////
            //// EXAMPLE: SELECT MAX ONE OPTION; SELECTION REQUIRED ////
            ////////////////////////////////////////////////////////////

            // class init            
            Checkbox c1 = new Checkbox("Select one of the following options", options);
            var res1 = c1.Select();

            Console.Clear();

            // example usage: print selected indices and options

            foreach (var checkboxReturn in res1)
            {
                Console.WriteLine(checkboxReturn.Index);
                Console.WriteLine(checkboxReturn.Option);
            }

            Console.ReadKey(true);

            //////////////////////////////////////////////////////////////
            //// EXAMPLE: SELECT MULTIPLE OPTIONS; SELECTION REQUIRED ////
            //////////////////////////////////////////////////////////////

            // class init
            Checkbox c2 = new Checkbox("Select at least one of the following options", true, true, options);
            var res2 = c2.Select();

            Console.Clear();

            // example usage: print selected indices and options

            foreach (var checkboxReturn in res2)
            {
                Console.WriteLine(checkboxReturn.Index);
                Console.WriteLine(checkboxReturn.Option);
            }

            Console.ReadKey(true);

            ///////////////////////////////////////////////////////////////
            //// EXAMPLE: SELECT MAX ONE OPTION; NO SELECTION REQUIRED ////
            ///////////////////////////////////////////////////////////////

            // class init
            Checkbox c3 = new Checkbox("Select one of the following options (optional)", false, false, options);
            var res3 = c3.Select();

            Console.Clear();

            // example usage: print selected indices and options

            foreach (var checkboxReturn in res3)
            {
                Console.WriteLine(checkboxReturn.Index);
                Console.WriteLine(checkboxReturn.Option);
            }

            Console.ReadKey(true);

            /////////////////////////////////////////////////////////////////
            //// EXAMPLE: SELECT MULTIPLE OPTIONS; NO SELECTION REQUIRED ////
            /////////////////////////////////////////////////////////////////

            // class init
            Checkbox c4 = new Checkbox("Select at least one of the following options (optional)", true, false, options);
            var res4 = c4.Select();

            Console.Clear();

            // example usage: print selected indices and options

            foreach (var checkboxReturn in res4)
            {
                Console.WriteLine(checkboxReturn.Index);
                Console.WriteLine(checkboxReturn.Option);
            }

            Console.ReadKey(true);
        }
    }
}