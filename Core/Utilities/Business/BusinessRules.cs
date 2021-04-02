using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Result;

namespace Core.Utilities.BusinessRules
{
   public class BusinessRules
    {
        public static IResult Run(params IResult[] logicResults)
        {
            foreach (var logics in logicResults)
            {
                if (!logics.Success)
                {
                    return logics;
                }

            }

            return null;
        }
    }
}
