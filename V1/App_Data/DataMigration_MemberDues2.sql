INSERT INTO [IEB].[dbo].[Mem_Fees]
           ([Mem_MemberID]
           ,[Amount]
           ,[DatePaid]
           ,[PaidFor]
           ,[ExtraField]
           ,[AddedDate]
           ,[AddedBy]
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[Comn_RowStatusID]
           ,[RefferenceNo]
           ,[Comn_PaymentByID])
    
           SELECT Mem_Member.Mem_MemberID,[MembershipDues].Amount
      ,[MembershipDues].PaymentDate
      ,FiscaleYear.FiscaleYearName
      ,'Old DB',GETDATE(),1,1,GETDATE(),1,'',1
  FROM [IEBDB].[dbo].[MembershipDues]
  left outer join [IEBDB].[dbo].FiscaleYear on FiscaleYear.FiscaleYearId= MembershipDues.PaidUpto
  left outer join [IEB].[dbo].Mem_Member on Mem_Member.ScrollNo= MembershipDues.MemRegNo
   order by [PaidUpto]

