using ComplexLogger;
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
        MeLogger.WriteMessage($"Отправляем запрос:{BaseURL + resourceURL}");
        
        var client = new RestClient(BaseURL);
        var request = new RestRequest(resourceURL, Method.GET);

        IRestResponse response;
        response = client.Execute(request);

        CorrectStatusCode(response);

        string content = ConvertResponseContentJSON(response);

        MeLogger.WriteMessage($"Получили ответ:{content}");

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
        MeLogger.WriteMessage($"Получили ответ:{err.ToString()}");
        throw new Exception(err.ToString());
      }
    }

    private static string ConvertResponseContentJSON(IRestResponse response)
    {
      return JsonConvert.DeserializeObject<string>(response.Content);
    }

    private static void CorrectStatusCode(IRestResponse response)
    {
      if(response == null)
        throw new Exception("Пустой ответ от сервера!");

      if (response.Content == "" || response.Content == null)
        throw new Exception("Пустой ответ от сервера!");

      if (response.StatusCode != HttpStatusCode.OK)
        throw new Exception(response.Content);


    }
  }
}