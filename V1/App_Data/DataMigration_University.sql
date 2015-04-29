Declare @Comn_UniversityName nvarchar(256)
Declare @Comn_UniversityID int

DECLARE product_cursor CURSOR FOR 
   Select Comn_UniversityName,Comn_UniversityID
  FROM [IEB].[dbo].Comn_University

    OPEN product_cursor
    FETCH NEXT FROM product_cursor 
		INTO
		@Comn_UniversityName,@Comn_UniversityID

    IF @@FETCH_STATUS <> 0 
        PRINT '         <<None>>'     

    WHILE @@FETCH_STATUS = 0
    BEGIN
		update  [IEB].[dbo].Comn_University
                set Details=(Select top 1 Details from [IEB].[dbo].Comn_UniversityTmp where Comn_UniversityName=@Comn_UniversityName)
                where Comn_UniversityID=@Comn_UniversityID
         update IEB.dbo.Mem_EducationalInfo 
         set Comn_UniversityID= @Comn_UniversityID
         where InstituteName=@Comn_UniversityName
         
         update  Mem_Member
         set Comn_UniversityID = @Comn_UniversityID
         where Mem_Member.Mem_MemberID in (select Mem_MemberID from Mem_EducationalInfo where InstituteName =@Comn_UniversityName)
			
        FETCH NEXT FROM product_cursor 
        INTO
		@Comn_UniversityName,@Comn_UniversityID

        END

    CLOSE product_cursor
    DEALLOCATE product_cursor