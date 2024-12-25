using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs
{
    public class GetAllCategory
    {
       public IQueryable<GetCategoryDto> _categories;
    }
}
