using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Exception
{
    public class CategoryNameException:System.Exception
    {
        public CategoryNameException():base("Category name duzgun deyil") { }

        public CategoryNameException(string message):base(message) { }
    }
}
