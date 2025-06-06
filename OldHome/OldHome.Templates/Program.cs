using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Templates
{
    public class Program
    {
        static void Main()
        {
            var entities = new[] { "Resident", "Staff", "Room", "Bed", "Medicine" };

            foreach (var entity in entities)
            {
                // 读取模板
                var template = File.ReadAllText("ResidentDTOGenerator.tt");

                // 替换实体名
                template = template.Replace("Resident.cs", $"{entity}.cs");

                // 写入新的模板文件
                File.WriteAllText($"{entity}DTOGenerator.tt", template);

                Console.WriteLine($"已为 {entity} 创建模板文件");
            }
        }
    }
}
