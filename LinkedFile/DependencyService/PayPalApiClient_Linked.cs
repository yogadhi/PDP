using System;
using RestSharp;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;
using System.Linq;
using MyCloudTable;

#if __ANDROID__
using MyCloudTable.Droid;
#endif
#if __IOS__
using MyCloudTable.iOS;
#endif

namespace MyCloudTable
{
	public class PayPalApiClient_Linked : IPayPalApiClient {

		RestClient restClient { get; set; }

		// constructor
		public PayPalApiClient_Linked () {
			restClient = new RestClient (PayPalConfig.ApiUrl);
		}

		// Get access (bearer) token from paypal
		public async Task<PayPalGetTokenResponse> GetAccessToken() {
			try{
				var restRequest = new RestRequest ("/oauth2/token", Method.POST);

				// Add headers
				restRequest.AddHeader ("Accept", "application/json");
				restRequest.AddHeader ("Accept-Language", "en_US");

				// Make Authorization header
				restClient.Authenticator = new HttpBasicAuthenticator(PayPalConfig.ApiClientId, PayPalConfig.ApiSecret);

				// add data to send
				restRequest.AddParameter ("grant_type", "client_credentials");

				var response = restClient.Execute<PayPalGetTokenResponse> (restRequest);

				response.Data.DisplayError = CheckResponseStatus (response, HttpStatusCode.OK);

				return response.Data;
			}
			catch (Exception ex)
			{
				AppStyle.Log.sendException("GetAccessToken", ex);
				return null;
			}
		}

		// Make a payment
		// Should do validation of the returned data
		public async Task<PayPalExecutePaymentResult> MakePayment(IPayPalReceipt receipt) {
			try{
				var accessTokenData = await GetAccessToken();
				var executePaymentResult = new PayPalExecutePaymentResult();

				if (accessTokenData.DisplayError == null) {
					var restRequest = new RestRequest ("/payments/payment", Method.POST);

					// Add headers
					restRequest.AddHeader ("Content-Type", "application/json");
					restRequest.AddHeader ("Authorization", "Bearer " + accessTokenData.AccessToken);

					// Add data to send
					restRequest.RequestFormat = DataFormat.Json;
					// This transaction information should be made dynamic!
					// Source: https://developer.paypal.com/docs/api/#create-a-payment
					restRequest.AddBody (new PayPalMakePaymentData {
						intent = "sale",
						redirect_urls = new PayPalMakePaymentRedirectUrls {
							return_url = PayPalConfig.ReturnUrl,
							cancel_url = PayPalConfig.CancelUrl
						},
						payer = new PayPalPayer {
							payment_method = "paypal"
						},
						transactions = new [] {
							new PayPalTransaction {
								amount = new PayPalAmount {
									total = receipt.Total.ToString().Trim(' '),
									currency = receipt.Currency,
									details = new PayPalAmountDetails {
										subtotal = receipt.SubTotal.ToString().Trim(' '),
										tax = receipt.TaxTotal.ToString().Trim(' '),
										shipping = receipt.Shipping.ToString().Trim(' '),
									}
								},
								item_list = new PayPalItemList {
									items = new [] {
										new PayPalItem {
											quantity = receipt.Quantity.ToString().Trim(' '),
											name = "Reservation Detail",
											price = receipt.Price.ToString().Trim(' '),
											currency = receipt.Currency,
											description = receipt.Desc,
											tax = receipt.SubTax.ToString().Trim(' '),
										}
									}
								}
							}
						}
					});

					var response = restClient.Execute<PayPalPaymentResponse> (restRequest);

					executePaymentResult.DisplayError = CheckResponseStatus (response, HttpStatusCode.Created);

					if (executePaymentResult.DisplayError == null) {
						// Get the approval url from the links provided by the response
						var links = from link in response.Data.Links
								where link.Rel == "approval_url"
							select link.Href;

						if ( !String.IsNullOrEmpty(links.First()) ) {
							executePaymentResult.Url = links.First ();
							executePaymentResult.AccessToken = accessTokenData.AccessToken;

							// Send the approval url along with the access token the paypal webview
							return executePaymentResult;
						} else {
							executePaymentResult.DisplayError = "Something went wrong. Please try again.";
						}
					}
				} else {
					executePaymentResult.DisplayError = accessTokenData.DisplayError;
				}

				return executePaymentResult;
			}
			catch (Exception ex)
			{
				AppStyle.Log.sendException("MakePayment", ex);
				return null;
			}
		}

		// Validate a payment using webview for user to enter his credentials and to review the purchase
		public async Task<string> ExecuteApprovedPayment(string payerId, string accessToken, string paymentId) {
			try{
				var restRequest = new RestRequest (String.Format("/payments/payment/{0}/execute", paymentId), Method.POST);

				// Add headers
				restRequest.AddHeader ("Content-Type", "application/json");
				restRequest.AddHeader ("Authorization", "Bearer " + accessToken);

				// Add data to send
				restRequest.RequestFormat = DataFormat.Json;
				restRequest.AddBody (new {
					payer_id = payerId
				});

				var response = restClient.Execute<PayPalPaymentResponse> (restRequest);

				return CheckResponseStatus (response, HttpStatusCode.OK);
			}
			catch (Exception ex)
			{
				AppStyle.Log.sendException("ExecuteApprovedPayment", ex);
				return null;
			}
		}

		string CheckResponseStatus(IRestResponse response, HttpStatusCode validStatusCode) {
			try{
				if (response.ResponseStatus == ResponseStatus.Completed) {
					if (response.StatusCode != validStatusCode) {
						// something went wrong
						Debug.WriteLine ("{0} -- {1}", response.StatusCode, response.StatusDescription);

						return "Something went wrong. Please try again.";
					} else {

						// everythings fine
						return null;
					}
				} else {

					// something went wrong. please check your internet connection
					return "Something went wrong. Please check your internet connection.";
				}
			}
			catch (Exception ex)
			{
				AppStyle.Log.sendException("CheckResponseStatus", ex);
				return null;
			}
		}
	}
}