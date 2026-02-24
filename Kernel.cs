using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace CosmosLUNA
{
    public class Kernel : Sys.Kernel
    {
        Sys.FileSystem.CosmosVFS fs = new Cosmos.System.FileSystem.CosmosVFS();

        protected override void BeforeRun()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            Console.Clear();
            Console.WriteLine("CosmosLUNA [Version 0.1.1]");
            Console.WriteLine("2026 Pavel Levin");
        }

        protected override void Run()
        {
            Console.Write("LOCATION> ");
            var input = Console.ReadLine();
            switch (input)
            {
                default:
                    Console.WriteLine(input + " is not recognized as an internal or external command, operable program or batch file.");
                break;

                case "help":
                    Console.WriteLine("help    Provides Help information for CosmosLUNA commands.");
                    Console.WriteLine("shutdown       Allows proper local or remote shutdown of machine.");
                    Console.WriteLine("(use shutdown /r to restart)");
                    Console.WriteLine("cl_fsad       Free space available on the drive");
                    Console.WriteLine("cl_fstp       File system tipe");
                    break;

                case "shutdown":
                    Cosmos.System.Power.Shutdown(); 
                break;

                case "shutdown /r":
                    Cosmos.System.Power.Reboot();
                break;

                case "cl_fsad":
                    var available_space = fs.GetAvailableFreeSpace(@"0:\");
                    Console.WriteLine("Available Free Space: " + available_space);
                 break;

                case "cl_fstp":
                    var fs_type = fs.GetFileSystemType(@"0:\");
                    Console.WriteLine("File System Type: " + fs_type);
                    break;
            }
        }
    }
}
