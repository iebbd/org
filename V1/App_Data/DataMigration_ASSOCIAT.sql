Declare @ID [nvarchar](8)
Declare @NAME [nvarchar](50)
Declare @ADDR1 [nvarchar](50)
Declare @ADDR2 [nvarchar](50)
Declare @ADDR3 [nvarchar](50)
Declare @TEL [nvarchar](30)
Declare @AINS [nvarchar](20)
Declare @YEARPASS [float]
Declare @AINS1 [nvarchar](30)
Declare @AINS2 [nvarchar](30)
Declare @CENTRE [nvarchar](12)
Declare @DATE [datetime]
Declare @DUES [nvarchar](30)
Declare @DIPNO [nvarchar](30)
Declare @DATE_OF_BIRTH [nvarchar](50)

DECLARE product_cursor CURSOR FOR 
    SELECT  [ID]
      ,[NAME]
      ,[ADDR1]
      ,[ADDR2]
      ,[ADDR3]
      ,[TEL]
      ,[AINS]
      ,[YEARPASS]
      ,[AINS1]
      ,[AINS2]
      ,[CENTRE]
      ,[DATE]
      ,[DUES]
      ,[DIPNO]
      ,[DATE OF BIRTH]
  FROM [IEBDB].[dbo].[ASSOCIAT]

    OPEN product_cursor
    FETCH NEXT FROM product_cursor 
		INTO
		@ID
      ,@NAME
      ,@ADDR1
      ,@ADDR2
      ,@ADDR3
      ,@TEL
      ,@AINS
      ,@YEARPASS
      ,@AINS1
      ,@AINS2
      ,@CENTRE
      ,@DATE
      ,@DUES
      ,@DIPNO
      ,@DATE_OF_BIRTH

    IF @@FETCH_STATUS <> 0 
        PRINT '         <<None>>'     

    WHILE @@FETCH_STATUS = 0
    BEGIN
		update [IEB].[dbo].[Mem_Member] 
                set MailingAddress1=@ADDR1
                   ,MailingAddress2=@ADDR2
                   ,MailingAddress3=@ADDR3
                   ,ExtraField3=@AINS
                   ,PassingYear=@YEARPASS
                where MemberShipNo=@ID	
        
        FETCH NEXT FROM product_cursor 
        INTO
		@ID
      ,@NAME
      ,@ADDR1
      ,@ADDR2
      ,@ADDR3
      ,@TEL
      ,@AINS
      ,@YEARPASS
      ,@AINS1
      ,@AINS2
      ,@CENTRE
      ,@DATE
      ,@DUES
      ,@DIPNO
      ,@DATE_OF_BIRTH

        END

    CLOSE product_cursor
    DEALLOCATE product_cursor