// Download the twilio-csharp library from www.twilio.com/docs/libraries/csharp#installation
using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Notify.V1.Service;

public class Example
{
    public static void Main(string[] args)
    {
        // Find your Account SID and Auth Token at twilio.com/console
        // To set up environmental variables, see http://twil.io/secure
        const string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
        const string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

        const string serviceSid = Environment.GetEnvironmentVariable("TWILIO_SERVICE_SID");

        TwilioClient.Init(accountSid, authToken);

        var notification = NotificationResource.Create(
            serviceSid,
            body: "Hello Bob",
            identity: new List<string> { "00000001" },
            tag: new List<string> { "preferred_device" });

        Console.WriteLine(notification.Sid);
    }
}
