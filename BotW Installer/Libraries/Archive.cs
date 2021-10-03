﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotW_Installer.Libraries
{
    public class Archive
    {
        public static async Task CopyDirectory(string inputDir, string outputDir)
        {
            List<Task> tasks = new();

            await Task.Run(() =>
            {
                foreach (var file in Directory.EnumerateFiles(inputDir, "*.*", SearchOption.AllDirectories))
                {
                    var fi = new FileInfo(file);
                    var di = new DirectoryInfo(fi.DirectoryName);

                    Directory.CreateDirectory(di.FullName.Replace(inputDir, outputDir));
                    tasks.Add(Task.Run(() => File.Copy(file, file.Replace(inputDir, outputDir))));
                }
            });

            await Task.WhenAll(tasks);
        }
    }
}
