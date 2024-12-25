using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace BlogApp.Business.DTOs
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
    }

    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
    {

        public CreateCategoryValidator()
        {

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("bos ola bilmez")
                .NotNull()
                .WithMessage("bos ola bilmez")
                .MaximumLength(30)
                .WithMessage("name uzunlugu max 20 ola biler")
                .MinimumLength(5)
                .WithMessage("name uzunlugu min5 max ola biler");

        }
    }
}
