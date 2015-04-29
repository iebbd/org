Declare @MemRegNo int

DECLARE product_cursor CURSOR FOR 
   Select distinct MemRegNo
  FROM [IEBDB].[dbo].[MembershipPicture]

    OPEN product_cursor
    FETCH NEXT FROM product_cursor 
		INTO
		@MemRegNo

    IF @@FETCH_STATUS <> 0 
        PRINT '         <<None>>'     

    WHILE @@FETCH_STATUS = 0
    BEGIN
		update  [IEBDB].[dbo].[MembershipPicture]
                set MembershipNo=(Select MemberShipNo from [IEB].[dbo].Mem_Member where ScrollNo=@MemRegNo)
                where MemRegNo=@MemRegNo
        
        FETCH NEXT FROM product_cursor 
        INTO
		@MemRegNo

        END

    CLOSE product_cursor
    DEALLOCATE product_cursor