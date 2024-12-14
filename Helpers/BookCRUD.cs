using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDev.HtmlRenderer.Adapters;

namespace LibraryAutomation.Helpers
{

    public class BookCRUD
    {
        private readonly Database database;
        public BookCRUD()
        {
            database = new Database();
        }

        public List<object[]> GetBookList()
        {
            return database.GetList("Book", 3);
        }


    }
}
