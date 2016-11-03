const http = require('http');
const express = require('express');
const twilio = require('twilio');

const app = express();

app.get('/token', function(req, res) {
  // put your Twilio API credentials here
  const accountSid = 'ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX';
  const authToken = 'your_auth_token';

  // put your Twilio Application Sid here
  const appSid = 'APXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX';

  let capability = new twilio.jwt.Capability(accountSid, authToken);
  capability.allowClientOutgoing(appSid);
  capability.allowClientIncoming('jenny');
  const token = capability.generate();

  res.set('Content-Type', 'application/jwt');
  res.send(token);
});

app.post('/voice', function(req, res) {
    // TODO: Create TwiML response
});

http.createServer(app).listen(1337, '127.0.0.1');
console.log('Twilio Client app server running at http://127.0.0.1:1337/token/');
