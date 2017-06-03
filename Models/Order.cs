using Calculator.BaseCalculator;

namespace Calculator.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId  { get; set; }
        public Field TotalOfPiece { get; set; }
        public Field TotalAmount { get; set; }
        public OrderDetailList OrderDetails { get; set; }

    }
}
