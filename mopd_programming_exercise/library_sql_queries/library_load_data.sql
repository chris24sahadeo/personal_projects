USE Library;
GO

-- INSERT INTO library.role (role_id, role_name, role_desc) VALUES
-- (1, 'admin', 'Full Database Access'),
-- (2, 'member', 'Member Database Access');

-- SET IDENTITY_INSERT library.member ON;

-- INSERT INTO library.member (user_id, first_name, last_name, dob, address, email, phone, role_id) VALUES
-- (1, 'Chris', 'Sahadeo', '19971128', 'LP 52 Joe Street, Dinsley Village, Tacarigua', 'christophersahadeo@gmail.com', '8683204240', 1),
-- (2, 'Tristan', 'Sankar', '19960922', 'El Dorado', 'tristansankar@gmail.com', '8681234567',  1),
-- (3, 'John', 'Doe', '20001029', 'Chaguanas', 'johndoe@gmail.com', '8689876257',  2),
-- (4, 'Jane', 'Doe', '19600403', 'Port-of-Spain', 'janedoe@hotmail.com', '8682218996',  2),
-- (5, 'John', 'Carmack', '19751120', 'San Francisco', 'johncarmack@id.com', '8680925874',  2);

-- SET IDENTITY_INSERT library.member OFF;

INSERT INTO library.publisher (publisher_name) VALUES
('Penguin Random House'),
('Warner Books Ed'),
('Harper Perennial Modern Classics'),
('Prentice Hall');

INSERT INTO library.genre (genre_name, genre_type) VALUES
('Action and adventure', 'Fiction'),
('Alternate history', 'Fiction'),
('Anthology', 'Fiction'),
('Chick lit', 'Fiction'),
('Children', 'Fiction'),
('Comic book', 'Fiction'),
('Coming-of-age', 'Fiction'),
('Crime', 'Fiction'),
('Drama', 'Fiction'),
('Fairytale', 'Fiction'),
('Fantasy', 'Fiction'),
('Graphic novel', 'Fiction'),
('Historical fiction', 'Fiction'),
('Horror', 'Fiction'),
('Mystery', 'Fiction'),
('Paranormal romance', 'Fiction'),
('Picture book', 'Fiction'),
('Poetry', 'Fiction'),
('Political thriller', 'Fiction'),
('Romance', 'Fiction'),
('Satire', 'Fiction'),
('Science fiction', 'Fiction'),
('Short story', 'Fiction'),
('Suspense', 'Fiction'),
('Thriller', 'Fiction'),
('Young adult', 'Fiction'),
('Art', 'Non-Fiction'),
('Autobiography', 'Non-Fiction'),
('Biography', 'Non-Fiction'),
('Book review', 'Non-Fiction'),
('Cookbook', 'Non-Fiction'),
('Diary', 'Non-Fiction'),
('Dictionary', 'Non-Fiction'),
('Encyclopedia', 'Non-Fiction'),
('Guide', 'Non-Fiction'),
('Health', 'Non-Fiction'),
('History', 'Non-Fiction'),
('Journal', 'Non-Fiction'),
('Math', 'Non-Fiction'),
('Memoir', 'Non-Fiction'),
('Prayer', 'Non-Fiction'),
('Religion, spirituality, and new age', 'Non-Fiction'),
('Textbook', 'Non-Fiction'),
('Review', 'Non-Fiction'),
('Science', 'Non-Fiction'),
('Self help', 'Non-Fiction'),
('Travel', 'Non-Fiction'),
('True crime', 'Non-Fiction');

