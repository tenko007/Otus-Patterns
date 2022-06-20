using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace MyGenerator
{
    [Generator]
    public class MySourceGenerator : ISourceGenerator
    {
        public void Execute(SourceGeneratorContext context)
        {
            // TODO - здесь размещается генератор исходного кода
        }

        public void Initialize(InitializationContext context)
        {
            // инициализация здесь не требуется 
        }
    }
}