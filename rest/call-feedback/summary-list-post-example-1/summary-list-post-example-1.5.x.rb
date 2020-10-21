# Get twilio-ruby from twilio.com/docs/ruby/install
require 'twilio-ruby'

# Get your Account SID and Auth Token from twilio.com/console
# To set up environmental variables, see http://twil.io/secure
account_sid = ENV['TWILIO_ACCOUNT_SID']
auth_token = ENV['TWILIO_AUTH_TOKEN']

# Initialize Twilio Client
@client = Twilio::REST::Client.new(account_sid, auth_token)

@summary = @client.calls.feedback_summaries
                  .create(
                    start_date: Time.parse('2014-06-01'),
                    end_date: Time.parse('2014-06-30'),
                    include_subaccounts: 'true'
                  )

puts @summary.status, @summary.sid
