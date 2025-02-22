using Microsoft.AspNetCore.Mvc;

namespace Common.Helper
{
    public static class HandleRequestHelper
    {
        public static async Task<IActionResult> HandleRequest(Func<Task<(bool Success, object Response)>> action)
        {
            Dictionary<string, dynamic> modelJson = new();

            try
            {
                var (success, response) = await action();

                modelJson.Add("Success", success);
                modelJson.Add("ResponseRequest", response);
            }
            catch (Exception error)
            {
                modelJson.Add("Success", false);
                modelJson.Add("ResponseRequest", "Error: " + error.Message);
            }

            return new OkObjectResult(modelJson);
        }
    }
}
