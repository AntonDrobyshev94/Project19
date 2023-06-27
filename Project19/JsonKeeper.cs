using Newtonsoft.Json;

namespace Project19
{
    public static class JsonKeeper
    {
        public static void SaveClientCollection(List<Contact> project, string nameOfFile)
        {
            File.WriteAllText($"{nameOfFile}.json", JsonConvert.SerializeObject(project));
        }
    }
}
