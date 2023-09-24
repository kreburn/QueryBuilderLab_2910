using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QB_Lab
{
    public class FileRoot
    {
        public static string? Root { get; } = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
    }
}
