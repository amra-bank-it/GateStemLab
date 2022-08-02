using InterFaceEkassir.Basic.Provider.Models;
using Newtonsoft.Json;
using Provider.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InterFaceEkassir.Basic.Provider.Adapter
{
  internal class PayReq
  {
        public void Get()
        {
            try
            {
                var client = new RestClient($"{GlobalContainer.settFields.apiURL}");
                var request = new RestRequest($"/api/Pay?userName={GlobalContainer.settFields.userName}&apiKey={GlobalContainer.settFields.apiKey}&branch={GlobalContainer.cliFields.branch}&id_dogovor={GlobalContainer.srvFields.Account}&amount={GlobalContainer.srvFields.Value.ToString().Replace(',','.')}", Method.Get);

                RestResponse response;
                response = client.Execute(request);


                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(response.ErrorException.InnerException.ToString());

                if (response.Content == "")
                    throw new Exception("Пустой ответ от сервера!");


                string content = JsonConvert.DeserializeObject<string>(response.Content);

                RespPay RP = JsonConvert.DeserializeObject<RespPay>(content);
                GlobalContainer.cliFields.Success = RP.Success;
                GlobalContainer.cliFields.idRecepient = RP.idRecepient;                
                GlobalContainer.cliFields.income = RP.income;
                GlobalContainer.cliFields.isConfirmed = RP.isConfirmed;

            }
            catch(Exception err)
            {
                throw new Exception(err.ToString());
            }
        }
  }
}