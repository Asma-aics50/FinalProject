namespace FinalProject.Models
{
    public class BillItems
    {
        public int BillId { get; set; }
        public int ServiceId { get; set;}
        public Bill Bill { get; set; }
        public Service Service { get; set; }

    }
}
