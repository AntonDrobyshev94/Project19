using Microsoft.AspNetCore;

namespace Project19
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Repository.Open("JsonCoolection");
                CurrentId();
            }
            catch
            {

            }

            Repository.Add("������", "����", "��������", "123456", "������",
                "�������");
            Repository.Add("������", "ϸ��", "��������", "789012", "�����-���������",
                "��������");
            Repository.Add("�����������", "���������", "�������������", "345678", "�����������",
                "��������");

            Repository.Save("JsonCoolection");

            CreateWebHostBuilder(args).Build().Run(); //��������� �������
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();

        /// <summary>
        /// ����� ����������� �������� ID
        /// </summary>
        static public void CurrentId()
        {
            for (int i = Repository.db.Count - 1; i < Repository.db.Count; i++)
            {
                Repository.individualId = Repository.db[i].ID;
            }
        }
    }
}