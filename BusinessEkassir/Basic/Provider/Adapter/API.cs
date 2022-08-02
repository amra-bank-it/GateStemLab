using InterFaceEkassir.Basic.Provider.Models;
using Newtonsoft.Json;
using Provider.Model;
using RestSharp;
using System;
using System.Net;

namespace InterFaceEkassir.Basic.Provider.Adapter
{
  internal class API
  {
    public void SendRequest(string BaseURL, string resourceURL, bool isPay)
    {
      try
      {
        var client = new RestClient(BaseURL);
        var request = new RestRequest(resourceURL, Method.Get);

        RestResponse response;
        response = client.Execute(request);

        CorrectStatusCode(response);

        string content = ConvertResponseContentJSON(response);

        switch (isPay)
        {
          case true:
            {
              RespPay RP = JsonConvert.DeserializeObject<RespPay>(content);
              GlobalContainer.cliFields.Success = RP.Success;
              GlobalContainer.cliFields.idRecepient = RP.idRecepient;
              GlobalContainer.cliFields.income = RP.income;
              GlobalContainer.cliFields.isConfirmed = RP.isConfirmed;

              break;
            }
          case false:
            {
              Root RC = JsonConvert.DeserializeObject<Root>(content);
              GlobalContainer.cliFields.Balance = RC.Balance;
              GlobalContainer.cliFields.Student = RC.Student;

              break;
            }
        }

      }
      catch (Exception err)
      {
        throw new Exception(err.ToString());
      }
    }

    private static string ConvertResponseContentJSON(RestResponse response)
    {
      return JsonConvert.DeserializeObject<string>(response.Content);
    }

    private static void CorrectStatusCode(RestResponse response)
    {
      if (response.StatusCode != HttpStatusCode.OK)
        throw new Exception(response.ErrorException.ToString() + response.Content != null ? response.Content : "");

      if (response.Content == "" || response.Content == null)
        throw new Exception("Пустой ответ от сервера!");

    }
  }
}