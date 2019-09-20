create procedure sp_delete_padrao
@ID INT
as

DELETE FROM [dbo].[CONFIG_PRINTER]
      WHERE id = @ID
GO


