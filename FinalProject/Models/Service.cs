﻿namespace FinalProject.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ICollection<BillItems> BillItems { get; set; }
    }
}
