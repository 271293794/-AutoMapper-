using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace 配置AutoMapper映射规则
{
    class Program
    {
        /// <summary>
        /// 源数据类
        /// </summary>
        public class Source
        {
            public int SomeValue { get; set; }
            public string AnotherValue { get; set; }
        }
        /// <summary>
        /// 目标类
        /// </summary>
        public class Destination
        {
            public int SomeValue { get; set; }
            public string Another { get; set; }
        }
        public static void CreateMap()
        {
            // dest 目标对象（Destination 简写），src 源对象（Source 简写）
            Mapper.Initialize(cfg => cfg.CreateMap<Source, Destination>().
            // AnotherValue 映射到 Another
            ForMember(dest => dest.Another, opt => opt.MapFrom(src => src.AnotherValue)));
            // 源中的SomeValue自动映射到目标类中同名属性
            

        }
        static void Main(string[] args)
        {

            CreateMap();
            Source src = new Source() { SomeValue = 1, AnotherValue = "作者" };
            Destination dest = Mapper.Map<Destination>(src);

            Console.WriteLine(dest.SomeValue+"\r\n"+dest.Another);
        }
    }
}
