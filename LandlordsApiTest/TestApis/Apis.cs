using System;
using LandlordsApiTest.publicMethodsAndPerporities;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;

namespace LandlordsApiTest.TestApis
{
    class Apis
    {
        //post
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiAddress"></param>
        /// <param name="headerKey"></param>
        /// <param name="headerValue"></param>
        /// <param name="body"></param>
        public static void PostMethod(string apiAddress, string headerKey, string headerValue,
            MethodsAndProperties.Body body)
        {
            var client = new RestClient(apiAddress);
            var request = new RestRequest(Method.POST);

            request.AddHeader(headerKey, headerValue);
            request.AddParameter(headerValue, MethodsAndProperties.ConvertPosrbodyToString(body),
                ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            string content = response.Content;

            //deserilization--返回的响应
            MethodsAndProperties.ResponseBodyFromPosts.Add(
                JsonConvert.DeserializeObject<MethodsAndProperties.ResponseBodyFromPost>(content));
            //对比回来的数据；
            foreach (var variable in MethodsAndProperties.ResponseBodyFromPosts)
            {
                MethodsAndProperties.Id = variable.id;
                Assert.AreEqual(body.firstName, variable.firstName);
                Assert.AreEqual(body.lastName, variable.lastName);
                Console.WriteLine("Post Response Id:  " + variable.id);
            }
        }

        /// <summary>
        /// get
        /// </summary>
        /// <param name="apiAddress"></param>
        /// <param name="id"></param>
        /// <param name="body"></param>
        public static void GetByIdMethdd(string apiAddress, string id, MethodsAndProperties.Body body)
        {
            var client = new RestClient(apiAddress + id);
            //取操作
            var request = new RestRequest(Method.GET);
            //得到response
            IRestResponse response = client.Execute(request);

            //get response data: string
            string content = response.Content;

            //deserilization-json
            //ResponseBodyFromGets 是一个list,这里操作往 list里面添加返回的对象；
            MethodsAndProperties.ResponseBodyFromGets.Add(
                //                将content 反序列化为ResponseBodyFromGet对象
                JsonConvert.DeserializeObject<MethodsAndProperties.ResponseBodyFromGet>(content));
            //compare the get value to the posted value
            foreach (var variable in MethodsAndProperties.ResponseBodyFromGets)
            {
                // here is a important, add the geted id and store it into MethodsAndProperties.Id for further use.
                Assert.AreEqual(body.firstName, variable.firstName);
                Assert.AreEqual(body.lastName, variable.lastName);
                Console.WriteLine("Get Id:  " + id);
            }
        }


        /// <summary>
        /// put
        /// </summary>
        /// <param name="apiAddress"></param>
        /// <param name="id"></param>
        /// <param name="headerKey"></param>
        /// <param name="headerValue"></param>
        /// <param name="postBody">put body</param>
        public static void PutMethod(string apiAddress, string id, string headerKey, string headerValue,
            MethodsAndProperties.Body body)
        {
            var client = new RestClient(apiAddress + id);
            var request = new RestRequest(Method.PUT);
            request.AddHeader(headerKey, headerValue);
            request.AddParameter(headerValue, MethodsAndProperties.ConvertPosrbodyToString(body),
                ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string content = response.Content;
            MethodsAndProperties.PutMeessages.Add(
                JsonConvert.DeserializeObject<MethodsAndProperties.PutMessage>(content));
            foreach (var variable in MethodsAndProperties.PutMeessages)
            {
                Assert.AreEqual("LandLord with id: " + id + " successfully updated", variable.message);
                Console.WriteLine("Put Id:  " + id);
            }
        }

        //delete
        /// <summary>
        /// delete
        /// </summary>
        /// <param name="apiAddress"></param>
        /// <param name="id"></param>
        public static void DeleteMethod(string apiAddress, string id)
        {
            var client = new RestClient(apiAddress + id);
            var request = new RestRequest(Method.DELETE);
            IRestResponse response = client.Execute(request);
            string content = response.Content;
            MethodsAndProperties.DeleteMeessages.Add(
                JsonConvert.DeserializeObject<MethodsAndProperties.DeleteMessage>(content));
            foreach (var variable in MethodsAndProperties.DeleteMeessages)
            {
                Console.WriteLine(variable.message);
                Assert.AreEqual("LandLord with id: " + id + " successfully deleted", variable.message);
                Console.WriteLine("Delete Id:  " + id);
            }
        }
    }
}