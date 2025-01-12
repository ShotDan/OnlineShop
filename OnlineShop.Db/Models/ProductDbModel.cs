﻿using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Db.Models
{
    public class ProductDbModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
    }
}
