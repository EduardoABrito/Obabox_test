
GO
/****** Object:  StoredProcedure [dbo].[spo_EstudanteTesteEduardo_Inserir]    Script Date: 14/03/2022 14:12:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Eduardo Brito>
-- Create date: <14/03/2022>
-- Description:	<Atualizar Estudante por identificador>
-- =============================================
Create PROCEDURE [dbo].[spo_EstudanteTesteEduardo_Alterar] --1,'Eduardo A Brito','matematica','2003-06-12','0'
		 @Identificador int
		,@Nome nvarchar(100)
		,@Curso nvarchar(130)
		,@DataNascimento datetime
		,@Status bit
		AS
BEGIN

	SET NOCOUNT ON;
	
		update [dbo].[EstudanteTesteEduardo] set 
		         [Nome] = @Nome
				,[Curso] = @Curso
				,[DataNascimento] = @DataNascimento
				,[Status] = @Status
				Where Identificador = @Identificador

END
