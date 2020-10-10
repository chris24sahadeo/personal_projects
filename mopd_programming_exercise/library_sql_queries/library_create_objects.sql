-- TODO:
-- change on delete/update casade to no action where applicable
-- make all table names capital in the future since they correspond to class names 

USE master;
GO

IF DB_ID (N'Library') IS NULL
CREATE DATABASE Library;
GO

USE Library;
GO

CREATE SCHEMA library;
GO

-- removing role and member entities since it is managed best by ASP.NET Identity 

-- CREATE TABLE library.role (
-- 	role_id INT PRIMARY KEY,
-- 	role_name NVARCHAR (30),
-- 	role_desc NVARCHAR (100)
-- );

-- CREATE TABLE library.member (
-- 	user_id INT IDENTITY (1, 1) PRIMARY KEY,
-- 	first_name NVARCHAR (30) NOT NULL,
-- 	last_name NVARCHAR (30) NOT NULL,
-- 	dob DATE NOT NULL,
-- 	address NVARCHAR (100),
-- 	email NVARCHAR (60) NOT NULL,
-- 	-- password,
-- 	phone NVARCHAR (15) NOT NULL,
-- 	date_joined DATETIME DEFAULT GETDATE(),
-- 	role_id INT, 
-- 	profile_pic_path NVARCHAR (60),
-- 	FOREIGN KEY (role_id)
-- 		REFERENCES library.role (role_id)
-- 		ON DELETE CASCADE ON UPDATE CASCADE
-- );

CREATE TABLE library.publisher (
	publisher_name NVARCHAR(60) PRIMARY KEY
);

CREATE TABLE library.genre (
	genre_name NVARCHAR(60) PRIMARY KEY,
	genre_type NVARCHAR(20) NOT NULL CHECK (genre_type IN('Fiction', 'Non-Fiction')) 
);

CREATE TABLE library.book (
	book_id NVARCHAR (13) PRIMARY KEY, -- ISBN
	book_name NVARCHAR (100) NOT NULL,
	edition DECIMAL (4, 1) NOT NULL,
	year_published SMALLINT NOT NULL,
	publisher_name NVARCHAR(60),
	genre_name NVARCHAR(60),
	cover_photo_path NVARCHAR (60),
	rating DECIMAL (2, 1) CHECK (rating BETWEEN 0.0 AND 5.0),
	summary NVARCHAR (4000),
	FOREIGN KEY (publisher_name)
		REFERENCES library.publisher (publisher_name)
		ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (genre_name)
		REFERENCES library.genre (genre_name)
		ON DELETE CASCADE ON UPDATE CASCADE
);

-- CREATE TABLE library.inventory (
-- 	item_id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
-- 	book_id NVARCHAR (13),
-- 	FOREIGN KEY (book_id)
-- 		REFERENCES library.book (book_id)
-- 		ON DELETE CASCADE ON UPDATE CASCADE
-- );

-- CREATE TABLE library.loan (
-- 	loan_id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
-- 	date_borrowed DATETIME DEFAULT GETDATE(),
-- 	date_due DATETIME NOT NULL,
-- 	date_returned DATETIME,
-- 	item_id UNIQUEIDENTIFIER,
-- 	user_id UNIQUEIDENTIFIER NOT NULL,
-- 	FOREIGN KEY (item_id)
-- 		REFERENCES library.inventory (item_id)
-- 		ON DELETE CASCADE ON UPDATE CASCADE,
-- 	-- FOREIGN KEY (user_id)
-- 	-- 	REFERENCES library.member (user_id)
-- 	-- 	ON DELETE CASCADE ON UPDATE CASCADE
-- );

CREATE TABLE library.wishlistitem (
	wish_list_item_id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(), -- GUID - Foreign Key with user_id
	user_id NVARCHAR (128) NOT NULL,
	book_id NVARCHAR(13), -- ISBN
	date_created DATETIME DEFAULT GETDATE(),
	-- PRIMARY KEY(user_id, book_id),
	-- FOREIGN KEY (user_id)
	-- 	REFERENCES library.member (user_id)
	-- 	ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (book_id)
		REFERENCES library.book (book_id)
		ON DELETE CASCADE ON UPDATE CASCADE
);

-- CREATE TABLE library.bookreview (
-- 	book_review_id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(), -- GUID
-- 	book_id NVARCHAR (13), -- ISBN
-- 	reviewer_id UNIQUEIDENTIFIER NOT NULL,
-- 	review NVARCHAR (1000) NOT NULL,
-- 	rating DECIMAL (2, 1) CHECK (rating BETWEEN 0.0 AND 5.0),
-- 	-- PRIMARY KEY (book_id, reviewer_id),
-- 	FOREIGN KEY (book_id)
-- 		REFERENCES library.book (book_id)
-- 		ON DELETE CASCADE ON UPDATE CASCADE,
-- 	-- FOREIGN KEY (reviewer_id)
-- 	-- 	REFERENCES library.member (user_id)
-- 	-- 	ON DELETE CASCADE ON UPDATE CASCADE
-- );

CREATE TABLE library.author (
	author_id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(), -- GUID
	first_name NVARCHAR (30) NOT NULL,
	last_name NVARCHAR (30) NOT NULL
);

CREATE TABLE library.bookauthor (
	book_author_id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(), -- GUID
	book_id NVARCHAR (13), -- ISBN
	author_id UNIQUEIDENTIFIER, -- GUID
	-- PRIMARY KEY (book_id, author_id),
	UNIQUE (book_id, author_id),
	FOREIGN KEY (book_id)
		REFERENCES library.book (book_id)
		ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (author_id)
		REFERENCES library.author (author_id)
		ON DELETE CASCADE ON UPDATE CASCADE
);
