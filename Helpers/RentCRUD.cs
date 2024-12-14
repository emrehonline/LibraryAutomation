using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Helpers
{
    public class RentCRUD
    {
        private readonly Database database;
        public RentCRUD()
        {
            database = new Database();
        }

        public List<object[]> GetRentListByQuery()
        {
            string query = "Select b.Name, c.Name || ' ' || c.LastName as Customer, cb.RentedDate, cb.ReturnDate from CustomerBook cb inner join Customer c ON cb.CustomerID = c.ID inner join Book b ON cb.BookID = b.ID";
            return database.GetListByQuery(query, 4);
        }

        public bool CheckIfBookRented(int bookId, int customerId, string rentedDate, string returnDate)
        {
            string query = "Select * from CustomerBook where BookID = @BookID and CustomerID = @CustomerID and RentedDate= @RentedDate and ReturnDate = @ReturnDate";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@BookID", bookId);
            parameters.Add("@CustomerID", customerId);
            parameters.Add("@RentedDate", rentedDate);
            parameters.Add("@ReturnDate", returnDate);

            return database.CheckIfDataExist(query, parameters, 1);
        }

        public bool CreateRent(int bookId, int customerId, string rentedDate, string returnDate)
        {
            string query = "Insert Into CustomerBook(BookID, CustomerID, RentedDate, ReturnDate) Values(@BookID, @CustomerID, @RentedDate, @ReturnDate)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@BookID", bookId);
            parameters.Add("@CustomerID", customerId);
            parameters.Add("@RentedDate", rentedDate);
            parameters.Add("@ReturnDate", returnDate);

            return database.ExecuteCommand(query, parameters);
        }
    }
}
