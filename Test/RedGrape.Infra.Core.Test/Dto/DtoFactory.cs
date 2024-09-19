using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.RedGrape.Infra.Core.Test.Dto
{
    internal class DtoFactory
    {
        public static PostRequest CraetePostResquest()
        {
            return new PostRequest
            {
                Body = "body",
                Title = "title",
                UserId = 100

            };
        }

        internal static object CreateExceptdPostResponse()
        {
            return new PostResponse { Body = "body", Id = 101 , Title = "title" , UserId = 100 };
        }
    }
}
