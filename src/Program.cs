using StackExchange.Redis;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace poc_csharp_console_app_redis
{
    class Program
    {
        private const string RedisConnectionString = "localhost,port: 6379,password=123456";
        private static ConnectionMultiplexer connection =
          ConnectionMultiplexer.Connect(RedisConnectionString);

        static void Main(string[] args)
        {
            IDatabase db = connection.GetDatabase();
            db.StringSet("mykey", DateTime.Now.ToString());

            Console.WriteLine(db.StringGet("mykey"));
            Console.WriteLine(db.StringGet("key-add-on-another-client"));
            Console.WriteLine(db.StringGet("key-404"));
        }
    }
}
