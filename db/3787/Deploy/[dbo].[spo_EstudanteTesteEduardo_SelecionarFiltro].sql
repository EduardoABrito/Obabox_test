
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Eduardo Brito>
-- Create date: <14/03/2022>
-- Description:	<Filtro >
-- =============================================
Create PROCEDURE [dbo].[spo_EstudanteTesteEduardo_SelecionarFiltro] --'','','','2'
	-- Add the parameters for the stored procedure here
	 @Identificador nvarchar(300)
	,@Nome nvarchar(100)
	,@Curso nvarchar(130)
	,@Status int
AS
BEGIN
	SET NOCOUNT ON;

	Declare @WHERE nvarchar(max)='where 0=0 ';
	Declare @SQL nvarchar(max);

	if(@Identificador != '') begin 
		set @WHERE+='and [Identificador] in ('+ @Identificador +') ';
	end
	if(@Nome != '') begin 
		set @WHERE+='and [Nome] like ''%'+ @Nome +'%'' ';
   end
   	if(@Curso != '') begin 
		set @WHERE+='and [Curso] like ''%'+ @Curso +'%'' ';
   end
   	if(@Status != '2')
   begin 
		if(@Status = '1') begin 
			set @WHERE+='and [Status]=1';
		end
		else begin 
			set @WHERE+='and [Status]=0 ';
		end
   end

  set @SQL ='select [Identificador]
		,[Nome]
		,[Curso]
		,[DataNascimento]
		,[Status]
		from EstudanteTesteEduardo '+ @WHERE ;
	
	execute(@SQL);
END
GO
