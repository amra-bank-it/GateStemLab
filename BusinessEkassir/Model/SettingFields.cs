namespace Provider.Model
{
  /// <summary>
  /// Контейнер работы с полями настройки приложения при инициализации
  /// </summary>
  public class SettingFields
  {
    public int TraceLog { get; set; }
    public string SentryUrl { get; set; }

    public string userName { get; set; }

    public string apiKey { get; set; }
    public string apiURL { get; set; }

    public string payer_name { get; set; }

  }
}