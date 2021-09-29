using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.common.MessageBoxHelper
{
    static class MessageBoxHelper
    {
        public static DialogResult ShowYesNoInfoMessageBox (this ContainerControl control, string message, string caption = "Info")
        {
           return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information); 
        }

        public static DialogResult ShowOkInfoMessageBox(this ContainerControl control, string message, string caption = "Info")
        {
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }

        public static DialogResult ShowOkErrorMessageBox(this ContainerControl control, string message, string caption = "Error")
        {
            return MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
