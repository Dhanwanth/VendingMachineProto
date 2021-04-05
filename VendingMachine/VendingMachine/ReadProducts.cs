using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VendingMachine.Model;

namespace VendingMachine
{
    public class ReadProducts
    {
        public static async Task<Products> readProducts()
        {
            string json = string.Empty;
            using (StreamReader str = new StreamReader("./products.json"))
            {
                json = await str.ReadToEndAsync();
            }
            var products = JsonConvert.DeserializeObject<Products>(json);
            return products;
        }
    }
}
