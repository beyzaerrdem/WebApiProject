﻿using WebApiProject.DbOperations;

namespace WebApiProject.Services.BookOperations
{
    public class DeleteBookCommand
    {
        private readonly IBookStoreDbContext _dbcontext;

        public DeleteBookCommand(IBookStoreDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public int BookId { get; set; }

        public void Handle()
        {
            var book = _dbcontext.Books.SingleOrDefault(x => x.BookId == BookId);

            if (book == null)
            {
                throw new InvalidOperationException("Silinecek kitap bulunamadı.");
            }
            _dbcontext.Books.Remove(book);
            _dbcontext.SaveChanges();
        }
    }
}
