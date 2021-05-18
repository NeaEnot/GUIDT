using System;

namespace UiDriver
{
    public class PageDriver
    {
        public Action<string> ShowErrorMessage { protected get; set; }
        public Action<string> ShowInfoMessage { protected get; set; }

        protected UiContext context;

        protected PageDriver(UiContext context)
        {
            this.context = context;
            ShowErrorMessage = (msg) => { };
            ShowInfoMessage = (msg) => { };
        }
    }
}
