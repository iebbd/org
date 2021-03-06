Declare @ID [nvarchar](8) 
Declare @NAME [nvarchar](50) 
Declare @ADDR1 [nvarchar](50) 
Declare @ADDR2 [nvarchar](50) 
Declare @ADDR3 [nvarchar](45) 
Declare @AREA_CODE [nvarchar](50) 
Declare @TEL [nvarchar](40) 
Declare @AINS [nvarchar](20) 
Declare @YEARPASS [float] 
Declare @AINS1 [nvarchar](30) 
Declare @AINS2 [nvarchar](30) 
Declare @CENTRE [nvarchar](14) 
Declare @DUES [nvarchar](30) 
Declare @DIP [nvarchar](30) 
Declare @CODE [nvarchar](40) 
Declare @DEPT [nvarchar](50) 
Declare @DATE_OF_BIRTH [nvarchar](50) 
Declare @MALE_FEMALE [nvarchar](40) 
Declare @Field1 [nvarchar](50) 
Declare @EMAIL [nvarchar](50) 
Declare @RELIGION [nvarchar](50) 
Declare @FOREIGN [nvarchar](50) 
Declare @Field2 [nvarchar](50)

DECLARE product_cursor CURSOR FOR 
    SELECT  [ID]
          ,[NAME]
          ,[ADDR1]
          ,[ADDR2]
          ,[ADDR3]
          ,[AREA CODE]
          ,[TEL]
          ,[AINS]
          ,[YEARPASS]
          ,[AINS1]
          ,[AINS2]
          ,[CENTRE]
          ,[DUES]
          ,[DIP]
          ,[CODE]
          ,[DEPT]
          ,[DATE OF BIRTH]
          ,[MALE/FEMALE]
          ,[Field1]
          ,[EMAIL]
          ,[RELIGION]
          ,[FOREIGN]
          ,[Field2]
      FROM [IEBDB].[dbo].[MEMBER]

    OPEN product_cursor
    FETCH NEXT FROM product_cursor 
		INTO
		@ID
          ,@NAME
          ,@ADDR1
          ,@ADDR2
          ,@ADDR3
          ,@AREA_CODE
          ,@TEL
          ,@AINS
          ,@YEARPASS
          ,@AINS1
          ,@AINS2
          ,@CENTRE
          ,@DUES
          ,@DIP
          ,@CODE
          ,@DEPT
          ,@DATE_OF_BIRTH
          ,@MALE_FEMALE
          ,@Field1
          ,@EMAIL
          ,@RELIGION
          ,@FOREIGN
          ,@Field2

    IF @@FETCH_STATUS <> 0 
        PRINT '         <<None>>'     

    WHILE @@FETCH_STATUS = 0
    BEGIN
		update [IEB].[dbo].[Mem_Member] 
                set MailingAddress1=@ADDR1
                   ,MailingAddress2=@ADDR2
                   ,MailingAddress3=@ADDR3
                   ,ExtraField1=@AREA_CODE
                   ,ExtraField2=@CODE
                   ,ExtraField3=@AINS
                   ,ExtraField4=@DEPT
                   ,ExtraField5=@RELIGION
                   ,PassingYear=@YEARPASS
                where MemberShipNo=@ID	
        
        FETCH NEXT FROM product_cursor 
        INTO
		@ID
          ,@NAME
          ,@ADDR1
          ,@ADDR2
          ,@ADDR3
          ,@AREA_CODE
          ,@TEL
          ,@AINS
          ,@YEARPASS
          ,@AINS1
          ,@AINS2
          ,@CENTRE
          ,@DUES
          ,@DIP
          ,@CODE
          ,@DEPT
          ,@DATE_OF_BIRTH
          ,@MALE_FEMALE
          ,@Field1
          ,@EMAIL
          ,@RELIGION
          ,@FOREIGN
          ,@Field2

        END

    CLOSE product_cursor
    DEALLOCATE product_cursor