using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathOfLava
{    public static class ControlExtensions
    {
        public static void UpdateControlText(this Control control, string text)
        {
            if (control.InvokeRequired)
            {
                _ = control.Invoke(new Action<Control, string>(UpdateControlText), control, text);
            }

            control.Text = text;
        }

        public static void UpdateAsync(this Control control, Action<Control> action)
        {
            if (control.InvokeRequired)
            {
                _ = control.Invoke(new Action<Control, Action<Control>>(UpdateAsync), control, action);
            }

            action(control);
        }
    }
}
