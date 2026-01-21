using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagery.Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message) { }
        public SuccessResult() : base(true) { }
    }

    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message) { }
        public ErrorResult() : base(false) { }
    }

    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message) { }
        public SuccessDataResult(T data) : base(data, true) { }
        public SuccessDataResult(string message) : base(default, true, message) { }
        public SuccessDataResult() : base(default, true) { }
    }

    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message) { }
        public ErrorDataResult(T data) : base(data, false) { }
        public ErrorDataResult(string message) : base(default, false, message) { }
        public ErrorDataResult() : base(default, false) { }
    }
}
