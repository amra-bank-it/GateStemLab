using InterFaceEkassir.Basic.Provider.Adapter;
using Provider.Model;

namespace InterFaceEkassir.Basic.Provider.Base
{
  public class StemAPI
  {
    private string _baseURL { get; set; }

    private string _resourceURL { get; set; }

    private API _client { get; set; }

    public StemAPI()
    {
      _client = new API();
      _baseURL =  GlobalContainer.settFields.apiURL;
    }

    public void Check()
    {
      _resourceURL = $"/api/Check?userName={GlobalContainer.settFields.userName}&apiKey={GlobalContainer.settFields.apiKey}&branch={GlobalContainer.cliFields.branch}&id_dogovor={GlobalContainer.srvFields.Account}";
      _client.SendRequest(_baseURL, _resourceURL, false);
    }

    public void Pay()
    {
      _resourceURL = $"/api/Pay?userName={GlobalContainer.settFields.userName}&apiKey={GlobalContainer.settFields.apiKey}&branch={GlobalContainer.cliFields.branch}&id_dogovor={GlobalContainer.srvFields.Account}&amount={GlobalContainer.srvFields.Value.ToString().Replace(',', '.')}&payer_name={GlobalContainer.settFields.payer_name}";
      _client.SendRequest(_baseURL, _resourceURL, true);
    }

  }
}