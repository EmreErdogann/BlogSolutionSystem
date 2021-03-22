using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSolutionSystem.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IArticleRepository Articles { get; }
        ICategoryRepository Categories { get; }
        ICommentRepository Comment { get; }
        void Save();
    }
}
