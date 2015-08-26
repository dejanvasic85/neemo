
IF OBJECT_ID('[dbo].[CustomerReview_GetForProvider]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[CustomerReview_GetForProvider] 
END 
GO
CREATE PROC [dbo].[CustomerReview_GetForProvider] 
    @ProviderId INT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	SELECT  c.*
	FROM	CustomerReview c
	JOIN	ProviderCustomerReview p
		ON	p.CustomerReviewId = c.CustomerReviewId
	AND		p.ProviderId = @ProviderId

GO
