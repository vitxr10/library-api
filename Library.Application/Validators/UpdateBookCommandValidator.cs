using FluentValidation;
using Library.Application.Commands.BooksCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Validators
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(b => b.Title)
                .NotEmpty().WithMessage("O preenchimento do título é obrigatório.")
                .NotNull().WithMessage("O preenchimento do título é obrigatório.");

            RuleFor(b => b.Actor)
                .NotEmpty().WithMessage("O preenchimento do ator é obrigatório.")
                .NotNull().WithMessage("O preenchimento do ator é obrigatório.");

            RuleFor(b => b.ISBN)
                .NotEmpty().WithMessage("O preenchimento do ISBN é obrigatório.")
                .NotNull().WithMessage("O preenchimento do ISBN é obrigatório.");

            RuleFor(b => b.YearOfPublication)
                .GreaterThan(0).WithMessage("O ano de publicação deve ser maior que zero.");
        }
    }
}