INSERT INTO library.book (book_id, book_name, edition, year_published, publisher_name, genre_name, rating, summary) VALUES
('013604259', 'Artificial Intelligence - A Modern Approach', 3.0, '2010', 'Prentice Hall', 'Textbook', 5.0, 'Artificial Intelligence: A Modern Approach (AIMA) is a university textbook on artificial intelligence, written by Stuart J. Russell and Peter Norvig. It was first published in 1995 and the third edition of the book was released 11 December 2009. It is used in over 1350 universities worldwide[1] and has been called "the most popular artificial intelligence textbook in the world".[2] It is considered the standard text in the field of artificial intelligence.[3] The book is intended for an undergraduate audience but can also be used for graduate-level studies with the suggestion of adding some of the primary sources listed in the extensive bibliography.'),
('9781612680019', 'Rich Dad, Poor Dad', 1.0, '1997', 'Harper Perennial Modern Classics', 'Self help', 4.3, 'Rich Dad Poor Dad is a 1997 book written by Robert Kiyosaki and Sharon Lechter. It advocates the importance of financial literacy (financial education), financial independence and building wealth through investing in assets, real estate investing, starting and owning businesses, as well as increasing one''s financial intelligence (financial IQ) to improve one''s business and financial aptitude. Rich Dad Poor Dad is written in the style of a set of parables, ostensibly based on Kiyosaki''s life.[1]'),
('0345816021', '12 Rules for Life: An Antidote to Chaos', 3.0, '2018', 'Penguin Random House', 'Self help', 5.0, '12 Rules for Life: An Antidote to Chaos is a 2018 self-help book by Canadian clinical psychologist and psychology professor Jordan Peterson. It provides life advice through essays on abstract ethical principles, psychology, mythology, religion, and personal anecdotes.'),
('9780061339202', 'Flow: the Psychology of Optimal Experience', 2.0, '1990', 'Penguin Random House', 'Self help', 3.5, 'More than anything else, this book is an exploration of happiness. What makes us happy? How can we live a fulfilling life? These are no simple questions to ask, but author Csikszentmihalyi makes a compelling and clear argument as to how happiness can be obtained (in passing, he even gives simple explanations for consciousness and the meaning of life!).In doing so, the author touches on a lot of principles from ancient philosophies and religions, such as Stoicism and Buddhism. Yet the approach for a happy life set out in Flow is based upon scientific research, as opposed to rules and guidelines obtained from ancient wisdom. Not that there''s anything wrong with ancient wisdom, but it''s all the more impressive to see modern guidelines to happiness based on scientific research.So what does it come down to? On the one hand, happiness is not a destination where you arrive, but a condition that needs to be cultivated. It''s affected by the information we let into our thoughts and the way we seek happiness. Csikszentmihalyi makes a clear distinction between pleasure seeking and enjoyment, where pleasure is externally focused and hence a temporary fix for happiness, while true enjoyment comes from within and is sustainable.On the other hand, it depends on how we engage in activities, and this is where flow enters the scene: the research shows surprisingly few moments of happiness occur when we''re idle. While engaged in work, in creating something, in pursuit of some kind of goal, stretching our abilities to their limits, those are the moments when most of us experience true happiness. This is when we''re in a state of flow.Paradoxically, this means we often feel happier when working than when engaged in what most people consider leisure time: watching TV, getting drunk, lying on a beach for a week. Flow provides a solution: when the principles are understood, many activities can be turned into rewarding experiences that contribute to our happiness, and who would say no to that?');

-- SET IDENTITY_INSERT library.inventory ON;

-- INSERT INTO library.inventory (item_id, book_id) VALUES 
-- (1, '013604259'),
-- (2, '013604259'),
-- (3, '013604259'),
-- (4, '013604259'),
-- (5, '013604259'),
-- (6, '013604259'),
-- (7, '9781612680019'),
-- (8, '9781612680019'),
-- (9, '9781612680019'),
-- (10, '9781612680019'),
-- (11, '9781612680019'),
-- (12, '0345816021'),
-- (13, '9780061339202'),
-- (14, '9780061339202'),
-- (15, '9780061339202'),
-- (16, '9780061339202'),
-- (17, '9780061339202'),
-- (18, '9780061339202'),
-- (19, '9780061339202'),
-- (20, '9780061339202');

-- SET IDENTITY_INSERT library.inventory OFF;

-- INSERT INTO library.loan (item_id, user_id, date_due, date_returned) VALUES
-- (2, 1, '20200101 12:00:00 PM', NULL), -- not yet returned
-- (3, 1, '20210101 12:00:00 PM', '20210102 12:00:00 PM'), -- returned one day late
-- (10, 1, '20200501 12:00:00 PM', '20191001 12:00:00 PM'), -- returned on time
-- (17, 3, '20191128 12:00:00 PM', NULL),
-- (12, 1, '20200101 12:00:00 PM', NULL),
-- (11, 2, '20200101 12:00:00 PM', '20200101 11:00:00 AM'); -- returned one hour early

-- INSERT INTO library.wishlist (user_id, book_id) VALUES 
-- (1, '013604259'),
-- (1, '9781612680019'),
-- (1, '0345816021'),
-- (3, '013604259'),
-- (3, '9780061339202');

-- INSERT INTO library.bookreview (book_id, reviewer_id, review, rating) VALUES 
-- ('0345816021', 1, 'Life altering!', 5.0),
-- ('0345816021', 2, 'Changed my life!!!', 4.9),
-- ('9780061339202', 1, 'An amazing intro to AI.', 4.0);

-- SET IDENTITY_INSERT library.author ON;

INSERT INTO library.author (author_id, first_name, last_name) VALUES 
('9aa78aa9-a922-4144-8c22-43364d9f5594', 'Jordan', 'Peterson'),
('b3acaa2e-2367-4929-ba88-fa95db17d7fb', 'Robert', 'Kiyosaki'),
('34034494-8804-4fcd-8fb6-628e1c4d3336', 'Stuart', 'Russell'),
('b84ed0e9-c7b5-4cbe-8a1e-2aedfafd3521', 'Peter', 'Norvig'),
('4fceaf21-5ac0-4cba-b5ea-6167e6d13b16', 'Mihaly', 'Csikszentmihalyi');

-- SET IDENTITY_INSERT library.author OFF;

INSERT INTO library.bookauthor (book_id, author_id) VALUES 
('013604259', '34034494-8804-4fcd-8fb6-628e1c4d3336'),
('013604259', 'b84ed0e9-c7b5-4cbe-8a1e-2aedfafd3521'),
('9781612680019', 'b3acaa2e-2367-4929-ba88-fa95db17d7fb'),
('0345816021', '9aa78aa9-a922-4144-8c22-43364d9f5594'),
('9780061339202', '4fceaf21-5ac0-4cba-b5ea-6167e6d13b16');
