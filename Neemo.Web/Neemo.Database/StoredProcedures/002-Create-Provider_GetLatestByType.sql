SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Provider_GetLatestByType]
	  @ProviderType NVARCHAR(100)
	, @Max INT
           
AS

/*
	e.g.
	exec dbo.Provider_GetLatestByType
		@ProviderType = 'Wreckers',
		@Max = 5
*/
SELECT TOP (@Max) p.* FROM Provider p 
WHERE 
	p.Active = 1
AND EXISTS (
	SELECT	1 FROM Provider_ProviderType ppt
	JOIN	ProviderType pt
		ON	pt.ProviderTypeID = ppt.ProviderTypeID
		AND	pt.ProviderType = @ProviderType
	WHERE	ppt.ProviderID = p.ProviderID )

ORDER BY p.CreatedDateTime DESC