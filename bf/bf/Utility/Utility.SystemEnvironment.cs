/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace bf
{
    public sealed partial class Utility
    {

        private static class _SystemEnvironment
        {
            /// <summary>
            /// 获取系统环境变量
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            public static string GetSysEnvironmentByName(string name)
            {
                string result = string.Empty;
                try
                {
                    result = OpenSysEnvironment().GetValue(name).ToString();//读取
                }
                catch (Exception)
                {
        
                    return string.Empty;
                }
                return result;
        
            }
        
            /// <summary>
            /// 打开系统环境变量注册表
            /// </summary>
            /// <returns>RegistryKey</returns>
            private static RegistryKey OpenSysEnvironment()
            {
                RegistryKey regLocalMachine = Registry.LocalMachine;
                RegistryKey regSYSTEM = regLocalMachine.OpenSubKey("SYSTEM", true);//打开HKEY_LOCAL_MACHINE下的SYSTEM 
                RegistryKey regControlSet001 = regSYSTEM.OpenSubKey("ControlSet001", true);//打开ControlSet001 
                RegistryKey regControl = regControlSet001.OpenSubKey("Control", true);//打开Control 
                RegistryKey regManager = regControl.OpenSubKey("Session Manager", true);//打开Control 
        
                RegistryKey regEnvironment = regManager.OpenSubKey("Environment", true);
                return regEnvironment;
            }
        
            /// <summary>
            /// 设置系统环境变量
            /// </summary>
            /// <param name="name">变量名</param>
            /// <param name="strValue">值</param>
            public static void SetSysEnvironment(string name, string strValue)
            {
                OpenSysEnvironment().SetValue(name, strValue);
        
            }
        
            /// <summary>
            /// 检测系统环境变量是否存在
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            public static bool CheckSysEnvironmentExist(string name)
            {
                if (!string.IsNullOrEmpty(GetSysEnvironmentByName(name)))
                    return true;
                else
                    return false;
            }
        
            /// <summary>
            /// 添加到PATH环境变量（会检测路径是否存在，存在就不重复）
            /// </summary>
            /// <param name="strPath"></param>
            public static void SetPathAfter(string strHome)
            {
                string pathlist ;
                pathlist = GetSysEnvironmentByName("PATH");
                //检测是否以;结尾
                if (pathlist.Substring(pathlist.Length - 1, 1) != ";")
                {
                    SetSysEnvironment("PATH", pathlist + ";");
                    pathlist = GetSysEnvironmentByName("PATH");
                }
                string[] list = pathlist.Split(';');
                bool isPathExist = false;
        
                foreach (string item in list)
                {
                    if (item == strHome)
                        isPathExist = true;
                }
                if (!isPathExist)
                {
                    SetSysEnvironment("PATH", pathlist +strHome+ ";");
                }
        
            }
        
            public static void SetPathBefore(string strHome)
            {
        
                string pathlist;
                pathlist = GetSysEnvironmentByName("PATH");
                            string[] list = pathlist.Split(';');
                bool isPathExist = false;
        
                foreach (string item in list)
                {
                    if (item == strHome)
                        isPathExist = true;
                }
                if (!isPathExist)
                {
                    SetSysEnvironment("PATH", strHome + ";" + pathlist);
                }
        
            }
        
            public static void SetPath(string strHome)
            {
        
                string pathlist;
                pathlist = GetSysEnvironmentByName("PATH");
                string[] list = pathlist.Split(';');
                bool isPathExist = false;
        
                foreach (string item in list)
                {
                    if (item == strHome)
                        isPathExist = true;
                }
                if (!isPathExist)
                {
                    SetSysEnvironment("PATH", pathlist + strHome + ";" );
                }
        
            }
            
            
           
            
        }


        public static class SystemEnvironment
        {
            [DllImport("Kernel32.DLL ", SetLastError = true)]
            public static extern bool SetEnvironmentVariable(string lpName, string lpValue);

            public static void SetPath(string pathValue)
            {
                string pathlist;
                pathlist = _SystemEnvironment.GetSysEnvironmentByName("PATH");
                string[] list = pathlist.Split(';');
                bool isPathExist = false;
                Console.WriteLine(pathlist.Length);
                foreach (string item in list)
                {
                    if (item == pathValue)
                    {
                        isPathExist = true;
                        break;
                    }

                    Console.WriteLine(item);
                }
                
                if (!isPathExist)
                {
                    SetEnvironmentVariable("PATH", pathlist + pathValue+";");
                }

            }
        }

    }
}