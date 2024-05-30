// See https://aka.ms/new-console-template for more information
using Ping;

ISender sender = new Sender();
DummyUser.Id = new Guid("3356dc1a-559d-42cc-9a94-729e7f7686d4");
Console.WriteLine("Ping запущен.");
Console.WriteLine("Чтобы увидеть список комманд введите /commands");

while (true)
{
    var action = Console.ReadLine();
    switch (action)
    {
        case "/commands":
            Console.WriteLine("Список команд");
            Console.WriteLine("/addMessage \n/getMessage\n/getMessageList\n/deleteMessage");
            break;

        case "/addMessage":
            Console.WriteLine("Введите текст сообщения");
            var text = Console.ReadLine();
            var addMessageResponse = await sender.AddMessage(text);
            Console.WriteLine(addMessageResponse.Id);
            Console.WriteLine(addMessageResponse.Status);
            break;

        case "/getMessage":
            Console.WriteLine("Введите id сообщения");
            var id = Console.ReadLine();
            var getMessageResponse = await sender.GetMessage(new Guid(id));
            Console.WriteLine(getMessageResponse.Status);
            Console.WriteLine(getMessageResponse.Id);
            Console.WriteLine(getMessageResponse.Text);
            break;

        case "/getMessageList":
            var getMessageListResponse = await sender.GetMessageList(DummyUser.Id);
            
            foreach(var item in getMessageListResponse)
            {
                Console.WriteLine(item.Status);
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Text);
                Console.WriteLine();
            }
            break;

        case "/deleteMessage":
            Console.WriteLine("Введите id сообщения");
            var deleteMessageId = Console.ReadLine();
            var deleteMessageResponse = await sender.DeleteMessage(new Guid(deleteMessageId));
            Console.WriteLine(deleteMessageResponse.Status);
            break;
    }
        
}



