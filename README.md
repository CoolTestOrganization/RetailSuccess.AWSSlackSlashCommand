# RetailSuccess.AWSSlackSlashCommand
This repository has the code to create git repositories through Slack.  You do need to set up your credentials and possibly get a 
personal access token.  See the class, "GitCredentials" for information on how to do that.  

# Setting up Slack:
1. Go to https://teamname.slack.com/apps. 
2. Click Manage, then, custom Integrations.
3. Click Slash Commands
4. Click Add Configuration.

# Setting Up Slack Slash Command:
0: Name it. /fakeorsomethin
1. set a fake url temporarily.
2. Click Method, Get (or Post if you feel super confident).
3. Copy your Token and keep it secret, keep it safe.
4. Give your command a custom name.
5. Choose an icon that will represent your bot.
6. Autocomplete Help Text -description will tell ppl what it does.
7. AutoComplete Help Text -Usage Hint, just put variables in brackets to show parameters accepted. like this [req var1] [opt var2]
8. Click Save Integration.

# Setting Up Lambda:
1. After setting up your AWS account, got o your console.  
2. Under Compute, click Lambda.
3. Select Create Function
4. Author from Scratch
5. Name it.
6. RunTime C# (.NET Core 2.0)
7. Assign a Basic permissions service role.  You may need to create this.  
8. Create a role: I added lambda and edgelambda permissions.

# Setting up API Gateway:
1. From your AWS Console, you can type "Gateway"
2. Choose API Gateway, which will take you to: https://console.aws.amazon.com/apigateway/
3. Be aware of your region, I chose East 1, which is currently N. Virginia.
4. Select Create API, give it a name and description.
5. Under Resources, currently near top, there should be a /.  a button nearby currently says "actions".  Select it.
6. Create Method, choose Get. confirm.
7. Choose Integration Type: Lambda Function.
8. Lambda Region, choose the region you created it in, make it the same as the api gateway...
9. Start typing in the Lambda Function textbox and then select your lambda function's name. Then Save.
10. Click the box, Integration Request, then under Body Mapping templates, Request Body Passthrough: check Never.
11. Click Add Mapping Template... name it: application/json.
12. Add the following Code:
```
## convert HTML POST data or HTTP GET query string to JSON
 
## get the raw post data from the AWS built-in variable and give it a nicer name
#if ($context.httpMethod == "POST")
 #set($rawAPIData = $input.path('$'))
#elseif ($context.httpMethod == "GET")
 #set($rawAPIData = $input.params().querystring)
 #set($rawAPIData = $rawAPIData.toString())
 #set($rawAPIDataLength = $rawAPIData.length() - 1)
 #set($rawAPIData = $rawAPIData.substring(1, $rawAPIDataLength))
 #set($rawAPIData = $rawAPIData.replace(", ", "&"))
#else
 #set($rawAPIData = "")
#end
 
## first we get the number of "&" in the string, this tells us if there is more than one key value pair
#set($countAmpersands = $rawAPIData.length() - $rawAPIData.replace("&", "").length())
 
## if there are no "&" at all then we have only one key value pair.
## we append an ampersand to the string so that we can tokenise it the same way as multiple kv pairs.
## the "empty" kv pair to the right of the ampersand will be ignored anyway.
#if ($countAmpersands == 0)
 #set($rawPostData = $rawAPIData + "&")
#end
 
## now we tokenise using the ampersand(s)
#set($tokenisedAmpersand = $rawAPIData.split("&"))
 
## we set up a variable to hold the valid key value pairs
#set($tokenisedEquals = [])
 
## now we set up a loop to find the valid key value pairs, which must contain only one "="
#foreach( $kvPair in $tokenisedAmpersand )
 #set($countEquals = $kvPair.length() - $kvPair.replace("=", "").length())
 #if ($countEquals == 1)
  #set($kvTokenised = $kvPair.split("="))
  #if ($kvTokenised[0].length() > 0)
   ## we found a valid key value pair. add it to the list.
   #set($devNull = $tokenisedEquals.add($kvPair))
  #end
 #end
#end
 
## next we set up our loop inside the output structure "{" and "}"
{
#foreach( $kvPair in $tokenisedEquals )
  ## finally we output the JSON for this pair and append a comma if this isn't the last pair
  #set($kvTokenised = $kvPair.split("="))
 "$util.urlDecode($kvTokenised[0])" : #if($kvTokenised[1].length() > 0)"$util.urlDecode($kvTokenised[1])"#{else}""#end#if( $foreach.hasNext ),#end
#end
}
```
