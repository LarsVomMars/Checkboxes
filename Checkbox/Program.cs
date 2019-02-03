using System;
using System.Collections;
using System.Collections.Generic;
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
            
            ////////////////////////////////////////////////////////////
            //// EXAMPLE: SELECT MAX ONE OPTION; SELECTION REQUIRED ////
            ////////////////////////////////////////////////////////////
                        
            // class init            
            Checkbox c1 = new Checkbox("first option", "second option", "third option", "fourth option", "fifth option");                         
            
            c1.Show();
            c1.Select();
            
            Console.Clear();
            List<ArrayList> resCheckbox1 = c1.GetStatus();
            
            Console.ReadKey(true);
            
            /////////////////////////////////////////////////////////////////
            //// EXAMPLE: SELECT MULTIPLE OPTIONS; SELECTION REQUIRED ///////
            /////////////////////////////////////////////////////////////////
            
            // class init
            Checkbox c2 = new Checkbox(true, true, "first option", "second option", "third option", "fourth option", "fifth option");                         
            
            c2.Show();
            c2.Select();            
            
            Console.Clear();
            List<ArrayList> resCheckbox2 = c2.GetStatus();          
            
            Console.ReadKey(true);
            
            /////////////////////////////////////////////////////////////////
            //// EXAMPLE: SELECT MAX ONE OPTION; NO SELECTION REQUIRED //////
            /////////////////////////////////////////////////////////////////
            
            // class init
            Checkbox c3 = new Checkbox(false, false, "first option", "second option", "third option", "fourth option", "fifth option");                         
            
            c3.Show();
            c3.Select();            
            
            Console.Clear();
            List<ArrayList> resCheckbox3 = c3.GetStatus();          
            
            Console.ReadKey(true);
            
            ///////////////////////////////////////////////////////////////////
            //// EXAMPLE: SELECT MULTIPLE OPTIONS; NO SELECTION REQUIRED //////
            ///////////////////////////////////////////////////////////////////
            
            // class init
            Checkbox c4 = new Checkbox(true, false, "first option", "second option", "third option", "fourth option", "fifth option");                         
            
            c4.Show();
            c4.Select();            
            
            Console.Clear();
            List<ArrayList> resCheckbox4 = c4.GetStatus();          
            
            Console.ReadKey(true);
            
            
        }
    }
}