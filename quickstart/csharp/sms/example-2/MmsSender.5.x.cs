using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Quickstart
{
    class MmsSender
    {
        static void Main(string[] args)
        {
            // Set our Account SID and Auth Token
            // To set up environmental variables, see http://twil.io/secure
            const string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            const string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

            // Initialize the Twilio client
            TwilioClient.Init(accountSid, authToken);

            // make an associative array of people we know, indexed by phone number
            var people = new Dictionary<string, string>() {
                {"+14158675308", "Curious George"},
                {"+12349013030", "Boots"},
                {"+12348134522", "Virgil"}
            };

            // Iterate over all our friends
            foreach (var person in people)
            {
                // Send a new outgoing SMS by POSTing to the Messages resource
                MessageResource.Create(
                    from: new PhoneNumber("555-555-5555"), // From number, must be an SMS-enabled Twilio number
                    to: new PhoneNumber(person.Key), // To number, if using Sandbox see note above
                    mediaUrl: new List<Uri> { new Uri("https://demo.twilio.com/owl.png") });

                Console.WriteLine($"Sent message to {person.Value}");
            }
        }
    }
}
