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
            if (3<=args.Length) 
            {
                if ("new"==args[0]) // bf new unity ProjectName c 
                {
                    Utility.Project.CheckOrCreateProjectFolder_Windows(args[2],args[1],4<=args.Length?args[3][0].ToString():"d");
                    return 1;
                }
            }
            return 0;
        }
        
    }
}