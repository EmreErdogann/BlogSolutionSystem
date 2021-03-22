using BlogSolutionSystem.Business.Interfaces;
using BlogSolutionSystem.Core.Utilities.Results.Abstract;
using BlogSolutionSystem.Core.Utilities.Results.ComplexTypes;
using BlogSolutionSystem.Core.Utilities.Results.Concrete;
using BlogSolutionSystem.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSolutionSystem.Business.Implementaions
{
    public class CommentManager : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IDataResult<int> Count()
        {
            var commentCount = _unitOfWork.Comment.Count(c => c.IsDeleted == true);
            if (commentCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, commentCount);
            }
            return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen hata ile karşılaşıldı", -1);

        }
    }
}
