using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
   public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
        }

        public ErrorDataResult(T data) : base(data,false)
        {
        }

        public ErrorDataResult(string messages) : base(default, false, messages)
        {

        }

        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
