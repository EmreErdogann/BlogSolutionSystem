using AutoMapper;
using BlogSolutionSystem.Business.Interfaces;
using BlogSolutionSystem.Core.Utilities.Results.Abstract;
using BlogSolutionSystem.Core.Utilities.Results.ComplexTypes;
using BlogSolutionSystem.Core.Utilities.Results.Concrete;
using BlogSolutionSystem.Data.Interfaces;
using BlogSolutionSystem.Entities.Concrete;
using BlogSolutionSystem.Entities.Dtos.CommentD;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSolutionSystem.Business.Implementaions
{
    public class CommentManager : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CommentManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IResult Add(CommentAddDto commentAddDto)
        {
            var comment = _mapper.Map<Comment>(commentAddDto);
            var addedComment = _unitOfWork.Comment.Add(comment);
            _unitOfWork.Save();
            return new Result(ResultStatus.Success, $"{addedComment.Text} adlı yorum başarı ile eklenmiştir");

        }

        public IDataResult<CommentDto> Approve(int commentId, string modifiedByName)
        {
            var comment = _unitOfWork.Comment.Get(c => c.Id == commentId, c => c.Article);
            if (comment != null)
            {
                comment.IsActive = true;
                comment.ModifiedByName = modifiedByName;
                comment.ModifiedDate = DateTime.Now;
                var updatedComment = _unitOfWork.Comment.Update(comment);
                _unitOfWork.Save();
                return new DataResult<CommentDto>(ResultStatus.Success, $"{comment.Id} no'lu yorum başarıyla onaylanmıştır", new CommentDto { Comment = updatedComment });
            }
            return new DataResult<CommentDto>(ResultStatus.Error, "", null);
        }

        public IDataResult<int> Count()
        {
            var commentCount = _unitOfWork.Comment.Count(c => c.IsDeleted == false);
            if (commentCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, commentCount);
            }
            return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen hata ile karşılaşıldı", -1);

        }

        public IResult Delete(int commentId, string modifiedByName)
        {
            var comment = _unitOfWork.Comment.Get(c => c.Id == commentId);
            if (comment != null)
            {
                comment.IsDeleted = true;
                comment.ModifiedByName = modifiedByName;
                comment.ModifiedDate = DateTime.Now;
                var deletedComment = _unitOfWork.Comment.Update(comment);
                _unitOfWork.Save();
            }
            return new Result(ResultStatus.Error, "Böyle bir makale bulunamadı");

        }
        public IDataResult<CommentDto> Get(int commentId)
        {
            var comment = _unitOfWork.Comment.Get(c => c.Id == commentId);
            if (comment != null)
            {
                return new DataResult<CommentDto>(ResultStatus.Success, new CommentDto
                {
                    Comment = comment,
                });
            }
            return new DataResult<CommentDto>(ResultStatus.Error, "Böyle bir yorum bulunamadı", null);

        }

        public IDataResult<CommentListDto> GetAll()
        {
            var comments = _unitOfWork.Comment.GetAll(null, c => c.Article);
            if (comments.Count > -1)
            {
                return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto
                {
                    Comments = comments
                });
            }
            return new DataResult<CommentListDto>(ResultStatus.Error, "Böyle bir makale bulunamadı", null);
        }

        public IDataResult<CommentListDto> GetAllByDeleted()
        {
            var comments = _unitOfWork.Comment.GetAll(x => x.IsDeleted == false, c => c.Article);
            if (comments.Count > -1)
            {
                return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto
                {
                    Comments = comments
                });
            }
            return new DataResult<CommentListDto>(ResultStatus.Error, "Böyle bir makale bulunamadı", null);
        }

        public IDataResult<CommentUpdateDto> GetCommentUpdateDto(int commentId)
        {
            var result = _unitOfWork.Comment.Any(c => c.Id == commentId);
            if (result)
            {
                var comment = _unitOfWork.Comment.Get(c => c.Id == commentId);
                var commentUpdateDto = _mapper.Map<CommentUpdateDto>(comment);
                return new DataResult<CommentUpdateDto>(ResultStatus.Success, commentUpdateDto);
            }
            return new DataResult<CommentUpdateDto>(ResultStatus.Error, "", null);

        }

        public IResult HardDelete(int commentId)
        {
            var comment = _unitOfWork.Comment.Get(c => c.Id == commentId);
            if (comment != null)
            {
                _unitOfWork.Comment.Delete(comment);
                _unitOfWork.Save();
                return new Result(ResultStatus.Success, $"{comment.Text} adlı yorum başarı ile silinmiştir");
            }
            return new Result(ResultStatus.Error, "Böyle bir yorum bulunmadı");
        }

        public IResult Update(CommentUpdateDto commentUpdateDto, string modifiedByName)
        {
            var oldComment = _unitOfWork.Comment.Get(c => c.Id == commentUpdateDto.Id);
            var comment = _mapper.Map<CommentUpdateDto, Comment>(commentUpdateDto, oldComment);
            comment.ModifiedByName = modifiedByName;
            var updatedComment = _unitOfWork.Comment.Update(comment);
            _unitOfWork.Save();
            return new Result(ResultStatus.Success, $"{updatedComment.Text} adlı yorum başarı ile güncellenmiştir");

        }
    }
}
