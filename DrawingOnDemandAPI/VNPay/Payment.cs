using DrawingOnDemandAPI.Utils;
using DrawingOnDemandAPI.VNPay.Models;

namespace DrawingOnDemandAPI.VNPay
{
    public class Payment
    {
        public static VNPayRequest Send(VNPayRequest request, HttpContext context)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();

            // Get Config Info
            string vnp_Url = configuration["vnp_Url"]; //URL thanh toan cua VNPAY 
            string vnp_TmnCode = configuration["vnp_TmnCode"]; //Ma định danh merchant kết nối (Terminal Id)
            string vnp_HashSecret = configuration["vnp_HashSecret"]; //Secret Key

            // Generate Order ID
            var createdDate = DateTime.Now;
            var orderId = createdDate.Ticks;

            //Build URL for VNPAY
            VnPayLibrary vnpay = new();

            vnpay.AddRequestData("vnp_Version", VnPayLibrary.VERSION);
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
            vnpay.AddRequestData("vnp_Amount", (request.Price * 100).ToString()); //Số tiền thanh toán. Số tiền không mang các ký tự phân tách thập phân, phần nghìn, ký tự tiền tệ. Để gửi số tiền thanh toán là 100,000 VND (một trăm nghìn VNĐ) thì merchant cần nhân thêm 100 lần (khử phần thập phân), sau đó gửi sang VNPAY là: 10000000

            switch (request.Method)
            {
                case 1:
                    vnpay.AddRequestData("vnp_BankCode", "VNPAYQR");
                    break;
                case 2:
                    vnpay.AddRequestData("vnp_BankCode", "VNBANK");
                    break;
                case 3:
                    vnpay.AddRequestData("vnp_BankCode", "INTCARD");
                    break;
                default:
                    break;
            }

            vnpay.AddRequestData("vnp_CreateDate", createdDate.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_IpAddr", Utils.Utils.GetIpAddress(context));
            vnpay.AddRequestData("vnp_Locale", request.Lang);
            vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang: " + request.OrderId);
            vnpay.AddRequestData("vnp_OrderType", "other"); //default value: other

            vnpay.AddRequestData("vnp_ReturnUrl", request.ReturnUrl);
            vnpay.AddRequestData("vnp_TxnRef", orderId.ToString()); // Mã tham chiếu của giao dịch tại hệ thống của merchant. Mã này là duy nhất dùng để phân biệt các đơn hàng gửi sang VNPAY. Không được trùng lặp trong ngày

            //Add Params of 2.1.0 Version
            //Billing

            request.OrderId = orderId.ToString();
            request.PaymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);

            return request;
        }

        public static string Query()
        {
            return "00";
        }
    }
}
