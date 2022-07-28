using InterFaceEkassir.Basic.Provider.Models;
using Newtonsoft.Json;
using Provider.Model;
using RestSharp;
using System;

namespace InterFaceEkassir.Basic.Provider.Adapter
{
  internal class CheckReq
  {
    public void Get()
    {
      try
      {
        var client = new RestClient($"{GlobalContainer.settFields.apiURL}");
        var request = new RestRequest($"/api/Check?userName={GlobalContainer.settFields.userName}&apiKey={GlobalContainer.settFields.apiKey}&branch={GlobalContainer.cliFields.branch}&id={GlobalContainer.srvFields.Account}", Method.Get);
        var response = client.Execute(request);
        
        if (response.Content == "")
          throw new Exception("Пустой ответ от сервера!");

        //Делаем десерелизацию
        RespCheck RC = JsonConvert.DeserializeObject<RespCheck>(response.Content);
        GlobalContainer.cliFields.Balance = RC.Balance;
        GlobalContainer.cliFields.Student = RC.Student;


      }
      catch (Exception err)
      {
        throw new Exception(err.ToString());
      }

    }
  }
}
