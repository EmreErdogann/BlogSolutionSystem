using BlogSolutionSystem.Core.Utilities.Results.Abstract;
using BlogSolutionSystem.Core.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSolutionSystem.Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(ResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
        }
        public Result(ResultStatus resultStatus, string message)
        {
            ResultStatus = resultStatus;
            Message = message;

        }
        public Result(ResultStatus resultStatus, string message, Exception exception)
        {
            ResultStatus = resultStatus;
            Message = message;
            Exception = exception;
        }

        public ResultStatus ResultStatus { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }
}
