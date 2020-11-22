using System;

namespace MerakiAutomation.Client.Services.FormHelpers
{
    public interface ICanSubmitForms
    {
        /// <summary>
        /// Used to Send the form data back when you hit the submit button
        /// </summary>
        public  void HandleValidSubmit();


        /// <summary>
        /// Used to Send the form data back when it is invalid when you hit the submit button
        /// </summary>
        public  void HandleInvalidSubmit();

    }
}