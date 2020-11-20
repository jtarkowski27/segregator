using System;
using System.IO;
using System.Security.Permissions;

namespace segregator
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }
        
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private static void Run()
        {
            string[] args = {@"C:\Users\jtark\Desktop"};

            // Create a new FileSystemWatcher and set its properties.
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = args[0];

                // Watch for changes in LastAccess and LastWrite times, and
                // the renaming of files or directories.
                watcher.NotifyFilter = NotifyFilters.LastAccess
                                       | NotifyFilters.LastWrite
                                       | NotifyFilters.FileName
                                       // | NotifyFilters.DirectoryName
                                       ;

                //// Only watch text files.
                // watcher.Filter = "*.txt";

                // Add event handlers.
                watcher.Changed += OnChanged;
                watcher.Created += OnChanged;
                // watcher.Deleted += OnChanged;
                watcher.Renamed += OnRenamed;

                // Begin watching.
                watcher.EnableRaisingEvents = true;

                // Wait for the user to quit the program.
                Console.WriteLine("Press 'q' to quit the sample.");
                while (Console.Read() != 'q');
            }
        }
        
        private static void OnChanged

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
        }

        private static void OnRenamed(object source, RenamedEventArgs e) =>
            Console.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");
    }
}