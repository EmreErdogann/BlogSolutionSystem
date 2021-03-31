using AutoMapper;
using BlogSolutionSystem.Business.Interfaces;
using BlogSolutionSystem.Core.Utilities.Results.Abstract;
using BlogSolutionSystem.Core.Utilities.Results.ComplexTypes;
using BlogSolutionSystem.Core.Utilities.Results.Concrete;
using BlogSolutionSystem.Data.Interfaces;
using BlogSolutionSystem.Entities.Concrete;
using BlogSolutionSystem.Entities.Dtos.ArticleD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSolutionSystem.Business.Implementaions
{
    public class ArticleManager : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ArticleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IResult Add(ArticleAddDto articleAddDto, string createdByName, int userId)
        {
            var article = _mapper.Map<Article>(articleAddDto);
            article.CreatedDate = DateTime.Now;
            article.CreatedByName = createdByName;
            article.ModifiedByName = createdByName;
            article.UserId = userId;
            _unitOfWork.Articles.Add(article);
            _unitOfWork.Save();
            return new Result(ResultStatus.Success, $"{articleAddDto.Title} başlıklı makale başarı ile eklenmiştir");
        }

        public IDataResult<int> Count()
        {
            var articleCount = _unitOfWork.Articles.Count(c => c.IsDeleted == false);
            if (articleCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, articleCount);

            }
            return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen hata ile karşılaşıldı", -1);
        }

        public IResult Delete(int articleId, string modifiedByName)
        {
            var result = _unitOfWork.Articles.Any(c => c.Id == articleId);
            if (result)
            {
                var article = _unitOfWork.Articles.Get(a => a.Id == articleId);
                article.ModifiedByName = modifiedByName;
                article.IsDeleted = true;
                _unitOfWork.Articles.Update(article);
                _unitOfWork.Save();
                return new Result(ResultStatus.Success, $"{article.Title} başlıklı makale başarı ile silinmiştir");
            }
            return new Result(ResultStatus.Error, "Böyle bir makale bulunamadı");
        }

        public IDataResult<ArticleDto> Get(int articleId)
        {
            var article = _unitOfWork.Articles.Get(predicate: a => a.Id == articleId, a => a.Category, a => a.User, a => a.Comments);
            if (article != null)
            {
                return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto
                {
                    Article = article
                });
            }
            return new DataResult<ArticleDto>(ResultStatus.Error, "Böyle bir makale bulunamadı", null);
        }

        public IDataResult<ArticleListDto> GetAll()
        {
            var articles = _unitOfWork.Articles.GetAll(null, c => c.Category, c => c.User);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Böyle bir makale bulunamadı", null);

        }

        public IDataResult<ArticleListDto> GetAllByDeleted()
        {
            var articles = _unitOfWork.Articles.GetAll(predicate: c => c.IsDeleted == false, c => c.Category, a => a.User);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Böyle bir makale bulunamadı", null);

        }

        //public IDataResult<ArticleListDto> GetAllByViewCount(bool isAscending, int? takeSize)
        //{
        //    var articles = _unitOfWork.Articles.GetAll(a => a.IsDeleted == false, a => a.User);
        //    var sortedArticles = isAscending ? articles.OrderBy(a => a.ViewsCount) : articles.OrderByDescending(x => x.ViewsCount);
        //    return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
        //    {
        //        Articles = takeSize = null ? sortedArticles.ToList() : sortedArticles.Take(takeSize.Value).ToList()
        //    });
        //}

        public IDataResult<ArticleUpdateDto> GetArticleUpdate(int articleId)
        {
            var result = _unitOfWork.Articles.Any(c => c.Id == articleId);
            if (result)
            {
                var article = _unitOfWork.Articles.Get(c => c.Id == articleId);
                var articleUpdateDto = _mapper.Map<ArticleUpdateDto>(article);
                return new DataResult<ArticleUpdateDto>(ResultStatus.Success, articleUpdateDto);
            }
            return new DataResult<ArticleUpdateDto>(ResultStatus.Error, "", null);
        }

        public IResult HardDelete(int articleId)
        {
            var result = _unitOfWork.Articles.Any(c => c.Id == articleId);
            if (result)
            {
                var article = _unitOfWork.Articles.Get(a => a.Id == articleId);
                _unitOfWork.Articles.Delete(article);
                _unitOfWork.Save();
                return new Result(ResultStatus.Success, $"{article.Title} başlıklı makale başarı ile silinmiştir");
            }
            return new Result(ResultStatus.Error, "Böyle bir makale bulunamadı");
        }

        public IResult Update(ArticleUpdateDto articleUpdateDto, string modifeidByName)
        {
            var article = _mapper.Map<Article>(articleUpdateDto);
            article.ModifiedByName = modifeidByName;
            article.ModifiedDate = DateTime.Now;
            _unitOfWork.Articles.Update(article);
            _unitOfWork.Save();
            return new Result(ResultStatus.Success, $"{articleUpdateDto.Title} başlıklı makale başarı ile güncellenmiştir");
        }
    }
}
