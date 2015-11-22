
IF OBJECT_ID('[dbo].[CustomerReview_Add]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[CustomerReview_Add] 
END 
GO
CREATE PROC [dbo].[CustomerReview_Add] 
    @Score decimal(18, 2) = NULL,
    @Comment nvarchar(MAX) = NULL,
    @Active bit = NULL,
    @CreatedDateTime datetime = NULL,
    @CreatedByUser nvarchar(50) = NULL,
    @EffectiveDateFrom datetime = NULL,
    @EffectiveDateTo datetime = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[CustomerReview] ([Score], [Comment], [Active], [CreatedDateTime], [CreatedByUser], [EffectiveDateFrom], [EffectiveDateTo])
	SELECT @Score, @Comment, @Active, @CreatedDateTime, @CreatedByUser, @EffectiveDateFrom, @EffectiveDateTo
	
	-- Begin Return Select <- do not remove
	SELECT [CustomerReviewId], [Score], [Comment], [Active], [CreatedDateTime], [CreatedByUser], [LastModifiedDateTime], [LastModifiedByUser], [DeletedDateTime], [DeletedByUser], [EffectiveDateFrom], [EffectiveDateTo]
	FROM   [dbo].[CustomerReview]
	WHERE  [CustomerReviewId] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
