using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Exception
{
    public class ExceptionForId : System.Exception
    {
        public ExceptionForId() : base("Id menfi ve sifir ola bilmez") { }
        public ExceptionForId(string message) : base(message) { }
    }
}
