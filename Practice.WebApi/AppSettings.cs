using Newtonsoft.Json;

namespace Practice.WebApi
{
    public class Settings
    {
        public string[] Blacklist { get; set; }
        public int ParallelLimit { get; set; }
    }

    public class AppSettings
    {
        public Settings Settings { get; set; }

        public static AppSettings Load()
        {
            string json = File.ReadAllText(@"appsettings.json");
            return JsonConvert.DeserializeObject<AppSettings>(json);
        }
    }
}
