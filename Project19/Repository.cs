using Newtonsoft.Json;

namespace Project19
{
    public static class Repository
    {
        public static List<Contact> db;
        public static int individualId;

        /// <summary>
        /// Метод определения значения индекса, возвращающий int
        /// значение переменной. В методе происходит присваивание
        /// значения individualId +1 и возвращение этой переменной
        /// </summary>
        /// <returns></returns>
        private static int NextID()
        {
            individualId++;
            return individualId;
        }

        static Repository()
        {
            db = new List<Contact>();
        }

        /// <summary>
        /// Метод, возвращающий новый экземпляр типа Contact, который
        /// принимает значения параметров Contact, такие как имя,
        /// фамилия и т.д.
        /// </summary>
        /// <param name="surname"></param>
        /// <param name="name"></param>
        /// <param name="fatherName"></param>
        /// <param name="telephoneNumber"></param>
        /// <param name="residenceAdress"></param>
        /// <param name="Description"></param>
        /// <returns></returns>
        public static Contact GetContact(string surname, string name,
            string fatherName, string telephoneNumber,
            string residenceAdress, string Description)
        {
            return new Contact()
            {
                ID = NextID(),
                Name = name,
                Surname = surname,
                FatherName = fatherName,
                TelephoneNumber = telephoneNumber,
                ResidenceAdress = residenceAdress,
                Description = Description
            };
        }

        /// <summary>
        /// Метод добавления клиента 
        /// </summary>
        /// <param name="surname"></param>
        /// <param name="name"></param>
        /// <param name="fatherName"></param>
        /// <param name="telephoneNumber"></param>
        /// <param name="residenceAdress"></param>
        /// <param name="Description"></param>
        public static void Add(string surname, string name,
            string fatherName, string telephoneNumber,
            string residenceAdress, string Description)
        {
            db.Add(GetContact(surname, name, fatherName,
                telephoneNumber, residenceAdress, Description));
        }

        /// <summary>
        /// Метод загрузки файла json и сохранения в коллекцию db
        /// </summary>
        /// <param name="nameOfFile"></param>
        public static void Open(string nameOfFile)
        {
            db = JsonConvert.DeserializeObject<List<Contact>>(File.ReadAllText($"{nameOfFile}.json"));
        }

        /// <summary>
        /// Метод сохранения файла формата json, который принимает
        /// строковую переменную с названием файла. Метод обращается
        /// к классу JsonKeeper, в котором реализован метод сохранения
        /// </summary>
        /// <param name="nameOfFile"></param>
        public static void Save(string nameOfFile)
        {
            JsonKeeper.SaveClientCollection(db, nameOfFile);
        }

        /// <summary>
        /// Метод, возвращающий интерфейс IEnumerable, который служит
        /// для перечисления элементов коллекции Contact. Метод 
        /// принимает в себя коллекцию List класса Contact.
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static IEnumerable<Contact> GetDataFromViewListObject(List<Contact> db)
        {
            return db;
        }

        /// <summary>
        /// Метод, возвращающий экземпляр класса Contact с указанным id, 
        /// данный метод принимает в себя int id. В методе происходит
        /// создание нового экземпляра с пустыми параметрами, далее
        /// происходит запуск цикла foreach, в котором происходит
        /// сравнение текущего ID с принимаемым id. При совпадении
        /// происходит кеширование экземпляра Contact в переменную и 
        /// возвращение этого экземпляра.
        /// переменную 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Contact GetConcreteContact(int id)
        {
            Contact concreteContact = new Contact()
            {
                ID = 0,
                Name = "",
                Surname = "",
                FatherName = "",
                TelephoneNumber = "",
                ResidenceAdress = "",
                Description = ""
            };
            foreach (var contact in db)
            {
                if (contact.ID == id)
                {
                    concreteContact = contact;
                }
            }
            return concreteContact;
        }
    }
}
