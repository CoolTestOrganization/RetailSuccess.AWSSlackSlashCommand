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
