using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Exception
{
    public class CategoryException:System.Exception
    {
        public CategoryException():base("bele Category varindi") { }
 
    
        public CategoryException(string message):base(message) { }  
    }
}
