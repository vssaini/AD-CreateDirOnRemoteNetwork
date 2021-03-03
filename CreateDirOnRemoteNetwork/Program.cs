using System;
using CreateDirOnRemoteNetwork.Helpers;

namespace CreateDirOnRemoteNetwork
{
    internal class Program
    {
		// Ref - https://technet.microsoft.com/en-us/library/ee791865(v=ws.10).aspx

		// 'data' is the share name and also folder on resepctive system
		// 'Server name' instead of IP Address will not work		
        private const string NetworkName = @"\\192.168.1.202\Data";
        private const string NetworkDirFullName = @"\\192.168.1.202\Data\VikramDirectory";

        private static void Main()
        {
            try
            {
                Console.WriteLine("Creating directory over network share or mapped drive...\n\n");
                CreateDirectoryAtUncPath();

                //GetUncPath();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e);
                Console.ResetColor();
            }

            // Hold till we read
            Console.ReadLine();
        }

        private static void CreateDirectoryAtUncPath()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Utility.CreateDirectoryInShare(NetworkName, NetworkDirFullName);
            Console.WriteLine("Directory created at path '{0}'", NetworkDirFullName);
            Console.ResetColor();
        }

        private static void GetUncPath()
        {
            //const string path = @"Z:\25UsersImport.csv"; // By default drive letter is Z
            const string path = @"E:\Xtra";

            if (path.StartsWith(@"\") && Utility.PathIsNetworkPath(path))
            {
                //ReadFromUncPath();
                Console.ForegroundColor = ConsoleColor.Green;
                var uncPath = Utility.GetUNCPath(path);
                Console.WriteLine("The UNC path returned for path '{0}' -\n\n{1}", path, uncPath);
                Console.ResetColor();

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                var uncPath = Utility.GetUNCPath(path);
                Console.WriteLine("The local path returned for path '{0}' -\n\n{1}", path, uncPath);
                Console.ResetColor();
            }

        }
    }
}
