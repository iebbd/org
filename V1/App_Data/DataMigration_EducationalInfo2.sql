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
    
           
         SELECT  Mem_Member.Mem_MemberID,3,[InstitutionName],0,EngFieldID,'',PassYear,0,'','',1,GETDATE(),1,GETDATE(),1
  FROM [IEBDB].[dbo].[MembershipEducationalInfo]
  inner join IEB.dbo.Mem_Member on Mem_Member.ScrollNo =[MembershipEducationalInfo].MemRegNo
 order by Mem_Member.Mem_MemberID


