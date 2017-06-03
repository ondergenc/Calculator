using Calculator.BaseCalculator;

namespace Calculator.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public string ProductName { get; set; }
        public Field ProductPrice { get; set; }
        public Field ProductQuantity { get; set; }
    }
}
