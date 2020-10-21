require 'twilio-ruby'

# Get your Account SID and Auth Token from twilio.com/console
# To set up environmental variables, see http://twil.io/secure
account_sid = ENV['TWILIO_ACCOUNT_SID']
auth_token = ENV['TWILIO_AUTH_TOKEN']
service_sid = 'ISXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX'
@client = Twilio::REST::Client.new(account_sid, auth_token)

# Retrieve a particular channel
my_channel_sid = 'CHXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX'
service = @client.chat.v2.services(service_sid)
channel = service.channels(my_channel_sid).fetch
puts "Channel #{channel.sid} has Unique Name \"#{channel.unique_name}\""
