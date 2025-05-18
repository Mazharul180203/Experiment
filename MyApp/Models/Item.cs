﻿namespace MyApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
    }

    public class ItemCreate
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    
}
