using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Flurl.Http;
using Amazon.APIGateway;
using Amazon.Lambda.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RetailSuccess.GitHub;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace RetailSuccess.AWSSlackSlashCommand
{
    public class Function
    {

        /*
        /// <summary>
        /// A simple function that takes a string and takes the values.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler(SlashCommand t, ILambdaContext context)
        {//I did use JObject t with the foreach.
            var y = "values: ";
            //foreach (var x in t) {y += x.Value;}
            y += "and now: " + t.Text + t.UserName;
            return y;
        }
         */


        /// <summary>
        /// A simple function that takes a string and takes the values.
        /// </summary>
        /// <param name="slCom"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task FunctionHandler(SlashCommand slCom, ILambdaContext context)
        {
            if (slCom == null) return;
            if (slCom.Token != "xMZ9mwYeDyNv1uNaxf920JEG") return;
            if (string.IsNullOrWhiteSpace(slCom.Text)) return;
            string c = "Create Repo Command Sent. ";
            try
            {
                var repoParams = slCom.Text.Split(' ');
                switch (repoParams.Length)
                {
                    case 4:
                        SetUpRepository.Run(repoParams[0], repoParams[1], repoParams[2] + " " + repoParams[3]).GetAwaiter().GetResult();
                        break;
                    case 3:
                        SetUpRepository.Run(repoParams[0], repoParams[1], repoParams[2]).GetAwaiter().GetResult();
                        break;
                    case 2:
                        SetUpRepository.Run(repoParams[0], repoParams[1], "Retail Success").GetAwaiter().GetResult();
                        break;
                    default:
                        SetUpRepository.Run(slCom.Text, "CoolTestOrganization", "Retail Success").GetAwaiter().GetResult();
                        break;
                }
            }
            catch (Exception ex)
            {
                await sendSlackReplyAsync(ex.Message, slCom.ResponseUrl);
            }
            await sendSlackReplyAsync(c, slCom.ResponseUrl);
        }
        private async Task sendSlackReplyAsync(string text, string responseUrl)
        {
            var slackReply = new SlackReply()
            {
                Text = text
            };
            await responseUrl.PostJsonAsync(slackReply);
        }
    }
}
