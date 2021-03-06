﻿using System.IO;
using Microsoft.AspNetCore.Http;

namespace Create_ASP_App.Utility.FileUtility
{
    // This Class use Complete path with file name for do any method on file 
    public static class FileTools
    {
        public static bool SaveFile(IFormFile file, string path)
        {
            try
            {
                path = Path.Join(Directory.GetCurrentDirectory(), "wwwroot", path);
                using var stream = new FileStream(path, FileMode.Create);
                file.CopyTo(stream);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeleteFile(string filePath)
        {
            try
            {
                filePath = Path.Join(Directory.GetCurrentDirectory(), "wwwroot", filePath);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool UpdateFile(IFormFile file, string path)
        {
            try
            {
                path = Path.Join(Directory.GetCurrentDirectory(), "wwwroot", path);
                if (!DeleteFile(path))
                {
                    throw new FileNotFoundException();
                }

                SaveFile(file, path);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
