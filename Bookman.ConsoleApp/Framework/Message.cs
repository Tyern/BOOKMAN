using System;

namespace Bookman.ConsoleApp.Framework
{
    public enum MessageType { Success, Error, Information, Confirmation}

    public class Message
    {
        public MessageType Type { get; set; }
        public string Label { get; set; }
        public string Text { get; set; }
        public string BackRoute { get; set; }
    }

    public class MessageView : RenderToFile<Message>
    {
        public MessageView(Message model) : base(model)
        {

        }

        public override void Render()
        {
            switch (Model.Type)
            {
                case (MessageType.Success):
                    ViewHelp.WriteLine((Model.Label != null) ? Model.Label : "SUCCESS", ConsoleColor.Green);
                    break;

                case (MessageType.Error):
                    ViewHelp.WriteLine((Model.Label != null) ? Model.Label : "ERROR", ConsoleColor.Red);
                    break;

                case (MessageType.Information):
                    ViewHelp.WriteLine((Model.Label != null) ? Model.Label : "INFORMATION", ConsoleColor.Green);
                    break;

                case (MessageType.Confirmation):
                    ViewHelp.WriteLine((Model.Label != null) ? Model.Label : "CONFIRMATION", ConsoleColor.Green);
                    break;
            }

            ViewHelp.WriteLine(Model.Text, ConsoleColor.Black);

            if (Model.Type == MessageType.Confirmation)
            {
                var answer = Console.ReadLine().ToLower();

                if (answer == "y" || answer == "yes")
                {
                    Router.Instance.Forward(Model.BackRoute);
                }
            }    
        }
    }
}
