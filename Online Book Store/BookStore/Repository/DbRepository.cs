using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Dapper;
using BookStore.Models;
using BookStore.DBAccess;
using System.Data.SqlClient;
using System.Data;

namespace BookStore.Repository
{
    public class DbRepository : IDbRepository
    {
        ILog logger;

        public void DatabaseRepository(ILog logger)
        {
            this.logger = logger;
        }

        public bool AddABook(Book book)
        {
            try
            {
                using (SqlConnection conn = DBAccess.DBAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@Title", book.Title);
                    parameter.Add("@Author", book.Author);
                    parameter.Add("Stock", book.Stock);

                    int result = conn.Execute("dbo.AddABook", parameter, commandType: CommandType.StoredProcedure);

                    return result > 0;
                }
            }
            catch (Exception e)
            {
                logger.Error("Error! Couldn't add the book! " + e.Message, e);
                return false;
            }
        }
        

        public bool AddACategory(Category category)
        {
            try
            {
                using (SqlConnection conn = DBAccess.DBAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("Category", category);

                    int result = conn.Execute("dbo.AddACategory", parameter, commandType: CommandType.StoredProcedure);

                    return result > 0;
                }
            }
            catch (Exception e)
            {
                logger.Error("Error! Couldn't add the category! ", e);
                return false;
            }
        }

        public bool AddACustomer(Customers customer)
        {
            try
            {
                using (SqlConnection conn = DBAccess.DBAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@FirstName", customer.FirstName);
                    parameter.Add("@LastName", customer.LastName);
                    parameter.Add("@BirthDate", customer.BirthDate);
                    parameter.Add("@Address", customer.Address);
                    parameter.Add("@PhoneNumber", customer.PhoneNumber);
                    parameter.Add("@Email", customer.Email);

                    int result = conn.Execute("dbo.AddACustomer", parameter, commandType: CommandType.StoredProcedure);

                    return result > 0;
                }
            }
            catch (Exception e)
            {
                logger.Error("Error! Couldn't add the new customer! " + e.Message, e);
                return false;
            }
        }

        public bool DeleteBook(int bookId)
        {
            logger.Info("Deleting book: " + bookId);
            try
            {
                using (SqlConnection conn = DBAccess.DBAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@BookId", bookId);

                    int result = conn.Execute("dbo.DeleteBook", parameter, commandType: CommandType.StoredProcedure);

                    return result > 0;
                }
            }
            catch (Exception e)
            {
                logger.Error("Error! Couldn't delete the book! " + e.Message, e);
                return false;
            }
        }

        public Customers GetCustomer(int customerId)
        {
            try
            {
                using (SqlConnection conn = DBAccess.DBAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@CustomerId", customerId);

                    Customers result = conn.Query<Customers>("dbo.GetCustomer", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    return result;
                }
            }
            catch (Exception e)
            {
                logger.Error("Error happened while getting the student! " + e.Message, e);
                return null;
            }
        }

        public Book SelectBookByAuthor(string author)
        {
            try
            {
                using (SqlConnection conn = DBAccess.DBAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@Author", author);

                    Book result = conn.Query<Book>("dbo.SelectBookByAuthor", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    return result;
                }
            }
            catch (Exception e)
            {
                logger.Error("Error! The book couldn't be found! " + e.Message, e);
                return null;
            }
        }

        public Book SelectBookByTitle(string title)
        {
            try
            {
                using (SqlConnection conn = DBAccess.DBAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@Title", title);

                    Book result = conn.Query<Book>("dbo.SelectBookByTitle", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    return result;
                }
            }
            catch (Exception e)
            {
                logger.Error("Error! The book couldn't be found! " + e.Message, e);
                return null;
            }
        }

        public Book SelectByCategory(string category)
        {
            try
            {
                using (SqlConnection conn = DBAccess.DBAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@Category", category);

                    Book result = conn.Query<Book>("dbo.SelectBookByCategory", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    return result;
                }
            }
            catch (Exception e)
            {
                logger.Error("Error! The book couldn't be found! " + e.Message, e);
                return null;
            }
        }

        public bool UpdateCustomerInfo(Customers customer)
        {
            try
            {
                using (SqlConnection conn = DBAccess.DBAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@CustomerId", customer.CustomerId);
                    parameter.Add("@FirstName", customer.FirstName);
                    parameter.Add("@LastName", customer.LastName);
                    parameter.Add("@BirthDate", customer.BirthDate);
                    parameter.Add("@Address", customer.Address);
                    parameter.Add("@PhoneNumber", customer.PhoneNumber);
                    parameter.Add("@Email", customer.Email);


                    int result = conn.Execute("dbo.UpdateCustomerInfo", parameter, commandType: CommandType.StoredProcedure);

                    return result > 0;
                }
            }
            catch (Exception e)
            {
                logger.Error("Error while updateing! " + e.Message, e);
                return false;
            }
        }

        public bool DeleteCustomer(int customerId)
        {
            try
            {
                using (SqlConnection conn = DBAccess.DBAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@CustomerId", customerId);

                    int result = conn.Execute("dbo.DeleteCustomer", parameter, commandType: CommandType.StoredProcedure);

                    return result > 0;
                }
            }
            catch (Exception e)
            {
                logger.Error("Customer not found! " + e.Message, e);
                return false;
            }
        }

        public bool UpdateBook(int bookId, Book book)
        {
            try
            {
                using (SqlConnection conn = DBAccess.DBAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@BookId", bookId);
                    parameter.Add("@Title", book.Title);
                    parameter.Add("@Author", book.Author);
                    parameter.Add("@Stock", book.Stock);
                    parameter.Add("@CategoryId", book.CategoryId);

                    int result = conn.Execute("dbo.UpdateBook", parameter, commandType: CommandType.StoredProcedure);

                    return result > 0;
                }
            }
            catch (Exception e)
            {
                logger.Error("Error! The book couldn't be found! " + e.Message, e);
                return false;
            }
        }

        public Book GetBook(int bookId)
        {
            try
            {
                using (SqlConnection conn = DBAccess.DBAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@BookId", bookId);

                    Book result = conn.Query<Book>("dbo.GetABook", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    return result;
                }
            }
            catch (Exception e)
            {
                logger.Error("An Error happened! " + e.Message, e);
                return null;
            }
        }

        public Customers GetCustomers(string username, string password)
        {
            try
            {
                using (SqlConnection conn = DBAccess.DBAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@username", username);
                    parameter.Add("@password", password);

                    Customers result = conn.Query<Customers>("spUserLogin", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    return result;
                }
            }
            catch (Exception e)
            {
                logger.Error("Error happened while getting the product! " + e.Message, e);
                return null;
            }
        }
    }
}
