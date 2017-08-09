using System;
using System.Collections.Generic;
using System.Text;

//工厂方法
namespace Lind.DesignPattern.Lib.FactoryMethod
{
    /// <summary>
    /// 抽象产品
    /// </summary>
    public abstract class ProductEventHandler
    {
        public abstract string Name { get; }
        public abstract void PrintMsg();
    }

    /// <summary>
    /// 抽象工厂
    /// </summary>
    public interface IEventHandlerFactory
    {
        void Execute(ProductEventHandler handler);
    }

    /// <summary>
    /// 具体产品
    /// </summary>
    public class RedisEventHandler : ProductEventHandler
    {
        public override string Name { get { return "redis"; } }
        public void InsertHash(string key, string value)
        {
            Console.WriteLine("key:{0},value:{1}", key, value);
        }

        public override void PrintMsg()
        {
            Console.WriteLine("PrintMsg.Name:" + this.Name);
        }
    }

    /// <summary>
    /// 具体工厂
    /// </summary>
    public class RedisEventHandlerFactory : IEventHandlerFactory
    {
        public void Execute(ProductEventHandler handler)
        {
            var redis = handler as RedisEventHandler;
            Console.WriteLine(redis.Name);
            redis.InsertHash("zzl", "lind");
            redis.PrintMsg();
        }
    }
}
