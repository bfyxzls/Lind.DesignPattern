using System;

namespace Lind.DesignPattern.Lib
{
    /// <summary>
    /// 职责链模式
    /// </summary>
    public class ChainResponsibility
    {
        // 采购请求
        public class PurchaseRequest
        {
            // 金额
            public double Amount { get; set; }
            // 产品名字
            public string ProductName { get; set; }
            public PurchaseRequest(double amount, string productName)
            {
                Amount = amount;
                ProductName = productName;
            }
        }

        // 审批人,Handler
        public abstract class Approver
        {
            public Approver NextApprover { get; set; }
            public string Name { get; set; }
            public Approver(string name)
            {
                this.Name = name;
            }
            public abstract void ProcessRequest(PurchaseRequest request);
        }

        // ConcreteHandler
        public class Manager : Approver
        {
            public Manager(string name)
                : base(name)
            { }

            public override void ProcessRequest(PurchaseRequest request)
            {
                if (request.Amount < 10000.0)
                {
                    Console.WriteLine("{0}-{1} approved the request of purshing {2}", this, Name, request.ProductName);
                }
                else if (NextApprover != null)
                {
                    NextApprover.ProcessRequest(request);
                }
            }
        }

        // ConcreteHandler,副总
        public class VicePresident : Approver
        {
            public VicePresident(string name)
                : base(name)
            {
            }
            public override void ProcessRequest(PurchaseRequest request)
            {
                if (request.Amount < 25000.0)
                {
                    Console.WriteLine("{0}-{1} approved the request of purshing {2}", this, Name, request.ProductName);
                }
                else if (NextApprover != null)
                {
                    NextApprover.ProcessRequest(request);
                }
            }
        }

        // ConcreteHandler，总经理
        public class President : Approver
        {
            public President(string name)
                : base(name)
            { }
            public override void ProcessRequest(PurchaseRequest request)
            {
                if (request.Amount < 100000.0)
                {
                    Console.WriteLine("{0}-{1} approved the request of purshing {2}", this, Name, request.ProductName);
                }
                else
                {
                    Console.WriteLine("Request需要组织一个会议讨论");
                }
            }
        }
}
