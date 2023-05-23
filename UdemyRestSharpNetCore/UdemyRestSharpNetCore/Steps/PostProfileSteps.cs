using RestSharp;
using UdemyRestSharpNetCore.Base;
using UdemyRestSharpNetCore.Model;
using UdemyRestSharpNetCore.Utilities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace UdemyRestSharpNetCore.Steps
{

    [Binding]
    public class PostProfileSteps
    {
        private Settings _settings;
        public PostProfileSteps(Settings settings) => _settings = settings;

        [Given(@"I Perform POST operation for ""(.*)"" with body")]
        public void GivenIPerformPOSTOperationForWithBody(string url, Table table)
        {

            dynamic data = table.CreateDynamicInstance();

            _settings.Request = new RestRequest(url, Method.POST);

            //_settings.Request.RequestFormat = DataFormat.Json;
            //_settings.Request.AddBody(new { name = data.name.ToString() });

            _settings.Request.AddJsonBody(new { name = data.name.ToString() });

            _settings.Request.AddUrlSegment("profileNo", ((int)data.profile).ToString());

            _settings.Response = _settings.RestClient.ExecuteAsyncRequests<Posts>(_settings.Request).GetAwaiter().GetResult();

        }

    }
}
