using System;

namespace Create_ASP_App.Utility.Generator
{
    public static class CodeGenerator
    {
        public static string GenerateRandomFileName()
        {
            var timeNow = DateTime.Now;
            string time = timeNow.Year + timeNow.Month.ToString() + timeNow.Day;
            return Guid.NewGuid().ToString().Replace("-", "") + "_" + time;
        }
    }
}
