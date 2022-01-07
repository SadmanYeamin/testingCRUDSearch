using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace testingCRUDSearch.Models
{
    public class BookModel
    {
        DataAccess dataAccess;

        public BookModel()
        {
            dataAccess = new DataAccess();
        }

        public List<Book> GetBooks()
        {
            string sql = "select * from books";
            SqlDataReader reader = dataAccess.GetData(sql);
            List<Book> books = new List<Book>();
            while(reader.Read())
            {
                Book book = new Book();
                book.BookId =(int) reader["BookId"];
                book.Title = reader["Title"].ToString();
                book.Author = reader["Author"].ToString();
                book.Price = (int)reader["Price"];
                books.Add(book);
            }
            return books;

        }

        public Book GetBook(int id)
        {
            string sql = "select * from books where BookId="+id;
            SqlDataReader reader = dataAccess.GetData(sql);
            List<Book> books = new List<Book>();
            reader.Read();
            
                Book book = new Book();
                book.BookId = (int)reader["BookId"];
                book.Title = reader["Title"].ToString();
                book.Author = reader["Author"].ToString();
                book.Price = (int)reader["Price"];
                
            
            return book;
        }

        public int Insert(Book book)
        {
            string sql = "insert into books (Title,Author,Price)Values('"+book.Title+ "','" + book.Author + "','" + book.Price + "')";
            int result = dataAccess.ExecuteQuery(sql);
            if(result>0)
            {
                return result;
            }
            return 0;
        }

        public int Update(Book book)
        {
            string sql = "update books set Title='" + book.Title + "',Author='" + book.Author + "', Price='"+ book.Price + "'where BookId="+book.BookId;
            int result = dataAccess.ExecuteQuery(sql);
            
             return result;
            
        }

        public int Delete(int id)
        {
            string sql = "delete from books where BookId=" + id;
            int result = dataAccess.ExecuteQuery(sql);

            return result;

        }
    }
}