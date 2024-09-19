using RedGrape.Infra.Transmit.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.RedGrape.Infra.Core.Test.Dto;

namespace Test.RedGrape.Infra.Core.Test
{
    
    public class RestClientTest
    {
        [Fact]
        public void send_post_except_get_response()
        {
            //arange
            RestClient restClient = new RestClient();
            PostRequest postRequest = DtoFactory.CraetePostResquest();
            var exceptdResponse = DtoFactory.CreateExceptdPostResponse();

            //ast 
            PostResponse value = restClient.PostAsync<PostResponse, PostRequest>("https://jsonplaceholder.typicode.com/posts", postRequest).Result;

            //assert
            Assert.Equivalent(exceptdResponse, value);


        }

        [Fact]
        public async Task call_get_except_valid_response()
        {
            //arrang
            RestClient restClient = new RestClient();
            var exceptdResponse = DtoFactory.CreateExceptdPostResponse();

            //ast 
            PostResponse value = await restClient.GetAsync<PostResponse>("https://jsonplaceholder.typicode.com/posts/1");

            //assert
            Assert.IsType<PostResponse>(value);
        }


    }
}
