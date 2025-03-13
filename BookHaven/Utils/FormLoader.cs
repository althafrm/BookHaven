using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Utils
{
    public static class FormLoader
    {
        public static void LoadFormIntoPanel(Panel container, Form form)
        {
            if (container == null || form == null)
                return;

            container.Controls.Clear();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            container.Controls.Add(form);
            form.Show();
        }
    }
}
