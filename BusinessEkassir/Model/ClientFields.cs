namespace Provider.Model
{
  /// <summary>
  /// Контейнер с полями провайдера
  /// </summary>
  public class ClientFields
  {
    //Здесь должны быть описаны поля для конкретного провайдера, требуемые в работе по услуге
    public string branch { get; set; }

    public string Student { get; set; }

    public string Balance { get; set; }

    public int idRecepient { get; set; }

    public bool Success { get; set; }

    public int income { get; set; }


    public bool isConfirmed { get; set; }
    
  }
}