using InterFaceEkassir.Basic.Provider.Models;
using Newtonsoft.Json;
using System.Net;
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
                var request = new RestRequest($"/api/Check?userName={GlobalContainer.settFields.userName}&apiKey={GlobalContainer.settFields.apiKey}&branch={GlobalContainer.cliFields.branch}&id_dogovor={GlobalContainer.srvFields.Account}", Method.Get);
                
                RestResponse response;

                    response = client.Execute(request);


                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(response.ErrorException.InnerException.ToString());

                if (response.Content == "")
                    throw new Exception("Пустой ответ от сервера!");

                //Делаем десерелизацию
                string content = JsonConvert.DeserializeObject<string>(response.Content);
                Root RC = JsonConvert.DeserializeObject<Root>(content);
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
