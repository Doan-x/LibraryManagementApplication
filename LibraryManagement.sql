--use master
--go
--create database LibraryManagement
--use LibraryManagement
--go
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName VARCHAR(255) UNIQUE NOT NULL,
    [Description] TEXT
);

CREATE TABLE Books (
    BookID INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(255) ,
    Author NVARCHAR(255),
    CategoryID int,
	Price money,
	Quantity INT DEFAULT 1,
    DateAdded DATE DEFAULT GETDATE(),
	[Status] int default 1,
	CONSTRAINT FK_CategoryID FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID),
);

CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    [Password] VARCHAR(255) default '123',
    FullName VARCHAR(255) ,
    Email VARCHAR(255) UNIQUE NOT NULL,
    PhoneNumber VARCHAR(20),
	CCCD varchar(12) UNIQUE NOT NULL,
	Role VARCHAR(50) NOT NULL,
    DateJoined DATE DEFAULT GETDATE()
);


CREATE TABLE BorrowRecords (
    BorrowID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT,
    BookID INT,
    StartDate DATE DEFAULT GETDATE(),
    EndDate DATE ,
    ReturnDate DATE,
    BorrowStatus int default 0, -- 3 status: borrowing: 0, returned: 1, reseration: -1
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (BookID) REFERENCES Books(BookID),
);

CREATE TABLE Reservation (
    ReservationID INT PRIMARY KEY,
    BorrowID INT,
    UserID INT,
    ReservationDate DATE,
    Status bit default 0, --- 0: ch?a duyêt; 1: ?ã duy?t
    FOREIGN KEY (BorrowID) REFERENCES BorrowRecords(BorrowID),
    FOREIGN KEY (UserID) REFERENCES [Users](UserID)
	
);
INSERT INTO Categories (CategoryName, [Description]) VALUES
('Fiction', 'Fictional books and novels.'),
('Science', 'Books related to science and technology.'),
('History', 'Books about historical events and figures.'),
('Biography', 'Biographies and autobiographies.'),
('Children', 'Books for children.'),
('Mystery', 'Mystery and thriller books.'),
('Fantasy', 'Fantasy and magical realism books.'),
('Romance', 'Romantic novels.'),
('Self-Help', 'Self-help and motivational books.'),
('Travel', 'Travel guides and books.');

INSERT INTO Books (Title, Author, CategoryID, Price, Quantity) VALUES
('The Great Gatsby', 'F. Scott Fitzgerald', 1, 10.99, 5),
('A Brief History of Time', 'Stephen Hawking', 2, 15.99, 3),
('The Art of War', 'Sun Tzu', 3, 9.99, 7),
('Steve Jobs', 'Walter Isaacson', 4, 20.99, 2),
('Harry Potter and the Philosopher Stone', 'J.K. Rowling', 5, 12.99, 8),
('Gone Girl', 'Gillian Flynn', 6, 11.99, 4),
('The Hobbit', 'J.R.R. Tolkien', 7, 14.99, 6),
('Pride and Prejudice', 'Jane Austen', 8, 9.99, 10),
('How to Win Friends and Influence People', 'Dale Carnegie', 9, 10.99, 5),
('Lonely Planet Japan', 'Lonely Planet', 10, 22.99, 3);


INSERT INTO Users ([Password], FullName, Email, PhoneNumber, CCCD, Role, DateJoined)
VALUES 
    ('password1', 'Alice Johnson', 'alice@example.com', '123-456-7890', '123456789012', 'Customer', '2023-01-15'),
    ('password2', 'Bob Smith', 'bob@example.com', '234-567-8901', '234567890123', 'Customer', '2022-05-20'),
    ('password3', 'Charlie Brown', 'charlie@example.com', '345-678-9012', '345678901234', 'Admin', '2021-11-10'),
    ('password4', 'David Lee', 'david@example.com', '456-789-0123', '456789012345', 'Librarian', '2020-08-05'),
    ('password5', 'Eva Green', 'eva@example.com', '567-890-1234', '567890123456', 'Customer', '2019-03-30'),
    ('password6', 'Frank White', 'frank@example.com', '678-901-2345', '678901234567', 'Customer', '2018-06-25'),
    ('password7', 'Grace Davis', 'grace@example.com', '789-012-3456', '789012345678', 'Librarian', '2017-09-15'),
    ('password8', 'Helen Taylor', 'helen@example.com', '890-123-4567', '890123456789', 'Admin', '2016-02-10'),
    ('password9', 'Ian Martin', 'ian@example.com', '901-234-5678', '901234567890', 'Customer', '2015-07-20'),
    ('password10', 'Jack Wilson', 'jack@example.com', '012-345-6789', '012345678901', 'Customer', '2014-04-15'),

	('123', 'Doan Trong', 'admin@gmail.com', '8877665544', '012345678912', 'Admin',GETDATE());

	select*from Users
select*from Books	

-- Insert d? li?u m?u vào BorrowRecords
INSERT INTO BorrowRecords (UserID, BookID, StartDate, EndDate, ReturnDate, BorrowStatus)
VALUES 
     
    (12, 2, '2024-07-01', '2024-07-16',null, 0),  
    (12, 4, '2024-07-02', '2024-07-17',null, 0),  
    (13, 6, '2024-07-03', '2024-07-18',null, 0),  
    (14, 8, '2024-07-04', '2024-07-19',null, 0),  
    (15, 10, '2024-07-05', '2024-07-20',null, 0),  
    (16, 3, '2024-07-06', '2024-07-16',null, 0),  
    (17, 5, '2024-07-07', '2024-07-17',null, 0),  
    (18, 7, '2024-07-08', '2024-07-18',null, 0), 
    (19, 9, '2024-07-09', '2024-07-19',null, 0),  
    (20, 2, '2024-07-10', '2024-07-20',null, 0),  
    (21, 6, '2024-07-12', '2024-07-17',null, 0), 
    (15, 8, '2024-07-13', '2024-07-18',null, 0);  

-- Insert d? li?u m?u vào Reservation






