using BlogSolutionSystem.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSolutionSystem.Business.Interfaces
{
    public interface ICommentService
    {
        IDataResult<int> Count();

    }
}
