
IF OBJECT_ID('[dbo].[ProviderCustomerReview_Add]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[ProviderCustomerReview_Add] 
END 
GO
CREATE PROC [dbo].[ProviderCustomerReview_Add] 
    @ProviderId INT,
	@CustomerReviewId INT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[ProviderCustomerReview] ([ProviderId], [CustomerReviewId])
	SELECT @ProviderId, @CustomerReviewId
	
	           
	COMMIT
GO
