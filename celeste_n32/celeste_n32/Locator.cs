using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace celeste_n32
{
    internal class Locator
    {
        public static string Get()
        {
            var lad = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Roblox\\Versions";
            var isok = false;
            var latest = "";
            foreach (var flds in Directory.GetDirectories(lad))
            {
                // most likely wont happen, but just to make sure. 
                var i = new DirectoryInfo(flds);


                if (i.GetFiles().Length != 0)
                {
                    foreach (var fe in Directory.GetFiles(i.FullName))
                    {
                        var fileInfo1 = new FileInfo(fe);
                        if (Directory.Exists(i.FullName + "BuiltInPlugins"))
                        {
                        }
                    }
                }

                if (File.Exists(i.FullName + "\\RobloxPlayerBeta.exe"))
                {
                    latest = i.FullName;
                }

                if (i.GetFiles().Length == 0 || i.GetDirectories().Length == 0)
                {
                    if (!isok)
                    {
                        isok = true;
                    }
                    Directory.Delete(i.FullName);
                }
            }

            return latest;
        }
    }
}
