CREATE DATABASE BeSharpGymDataBase;

CREATE TABLE Members (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    FullName VARCHAR(100),
    Email NVARCHAR(100),
    RegistrationDate DATE,
    LastLoginDate DATE,
    IsPremiumMember BIT,
    MembershipStatus VARCHAR(50)
);

INSERT INTO Members (FullName, Email, RegistrationDate, LastLoginDate, IsPremiumMember, MembershipStatus)
VALUES
    ('Tom Hanks', 'tom.hanks@example.com', '2022-01-01', '2022-01-02', 1, 'Inactive'),
    ('Brad Pitt', 'brad.pitt@example.com', '2022-02-01', '2022-02-05', 0, 'Active'),
    ('Leonardo DiCaprio', 'leo.dicaprio@example.com', '2022-03-01', '2022-03-10', 1, 'Active'),
    ('Julia Roberts', 'julia.roberts@example.com', '2022-04-01', '2022-04-15', 1, 'Active'),
    ('Johnny Depp', 'johnny.depp@example.com', '2022-05-01', '2022-05-20', 0, 'Inactive'),
    ('Chris Hemsworth', 'chris.hemsworth@example.com', '2022-06-01', '2022-06-25', 1, 'Active'),
    ('Will Smith', 'will.smith@example.com', '2022-07-01', '2022-07-30', 0, 'Inactive'),
    ('Denzel Washington', 'denzel.washington@example.com', '2022-08-01', '2022-08-05', 1, 'Active'),
    ('Jenifer Aniston', 'jenifer.aniston@example.com', '2022-09-01', '2022-09-10', 1, 'Inactive'),
    ('Chris Evans', 'chris.evans@example.com', '2022-10-01', '2022-10-15', 0, 'Active'),
    ('Keanu Reeves', 'keanu.reeves@example.com', '2022-11-01', '2022-11-20', 1, 'Active'),
    ('Nicole Kidman', 'nickole.kidman@example.com', '2022-12-01', '2022-12-25', 0, 'Active'),
    ('Harrison Ford', 'harrison.ford@example.com', '2023-01-01', '2023-01-05', 1, 'Inactive'),
    ('Bruce Willis', 'bruce.willis@example.com', '2023-02-01', '2023-02-10', 1, 'Inactive'),
    ('Matt Damon', 'matt.damon@example.com', '2023-03-01', '2023-03-15', 0, 'Active'),
    ('Samuel L. Jackson', 'samuel.jackson@example.com', '2023-04-01', '2023-04-20', 0, 'Inactive'),
    ('Ryan Reynolds', 'ryan.reynolds@example.com', '2023-05-01', '2023-05-05', 1, 'Active'),
    ('Angelina Jolie', 'angelina.jolie@example.com', '2023-06-01', '2023-06-10', 0, 'Inactive'),
    ('Chris Pratt', 'chris.pratt@example.com', '2023-07-01', '2023-07-15', 1, 'Active'),
    ('Jenifer Lawrence', 'jenifer.lawrence@example.com', '2023-07-01', '2023-07-15', 1, 'Active');

SELECT * FROM Members
