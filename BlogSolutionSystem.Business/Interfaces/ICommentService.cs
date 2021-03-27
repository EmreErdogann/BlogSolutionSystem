using BlogSolutionSystem.Core.Utilities.Results.Abstract;
using BlogSolutionSystem.Entities.Dtos.CommentD;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSolutionSystem.Business.Interfaces
{
    public interface ICommentService
    {
        IDataResult<CommentDto> Get(int commentId);
        IDataResult<CommentUpdateDto> GetCommentUpdateDto(int commentId);
        IDataResult<CommentListDto> GetAll();
        IDataResult<CommentListDto> GetAllByDeleted();
        IResult Add(CommentAddDto commentAddDto);
        IResult Update(CommentUpdateDto commentUpdateDto, string modifiedByName);
        IResult Delete(int commentId, string modifiedByName);
        IResult HardDelete(int commentId);
        IDataResult<int> Count();

    }
}
