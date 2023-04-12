using ConsoleApp1.Model;
using System;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //"C:\GartnerApp\ConsoleApp1\Data\softwareadvice.json"
            //"C:\GartnerApp\ConsoleApp1\Data\capterra.yaml"

            try
            {
                Console.WriteLine("Enter File path:");
                string fileName = Console.ReadLine();
                string extension = Path.GetExtension(fileName);
                List<Product1> products = new List<Product1>();

                if (extension == ".json")
                {
                    products = ImportJson(fileName);
                }
                else if (extension == ".yaml")
                {
                    var result = ImportYaml(fileName);
                    products = ProductConvertor.ToProduct1(result);
                }

                foreach (var product in products)
                {
                    Console.WriteLine($"importing: Name: \"{product.Title}\"; Categories: {string.Join(", ", product.Categories)}; Twitter: {product.Twitter}");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: "+ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        public static List<Product1> ImportJson(string path)
        {
            var json = File.ReadAllText(path);
            var result = JsonConvert.DeserializeObject<Dictionary<string, List<Product1>>>(json)["products"];
            return result;
        }

        public static List<Product2> ImportYaml(string path)
        {
            var content = new StreamReader(path);
            var deserializer = new DeserializerBuilder().Build();
            var result = deserializer.Deserialize<List<Product2>>(content);
            return result;
        }
    }
}
