using BlogSolutionSystem.Core.Utilities.Results.Abstract;
using BlogSolutionSystem.Entities.Concrete;
using BlogSolutionSystem.Entities.Dtos.CategoryD;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSolutionSystem.Business.Interfaces
{
    public interface ICategoryService
    {
        IDataResult<CategoryDto> Get(int categoryId);
        IDataResult<CategoryListDto> GetAll();
        IDataResult<CategoryListDto> GetAllByDeleted();
        IResult Add(CategoryAddDto categoryAddDto, string createdByName);
        IResult Update(CategoryUpdateDto categoryUpdateDto, string modifeidByName);
        IResult Delete(int categoryId, string modifiedByName);
        IResult HardDelete(int categoryId);
        IDataResult<int> Count();

    }
}
