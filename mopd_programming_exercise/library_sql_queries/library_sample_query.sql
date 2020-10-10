USE Library;
GO

SELECT
	first_name, last_name, book_name
FROM
	library.author, library.book, library.bookauthor
WHERE
	library.author.author_id = library.bookauthor.author_id AND library.bookauthor.book_id = library.book.book_id;
