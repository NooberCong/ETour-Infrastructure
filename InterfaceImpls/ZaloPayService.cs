using Core.Entities;
using Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaloPay.Helper;
using ZaloPay.Helper.Crypto;

namespace Infrastructure.InterfaceImpls
{
    class ZaloPayService : IZaloPayService
    {
        static private string _appid = "554";
        static private string _key1 = "8NdU5pG5R2spGHGhyO99HN1OhD8IQJBn";
        static private string _createOrderUrl = "https://sandbox.zalopay.com.vn/v001/tpe/createorder";

        public async Task<string> CreateOrderAsync(Booking booking, long amount, string description)
        {
            var transid = Guid.NewGuid().ToString();
            var embeddata = new {};
            var items = new object[] {};
            var param = new Dictionary<string, string>();

            param.Add("appid", _appid);
            param.Add("appuser", booking.Owner.Name);
            param.Add("apptime", Utils.GetTimeStamp().ToString());
            // Quick hack to convert to VND :))
            param.Add("amount", Math.Ceiling(amount * 23193d).ToString());
            param.Add("apptransid", DateTime.Now.ToString("yyMMdd") + "_" + transid);
            param.Add("embeddata", JsonConvert.SerializeObject(embeddata));
            param.Add("item", JsonConvert.SerializeObject(items));
            param.Add("description", description);
            param.Add("bankcode", "zalopayapp");

            var data = _appid + "|" + param["apptransid"] + "|" + param["appuser"] + "|" + param["amount"] + "|"
                + param["apptime"] + "|" + param["embeddata"] + "|" + param["item"];
            param.Add("mac", HmacHelper.Compute(ZaloPayHMAC.HMACSHA256, _key1, data));

            var result = await HttpHelper.PostFormAsync(_createOrderUrl, param);
            foreach (var entry in result)
            {
                Console.WriteLine("{0} = {1}", entry.Key, entry.Value);
            }
            return result["orderurl"] as string;
        }
    }
}
