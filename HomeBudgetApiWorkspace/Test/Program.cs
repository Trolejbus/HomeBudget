// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using WebPush;

Console.WriteLine("Hello, World!");


string subscriptionUrl = @"https://fcm.googleapis.com/fcm/send/d_NvV0pEqNU:APA91bGU5AqwwTuMgU8sH_kKmDfwqMWSjsN-jtomZrKJh9ISMTaDr7FsMNwq5VowpJk1xFONZ6lFVyWSZ7CUW63JJbiAPw0kq-TbfumQKwwhhDy12xXER5J629ZPA-FOor6bMswBY3Vc";

PushSubscription subscription = new PushSubscription(endpoint: subscriptionUrl, p256dh: "BOVyfRf031h8d3WcFCyiyBajxW-q4lmFAVV7kLJDT7LD6UbBLoJ2Nh3aVBMVWalaLlxIqf74_6wUQu0PdMXaO2Q", auth: "NzpRVw7-SiEdAT0xmXm9fg");
string subject = "mailto:micha.duch@gmail.com";
var vapidDetails = new VapidDetails(subject, publicKey: "BE-jdntMfI0JHJ-1hAZg4VnUCyiCJDOTB4qKOgErUoVG6l2kzTkR4ewKH6yLZg9g24LFeXQg8eSIHz8NhoTYY50", privateKey: "dpe7ndcmstKPvOUlAlDfyMUHjBnVPcugQOleH218SlA");
var webPushClient = new WebPushClient();
var message = JsonConvert.SerializeObject("Your product is ready");
webPushClient.SendNotification(subscription, message, vapidDetails);
