using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Service
{
    public static class ProjectDirectories
    {
        private static readonly string _temp;
        private static readonly string _tempReports;
        private static readonly string _reportTemplates;

        static ProjectDirectories()
        {
            _temp = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp");
            _tempReports = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TempReports");
            _reportTemplates = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ReportTemplates");
        }

        public static void DeleteAllFilesFromTemp()
        {
            DeleteFiles(_temp);
        }

        public static void DeleteAllFilesFromTempReports()
        {
            DeleteFiles(_tempReports);
        }

        private static void DeleteFiles(string directory)
        {
            foreach (var entry in Directory.EnumerateFileSystemEntries(directory))
            {
                FileAttributes fa = File.GetAttributes(entry);
                if (fa.HasFlag(FileAttributes.Directory))
                {
                    DeleteFiles(entry);
                    Directory.Delete(entry);
                }
                else
                    File.Delete(entry);
            }
        }

        public static void CreateTempIfNoExists()
        {
            CreateDirectory(_temp);
        }

        public static void CreateTempReportsIfNoExists()
        {
            CreateDirectory(_tempReports);
        }

        private static void CreateDirectory(string directory)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }

        public static string GetTempDirectory()
        {
            return _temp;
        }

        public static string GetTempReportsDirectory()
        {
            return _tempReports;
        }

        public static string GetReportsTemplatesDirectory()
        {
            return _reportTemplates;
        }
    }
}