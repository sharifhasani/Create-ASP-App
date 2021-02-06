using System.IO;
using Create_ASP_App.Utility.Generator;
using Create_ASP_App.Utility.Validator;
using Microsoft.AspNetCore.Http;
using static System.String;

namespace Create_ASP_App.Utility.FileUtility
{
    public static class ImageUtility
    {
        #region Save File

        // Save file to path in folder "wwwroot/ ..." method by default generate random file name for file and save it 
        // if save file success return file name when save file contain Error return null
        public static string SaveImage(IFormFile file, string folder, string fileName = null, string prefix = null, string postfix = null)
        {
            try
            {
                if (file != null && file.IsImage())
                {
                    string imageName = "";

                    imageName += (IsNullOrWhiteSpace(prefix)) ? prefix : null;

                    imageName += (IsNullOrWhiteSpace(fileName)) ? fileName : CodeGenerator.GenerateRandomFileName();

                    imageName += (IsNullOrWhiteSpace(postfix)) ? "_" + postfix : null;

                    imageName += Path.GetExtension(file.FileName);

                    string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/", folder, imageName);

                    if (!FileTools.SaveFile(file, imagePath))
                        throw new FileLoadException();

                    return imageName;
                }
                throw new FileLoadException();
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region Update Image

        public static string UpdateImage(IFormFile file, string folder, string oldFileName
            , string fileName = null, string prefix = null, string postfix = null, string defaultFileName = null)
        {
            if (file != null)
            {
                string imagePath = "";
                if (oldFileName != defaultFileName)
                {
                    imagePath += Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/", folder, oldFileName);
                    if (!FileTools.DeleteFile(imagePath))
                    {
                        throw new FileNotFoundException();
                    }
                }
                return SaveImage(file, folder, fileName, prefix, postfix);
            }

            return null;
        }

        #endregion
    }
}
