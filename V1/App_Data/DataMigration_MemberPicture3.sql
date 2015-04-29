Declare @MemRegNo int

DECLARE product_cursor CURSOR FOR 
   Select MemRegNo
  FROM [IEBDB].[dbo].[MembershipPicture]

    OPEN product_cursor
    FETCH NEXT FROM product_cursor 
		INTO
		@MemRegNo

    IF @@FETCH_STATUS <> 0 
        PRINT '         <<None>>'     

    WHILE @@FETCH_STATUS = 0
    BEGIN
		update  [IEB].[dbo].Mem_Member
                set PictureURL='Yes'
                where ScrollNo=@MemRegNo
        
        FETCH NEXT FROM product_cursor 
        INTO
		@MemRegNo

        END

    CLOSE product_cursor
    DEALLOCATE product_cursor