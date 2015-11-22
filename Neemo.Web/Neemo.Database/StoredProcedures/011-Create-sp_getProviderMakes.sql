
IF OBJECT_ID('[dbo].[sp_getProviderMakes]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[sp_getProviderMakes] 
END 
GO
CREATE  Procedure [dbo].[sp_getProviderMakes]
	@ServiceTypeID  int
	,@ServiceType  nvarchar(100)
	,@ProviderID  int
AS
select PST.ServiceTypeID,ST.ServiceType ,PST.Active from ProviderServiceType PST 
inner join  ServiceType ST on PST.ServiceTypeID = ST.ServiceTypeID
where (PST.ProviderID = @ProviderID  OR @ProviderID  =0)
AND (PST.ServiceTypeID= @ServiceTypeID  OR @ServiceTypeID  =0)
AND (ST.ServiceType =@ServiceType  OR @ServiceType='')
AND PST.Active = 1
GO

GO
