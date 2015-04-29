Declare @Mem_FeesYearID int
Declare @Mem_FeesYearName nvarchar(50)

DECLARE product_cursor CURSOR FOR 
   SELECT [Mem_FeesYearID]
      ,Mem_FeesYearName
  FROM [IEB].[dbo].[Mem_FeesYear]

    OPEN product_cursor
    FETCH NEXT FROM product_cursor 
		INTO
		@Mem_FeesYearID,@Mem_FeesYearName

    IF @@FETCH_STATUS <> 0 
        PRINT '         <<None>>'     

    WHILE @@FETCH_STATUS = 0
    BEGIN
		update  Mem_Fees
                set Mem_FeesYearID=@Mem_FeesYearID
                where PaidFor=@Mem_FeesYearName
        
        FETCH NEXT FROM product_cursor 
        INTO
		@Mem_FeesYearID,@Mem_FeesYearName

        END

    CLOSE product_cursor
    DEALLOCATE product_cursor