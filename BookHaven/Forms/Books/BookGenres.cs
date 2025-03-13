using BookHaven.Services;
using BookHaven.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookHaven.Forms.Books
{
    public partial class BookGenres : Form
    {
        private Panel parentPanel;

        private readonly IServiceProvider _serviceProvider;
        public BookGenres(Panel panelContainer, IServiceProvider serviceProvider)
        {
            InitializeComponent();

            parentPanel = panelContainer;

            _serviceProvider = serviceProvider;
        }

        private void btnBackBooks_Click(object sender, EventArgs e)
        {
            FormLoader.LoadFormIntoPanel(parentPanel, new Books(parentPanel, _serviceProvider));
        }
    }
}
