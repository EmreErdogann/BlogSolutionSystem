using AutoMapper;
using BlogSolutionSystem.Business.Interfaces;
using BlogSolutionSystem.Core.Utilities.Results.Abstract;
using BlogSolutionSystem.Core.Utilities.Results.ComplexTypes;
using BlogSolutionSystem.Core.Utilities.Results.Concrete;
using BlogSolutionSystem.Data.Interfaces;
using BlogSolutionSystem.Entities.Concrete;
using BlogSolutionSystem.Entities.Dtos.CategoryD;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSolutionSystem.Business.Implementaions
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IResult Add(CategoryAddDto categoryAddDto, string createdByName)
        {
            var category = _mapper.Map<Category>(categoryAddDto);
            category.CreatedDate = DateTime.Now;
            category.CreatedByName = createdByName;
            category.ModifiedByName = createdByName;
            _unitOfWork.Categories.Add(category);
            _unitOfWork.Save();
            return new Result(ResultStatus.Success, $"{categoryAddDto.Name} adlı kategori başarı ile eklenmiştir");

        }

        public IDataResult<int> Count()
        {
            var categoryCount = _unitOfWork.Categories.Count(c => c.IsDeleted == false);
            if (categoryCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, categoryCount);
            }
            return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen hata ile karşılaşıldı", -1);
        }

        public IResult Delete(int categoryId, string modifiedByName)
        {
            var category = _unitOfWork.Categories.Get(c => c.Id == categoryId);
            if (category != null)
            {
                category.IsDeleted = true;
                category.ModifiedByName = modifiedByName;
                _unitOfWork.Categories.Update(category);
                _unitOfWork.Save();
                return new Result(ResultStatus.Success, $"{category.Name} adlı kategori başarı ile silinmiştir");
            }
            return new Result(ResultStatus.Error, "Böyle bir kategori bulunamadı");
        }

        public IDataResult<CategoryDto> Get(int categoryId)
        {
            var category = _unitOfWork.Categories.Get(c => c.Id == categoryId, c => c.Articles);
            if (category != null)
            {
                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    Category = category
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, "Böyle bir kategori bulunamadı", null);

        }

        public IDataResult<CategoryListDto> GetAll()
        {
            var category = _unitOfWork.Categories.GetAll(null, c => c.Articles);
            if (category.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = category
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Hiç bir kategori bulunamadı", null);
        }

        public IDataResult<CategoryListDto> GetAllByDeleted()
        {
            var category = _unitOfWork.Categories.GetAll(predicate: c => c.IsDeleted == false, includeProperties: c => c.Articles);
            if (category.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = category,
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Hiç bir kategori bulunamadı", null);
        }

        public IResult HardDelete(int categoryId)
        {
            var category = _unitOfWork.Categories.Get(c => c.Id == categoryId);
            if (category != null)
            {
                _unitOfWork.Categories.Delete(category);
                _unitOfWork.Save();
                return new Result(ResultStatus.Success, $"{category.Name} adlı kategori başarı ile veritabanından silinmiştir");
            }
            return new Result(ResultStatus.Error, "Böyle bir kategori bulunamadı");
        }

        public IResult Update(CategoryUpdateDto categoryUpdateDto, string modifeidByName)
        {
            var category = _mapper.Map<Category>(categoryUpdateDto);
            category.ModifiedDate = DateTime.Now;
            category.ModifiedByName = modifeidByName;
            return new Result(ResultStatus.Success, $"{categoryUpdateDto.Name} adlı kategori başarı ile güncellenmiştir");
        }
    }
}
