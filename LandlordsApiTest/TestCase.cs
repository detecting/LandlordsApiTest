using LandlordsApiTest.publicMethodsAndPerporities;
using LandlordsApiTest.TestApis;
using NUnit.Framework;

namespace LandlordsApiTest
{
    public class TestCase
    {
        [SetUp]
        public void Initialize()
        {
            MethodsAndProperties.ApiAddress = "http://localhost:8080/landlords/";
            MethodsAndProperties.HeaderKey = "content-type";
            MethodsAndProperties.HeaderValue = "application/json";
        }

        [Test, Order(1), Description("Post data to landlords")]
        public void Post()
        {
            Apis.PostMethod(MethodsAndProperties.ApiAddress, MethodsAndProperties.HeaderKey,
                MethodsAndProperties.HeaderValue, MethodsAndProperties.body);
        }


        [Test, Order(2), Description("Get data from landlords")]
        public void GetById()
        {
            Apis.GetByIdMethdd(MethodsAndProperties.ApiAddress, MethodsAndProperties.Id,
                MethodsAndProperties.body);
        }


        [Test, Order(3), Description("Put data to landlords")]
        public void PutById()
        {
            Apis.PutMethod(MethodsAndProperties.ApiAddress, MethodsAndProperties.Id,
                MethodsAndProperties.HeaderKey, MethodsAndProperties.HeaderValue, MethodsAndProperties.body);
        }

        [Test, Order(4), Description("Delete from landlords")]
        public void DeleteById()
        {
            Apis.DeleteMethod(MethodsAndProperties.ApiAddress, MethodsAndProperties.Id);
        }

        [TearDown]
        public static void ClearUp()
        {
        }
    }
}