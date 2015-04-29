INSERT INTO [IEB].[dbo].[Mem_EducationalInfo]
           ([Mem_MemberID]
           ,[Comn_GegreeID]
           ,[InstituteName]
           ,[Comn_UniversityID]
           ,[Comn_DepartmentID]
           ,[DegreeTitle]
           ,[YearOfPassing]
           ,[Comn_ResultTypeID]
           ,[Result]
           ,[Details]
           ,[AddedBy]
           ,[AddedDate]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[Comn_RowStatusID])
    
           
         SELECT  0,3,[InstitutionName],0,EngFieldID,'',PassYear,0,'','',1,GETDATE(),1,GETDATE(),1
  FROM [IEBDB].[dbo].[MembershipEducationalInfo]
  left outer join IEB.dbo.Mem_Member on Mem_Member.ScrollNo =[MembershipEducationalInfo].MemRegNo
 Where [MembershipEducationalInfo].MemRegNo 
 not in (select Distinct MemRegNo from [IEBDB].[dbo].MembershipRegistrationInfo)
 order by Mem_Member.Mem_MemberID


