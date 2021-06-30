using Core.Entities;
using Core.Interfaces;
using Nancy.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using ZaloPay.Helper;
using ZaloPay.Helper.Crypto;

namespace Infrastructure.InterfaceImpls
{
    public class MomoPaymentService : IMomoPaymentService
    {
        public Task<string> CreateOrderAsync(Booking booking, long amount, string description)
        {
            string secret = "MbRYDmFmFTVl11Dp8KqUYmeSPpUnEYnr";
            long amountVnd = amount * 21000;

            string partnerCode = "MOMOLEEQ20210615";
            string accessKey = "XGqCNhlAZAtL0lGD";
            string requestId = Utils.GetTimeStamp().ToString();
            string orderId = Guid.NewGuid().ToString();
            string orderInfo = description;
            string url = (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production"? "https://etour-client.azurewebsites.net/booking/momoconfirm" : "https://localhost:44323/booking/momoconfirm") + $"?id={booking.ID}";
            string requestType = "captureMoMoWallet";
            string extraData = "";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://test-payment.momo.vn/gw_payment/transactionProcessor");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    partnerCode,
                    accessKey,
                    requestId,
                    amount = amountVnd.ToString(),
                    orderId,
                    orderInfo,
                    returnUrl = url,
                    notifyUrl = url,
                    requestType,
                    signature = HmacHelper.Compute(key: secret, message: $"partnerCode={partnerCode}&accessKey={accessKey}&requestId={requestId}&amount={amountVnd.ToString()}&orderId={orderId}&orderInfo={orderInfo}&returnUrl={url}&notifyUrl={url}&extraData={extraData}"),
                    extraData
                });

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.WriteLine(result);
                return Task.FromResult<string>(((dynamic)new JavaScriptSerializer().DeserializeObject(result)).payUrl);
            }
        }
    }
}
