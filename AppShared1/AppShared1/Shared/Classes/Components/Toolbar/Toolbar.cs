using System;
using Xamarin.Forms;

namespace Shared.Classes.Components.Toolbar
{
    public class Toolbar
    {
        public static ToolbarItem Primary(string txt, string icon, Command cmd)
        {
            var tool = new ToolbarItem
            {
                Text = txt,
                Icon = icon,
                Order = ToolbarItemOrder.Primary,
                Command = cmd
            };

            return tool;
        }

        public static ToolbarItem Secondary(string txt, string icon, Command cmd)
        {
            var tool = new ToolbarItem
            {
                Text = txt,
                Icon = icon,
                Order = ToolbarItemOrder.Secondary,
                Command = cmd
            };

            return tool;
        }
    }
}
