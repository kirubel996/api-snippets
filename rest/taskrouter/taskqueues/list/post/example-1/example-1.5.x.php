<?php
// Get the PHP helper library from https://twilio.com/docs/libraries/php
require_once '/path/to/vendor/autoload.php'; // Loads the library

use Twilio\Rest\Client;

// Your Account Sid and Auth Token from twilio.com/user/account
// To set up environmental variables, see http://twil.io/secure
$accountSid = getenv('TWILIO_ACCOUNT_SID');
$authToken = getenv('TWILIO_AUTH_TOKEN');
$workspaceSid = "WSXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";

$client = new Client($accountSid, $authToken);

$taskQueue = $client->taskrouter
    ->workspaces($workspaceSid)
    ->taskQueues
    ->create(
        "English", "WAxxxx", "WAyyyy",
        array(
            'TargetWorkers' => 'languages HAS "english"'
        )
    );

echo $taskQueue->friendlyName;
