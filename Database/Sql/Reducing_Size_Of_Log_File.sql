ALTER DATABASE AmardShahrsazisabzevar
SET RECOVERY SIMPLE;
GO
-- Shrink the truncated log file to 1 MB.
DBCC SHRINKFILE (AmardShahrsaziKham_log, 1);
GO
-- Reset the database recovery model.
ALTER DATABASE AmardShahrsazisabzevar
SET RECOVERY FULL;
GO