using BlogSolutionSystem.Data.DataContext;
using BlogSolutionSystem.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSolutionSystem.Data.Implementaions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogSolutionSystemDataContext _dbContext;
        private EfArticleRepository _articleRepository;
        private EfCategoryRepository _categoryRepository;
        private EfCommentRepository _commentRepository;
        public UnitOfWork(BlogSolutionSystemDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IArticleRepository Articles => _articleRepository ?? new EfArticleRepository(_dbContext);

        public ICategoryRepository Categories => _categoryRepository ?? new EfCategoryRepository(_dbContext);

        public ICommentRepository Comment => _commentRepository ?? new EfCommentRepository(_dbContext);

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

    }
}
