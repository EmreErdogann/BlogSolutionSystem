using BlogSolutionSystem.Core.Utilities.Results.Abstract;
using BlogSolutionSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using BlogSolutionSystem.Entities.Dtos.ArticleD;

namespace BlogSolutionSystem.Business.Interfaces
{
    public interface IArticleService
    {
        IDataResult<ArticleDto> Get(int articleId);
        IDataResult<ArticleUpdateDto> GetArticleUpdate(int articleId);
        IDataResult<ArticleListDto> GetAll();
        IDataResult<ArticleListDto> GetAllByDeleted();
        //IDataResult<ArticleListDto> GetAllByViewCount(bool isAscending, int? takeSize);
        IResult Add(ArticleAddDto articleAddDto, string createdByName, int userId);
        IResult Update(ArticleUpdateDto articleUpdateDto, string modifeidByName);
        IResult Delete(int articleId, string modifiedByName);
        IResult HardDelete(int articleId);
        IDataResult<int> Count();

    }
}
