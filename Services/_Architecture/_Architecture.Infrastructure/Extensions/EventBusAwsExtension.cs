using Amazon.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Architecture.Infrastructure.Extensions;

public static class EventBusAwsExtension
{
    public static void AddAmazonServices(this IServiceCollection services, IConfiguration configuration)
    {
        //var awsCredentials = configuration.GetSection("Amazon:Credentials").Get<AwsCredentials>();
        //var credentials = new BasicAWSCredentials(awsCredentials.AccessKey, awsCredentials.SecretKey);
    }
}