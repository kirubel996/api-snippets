# Get twilio-ruby from twilio.com/docs/ruby/install
require 'twilio-ruby'

# Get your Account SID and Auth Token from twilio.com/console
# To set up environmental variables, see http://twil.io/secure
account_sid = ENV['TWILIO_ACCOUNT_SID']
auth_token = ENV['TWILIO_AUTH_TOKEN']

# Initialize Twilio Client
@client = Twilio::REST::Client.new(account_sid, auth_token)

# Retrieve available phone numbers that match the given pattern
@numbers = @client.api.available_phone_numbers('US').local
                  .list(contains: '510555****')

@number = @numbers[0].phone_number

@client.incoming_phone_numbers.create(phone_number: @number)
