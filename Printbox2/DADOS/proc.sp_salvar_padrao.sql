create procedure sp_salvar_padrao
@ID INT=0,
@PRINTER_IP VARCHAR(15),
@DESC_PRINTER VARCHAR(100),
@IS_DEFAULT BIT
as
INSERT INTO [dbo].[CONFIG_PRINTER]
           ([PRINTER_IP]
           ,[DESC_PRINTER]
           ,[IS_DEFAULT])
     VALUES
           (@PRINTER_IP
           ,@DESC_PRINTER
           ,@IS_DEFAULT)
GO


