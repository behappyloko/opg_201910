using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace opg_201910_interview.Services.IO
{
    /// <summary>
    /// Handles read operations
    /// </summary>
    public class ReadService
    {
        /// <summary>
        /// Reads the files of the directory
        /// </summary>
        /// <param name="directory"></param>
        /// <returns>the files in the given directory</returns>
        public FileInfo[] ReadDirectory(string directory)
        {
            // combines with current directory to get to file
            string targetDirectory = Path.Combine(
                                    Directory.GetCurrentDirectory(),
                                    directory
                                );

            FileInfo[] clientFiles;
            DirectoryInfo directoryInfo = new DirectoryInfo(targetDirectory);

            if(directoryInfo.Exists)
            {
                FileInfo[] files = directoryInfo.GetFiles();

                clientFiles = files.Where(f => f.Extension == ".xml").ToArray();
            }
            else
                throw new DirectoryNotFoundException();
            

            return clientFiles;
        }

        /// <summary>
        /// Reads the files of directory
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="customSort"></param>
        /// <returns>the sorted files from the given sort options in the given directory</returns>
        public FileInfo[] ReadDirectory(string directory, string[] customSort)
        {
            List<FileInfo> sortedFiles = new List<FileInfo>();
            FileInfo[] clientFiles = ReadDirectory(directory);

            for(int x = 0; x < customSort.Length; x++)
            {
                string keyword = customSort[x].ToLower();
                FileInfo[] matchedFilenames = clientFiles
                    .Where(file => file.Name.Contains(keyword))
                    .OrderBy(file => file.Name)
                    .ToArray();

                for (int y = 0; y < matchedFilenames.Length; y++)
                {
                    sortedFiles.Add(matchedFilenames[y]);
                }
            }

            return sortedFiles.ToArray();
        }
    }
}
