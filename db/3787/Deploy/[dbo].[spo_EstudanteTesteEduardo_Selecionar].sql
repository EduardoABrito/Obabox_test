
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Eduardo Brito>
-- Create date: <14/03/2022>
-- Description:	<Selecionar um estudante pelo identificador>
-- =============================================
CREATE PROCEDURE [dbo].[spo_EstudanteTesteEduardo_Selecionar] 
	@Identificador int 
AS
BEGIN
	
	SET NOCOUNT ON;

  select Identificador
		,[Nome]
		,[Curso]
		,[DataNascimento]
		,[Status]
		From [dbo].[EstudanteTesteEduardo] where Identificador = @Identificador; 
END
GO
