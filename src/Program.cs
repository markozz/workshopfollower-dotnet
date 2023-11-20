using System;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            string id = "8c36e86c-13b9-4102-a44f-646015dfd981";
            string name = "Mark";
            string email = "mark.abrahams@ordina.nl";
            string createdAt = "2016-01-01T01:00:00+01:00";
            string baseUri = "http://localhost:9000";

            WorkshopFollowerAPI api = new WorkshopFollowerAPI(baseUri);

            if(args.Length <= 1)
            {
                Console.WriteLine("-------------------");
                WriteoutArgsUsed(id, name, email, createdAt);
                WriteoutUsageInstructions();
                Console.WriteLine("-------------------");
            }
            else
            {
                id = args[0];
                name = args[1];
                email = args[2];
                createdAt = args[3];
                Console.WriteLine("-------------------");
                WriteoutArgsUsed(id, name, email, createdAt);
                Console.WriteLine("-------------------");
            }

            Console.WriteLine("Saving workshopfollower...");
            WorkshopFollower workshopFollower = new WorkshopFollower(id,name,email,createdAt);
            var result = api.CreateWorkshopFollower(workshopFollower).GetAwaiter().GetResult();
            var resultContentText = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Console.WriteLine(resultContentText);

            Console.WriteLine("Getting the workshopfollower");
            result = api.FindWorkshopFollower(id).GetAwaiter().GetResult();
            resultContentText = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Console.WriteLine(resultContentText);
        }

        static private void WriteoutArgsUsed(string idArg, string nameArg, string emailArg, string createdAtArg)
        {
            Console.WriteLine($"Running consumer with args: id = {idArg}, name = {nameArg}, email = {emailArg}, createdAt = {createdAtArg}");
        }

        static private void WriteoutUsageInstructions()
        {
            Console.WriteLine("To use with your own parameters:");
            Console.WriteLine("Usage: dotnet run [id] [name] [email] [createdAt]");
            Console.WriteLine("Usage Example: dotnet run 8c36e86c-13b9-4102-a44f-646015dfd981 mark mark.abrahams@ordina.nl 2016-01-01T01:00:00+01:00");
        }
    }
}
