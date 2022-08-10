using BusinessEkassir_sett;
using ComplexLogger;
using IBP.SDKGatewayLibrary;
using Oracle.ManagedDataAccess.Client;
using Provider;
using Provider.Model;
using System;
using System.Collections;
//using Provider.Exceptions;

namespace TestGateWay
{

    class Program
    {

        static void Main(string[] args)
        {
            for (int ttt = 100000; ttt < 100100; ttt++)
            {

                try
                {
                    //User us = new User();
                    //us.oo();
                    //return;



                    GatewayCore gateway = new GatewayCore();
                    Context context = new Context();
                    Exception exception = new Exception();
                    context.Add(GlobalContainer.PaymentContext("PointName"), "TEST");
                    context.Add(GlobalContainer.PaymentContext("Value"), 11.00m);
                    context.Add(GlobalContainer.PaymentContext("Id"), Guid.NewGuid());
                    context.Add(GlobalContainer.PaymentContext("Serial"), ttt);
                    context.Add(GlobalContainer.PaymentContext("ServerTime"), DateTime.Now);
                    context.Add(GlobalContainer.PaymentContext("Account"), "209");
                    context.Add(GlobalContainer.PaymentContext("branch"), "1");
                    //context.Add(contextServices.PaymentContext("DebtElev"), "0");
                    //context.Add(contextServices.PaymentContext("typeBlocked"), "О");
                    //context.Add(contextServices.PaymentContext("Purpose"), "Блокируем потому что так надо было (тесты)");

                    Hashtable RFR = new Hashtable();
          RFR.Add("userName", "dameyjonua@yandex.ru");
          RFR.Add("payer_name", "TestAmra");
          RFR.Add("apiKey", "1dcf4102-bdf2-11eb-b74c-ac1f6b4782be");
                    RFR.Add("apiURL", "http://10.55.31.89:1045");
                    RFR.Add("TraceLog", "1");
                    RFR.Add("SentryUrl", @"https://932e9e7e53db416ca2502fb326160a2c@sentry.asar.studio/17");
                    

                    //Тестируем работу модуля настройки шлюза
                    SettingManager settingM = new SettingManager();
                    settingM.InitSettingManadger("");
          settingM.GetPaymentContextKeys(Operation.CheckAccount);
          settingM.GetPaymentContextKeys(Operation.Process);
          //Тестируем работу модуля инициализации шлюза
          gateway.InitGateway(RFR,TypeModeLogger.sourcePrint.Console);

                    //Тестируем работу проведения платежа
                     gateway.CheckAccount(ref context);
                    //gateway.Process(ref context);

            
                    int rer = 0;
    
                    MeLogger.WriteMessage("кон:" + DateTime.Now.ToString());

                }
                catch (Exception e)
                {
                    int rr = 0;
                }
            }
            Console.ReadKey();
        }
    }
}