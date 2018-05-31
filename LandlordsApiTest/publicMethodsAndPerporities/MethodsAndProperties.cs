using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LandlordsApiTest.publicMethodsAndPerporities
{
    class MethodsAndProperties
    {
        public static List<ResponseBodyFromPost> ResponseBodyFromPosts = new List<ResponseBodyFromPost>();
        public static List<ResponseBodyFromGet> ResponseBodyFromGets = new List<ResponseBodyFromGet>();
        public static List<PutMessage> PutMeessages = new List<PutMessage>();
        public static List<DeleteMessage> DeleteMeessages = new List<DeleteMessage>();

        public static string Id = null;

        public static string ApiAddress = null;
        public static string HeaderKey = null;
        public static string HeaderValue = null;

        public static Body body=new Body()
        {
            firstName = "morgan" + GenerateRandomString(),
            lastName = "morgan" + GenerateRandomString(),
            trusted = false
        };


        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public static string ConvertPosrbodyToString(Body body)
        {
            string jsonString = JsonConvert.SerializeObject(body);
            return jsonString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomString()
        {
            string randomString = null;
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                int str = random.Next(97, 123);
                randomString += Convert.ToChar(str).ToString();
            }

            return randomString;
        }
        public class Body
        {

            public string firstName { get; set; }
            public string lastName { get; set; }
            public bool trusted { get; set; }
        }

        public class ResponseBodyFromPost
        {
            public string id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public bool trusted { get; set; }
            public string[] apartments { get; set; }
        }


        public class ResponseBodyFromGet
        {
            public string id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public bool trusted { get; set; }
            public string[] apartments { get; set; }
        }
   

        public class PutMessage
        {
            public string message { get; set; }
        }
        public class DeleteMessage
        {
            public string message { get; set; }
        }
    }
}
