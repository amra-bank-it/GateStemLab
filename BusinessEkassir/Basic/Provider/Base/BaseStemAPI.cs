using InterFaceEkassir.Basic.Provider.Adapter;

namespace InterFaceEkassir.Basic.Provider.Base
{
    public class StemAPI
    {
        public void Check()
        {
            CheckReq checkReq = new CheckReq();
            checkReq.Get();
        }

        public void Pay()
        {
            PayReq payReq = new PayReq();
            payReq.Get();

        }

    }
}