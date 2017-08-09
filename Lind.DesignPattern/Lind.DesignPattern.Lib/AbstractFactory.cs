using System;
using System.Collections.Generic;
using System.Text;

namespace Lind.DesignPattern.Lib.AbstractFactory
{
    /// <summary>
    /// 抽象产品:数据提供者
    /// </summary>
    public abstract class DataProvider
    {
        private string _connString;
        public DataProvider(string connString)
        {
            _connString = connString;
        }
        public string ConnString { get { return _connString; } }
        public abstract void SetConnstring();
    }
    /// <summary>
    /// 具体产品:SqlServer
    /// </summary>
    public class SqlServerDataProvider : DataProvider
    {
        public SqlServerDataProvider(string connString) : base(connString)
        { }

        public override void SetConnstring()
        {
            Console.WriteLine("设置sqlserver需要的链接串:{0}", ConnString);
        }
    }
    /// <summary>
    /// 具体产品:Mysql
    /// </summary>
    public class MySqlDataProvider : DataProvider
    {
        public MySqlDataProvider(string connString) : base(connString)
        { }

        public override void SetConnstring()
        {
            Console.WriteLine("设置MySql需要的链接串:{0}", ConnString);
        }
    }

    /// <summary>
    /// 抽象产品:命令提供者
    /// </summary>
    public abstract class CommandProvider
    {
        public abstract int ExecuteSql(string sql);
    }
    /// <summary>
    /// 具体产品:SqlServer命令
    /// </summary>
    public class SqlServerCommandProvider : CommandProvider
    {
        public override int ExecuteSql(string sql)
        {
            Console.WriteLine("SqlServer:" + sql);
            return 1;
        }
    }
    /// <summary>
    /// 具体产品:Mysql命令
    /// </summary>
    public class MySqlCommandProvider : CommandProvider
    {
        public override int ExecuteSql(string sql)
        {
            Console.WriteLine("MySql:" + sql);
            return 1;
        }
    }


    /// <summary>
    /// 抽象工厂
    /// </summary>
    public abstract class DataProviderFactory
    {
        public abstract DataProvider CreateDataProvider(string connStr);
        public abstract CommandProvider CreateCommandProvider();
    }
    /// <summary>
    /// 具体工厂:sql
    /// </summary>
    public class SqlDataProviderFactory : DataProviderFactory
    {
        public override CommandProvider CreateCommandProvider()
        {
            return new SqlServerCommandProvider();
        }

        public override DataProvider CreateDataProvider(string connStr)
        {
            return new SqlServerDataProvider(connStr);
        }
    }
    /// <summary>
    /// 具体工厂:mysql
    /// </summary>
    public class MySqlDataProviderFactory : DataProviderFactory
    {
        public override CommandProvider CreateCommandProvider()
        {
            return new MySqlCommandProvider();
        }

        public override DataProvider CreateDataProvider(string connStr)
        {
            return new MySqlDataProvider(connStr);
        }
    }
}
