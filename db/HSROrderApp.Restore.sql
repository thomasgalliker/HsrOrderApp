USE [master];
GO
RESTORE DATABASE HSROrderApp
FROM DISK = 'C:\src\github\HsrOrderApp\db\HSROrderApp.bak'
WITH REPLACE;
GO

UPDATE [dbo].[Users]
 SET Username='T450\Thomas'
 WHERE UserId=1; 