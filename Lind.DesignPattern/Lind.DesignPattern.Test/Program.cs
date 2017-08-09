using Lind.DesignPattern.Lib.SimpleFactory;
using Lind.DesignPattern.Lib.ChainResponsibility;
using Lind.DesignPattern.Lib.FactoryMethod;
using Lind.DesignPattern.Lib.AbstractFactory;
using System;
using System.Text;


namespace Lind.DesignPattern.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.WriteLine("Hello World!");

            #region 职责链
            HolidayRequest requestTelphone = new HolidayRequest(1, "张三");
            HolidayRequest requestSoftware = new HolidayRequest(4, "李四");
            HolidayRequest requestComputers = new HolidayRequest(20, "王二");

            Approver step1 = new Step1("直接领导");
            Approver step2 = new Step2("总监");
            Approver step3 = new Step3("老板");

            // 设置责任链
            step1.NextApprover = step2;
            step2.NextApprover = step3;

            // 处理请求
            step1.ProcessRequest(requestTelphone);
            step1.ProcessRequest(requestSoftware);
            step1.ProcessRequest(requestComputers);
            #endregion

            #region 简单工厂
            var language = LanguageFactory.Create("china");
            language.Write("lind");
            Console.WriteLine(language.Read());
            #endregion

            #region 工厂方法
            IEventHandlerFactory factory = new RedisEventHandlerFactory();
            ProductEventHandler handler = new RedisEventHandler();
            factory.Execute(handler);
            #endregion

            #region 抽象工厂
            DataProviderFactory dataProviderFactory = new MySqlDataProviderFactory();
            DataProvider dataProvider = new MySqlDataProvider("local");
            CommandProvider commandProvider = new MySqlCommandProvider();
            dataProvider.SetConnstring();
            commandProvider.ExecuteSql("select * from users");
            #endregion
            Console.ReadLine();
        }
    }
}