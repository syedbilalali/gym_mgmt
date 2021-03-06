USE [physiofit_db1]
GO
/****** Object:  Table [dbo].[SellsOrder]    Script Date: 10/16/2020 13:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SellsOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Invoice_number] [nvarchar](max) NULL,
	[Member_name] [nvarchar](50) NULL,
	[Subtotal] [decimal](18, 0) NULL,
	[Sales_Tax] [decimal](18, 0) NULL,
	[Total_Amount] [decimal](18, 0) NULL,
	[Paid_Status] [nvarchar](max) NULL,
	[Total_Pay] [decimal](18, 0) NULL,
	[Discount_price] [decimal](18, 0) NULL,
	[Remain_price] [decimal](18, 0) NULL,
	[CreatedAt] [smalldatetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesTax]    Script Date: 10/16/2020 13:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesTax](
	[Id] [int] NOT NULL,
	[SalesTaxName] [nvarchar](60) NULL,
	[SalesTaxValue] [nvarchar](60) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesOrderItems]    Script Date: 10/16/2020 13:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesOrderItems](
	[invoice_Id] [int] NOT NULL,
	[Invoice_number] [nvarchar](max) NOT NULL,
	[product_Id] [int] NOT NULL,
	[quantity] [decimal](18, 0) NOT NULL,
	[unit_price] [decimal](18, 0) NOT NULL,
	[discount_price] [decimal](18, 0) NOT NULL,
	[total_amount] [decimal](18, 0) NOT NULL,
	[createdAt] [smalldatetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleGroup]    Script Date: 10/16/2020 13:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleGroup](
	[GroupName] [nvarchar](max) NULL,
	[Access] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedAt] [smalldatetime] NOT NULL,
	[Id] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prospectus]    Script Date: 10/16/2020 13:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prospectus](
	[Id] [int] NOT NULL,
	[MemberID] [int] NOT NULL,
	[ContactMethod] [nvarchar](max) NULL,
	[FitnessGoal] [nvarchar](max) NULL,
	[PreviousGym] [nvarchar](max) NULL,
	[LeadStrength] [nvarchar](max) NULL,
	[Created] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductType]    Script Date: 10/16/2020 13:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductType](
	[Name] [nvarchar](max) NULL,
	[Tax_Rate_Name] [nvarchar](max) NULL,
	[Sold_Club] [nvarchar](max) NULL,
	[CreatedAt] [smalldatetime] NOT NULL,
	[Id] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 10/16/2020 13:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Name] [nvarchar](max) NOT NULL,
	[Type_Id] [int] NULL,
	[Supplier_Id] [int] NULL,
	[POS_group_Id] [int] NULL,
	[Barcode] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[ImageURL] [nvarchar](max) NULL,
	[CreatedAt] [smalldatetime] NOT NULL,
	[Id] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Module]    Script Date: 10/16/2020 13:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Module](
	[ModuleId] [uniqueidentifier] NOT NULL,
	[ModuleName] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](10) NOT NULL,
	[CreatedDate] [smalldatetime] NOT NULL,
	[UpdatedDate] [smalldatetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Membership]    Script Date: 10/16/2020 13:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Membership](
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[ValidDays] [int] NULL,
	[Amount] [decimal](18, 0) NOT NULL,
	[StartDate] [smalldatetime] NULL,
	[EndDate] [smalldatetime] NULL,
	[PreEndDate] [smalldatetime] NULL,
	[Capacity] [int] NULL,
	[CreatedAt] [smalldatetime] NULL,
	[UpdatedAt] [smalldatetime] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 10/16/2020 13:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[DOB] [nvarchar](max) NULL,
	[Gender] [nvarchar](50) NULL,
	[Note] [nvarchar](max) NULL,
	[MemberType] [nvarchar](50) NULL,
	[ImgURL] [nvarchar](max) NULL,
	[QRURL] [nvarchar](max) NULL,
	[Id] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Master_Login]    Script Date: 10/16/2020 13:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Master_Login](
	[MasterID] [int] NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[ImageURL] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmergencyContact]    Script Date: 10/16/2020 13:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmergencyContact](
	[Id] [int] NOT NULL,
	[MemberID] [int] NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Relationship] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Cell] [nvarchar](20) NULL,
	[Home] [nvarchar](20) NULL,
	[Work] [nvarchar](20) NULL,
	[MedicalInfo] [nvarchar](max) NULL,
	[Age] [nvarchar](10) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 10/16/2020 13:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[MemberID] [int] NULL,
	[Email] [nvarchar](max) NULL,
	[Cell] [nvarchar](50) NULL,
	[Home] [nvarchar](50) NULL,
	[Work] [nvarchar](50) NULL,
	[Address] [nvarchar](max) NULL,
	[Suburb] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[ZipCode] [nvarchar](10) NULL,
	[Subscribed] [nvarchar](20) NULL,
	[Id] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassSubscriptions]    Script Date: 10/16/2020 13:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassSubscriptions](
	[ClassID] [int] NOT NULL,
	[MemberID] [int] NOT NULL,
	[CreatedAt] [smalldatetime] NOT NULL,
	[Id] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 10/16/2020 13:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[ClassName] [nvarchar](max) NOT NULL,
	[From] [smalldatetime] NOT NULL,
	[To] [smalldatetime] NOT NULL,
	[Repeats] [nvarchar](50) NULL,
	[RepeatsEnd] [smalldatetime] NULL,
	[Resource] [nvarchar](max) NULL,
	[StaffID] [int] NULL,
	[Note] [nvarchar](max) NULL,
	[CreatedAt] [smalldatetime] NOT NULL,
	[Id] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 10/16/2020 13:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[catID] [int] NOT NULL,
	[catName] [nvarchar](max) NULL,
	[subID] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdditionalDetails]    Script Date: 10/16/2020 13:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdditionalDetails](
	[Id] [int] NOT NULL,
	[MemberID] [int] NULL,
	[Club] [int] NULL,
	[TrainerID] [int] NULL,
	[JoiningDate] [nvarchar](50) NULL,
	[SalesRepID] [int] NULL,
	[SourcePromotionID] [int] NULL,
	[ReferredMemberBy] [int] NULL,
	[Occupation] [nvarchar](max) NULL,
	[Organisation] [nvarchar](max) NULL,
	[InvolvementType] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Visitors]    Script Date: 10/16/2020 13:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visitors](
	[VisitorID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Username] [nvarchar](max) NULL,
	[UserType] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
	[Clock] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[CreatedAt] [nchar](10) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trainings]    Script Date: 10/16/2020 13:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainings](
	[TrainingID] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[StaffID] [int] NULL,
	[StartDate] [smalldatetime] NULL,
	[EndDate] [smalldatetime] NULL,
	[StartTime] [smalldatetime] NULL,
	[EndTime] [smalldatetime] NULL,
	[CreatedAt] [smalldatetime] NULL,
	[VailidDays] [decimal](18, 0) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subscriptions]    Script Date: 10/16/2020 13:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscriptions](
	[MembershipID] [int] NOT NULL,
	[MemberID] [int] NOT NULL,
	[Total_Amount] [decimal](18, 0) NULL,
	[Paid_Amount] [decimal](18, 0) NULL,
	[Due_Amount] [decimal](18, 0) NULL,
	[Paid_Status] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[CreatedAt] [smalldatetime] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubscriptionInvoice]    Script Date: 10/16/2020 13:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubscriptionInvoice](
	[InvoiceID] [int] IDENTITY(1,1) NOT NULL,
	[SubscriptionID] [int] NOT NULL,
	[Total_Amount] [decimal](18, 0) NOT NULL,
	[Paid_Amount] [decimal](18, 0) NULL,
	[Due_Amount] [decimal](18, 0) NULL,
	[Paid_Status] [nvarchar](50) NULL,
	[CreatedAt] [smalldatetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stocks]    Script Date: 10/16/2020 13:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stocks](
	[product_Id] [int] IDENTITY(1,1) NOT NULL,
	[get_price] [decimal](18, 0) NULL,
	[sell_price] [decimal](18, 0) NULL,
	[stock_in] [decimal](18, 0) NULL,
	[stock_out] [decimal](18, 0) NULL,
	[current_stock] [decimal](18, 0) NOT NULL,
	[CreatedAt] [smalldatetime] NOT NULL,
	[UpdatedAt] [smalldatetime] NULL,
	[Id] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StaffRole]    Script Date: 10/16/2020 13:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffRole](
	[StaffId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[Status] [nvarchar](10) NOT NULL,
	[CreatedDate] [smalldatetime] NOT NULL,
	[UpdatedDate] [smalldatetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 10/16/2020 13:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Gender] [nvarchar](10) NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Designation] [nvarchar](50) NULL,
	[QrURL] [nvarchar](max) NULL,
	[ImgURL] [nvarchar](max) NULL,
	[StaffID] [int] NOT NULL,
	[permisions] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[spVisitorDetails]    Script Date: 10/16/2020 13:52:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Syed Bilal ALi>
-- Create date: <5-3-2020>
-- Description:	<Finding the Details of the Vistior when visitir clock in and clock out and total time spends>
-- =============================================
CREATE PROCEDURE [dbo].[spVisitorDetails]
	-- Add the parameters for the stored procedure here
	
    @FILTER VARCHAR(10) = null,
    @FROM_DATE NVARCHAR(MAX)=null,
    @TO_DATE NVARCHAR(MAX)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    if(@FILTER = 'OFF')
    BEGIN
		SELECT DISTINCT(D.UserID),v.Username,v.Date, v.UserType ,D.* 
		FROM Visitors v 
			INNER JOIN (SELECT DISTINCT(v.UserID),
					MIN(Clock) OVER (PARTITION BY v.UserID) as ClockIn,
					MAX(Clock) OVER (PARTITION BY v.UserID) as  ClockOut,
					(SELECT datediff(minute, min(Clock),max(Clock)) FROM Visitors WHERE UserID=v.UserID) as  elapsed_min,
					(SELECT datediff(SECOND, min(Clock),max(Clock)) FROM Visitors WHERE UserID=v.UserID) as  elapsed_sec,
					(SELECT datediff(HOUR, min(Clock),max(Clock)) FROM Visitors WHERE UserID=v.UserID) as  elapsed_hour
		FROM Visitors v) AS D ON v.UserID = D.UserID
    END
    ELSE if(@FILTER ='ON')
    BEGIN
		SELECT DISTINCT(D.UserID),v.Username,v.Date, v.UserType ,D.* 
		FROM Visitors v 
			INNER JOIN (SELECT DISTINCT(v.UserID),
					MIN(Clock) OVER (PARTITION BY v.UserID) as ClockIn,
					MAX(Clock) OVER (PARTITION BY v.UserID) as  ClockOut,
					(SELECT datediff(minute, min(Clock),max(Clock)) FROM Visitors WHERE UserID=v.UserID) as  elapsed_min,
					(SELECT datediff(SECOND, min(Clock),max(Clock)) FROM Visitors WHERE UserID=v.UserID) as  elapsed_sec,
					(SELECT datediff(HOUR, min(Clock),max(Clock)) FROM Visitors WHERE UserID=v.UserID) as  elapsed_hour
		FROM Visitors v) AS D ON v.UserID = D.UserID
		WHERE v.Date BETWEEN CONVERT(nvarchar ,  @FROM_DATE  , 101)  AND CONVERT(date , @TO_DATE, 101)
    END
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateStocksIn]    Script Date: 10/16/2020 13:52:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateStocksIn] 
	-- Add the parameters for the stored procedure here
	@Id int ,
	@get_price decimal(18 , 0),
	@sell_price decimal(18,0), 
	@stock_in decimal(18 , 0),
	@current_stock decimal(18, 0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
    UPDATE Stocks SET stock_in=@stock_in, current_stock=@current_stock ,get_price=@get_price,sell_price=@sell_price,UpdatedAt=CURRENT_TIMESTAMP  where Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateStocks]    Script Date: 10/16/2020 13:52:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateStocks] 
	-- Add the parameters for the stored procedure here
	@Id int , 
	@ProductID  int,  
	@stock_in decimal(18 , 0),
	@stock_out decimal(18, 0), 
	@current_stock decimal(18, 0), 
	@UpdatedAt datetime  
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
    UPDATE Stocks SET product_Id=@ProductID , stock_in=@stock_in , stock_out=@stock_out , current_stock=@current_stock , UpdatedAt=@UpdatedAt  where Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateProductType]    Script Date: 10/16/2020 13:52:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateProductType] 
	-- Add the parameters for the stored procedure here
	 @Id int ,
	 @Name nvarchar(MAX), 
	 @Tax_Rate_Name nvarchar(MAX) , 
	 @Sold_Club nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	UPDATE ProductType SET Name=@Name , Tax_Rate_Name=@Tax_Rate_Name , Sold_Club=@Sold_Club WHERE Id=@Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateProducts]    Script Date: 10/16/2020 13:52:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateProducts] 
	-- Add the parameters for the stored procedure here
	@Id int , 
	@Name nvarchar(MAX) , 
	@Type_Id int , @Supplier_Id int ,@POS_Group_Id  int , @Barcode nvarchar(MAX) , 
	 @Description nvarchar(MAX),@ImageURL nvarchar(MAX) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    UPDATE Products SET Name=@Name , Type_Id=@Type_Id , Supplier_Id=@Supplier_Id  , POS_Group_Id=@POS_Group_Id ,Barcode=@Barcode ,Description=@Description , ImageURL=@ImageURL  WHERE @Id=Id ;
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateClasses]    Script Date: 10/16/2020 13:52:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateClasses]  
	-- Add the parameters for the stored procedure here
	@ClassName nvarchar(MAX), 
    @From datetime, 
    @To datetime ,
    @Repeats nvarchar(50),
    @RepeatsEnd datetime ,
    @Resource nvarchar(MAX),
    @StaffID int , 
    @Note nvarchar(MAX),
    @ID int   
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
    UPDATE Classes SET ClassName=@ClassName , [From]=@From , [To]=@To , Repeats=@Repeats , RepeatsEnd=@RepeatsEnd ,Resource=@Resource  ,StaffID=@StaffID ,Note=@Note WHERE Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[spSubscriptions]    Script Date: 10/16/2020 13:52:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spSubscriptions] 
	-- Add the parameters for the stored procedure here
	@Action nvarchar(50), 
	@by_ID int = null 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if(@Action='ALL_DATA')
	BEGIN
		--SELECT subs.Id , mem.Name as MembershipName ,mem.EndDate as ExpirayDate , memr.FirstName as MemberName ,mem.Amount as Ammount FROM dbo.Subscriptions subs INNER JOIN physiofit_admin.Membership mem ON mem.Id = subs.MemberID INNER JOIN physiofit_admin.Member memr ON memr.Id = subs.MembershipID
		--SELECT subs.Id , mem.Name as MembershipName ,mem.EndDate as ExpirayDate , memr.FirstName as MemberName ,mem.Amount as Ammount , subs.MembershipID  , subs.MemberID FROM dbo.Subscriptions subs INNER JOIN dbo.Membership mem ON mem.Id = subs.MembershipID INNER JOIN dbo.Member memr ON memr.Id = subs.MemberID
		SELECT subs.Id , mem.Name as MembershipName ,mem.EndDate as ExpirayDate , memr.FirstName as MemberName ,mem.Amount as Ammount , subs.MembershipID , subs.MemberID , subs.Paid_Amount ,subs.Paid_Status , subs.Due_Amount FROM dbo.Subscriptions subs INNER JOIN dbo.Membership mem ON mem.Id = subs.MembershipID INNER JOIN dbo.Member memr ON memr.Id = subs.MemberID 	 			
	END
	if(@Action = 'BY_ID')
	BEGIN
	  SELECT subs.Id , mem.Name as MembershipName ,mem.EndDate as ExpirayDate , memr.FirstName as MemberName ,mem.Amount as Ammount , subs.MembershipID , subs.MemberID , subs.Paid_Amount ,subs.Paid_Status , subs.Due_Amount  FROM dbo.Subscriptions subs INNER JOIN dbo.Membership mem ON mem.Id = subs.MembershipID INNER JOIN dbo.Member memr ON memr.Id = subs.MemberID
	  Where subs.MemberID = @by_ID;
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spMembershipOpt]    Script Date: 10/16/2020 13:52:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spMembershipOpt] 
	-- Add the parameters for the stored procedure here
	@Action varchar(50) = NULL,
	@Id int = NULL , 
	@Name nvarchar(50) = NULL , 
	@Description nvarchar(MAX) = NULL ,
	@ValidDays int  = NULL, 
	@Amount decimal(18 , 0) = NULL , 
	@StartDate datetime  = NULL, 
	@EndDate datetime = NULL , 
	@PreEndDate datetime  = NULL , 
	@Capacity int = NULL 
AS
BEGIN
    -- Insert statements for procedure here
	if(@Action = 'INSERT')
		BEGIN
		 INSERT INTO Membership(Name , Description , ValidDays , Amount , StartDate , EndDate , PreEndDate , Capacity , CreatedAt) VALUES(@Name ,@Description , @ValidDays , @Amount, @StartDate , @EndDate , @PreEndDate , @Capacity , CURRENT_TIMESTAMP);
		END
	if(@Action = 'UPDATE')
		BEGIN
		 UPDATE Membership SET Name=@Name , Description=@Description , ValidDays=@ValidDays , Amount=@Amount , StartDate=@StartDate , EndDate=@EndDate , PreEndDate=@PreEndDate , Capacity=@Capacity, UpdatedAt=CURRENT_TIMESTAMP WHERE Id=@Id;
		END
	if(@Action='DELETE')
		BEGIN
			DELETE FROM Membership WHERE Id=@Id;
		END
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertStocks]    Script Date: 10/16/2020 13:52:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spInsertStocks] 
	-- Add the parameters for the stored procedure here
	@ProductID  int,
	@get_price decimal(18, 0), 
	@sell_price decimal(18 , 0),  
	@stock_in decimal(18 , 0),
	@stock_out decimal(18, 0), 
	@current_stock decimal(18, 0) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
    INSERT INTO Stocks(product_Id  ,get_price,sell_price, stock_in , stock_out , current_stock , CreatedAt) VALUES(@ProductID ,@get_price,@sell_price, @stock_in , @stock_out , @current_stock , CURRENT_TIMESTAMP);
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertSellOrderItems]    Script Date: 10/16/2020 13:52:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spInsertSellOrderItems]  
	-- Add the parameters for the stored procedure here
	@invoice_id int  , 
	@Invoice_number nvarchar(MAX), 
	@product_id int  , 
	@quantity decimal(18 ,0) , 
	@unit_price decimal(18 ,0) , 
	@discount_price decimal(18, 0), 
	@total_ammount decimal(18 ,0)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SELECT * from Stocks
	SET NOCOUNT ON;
    -- Insert statements for procedure here
    INSERT INTO SalesOrderItems(invoice_Id ,Invoice_number  , product_Id , quantity , unit_price , discount_price ,total_amount  , createdAt) VALUES(@invoice_Id,@Invoice_number , @product_Id , @quantity , @unit_price , @discount_price ,@total_ammount , CURRENT_TIMESTAMP);
    UPDATE Stocks SET current_stock=current_stock - @quantity, stock_out=stock_out + @quantity WHERE product_Id=@product_id; 
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertSellOrder]    Script Date: 10/16/2020 13:52:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spInsertSellOrder]
	-- Add the parameters for the stored procedure here
	@Invoice_number int , 
	@Member_name nvarchar(50),
	@Subtotal decimal(18 , 0), 
	@Sales_Tax decimal(18, 0), 
	@Total_Amount decimal(18 ,0), 
	@Paid_Status nvarchar(MAX),
	@Total_Pay decimal(18, 0), 
	@Discount_price decimal(18 , 0), 
	@Remain_price decimal(18 , 0)  
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
    INSERT INTO dbo.SellsOrder(Invoice_number , Member_name , Subtotal , Sales_Tax , Total_Amount , Paid_Status , Total_Pay , Discount_price , Remain_price , CreatedAt) VALUES(@Invoice_number , @Member_name , @Subtotal ,@Sales_Tax ,  @Total_Amount , @Paid_Status , @Total_Pay , @Discount_price , @Remain_price ,CURRENT_TIMESTAMP);
	
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertRoleGroup]    Script Date: 10/16/2020 13:52:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spInsertRoleGroup] 
	-- Add the parameters for the stored procedure here
    @GroupName nvarchar(MAX) ,
    @Access nvarchar(MAX), 
    @Description nvarchar(MAX) =''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		INSERT INTO RoleGroup(GroupName , Access , Description, CreatedAt ) VALUES (@GroupName , @Access , @Description , CURRENT_TIMESTAMP);
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertProductType]    Script Date: 10/16/2020 13:52:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spInsertProductType]
	-- Add the parameters for the stored procedure here
	@Name nvarchar(MAX), 
	@Tax_Rate_Name nvarchar(MAX) , 
	@SoldClub nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
    INSERT INTO dbo.ProductType(Name, Tax_Rate_Name , Sold_Club , CreatedAt ) VALUES(@Name , @Tax_Rate_Name , @SoldClub , CURRENT_TIMESTAMP);
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertProducts]    Script Date: 10/16/2020 13:52:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spInsertProducts]
	-- Add the parameters for the stored procedure here
	@Name nvarchar(MAX) , 
	@Type_Id int , 
	@Supplier_Id int  , 
	@POS_group_Id int , 
	@Barcode nvarchar(MAX),
	@Description nvarchar(MAX) , 
	@ImageURL nvarchar(MAX)    
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Products(Name , Type_Id , Supplier_Id , POS_group_Id , Barcode , Description  , ImageURL , CreatedAt) VALUES(@Name , @Type_Id , @Supplier_Id  , @POS_group_Id , @Barcode , @Description , @ImageURL ,CURRENT_TIMESTAMP);
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertClasses]    Script Date: 10/16/2020 13:52:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spInsertClasses] 
	-- Add the parameters for the stored procedure here
    @ClassName nvarchar(MAX), 
    @From datetime, 
    @To datetime ,
    @Repeats nvarchar(50),
    @RepeatsEnd datetime ,
    @Resource nvarchar(MAX),
    @StaffID int , 
    @Note nvarchar(MAX)    	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON
    -- Insert statements for procedure here
	INSERT INTO Classes(ClassName , [From] , [To] , Repeats , RepeatsEnd , StaffID ,Note , CreatedAt) VALUES(@ClassName , @From , @To , @Repeats , @RepeatsEnd , @StaffID , @Note , CURRENT_TIMESTAMP);
END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteStocks]    Script Date: 10/16/2020 13:52:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteStocks] 
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
    DELETE FROM Stocks Where Id=@Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteProductType]    Script Date: 10/16/2020 13:52:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteProductType]  
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	DELETE FROM ProductType WHERE Id=@Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteProducts]    Script Date: 10/16/2020 13:52:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteProducts]  
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	DELETE FROM Products WHERE Id=@Id;
END
GO
