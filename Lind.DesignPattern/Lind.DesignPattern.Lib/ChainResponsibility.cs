using System;

//职责链模式
namespace Lind.DesignPattern.Lib.ChainResponsibility
{

    // 采购请求
    public class HolidayRequest
    {
        // 金额
        public double Day { get; set; }
        // 产品名字
        public string UserName { get; set; }
        public HolidayRequest(double amount, string productName)
        {
            Day = amount;
            UserName = productName;
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
        public abstract void ProcessRequest(HolidayRequest request);
    }

    // ConcreteHandler
    public class Step1 : Approver
    {
        public Step1(string name)
            : base(name)
        { }

        public override void ProcessRequest(HolidayRequest request)
        {
            if (request.Day < 3)
            {
                Console.WriteLine("{0}-{1} 审核了{2}的请假{3}天, ", this, Name, request.UserName, request.Day);
            }
            else if (NextApprover != null)
            {
                NextApprover.ProcessRequest(request);
            }
        }
    }

    // ConcreteHandler,副总
    public class Step2 : Approver
    {
        public Step2(string name)
            : base(name)
        {
        }
        public override void ProcessRequest(HolidayRequest request)
        {
            if (request.Day < 5)
            {
                Console.WriteLine("{0}-{1} 审核了{2}的请假{3}天, ", this, Name, request.UserName, request.Day);
            }
            else if (NextApprover != null)
            {
                NextApprover.ProcessRequest(request);
            }
        }
    }

    // ConcreteHandler，总经理
    public class Step3 : Approver
    {
        public Step3(string name)
            : base(name)
        { }
        public override void ProcessRequest(HolidayRequest request)
        {
            if (request.Day < 10)
            {
                Console.WriteLine("{0}-{1} 审核了{2}的请假{3}天, ", this, Name, request.UserName, request.Day);
            }
            else
            {
                Console.WriteLine("需要组织一个会议讨论,请假{0}天", request.Day);
            }
        }
    }

}
