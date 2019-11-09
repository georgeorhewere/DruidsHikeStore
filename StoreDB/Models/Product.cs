using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreDB.Models
{
    public class Product
    {

        private int productId;
        private string name;
        private string description;
        private double price;
        private int quantity;
        private int category;
        private string color;
        public Product(string name, string description,double price, int quantity, int category,string color)
        {
                       
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            Category = category;
            Color = color;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get => productId; set => productId = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public double Price { get => price; set => price = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int Category { get => category; set => category = value; }
        public string Color { get => color; set => color = value; }
    }
}
