using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace CodeGeneration.Variant3
{
    [Generator]
    public class HelloWorldGenerator : ISourceGenerator
    {
        public void Execute(SourceGeneratorContext context)
        {

            // код, который мы будем внедрять в компиляцию пользователя
            var sourceBuilder = new StringBuilder(@"

using System;
namespace HelloWorldGenerated
{
    public static class HelloWorld
    {
        public static void SayHello() 
        {
            Console.WriteLine(""Привет из сгенерированного кода!"");
            Console.WriteLine(""В компиляции данной программы есть следующие синтаксические деревья"");
");

            // используя контекст, получим список синтаксических деревьев в пользовательской компиляции
            var syntaxTrees = context.Compilation.SyntaxTrees;
            // добавим путь к файлу каждого дерева в класс, который мы создаем
            foreach (SyntaxTree tree in syntaxTrees)
            {
                sourceBuilder.AppendLine($@"Console.WriteLine(@"" - {tree.FilePath}"");");
            }
            //завершаем создание внедряемого кода
            sourceBuilder.Append(@"
        }
    }
}");
            // внедрим созданный исходник в компиляцию пользователя
            context.AddSource("helloWorldGenerator", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
        }

        public void Initialize(InitializationContext context)
        {
            // инициализация здесь не требуется 
        }
    }
}