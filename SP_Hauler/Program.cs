using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace SP_Hauler
{
    class Program
    {

        static void Main(string[] args)
        {
            //nameSpace = the namespace;
            //outDirectory = where the file will be extracted to;
            //internalFilePath = the name of the folder inside visual studio which the files are in;
            //resourceName = the name of the file;
            string AppFolderUser = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string progFolder = AppFolderUser + @"\SP_Copy_Content";
            string progFolderImagesDir = progFolder + "\\Images";
            if (Directory.Exists(progFolder))
            {
                Directory.Delete(progFolder, true);
            }
            System.IO.Directory.CreateDirectory(progFolder);
            System.IO.Directory.CreateDirectory(progFolderImagesDir);

            //Console.Write(AppFolderUser);
            Extract("SP_Hauler", progFolder, "Files", @"Batch.bat");
            Extract("SP_Hauler", progFolder, "Files", @"Launcher.ps1");
            Extract("SP_Hauler", progFolder, "Files", @"Copy_Home.txt");
            Extract("SP_Hauler", progFolder, "Files", @"MainWindow.xaml");
            Extract("SP_Hauler", progFolder, "Files", @"Microsoft.SharePoint.Client.dll");
            Extract("SP_Hauler", progFolder, "Files", @"Microsoft.SharePoint.Client.Runtime.dll");
            Extract("SP_Hauler", progFolder, "Files", @"Microsoft.SharePoint.Client.Taxonomy.dll");
            Extract("SP_Hauler", progFolderImagesDir, "Files.Images", @"file-icon-28038.png");
            Extract("SP_Hauler", progFolderImagesDir, "Files.Images", @"icon-folder-128.png");
            Extract("SP_Hauler", progFolderImagesDir, "Files.Images", @"Logo.ico");
            Extract("SP_Hauler", progFolderImagesDir, "Files.Images", @"Button_Next_S.png");
            Extract("SP_Hauler", progFolderImagesDir, "Files.Images", @"Button_Next_S_Click.png");
            Extract("SP_Hauler", progFolderImagesDir, "Files.Images", @"Button_Prev_S.png");
            Extract("SP_Hauler", progFolderImagesDir, "Files.Images", @"Button_Prev_S_Click.png");
            Extract("SP_Hauler", progFolderImagesDir, "Files.Images", @"Close_Clicked.png");
            Extract("SP_Hauler", progFolderImagesDir, "Files.Images", @"Close.png");
            Extract("SP_Hauler", progFolderImagesDir, "Files.Images", @"Top_Banner.png");
            Extract("SP_Hauler", progFolderImagesDir, "Files.Images", @"Top_Four.png");
            Extract("SP_Hauler", progFolderImagesDir, "Files.Images", @"Top_Three.png");
            Extract("SP_Hauler", progFolderImagesDir, "Files.Images", @"Top_Two.png");
            Extract("SP_Hauler", progFolderImagesDir, "Files.Images", @"Top_One.png");
            Extract("SP_Hauler", progFolderImagesDir, "Files.Images", @"Fields_Back_Advanced.png");
            Extract("SP_Hauler", progFolderImagesDir, "Files.Images", @"Explorer.png");
            Extract("SP_Hauler", progFolderImagesDir, "Files.Images", @"Filters.png");
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.FileName = progFolder + "\\" + "Batch.bat";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.Arguments = "gT4XPfvcJmHkQ5tYjY3fNgi7uwG4FB9j";

            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch
            {
                // Log error.
            }
            //if (Directory.Exists(progFolder))
            //{
            //     Directory.Delete(progFolder, true);
            //}
        }

        public static void Extract(string nameSpace, string outDirectory, string internalFilePath, string resourceName)
        {
            Assembly assembly = Assembly.GetCallingAssembly();

            using (Stream s = assembly.GetManifestResourceStream(nameSpace + "." + (internalFilePath == "" ? "" : internalFilePath + ".") + resourceName))
            using (BinaryReader r = new BinaryReader(s))
            using (FileStream fs = new FileStream(outDirectory + "\\" + resourceName, FileMode.OpenOrCreate))
            using (BinaryWriter w = new BinaryWriter(fs))
            {
                w.Write(r.ReadBytes((int)s.Length));
            }
        }
    }
}

