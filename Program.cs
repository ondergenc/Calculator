using System;
using Calculator.BaseCalculator;
using Calculator.BaseCalculator.Formulas;
using Calculator.Models;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderList orderList = new OrderList()
            {
                new Order()
                {
                    CustomerId = 1,
                    OrderId = 1,
                    TotalOfPiece = new Field(0),
                    TotalAmount = new Field(0),
                    OrderDetails = new OrderDetailList()
                    {
                        new OrderDetail()
                        {
                            OrderDetailId = 1,
                            ProductName = "Mouse",
                            ProductPrice = new Field(0),
                            ProductQuantity = new Field(0)
                        },
                        new OrderDetail()
                        {
                            OrderDetailId = 2,
                            ProductName = "Keyboard",
                            ProductPrice = new Field(0),
                            ProductQuantity = new Field(0)
                        }
                    }
                }
            };

            //Forumulas Setup
            CalcBase calculatorTotalOfPiece = new TotalFormulas();
            orderList.ForEach(o =>
            {
                o.OrderDetails.ForEach(od =>
                {
                    calculatorTotalOfPiece.AddFormulaField(od.ProductQuantity);
                });
            });
            calculatorTotalOfPiece.AddResultField(orderList[0].TotalOfPiece);

            CalcBase calculatorTotalAmount = new TotalFormulas();
            orderList.ForEach(o =>
            {
                o.OrderDetails.ForEach(od =>
                {
                    calculatorTotalAmount.AddFormulaField(od.ProductPrice);
                });
            });
            calculatorTotalAmount.AddResultField(orderList[0].TotalAmount);
            //Forumulas Setup

            //Data binding
            orderList[0].OrderDetails[0].ProductQuantity.Value = 2;
            orderList[0].OrderDetails[0].ProductPrice.Value = 100;

            orderList[0].OrderDetails[1].ProductQuantity.Value = 2;
            orderList[0].OrderDetails[1].ProductPrice.Value = 250;
            //Data binding

            Console.WriteLine("Total of piece : " + orderList[0].TotalOfPiece.Value);
            Console.WriteLine("Total amount : " + orderList[0].TotalAmount.Value);
            Console.ReadLine();
        }
    }
}
