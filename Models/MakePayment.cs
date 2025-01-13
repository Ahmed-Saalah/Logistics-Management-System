//using Stripe;

//namespace LogisticsManagementSystem.Models
//{
//    public class MakePayment
//    {
//        public static async Task<dynamic> PayAsync(Payment paymentModel)
//        {
//            try
//            {
//                var operationsToken = new TokenCreateOptions
//                {
//                    Card = new CreditCardOptions
//                    {
//                        cardNumber = paymentModel.CardNumber,
//                        Amount = paymentModel.Amount,
//                        cvc = paymentModel.CVC
//                    }
//                };

//                var serviceToken = new TokenService();
//                Token stripeToken = await serviceToken.CreateAsync(operationsToken);
//                var options = new ChargeCreateOptions
//                {
//                    Amount = paymentModel.Amount,
//                    Currency = "usd",
//                    Description = "test",
//                    Source = stripeToken.Id,
//                };

//                var service = new ChargeService();
//                Charge charge = await service.CreateAsync(options);

//                if (charge.Paid)
//                {
//                    return "Success";
//                }
//                else
//                {
//                    return "Faild";
//                }
//            }
//            catch (Exception ex)
//            {
//                return ex.Message;
//            }
//        }
//    }
//}
