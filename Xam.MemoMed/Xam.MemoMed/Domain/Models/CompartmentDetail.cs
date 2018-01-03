namespace Xam.MemoMed.Domain.Models
{
    public class CompartmentDetail
    {
        public int Id { get; set; }
        public Compartment Compartment { get; set; }
        public Medicine Medication{ get; set; }
        public int Quantity { get; set; }
    }
}
