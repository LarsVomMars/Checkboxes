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
            
            ////////////////////////////////////////////////////////////
            //// EXAMPLE: SELECT MAX ONE OPTION; SELECTION REQUIRED ////
            ////////////////////////////////////////////////////////////
                        
            // class init            
            Checkbox c1 = new Checkbox("Select one of the following options", "first option", "second option", "third option", "fourth option", "fifth option");                         
            
            c1.Show();
            c1.Select();
            
            Console.Clear();
            
            // Output
            // format
            List<ArrayList> resCheckbox1 = c1.GetStatus();                       
            
            // example usage: write indices and options to own arrays
            string[] c1Options = new string[resCheckbox1.Count];
            int[] c1Indices = new int[resCheckbox1.Count];

            for (int i = 0; i < resCheckbox1.Count; i++)
            {
                // 0: get option
                // 1: get index
                c1Options[i] = (string)resCheckbox1[i][0];
                c1Indices[i] = (int)resCheckbox1[i][1];
            }
            
            foreach (int i in c1Indices) Console.WriteLine(i);
            foreach (string s in c1Options) Console.WriteLine(s);
            
            
            Console.ReadKey(true);
            
            /////////////////////////////////////////////////////////////////
            //// EXAMPLE: SELECT MULTIPLE OPTIONS; SELECTION REQUIRED ///////
            /////////////////////////////////////////////////////////////////
            
            // class init
            Checkbox c2 = new Checkbox("Select at least one of the following options", true, true, "first option", "second option", "third option", "fourth option", "fifth option");                         
            
            c2.Show();
            c2.Select();            
            
            Console.Clear();
            
            // Output
            // format
            List<ArrayList> resCheckbox2 = c2.GetStatus();                       
            
            // example usage: write indices and options to own arrays
            string[] c2Options = new string[resCheckbox2.Count];
            int[] c2Indices = new int[resCheckbox2.Count];

            for (int i = 0; i < resCheckbox2.Count; i++)
            {
                // 0: get option
                // 1: get index
                c2Options[i] = (string)resCheckbox2[i][0];
                c2Indices[i] = (int)resCheckbox2[i][1];
            }
            
            foreach (int i in c2Indices) Console.WriteLine(i);
            foreach (string s in c2Options) Console.WriteLine(s);        
            
            Console.ReadKey(true);
            
            /////////////////////////////////////////////////////////////////
            //// EXAMPLE: SELECT MAX ONE OPTION; NO SELECTION REQUIRED //////
            /////////////////////////////////////////////////////////////////
            
            // class init
            Checkbox c3 = new Checkbox("Select one of the following options", false, false, "first option", "second option", "third option", "fourth option", "fifth option");                         
            
            c3.Show();
            c3.Select();            
            
            Console.Clear();
            
            // Output
            // format
            List<ArrayList> resCheckbox3 = c3.GetStatus();                       
            
            // example usage: write indices and options to own arrays
            string[] c3Options = new string[resCheckbox3.Count];
            int[] c3Indices = new int[resCheckbox3.Count];

            for (int i = 0; i < resCheckbox3.Count; i++)
            {
                // 0: get option
                // 1: get index
                c3Options[i] = (string)resCheckbox3[i][0];
                c3Indices[i] = (int)resCheckbox3[i][1];
            }
            
            foreach (int i in c3Indices) Console.WriteLine(i);
            foreach (string s in c3Options) Console.WriteLine(s);        
            
            Console.ReadKey(true);
            
            ///////////////////////////////////////////////////////////////////
            //// EXAMPLE: SELECT MULTIPLE OPTIONS; NO SELECTION REQUIRED //////
            ///////////////////////////////////////////////////////////////////
            
            // class init
            Checkbox c4 = new Checkbox("Select at least one of the following options", true, false, "first option", "second option", "third option", "fourth option", "fifth option");                         
            
            c4.Show();
            c4.Select();            
            
            Console.Clear();
            // Output
            // format
            List<ArrayList> resCheckbox4 = c4.GetStatus();                       
            
            // example usage: write indices and options to own arrays
            string[] c4Options = new string[resCheckbox4.Count];
            int[] c4Indices = new int[resCheckbox4.Count];

            for (int i = 0; i < resCheckbox4.Count; i++)
            {
                // 0: get option
                // 1: get index
                c4Options[i] = (string)resCheckbox4[i][0];
                c4Indices[i] = (int)resCheckbox4[i][1];
            }
            
            foreach (int i in c4Indices) Console.WriteLine(i);
            foreach (string s in c4Options) Console.WriteLine(s);  
            Console.ReadKey(true);                        
        }
    }
}