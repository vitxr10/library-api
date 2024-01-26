using Library.Application.InputModels;
using Library.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services.Interfaces
{
    public interface IBooksService
    {
        List<BookViewModel> GetAll();
        BookDetailsViewModel GetById(int id);
        int Create(CreateBookInputModel inputModel);
        void Delete(int id);
    }
}
