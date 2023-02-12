using System;
using System.Text.Json;

namespace JsonWriteFile
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string text = JsonFileRead("response.json");

            JsonFileWrite(text);

        }


        public static string JsonFileRead(string path)
        {
            string text = File.ReadAllText(path);

            var bill = JsonSerializer.Deserialize<List<Bill>>(text);
            Console.WriteLine(bill[0].description);
            return bill[0].description;
        }
        public static void JsonFileWrite(string text)
        {
            string[] text2 = new string[1000];
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    text2[i] = "----------------------------------------------";
                }
                else if (i == 1)
                {
                    text2[i] = "| line | text                                ";
                }
                else
                {
                    text2[i] = "----------------------------------------------";
                }
            }
            int count = 3;


            for (int i = 0; i < text.Split("\n").Length; i++)
            {

                text2[count] = "|" + Convert.ToInt32(i + 1).ToString() + "  | " + text.Split("\n")[i];
                count++;
            }
            File.WriteAllLines("Ex1.txt", text2);
        }
    }
    public class BoundingPoly
    {
        public List<Vertex> vertices { get; set; }
    }

    public class Bill
    {
        public string locale { get; set; }
        public string description { get; set; }
        public BoundingPoly boundingPoly { get; set; }
    }

    public class Vertex
    {
        public int x { get; set; }
        public int y { get; set; }
    }

}