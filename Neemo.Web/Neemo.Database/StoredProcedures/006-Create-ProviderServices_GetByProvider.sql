SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProviderServiceType_GetByProvider]
       @ProviderId INT
 
	/*
	   exec dbo.[ProviderServiceType_GetByProvider] 
			@ProviderId = 1
	 */
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT	st.*
	FROM	ProviderServiceType pst
	JOIN	ServiceType st
		ON	st.ServiceTypeID = pst.ServiceTypeID
	WHERE	ProviderID = @ProviderId

END
