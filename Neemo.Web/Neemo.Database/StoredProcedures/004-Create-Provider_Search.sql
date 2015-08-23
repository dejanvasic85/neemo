SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Provider_Search]
       @Keyword nvarchar(100) = null,
	   @ServiceTypeId varchar(100) = null,
	   @ProviderType varchar(100)
 
	   /*
	   exec dbo.Provider_Search 
			@ProviderType = 'Wreckers',
			@keyword = ''

	   */
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT  p.*
	FROM	Provider p
	WHERE	p.active = 1

	-- Filter only specific provider type
	AND EXISTS (SELECT	1 FROM Provider_ProviderType ppt
				JOIN	ProviderType pt
					ON	pt.ProviderTypeID = ppt.ProviderTypeID
					AND	pt.ProviderType = @ProviderType
				WHERE	ppt.ProviderID = p.ProviderID )

	-- Match keyword with p.Keyword or p.ProviderName
	AND		(		p.KeyWord LIKE ISNULL(@Keyword, p.KeyWord) + '%' 
				OR	p.ProviderName LIKE ISNULL(@Keyword, p.ProviderName) + '%'
				OR	p.[Description] LIKE ISNULL(@Keyword, p.[Description]) + '%')

	-- Service type
	AND		(		@ServiceTypeId IS NULL
				OR	EXISTS (SELECT	1 FROM ProviderServiceType pst
							WHERE	pst.ProviderID = p.ProviderID
							AND		pst.ServiceTypeID = @ServiceTypeId) )


END
