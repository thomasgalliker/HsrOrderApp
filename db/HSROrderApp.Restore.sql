USE [master];
GO
RESTORE DATABASE HSROrderApp
FROM DISK = 'C:\src\github\HsrOrderApp\db\HSROrderApp.bak'
WITH REPLACE;
GO