using System;
namespace ExpensesAPI.Models
{
    public class Material
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsService { get; set; }
        public string Description { get; set; }
    }
}

