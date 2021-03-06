Declare @ID [nvarchar](8)
Declare @NAME [nvarchar](50)
Declare @ADDR1 [nvarchar](50)
Declare @ADDR2 [nvarchar](40)
Declare @ADDR3 [nvarchar](42)
Declare @AREA_CODE [nvarchar](25)
Declare @TEL [nvarchar](30)
Declare @AINS [nvarchar](20)
Declare @YEARPASS [float]
Declare @AINS1 [nvarchar](30)
Declare @AINS2 [nvarchar](30)
Declare @CENTRE [nvarchar](12)
Declare @DATE [nvarchar](8)
Declare @DUES [nvarchar](30)
Declare @DIPNO [nvarchar](30)
Declare @CODE [nvarchar](30)
Declare @DEPT [nvarchar](20)
Declare @D_Birth [nvarchar](50)
Declare @MALE_FEMALE [nvarchar](40)
Declare @E_MAIL [nvarchar](50)
Declare @RELIGION [nvarchar](50)
Declare @FAX [nvarchar](40)
Declare @FOREIGN [nvarchar](50)

DECLARE product_cursor CURSOR FOR 
   Select [ID]
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
      ,[DATE]
      ,[DUES]
      ,[DIPNO]
      ,[CODE]
      ,[DEPT]
      ,[D_Birth]
      ,[MALE/FEMALE]
      ,[E-MAIL]
      ,[RELIGION]
      ,[FAX]
      ,[FOREIGN]
  FROM [IEBDB].[dbo].[FEL]

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
      ,@DATE
      ,@DUES
      ,@DIPNO
      ,@CODE
      ,@DEPT
      ,@D_Birth
      ,@MALE_FEMALE
      ,@E_MAIL
      ,@RELIGION
      ,@FAX
      ,@FOREIGN

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
      ,@DATE
      ,@DUES
      ,@DIPNO
      ,@CODE
      ,@DEPT
      ,@D_Birth
      ,@MALE_FEMALE
      ,@E_MAIL
      ,@RELIGION
      ,@FAX
      ,@FOREIGN

        END

    CLOSE product_cursor
    DEALLOCATE product_cursor