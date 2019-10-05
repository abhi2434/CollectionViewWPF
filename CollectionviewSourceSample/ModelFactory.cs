using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionviewSourceSample
{
    class ModelFactory
    {
        public static ViewItem[] Build() => new[]
  {
             new ViewItem { Id = "1", Name = "Abhishek", Developer = "WPF", Salary = 50000.20f },
           new ViewItem { Id = "2", Name = "Abhijit", Developer = "ASP.NET", Salary = 89000.20f },
          new ViewItem { Id = "3", Name = "Scott", Developer = "ASP.NET", Salary = 95000.20f },
            new ViewItem { Id = "4", Name = "Kunal", Developer = "Silverlight", Salary = 26000.20f },
           new ViewItem { Id = "5", Name = "Hanselman", Developer = "ASP.NET", Salary = 78000.20f },
            new ViewItem { Id = "6", Name = "Peter", Developer = "WPF", Salary = 37000.20f },
            new ViewItem { Id = "7", Name = "Tim", Developer = "Silverlight", Salary = 45000.20f },
           new ViewItem { Id = "8", Name = "John", Developer = "ASP.NET", Salary = 70000.20f },
           new ViewItem { Id = "9", Name = "Shibatosh", Developer = "WPF", Salary = 40000.20f }
        };
    }
}
