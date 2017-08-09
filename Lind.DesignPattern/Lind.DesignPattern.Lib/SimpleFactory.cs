using System;
using System.Collections.Generic;
using System.Text;

//简单工厂
namespace Lind.DesignPattern.Lib.SimpleFactory
{

    public abstract class LanguageBase
    {
        protected string Message = string.Empty;
        public abstract string Read();
        public abstract void Write(string message);
    }

    public class ChinaLanguage : LanguageBase
    {

        public override string Read()
        {
            return "中文:" + Message;
        }

        public override void Write(string message)
        {
            Message = message;
        }
    }
    public class EnglishLanguage : LanguageBase
    {
        public override string Read()
        {
            return "English:" + Message;
        }

        public override void Write(string message)
        {
            Message = message;
        }
    }

    public class LanguageFactory
    {
        public static LanguageBase Create(string type)
        {
            switch (type)
            {
                case "china":
                    return new ChinaLanguage();
                case "english":
                    return new EnglishLanguage();
                default:
                    throw new ArgumentException("语言类型参数无效！");
            }
        }
    }

}
