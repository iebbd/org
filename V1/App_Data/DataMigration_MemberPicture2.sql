Declare @MemRegNo int
Declare @MembershipNo nvarchar(50)
declare @count int
Set @count =0
DECLARE product_cursor CURSOR FOR 
   Select distinct MemRegNo,MembershipNo
  FROM [IEBDB].[dbo].[MembershipPicture]
  order by MembershipNo

    OPEN product_cursor
    FETCH NEXT FROM product_cursor 
		INTO
		@MemRegNo,@MembershipNo

    IF @@FETCH_STATUS <> 0 
        PRINT '         <<None>>'     

    WHILE @@FETCH_STATUS = 0
    BEGIN
		Set @count+=1
		update  [IEBDB].[dbo].[MembershipPicture]
                set RowNo=@count
                where MemRegNo=@MemRegNo
        
        FETCH NEXT FROM product_cursor 
        INTO
		@MemRegNo,@MembershipNo

        END

    CLOSE product_cursor
    DEALLOCATE product_cursor