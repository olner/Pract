// See https://aka.ms/new-console-template for more information
using Ping;

ISender sender = new Sender();
DummyUser.Id = new Guid("3356dc1a-559d-42cc-9a94-729e7f7686d4");
Console.WriteLine("Ping запущен.");

while (true)
{
    var action = Console.ReadLine();
    switch (action)
    {
        case "addMessage":
             var response = await sender.AddMessage("Test");
            Console.WriteLine(response.Id);
            Console.WriteLine(response.Status);
            break;

    }
        
}



