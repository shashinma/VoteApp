using System;
namespace VoteApp
{
    public class ConfigurationManager
    {
        private static IConfiguration configuration = null;

        static ConfigurationManager()
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
        }

        public static string GetFilePath()
        {
            return configuration["CustomKey:BaseUrl"] + "file/";
        }
    }
}