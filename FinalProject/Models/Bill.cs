﻿namespace FinalProject.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public string Total { get; set; }
        public DateTime Date { get; set;}
        public int PatientId { get; set; }
        public Patient Patient { get; set;}
        public ICollection<BillItems> BillItems { get; set; }
    }
}
