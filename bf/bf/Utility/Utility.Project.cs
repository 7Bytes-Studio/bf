/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System.IO;

namespace bf
{
    public sealed partial class Utility
    {
        /// <summary>
        /// 项目助手。
        /// </summary>
        public static class Project
        {
            /// <summary>
            /// 检查或创建项目目录。
            /// </summary>
            public static void CheckOrCreateProjectFolder_Windows(string projectName, string projectType,
                string d = "d")
            {
                if (projectType.Contains("unity"))
                {
                    projectType = "Unity3D";
                }

                var root = string.Format("{0}:/Workspace/Project/{1}", d, projectType);
                var projectRoot = Path.Combine(root, projectName);
                projectRoot = Path.Combine(projectRoot, projectName);
                //Console.WriteLine(projectRoot);
                BlackFire.Utility.IO.ExistsOrCreateFolder(projectRoot + ".Art");
                BlackFire.Utility.IO.ExistsOrCreateFolder(projectRoot + ".Build");
                BlackFire.Utility.IO.ExistsOrCreateFolder(projectRoot + ".Design");
                BlackFire.Utility.IO.ExistsOrCreateFolder(projectRoot + ".External");
                BlackFire.Utility.IO.ExistsOrCreateFolder(projectRoot + ".Unity");
                BlackFire.Utility.IO.ExistsOrCreateFolder(
                    projectRoot + ".Unity/Assets/Plugins/Framework/BasicFramework");
                BlackFire.Utility.IO.ExistsOrCreateFolder(
                    projectRoot + ".Unity/Assets/Plugins/Framework/BusinessFramework");
            }



            public static void CheckOrCreateSvnFolder(string projectName, string d = "d")
            {
                var root = string.Format("{0}:/Workspace/Project/SVN/{1}", d, projectName);
                BlackFire.Utility.IO.ExistsOrCreateFolder(root + "/trunk");
                BlackFire.Utility.IO.ExistsOrCreateFolder(root + "/branches/develop");
                BlackFire.Utility.IO.ExistsOrCreateFolder(root + "/branches/feature");
                BlackFire.Utility.IO.ExistsOrCreateFolder(root + "/branches/hotfix");
                BlackFire.Utility.IO.ExistsOrCreateFolder(root + "/branches/release");
                BlackFire.Utility.IO.ExistsOrCreateFolder(root + "/tags");
            }
        }
    }
}