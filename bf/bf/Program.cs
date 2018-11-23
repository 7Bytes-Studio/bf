/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
using System.Diagnostics;

namespace bf
{
    class Program
    {
        private static int Main(string[] args)
        {
            if (1<=args.Length)
            {
                if ("?"==args[0] || "help"==args[0] || "/help"==args[0])
                {
                    HelpCommand();
                    return 1;
                }
                
                
                
                
                if (2<=args.Length) 
                {
                    if ("new"==args[0]) // bf new unity ProjectName c 
                    {
                        Utility.Project.CheckOrCreateProjectFolder_Windows(args[2],args[1],4<=args.Length?args[3][0].ToString():"d");
                        return 1;
                    }
                    else if ("svn"==args[0]) //bf svn Demo
                    {
                        Utility.Project.CheckOrCreateSvnFolder(args[1],2<=args.Length?args[1][0].ToString():"d");
                        return 1;
                    }
                    
                }
            }
            
          
            
          
            return 0;
        }



        private static void HelpCommand()
        {
            Console.WriteLine("Copyright 2008 Mr-Alan. All rights reserved.");
            Console.WriteLine();
            Console.WriteLine("Options:");
            Console.WriteLine();
            Console.WriteLine("    new [Project Type] [Project Name] [Drive]");
            Console.WriteLine("    svn");
        }


      



    }
}