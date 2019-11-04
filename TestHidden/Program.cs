using System;
using System.Diagnostics;

namespace TestHidden
{
    class Program
    {
        static void Main(string[] args)
        {
            var process = Process.Start(
                                new ProcessStartInfo
                                {
                                    FileName = "/bin/bash",
                                    Arguments = $"-c ./reset.sh",
                                    RedirectStandardOutput = true,
                                    UseShellExecute = false,
                                    CreateNoWindow = true,
                                });
            process.WaitForExit();
            Console.WriteLine(process.StandardOutput.ReadToEnd());
            

            var attrBefore1 = System.IO.File.GetAttributes("secret1.txt");
            var attrBefore2 = System.IO.File.GetAttributes("secret2.txt");
            var attrBefore3 = System.IO.File.GetAttributes("secret3.txt");

            System.IO.File.SetAttributes("secret1.txt", System.IO.FileAttributes.Normal);
            System.IO.File.SetAttributes("secret2.txt", System.IO.FileAttributes.Normal);
            System.IO.File.SetAttributes("secret3.txt", System.IO.FileAttributes.Normal);

            var attrAfter1 = System.IO.File.GetAttributes("secret1.txt");
            var attrAfter2 = System.IO.File.GetAttributes("secret2.txt");
            var attrAfter3 = System.IO.File.GetAttributes("secret3.txt");

            Console.WriteLine($"secret1.txt {attrBefore1} -> {attrAfter1}");
            Console.WriteLine($"secret2.txt {attrBefore2} -> {attrAfter2}");
            Console.WriteLine($"secret3.txt {attrBefore3} -> {attrAfter3}");
        }
    }
}
