SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Eduardo Brito>
-- Create date: <14/03/2022>
-- Description:	<Inserir Estudante>
-- =============================================
CREATE PROCEDURE [dbo].[spo_EstudanteTesteEduardo_Inserir] --'Eduardo Brito','Dudu','2003-06-11','1'
		 @Nome nvarchar(100)
		,@Curso nvarchar(130)
		,@DataNascimento datetime
		,@Status bit
		AS
BEGIN

	SET NOCOUNT ON;
	
	insert into [dbo].[EstudanteTesteEduardo]
				([Nome]
				,[Curso]
				,[DataNascimento]
				,[Status]) 
		   values
				(@Nome
				,@Curso
				,@DataNascimento
				,@Status);
   select @@IDENTITY;
END
GO
