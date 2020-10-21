using System;
namespace Bookman.ConsoleApp
{
    using Framework;

    public class ControllerBase
    {
        /// <summary>
        /// overload and call the Render of simple class
        /// </summary>
        /// <param name="view"></param>
        public void Render(RenderToFile view)
        {
            view.Render();
        }

        /// <summary>
        /// RenderToFile class is the base class of all class in Views 
        /// so we can assign all object created from any class in Views to RenderToFile object
        /// Use this to call Render in each class
        /// </summary>
        /// <param name="view"></param>
        /// <param name="path"></param>
        /// <param name="both">Call back both Render, FileRender</param>
        public void Render<T>(RenderToFile<T> view, string path = "", bool both = false)
            // why virtual is needed?
            // if virtual is not exist
        {
            
            if (string.IsNullOrEmpty(path))
            {
                view.Render(); return;
            }

            if (both)
            {
                view.Render();
                view.FileRender(path);
                return;
            }
            view.FileRender(path);
        }

        /// <summary>
        /// Initialize the Message obj and assign the MessageView obj to it
        /// then we will be able to call the Render funciton
        /// </summary>
        /// <param name="message"></param>
        public virtual void Render(Message message)
            => Render(new MessageView(message));

        public virtual void Success(string text, string label = "SUCCESS")
            => Render(new Message() { Type = MessageType.Success, Text = text, Label = label });

        public virtual void Error(string text, string label = "ERROR")
            => Render(new Message() { Type = MessageType.Error, Text = text, Label = label });

        public virtual void Inform(string text, string label = "INFORMATION")
            => Render(new Message() { Type = MessageType.Information, Text = text, Label = label });

        public virtual void Confirm(string text, string route, string label = "CONFIRMATION")
            => Render(new Message() { Type = MessageType.Confirmation, Text = text, Label = label, BackRoute = route});
    }
}
