
/****** Object:  UserDefinedFunction [dbo].[FaturatPas12]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[FaturatPas12]
(
	@userid varchar(128)
	
)
RETURNS datetime
AS
BEGIN
declare @data as datetime	

	select @data= isnull(Date_Time,CAST(CAST(GETDATE() AS DATE) AS DATETIME))  from Reports where User_Id=@userid and CONVERT(date,Date_Time)=CONVERT(date,GETDATE()) and CONVERT(date,Date_Time)<>CONVERT(date,Start_Date_Time)

	if(@data is null) 
	set @data=CAST(CAST(GETDATE() AS DATE) AS DATETIME)

return @data
END


GO
/****** Object:  UserDefinedFunction [dbo].[GetXhiroTotaleAllUserHelper]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery1.sql|11|0|C:\Users\GERMAN\AppData\Local\Temp\~vsE591.sql
CREATE function [dbo].[GetXhiroTotaleAllUserHelper]()

returns
@T table
(
UserId varchar(128),
XhiroReale decimal,
XhiroKase decimal
)
as 

begin

declare @LastReportDate datetime

set @LastReportDate=(select isnull(min(o.OperationTime),GETDATE()) from Orders o where o.OrderStatus_Id=10 )
 


if(CONVERT(date,@LastReportDate)=CONVERT(date,getdate()))
begin


insert into @T    select bashkim.UserId as UserId,sum(bashkim.XhiroReale) as XhiroReale,sum(bashkim.xhirokase) as XhiroKase
from(
select User_Id as UserId ,
sum(base.xhiro) as XhiroReale,sum(base.xhirokase) as XhiroKase

from (
select ol.Id,ol.User_Id,
(select sum(Quantity*SalePrice)
from OrderDetails
where Order_Id=ol.Id and ol.OrderStatus_Id<>13

) as xhiro,

(select sum(Quantity*SalePrice)
from OrderDetails
where Order_Id=ol.Id and ol.FiscalCash=1  and ol.OrderStatus_Id<>13) as xhirokase





from 
Orders ol
 where convert(date,ol.OperationTime)=convert(date,getdate()) ) base
 group by base.User_Id


-- union  --union faturat e sotme edhe te mbyllura dhe faturat e tjera qe sjane bere sot

-- select User_Id as UserId ,
--sum(base.xhiro) as XhiroReale,sum(base.xhirokase) as XhiroKase

--from (
--select ol.Id,ol.User_Id,
--(select sum(Quantity*SalePrice)
--from OrderDetails
--where Order_Id=ol.Id and ol.OrderStatus_Id<>13 and ol.OrderStatus_Id<>15

--) as xhiro,

--(select sum(Quantity*SalePrice)
--from OrderDetails
--where Order_Id=ol.Id and ol.FiscalCash=1  and ol.OrderStatus_Id<>13 and ol.OrderStatus_Id<>15 ) as xhirokase





--from 
--Orders ol
-- where convert(date,ol.OperationTime)=convert(date,getdate()) ) base
-- group by base.User_Id



 ) bashkim

  group by UserId
end

else




--rasti kur e ka hapur dite me pare


begin


insert into @T select bashkim.UserId as UserId,sum(bashkim.XhiroReale) as XhiroReale,sum(bashkim.xhirokase) as XhiroKase
from(
select User_Id as UserId ,
sum(base.xhiro) as XhiroReale,sum(base.xhirokase) as XhiroKase

from (
select ol.Id,ol.User_Id,
(select sum(Quantity*SalePrice)
from OrderDetails
where Order_Id=ol.Id and ol.OrderStatus_Id<>13

) as xhiro,

(select sum(Quantity*SalePrice)
from OrderDetails
where Order_Id=ol.Id and ol.FiscalCash=1  and ol.OrderStatus_Id<>13) as xhirokase





from 
Orders ol
 where convert(date,ol.OperationTime)=convert(date,getdate()) ) base
 group by base.User_Id


 union  --union faturat e sotme edhe te mbyllura dhe faturat e tjera qe sjane bere sot

 select User_Id as UserId ,
sum(base.xhiro) as XhiroReale,sum(base.xhirokase) as XhiroKase

from (
select ol.Id,ol.User_Id,
(select sum(Quantity*SalePrice)
from OrderDetails
where Order_Id=ol.Id and ol.OrderStatus_Id<>13

) as xhiro,

(select sum(Quantity*SalePrice)
from OrderDetails
where Order_Id=ol.Id and ol.FiscalCash=1  and ol.OrderStatus_Id<>13 ) as xhirokase





from 
Orders ol
 where convert(date,ol.OperationTime)<convert(date,getdate()) and convert(date,ol.OperationTime)>=convert(date,@LastReportDate )and User_Id in(select distinct(User_Id) from orders u where u.OrderStatus_Id=10 )  ) base
 group by base.User_Id



 ) bashkim

  group by UserId
end

return;

end







GO
/****** Object:  UserDefinedFunction [dbo].[GetXhiroTotaleAllUserHelper2]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE function [dbo].[GetXhiroTotaleAllUserHelper2]()

returns
@T table
(
UserId varchar(128),
XhiroReale decimal,
XhiroKase decimal
)
as 

begin
declare @USERID varchar(128)
DECLARE MY_CURSOR CURSOR 
  LOCAL STATIC READ_ONLY FORWARD_ONLY
FOR 
SELECT  Id 
FROM AspNetUsers

declare @LastDateOpenOrder datetime




OPEN MY_CURSOR
FETCH NEXT FROM MY_CURSOR INTO @USERID
WHILE @@FETCH_STATUS = 0
BEGIN 
    --Do logic

set @LastDateOpenOrder=	(select isnull(min(o.OperationTime),GETDATE()) from Orders o where o.OrderStatus_Id in(9,10) and o.User_Id=@USERID )

--nuk kemi turne te pambyllura dje ose me para===========================================================================================
if(CONVERT(date,@LastDateOpenOrder)=CONVERT(date,getdate()))

begin

declare @datapas12 datetime
set @datapas12=dbo.FaturatPas12(@USERID)
insert into @T   select   User_Id as UserId ,
sum(base.xhiro) as XhiroReale,sum(base.xhirokase) as XhiroKase

from (
select ol.Id,ol.User_Id,
(select sum(Quantity*SalePrice)
from OrderDetails
where Order_Id=ol.Id and ol.OrderStatus_Id<>13

) as xhiro,

(select sum(Quantity*SalePrice)
from OrderDetails
where Order_Id=ol.Id and ol.FiscalCash=1  and ol.OrderStatus_Id<>13) as xhirokase





from 
Orders ol
 where convert(date,ol.OperationTime)=convert(date,getdate()) and ol.User_Id=@USERID and OperationTime>@datapas12 ) base

 group by User_Id
end


---- kemi turne te pambyllyra nda  dje ose me para ose kemi kaluar ne diten me pas por ka akoma fat te hapura===================================================================================


else

begin


 insert into @T select bashkim.UserId,SUM(bashkim.XhiroReale),SUM(bashkim.XhiroKase)
from 
  (select User_Id as UserId ,
sum(base.xhiro) as XhiroReale,sum(base.xhirokase) as XhiroKase

from (
select ol.Id,ol.User_Id,
(select sum(Quantity*SalePrice)
from OrderDetails
where Order_Id=ol.Id and ol.OrderStatus_Id<>13

) as xhiro,

(select sum(Quantity*SalePrice)
from OrderDetails
where Order_Id=ol.Id and ol.FiscalCash=1  and ol.OrderStatus_Id<>13) as xhirokase





from 
Orders ol
 where convert(date,ol.OperationTime)=convert(date,getdate()) and ol.User_Id=@USERID ) base

 group by User_Id

 union

 
 select User_Id as UserId ,
sum(base.xhiro) as XhiroReale,sum(base.xhirokase) as XhiroKase

from (
select ol.Id,ol.User_Id,
(select sum(Quantity*SalePrice)
from OrderDetails
where Order_Id=ol.Id and ol.OrderStatus_Id<>13

) as xhiro,

(select sum(Quantity*SalePrice)
from OrderDetails
where Order_Id=ol.Id and ol.FiscalCash=1  and ol.OrderStatus_Id<>13 ) as xhirokase





from 
Orders ol
 where convert(date,ol.OperationTime)<convert(date,getdate()) and ol.OperationTime>=@LastDateOpenOrder and ol.User_Id=@USERID  ) 
 base group by User_Id
 
 ) as bashkim
 group by bashkim.UserId



end







  
    FETCH NEXT FROM MY_CURSOR INTO @USERID
END
CLOSE MY_CURSOR
DEALLOCATE MY_CURSOR
return
end


GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Balance]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Balance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MenuItemId] [int] NULL,
	[Date] [datetime] NOT NULL,
	[QuantityState] [int] NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK__Balance__3214EC07D010C9C4] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClientOrder]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OperationTime] [datetime] NOT NULL,
	[OrderNotes] [varchar](500) NULL,
	[OrderStatus_Id] [int] NOT NULL,
	[Place_Id] [int] NOT NULL,
	[User_Id] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_ClientOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClientOrderDetails]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientOrderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NOT NULL,
	[SalePrice] [money] NOT NULL,
	[MenuItem_Id] [int] NOT NULL,
	[Order_Id] [int] NOT NULL,
 CONSTRAINT [PK_ClientOrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ComposedItems]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComposedItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NOT NULL,
	[ChildId] [int] NOT NULL,
	[quantity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Goods_Dispatch_Note]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Goods_Dispatch_Note](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderNumber] [varchar](50) NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[LastUpdateDate] [datetime] NULL,
	[OrderId] [int] NOT NULL,
 CONSTRAINT [PK__Goods_Di__3214EC0701AD2FA4] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Goods_Dispatch_Note_Details]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Goods_Dispatch_Note_Details](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GDNId] [int] NOT NULL,
	[MenuItemId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK__Goods_Di__3214EC0700E9222E] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Goods_Received_Note]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Goods_Received_Note](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Online_Id] [int] NOT NULL,
	[OrderNumber] [varchar](50) NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[LastUpdateDate] [datetime] NULL,
 CONSTRAINT [PK__Goods_Re__3214EC07AE51D03C] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Goods_Received_Note_Details]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Goods_Received_Note_Details](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GRNId] [int] NOT NULL,
	[MenuItemId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK__Goods_Re__3214EC076FDDAD4B] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LastBalance]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LastBalance](
	[MenuItemId] [int] NOT NULL,
	[LastQuantity] [int] NOT NULL,
	[LastPrice] [money] NOT NULL,
 CONSTRAINT [PK__LastBala__8943F7222BCB5ACE] PRIMARY KEY CLUSTERED 
(
	[MenuItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Logs]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MenuCategories]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OnlineId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Media_Id] [int] NOT NULL,
	[Place_Id] [int] NOT NULL,
	[CategoryImage] [varbinary](max) NULL,
	[IsItemActive] [bit] NOT NULL,
	[Printer] [varchar](50) NULL,
 CONSTRAINT [PK_dbo.MenuCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MenuItems]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OnlineId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Price] [money] NOT NULL,
	[Quantity] [int] NOT NULL,
	[MenuCategory_Id] [int] NOT NULL,
	[MinimumQuantityNotify] [int] NOT NULL,
	[Supplier_Id] [int] NULL,
	[IsItemActive] [bit] NOT NULL,
	[MenuItemTypeId] [int] NOT NULL,
	[UnitId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.MenuItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MenuItemType]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuItemType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NOT NULL,
	[SalePrice] [money] NOT NULL,
	[MenuItem_Id] [int] NOT NULL,
	[Data] [datetime] NOT NULL,
	[Order_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.OrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderForCancellation]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderForCancellation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderInfo]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderInfo](
	[Id] [int] NOT NULL,
	[HeadText] [varchar](500) NULL,
	[FootText] [varchar](500) NULL,
	[Image] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OperationTime] [datetime] NOT NULL,
	[OrderStatus_Id] [int] NOT NULL,
	[Table_Id] [int] NOT NULL,
	[User_Id] [nvarchar](128) NOT NULL,
	[FiscalCash] [bit] NOT NULL,
	[POS_ID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderSessions]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderSessions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Order_Id] [int] NOT NULL,
	[User_Id] [nvarchar](max) NULL,
	[Table_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.OrderSessions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderStatus]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.OrderStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Places]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Places](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[PlaceType_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Places] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PlaceTypes]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlaceTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.PlaceTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PriceList]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PriceList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MenuItemId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_PriceList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reports]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reports](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Orders_No] [int] NOT NULL,
	[Sold_Items_No] [int] NOT NULL,
	[Orders_Total_Sum] [money] NOT NULL,
	[Fiscal_Orders_Total_Sum] [money] NOT NULL,
	[Cash_Total] [money] NOT NULL,
	[Tips_Total_Sum] [money] NOT NULL,
	[Date_Time] [datetime] NOT NULL,
	[Start_Date_Time] [datetime] NOT NULL,
	[Place_Id] [int] NOT NULL,
	[User_Id] [nvarchar](128) NULL,
	[POS_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Reports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tables]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tables](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OnLineId] [int] NOT NULL,
	[Number] [int] NOT NULL,
	[Place_Id] [int] NOT NULL,
	[index] [int] NULL,
	[IsItemActive] [bit] NOT NULL,
	[POS_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Tables] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Unit]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserDatas]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDatas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[User_Id] [nvarchar](128) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Place_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.UserDatas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  UserDefinedFunction [dbo].[ArtikullHistory]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE function [dbo].[ArtikullHistory](@menuItemId int)

returns table

as return
(


select *
  from
(
select  'Dalje' as tipi,(-1*gd.Quantity) as Quantity ,gd.Price,g.OrderDate

from Goods_Dispatch_Note_Details gd join Goods_Dispatch_Note g

on g.Id=gd.GDNId
where gd.MenuItemId=@menuItemId
union all
select  'Hyrje' as tipi,gd.Quantity as Quantity,gd.Price,g.OrderDate

from Goods_Received_Note_Details gd join Goods_Received_Note  g

on g.Id=gd.GRNId
where gd.MenuItemId=@menuItemId
) temp

)





GO
/****** Object:  UserDefinedFunction [dbo].[getXhiroDitore]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE function [dbo].[getXhiroDitore](@userid nvarchar(128))

	returns table
	as return
	(
	select s.Name as Asortimenti,s.Price as Cmim,s.Nr as Nr ,s.Price*s.Nr as Total
from (select Name,Price+'' as Price ,(select sum(o.Quantity)
 from OrderDetails o join Orders ol on o.Order_Id = ol.Id
  where o.MenuItem_Id = m.Id and  convert(date, ol.OperationTime) = convert(date, GETDATE())
    and ol.User_Id=@userid) as Nr
    from MenuItems m) s where Nr >= 0

	)








GO
/****** Object:  UserDefinedFunction [dbo].[getXhiroDitoreTotalAllUser]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  function [dbo].[getXhiroDitoreTotalAllUser]()
returns table
as return
(


select * from dbo.GetXhiroTotaleAllUserHelper2()


)



GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1a5ed259-c156-4746-ba37-446176b7b72a', N'Waiter')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8130dff8-f8b4-42be-99d5-7a14ea205662', N'Client')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9522088b-8cd6-4e3d-8531-381919bd6598', N'Admin')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'cf99e260-64b7-41d9-b693-099caa9893b5', N'Manager')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b0efeae7-dbce-4e67-b31d-a4bd7d7dc2f1', N'cf99e260-64b7-41d9-b693-099caa9893b5')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [IsActive]) VALUES (N'b0efeae7-dbce-4e67-b31d-a4bd7d7dc2f1', N'ardit@ardit.al', 0, N'ALiF3iNOk+WioE56Z1iDIW3Non66qAhY8yVugB3JmvJDAAeIyp77fsCISKSZW7zIqg==', N'88720d71-4080-4883-a978-2121dd807339', N'+355693943536', 0, 0, NULL, 0, 0, N'ardit@ardit.al', 1)
GO
SET IDENTITY_INSERT [dbo].[Logs] ON 

GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (1, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (2, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (3, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (4, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (5, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (6, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (7, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (8, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (9, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (10, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (11, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (12, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (13, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (14, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (15, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (16, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (17, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (18, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (19, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (20, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (21, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (22, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (23, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (24, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (25, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (26, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (27, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (28, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (29, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (30, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (31, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (32, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (33, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (34, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (35, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (36, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (37, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (38, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (39, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (40, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (41, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (42, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (43, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (44, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (45, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (46, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (47, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (48, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (49, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (50, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (51, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (52, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (53, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (54, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (55, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (56, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (57, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (58, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (59, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (60, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (61, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (62, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (63, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (64, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (65, N'eshte tentuar te hapet llogaria juaj !')
GO
INSERT [dbo].[Logs] ([Id], [Text]) VALUES (66, N'eshte tentuar te hapet llogaria juaj !')
GO
SET IDENTITY_INSERT [dbo].[Logs] OFF
GO
SET IDENTITY_INSERT [dbo].[MenuItemType] ON 

GO
INSERT [dbo].[MenuItemType] ([Id], [Name]) VALUES (1, N'I Thjeshte')
GO
INSERT [dbo].[MenuItemType] ([Id], [Name]) VALUES (2, N'I Perbere')
GO
INSERT [dbo].[MenuItemType] ([Id], [Name]) VALUES (3, N'Perberes')
GO
SET IDENTITY_INSERT [dbo].[MenuItemType] OFF
GO
INSERT [dbo].[OrderInfo] ([Id], [HeadText], [FootText], [Image]) VALUES (1, N'Starbucks2', N'Starbucks', NULL)
GO
SET IDENTITY_INSERT [dbo].[OrderStatus] ON 

GO
INSERT [dbo].[OrderStatus] ([Id], [StatusName]) VALUES (8, N'Ordered')
GO
INSERT [dbo].[OrderStatus] ([Id], [StatusName]) VALUES (9, N'Pending')
GO
INSERT [dbo].[OrderStatus] ([Id], [StatusName]) VALUES (10, N'Closed')
GO
INSERT [dbo].[OrderStatus] ([Id], [StatusName]) VALUES (11, N'Printed Bill')
GO
INSERT [dbo].[OrderStatus] ([Id], [StatusName]) VALUES (12, N'Deleted')
GO
INSERT [dbo].[OrderStatus] ([Id], [StatusName]) VALUES (13, N'Cancelled')
GO
INSERT [dbo].[OrderStatus] ([Id], [StatusName]) VALUES (14, N'Approved')
GO
INSERT [dbo].[OrderStatus] ([Id], [StatusName]) VALUES (15, N'Collected')
GO
SET IDENTITY_INSERT [dbo].[OrderStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Places] ON 

GO
INSERT [dbo].[Places] ([Id], [Name], [PlaceType_Id]) VALUES (1, N'ADEM', 1)
GO
SET IDENTITY_INSERT [dbo].[Places] OFF
GO
SET IDENTITY_INSERT [dbo].[PlaceTypes] ON 

GO
INSERT [dbo].[PlaceTypes] ([Id], [TypeName]) VALUES (1, N'BAR')
GO
SET IDENTITY_INSERT [dbo].[PlaceTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Unit] ON 

GO
INSERT [dbo].[Unit] ([Id], [Name]) VALUES (1, N'Teke')
GO
INSERT [dbo].[Unit] ([Id], [Name]) VALUES (2, N'g')
GO
INSERT [dbo].[Unit] ([Id], [Name]) VALUES (3, N'ml')
GO
INSERT [dbo].[Unit] ([Id], [Name]) VALUES (4, N'Cope')
GO
SET IDENTITY_INSERT [dbo].[Unit] OFF
GO
SET IDENTITY_INSERT [dbo].[UserDatas] ON 

GO
INSERT [dbo].[UserDatas] ([Id], [User_Id], [FirstName], [LastName], [Address], [Place_Id]) VALUES (4, N'b0efeae7-dbce-4e67-b31d-a4bd7d7dc2f1', N'admin', NULL, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[UserDatas] OFF
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  CONSTRAINT [DF_AspNetUsers_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Goods_Dispatch_Note] ADD  DEFAULT ((0)) FOR [OrderId]
GO
ALTER TABLE [dbo].[Goods_Received_Note] ADD  CONSTRAINT [DF_Goods_Received_Note_Online_Id]  DEFAULT ((0)) FOR [Online_Id]
GO
ALTER TABLE [dbo].[MenuCategories] ADD  CONSTRAINT [DF_MenuCategories_OnlineId]  DEFAULT ((0)) FOR [OnlineId]
GO
ALTER TABLE [dbo].[MenuCategories] ADD  CONSTRAINT [DF_MenuCategories_IsItemActive]  DEFAULT ((1)) FOR [IsItemActive]
GO
ALTER TABLE [dbo].[MenuItems] ADD  CONSTRAINT [DF_MenuItems_OnlineId]  DEFAULT ((0)) FOR [OnlineId]
GO
ALTER TABLE [dbo].[MenuItems] ADD  CONSTRAINT [DF_MenuItems_MinimumQuantityNotify]  DEFAULT ((0)) FOR [MinimumQuantityNotify]
GO
ALTER TABLE [dbo].[MenuItems] ADD  CONSTRAINT [DF_MenuItems_IsItemActive]  DEFAULT ((1)) FOR [IsItemActive]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_FiscalCash]  DEFAULT ((1)) FOR [FiscalCash]
GO
ALTER TABLE [dbo].[Reports] ADD  CONSTRAINT [DF_Reports_Fiscal_Orders_Total_Sum]  DEFAULT ((0)) FOR [Fiscal_Orders_Total_Sum]
GO
ALTER TABLE [dbo].[Tables] ADD  CONSTRAINT [DF_Tables_OnLineId]  DEFAULT ((0)) FOR [OnLineId]
GO
ALTER TABLE [dbo].[Tables] ADD  CONSTRAINT [DF_Tables_IsItemActive]  DEFAULT ((1)) FOR [IsItemActive]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Balance]  WITH CHECK ADD  CONSTRAINT [FK__Balance__MenuIte__15DA3E5D] FOREIGN KEY([MenuItemId])
REFERENCES [dbo].[MenuItems] ([Id])
GO
ALTER TABLE [dbo].[Balance] CHECK CONSTRAINT [FK__Balance__MenuIte__15DA3E5D]
GO
ALTER TABLE [dbo].[ClientOrder]  WITH CHECK ADD FOREIGN KEY([OrderStatus_Id])
REFERENCES [dbo].[OrderStatus] ([Id])
GO
ALTER TABLE [dbo].[ClientOrder]  WITH CHECK ADD FOREIGN KEY([Place_Id])
REFERENCES [dbo].[Places] ([Id])
GO
ALTER TABLE [dbo].[ClientOrder]  WITH CHECK ADD FOREIGN KEY([User_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[ClientOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_ClientOrderDetails_ClientOrder] FOREIGN KEY([Id])
REFERENCES [dbo].[ClientOrder] ([Id])
GO
ALTER TABLE [dbo].[ClientOrderDetails] CHECK CONSTRAINT [FK_ClientOrderDetails_ClientOrder]
GO
ALTER TABLE [dbo].[ComposedItems]  WITH CHECK ADD  CONSTRAINT [FKChild] FOREIGN KEY([ChildId])
REFERENCES [dbo].[MenuItems] ([Id])
GO
ALTER TABLE [dbo].[ComposedItems] CHECK CONSTRAINT [FKChild]
GO
ALTER TABLE [dbo].[ComposedItems]  WITH CHECK ADD  CONSTRAINT [FKParent] FOREIGN KEY([ParentId])
REFERENCES [dbo].[MenuItems] ([Id])
GO
ALTER TABLE [dbo].[ComposedItems] CHECK CONSTRAINT [FKParent]
GO
ALTER TABLE [dbo].[Goods_Dispatch_Note]  WITH CHECK ADD  CONSTRAINT [c] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Goods_Dispatch_Note] CHECK CONSTRAINT [c]
GO
ALTER TABLE [dbo].[Goods_Dispatch_Note_Details]  WITH CHECK ADD  CONSTRAINT [FK__Goods_Dis__GDNId__12FDD1B2] FOREIGN KEY([GDNId])
REFERENCES [dbo].[Goods_Dispatch_Note] ([Id])
GO
ALTER TABLE [dbo].[Goods_Dispatch_Note_Details] CHECK CONSTRAINT [FK__Goods_Dis__GDNId__12FDD1B2]
GO
ALTER TABLE [dbo].[Goods_Dispatch_Note_Details]  WITH CHECK ADD  CONSTRAINT [FK__Goods_Dis__MenuI__1209AD79] FOREIGN KEY([MenuItemId])
REFERENCES [dbo].[MenuItems] ([Id])
GO
ALTER TABLE [dbo].[Goods_Dispatch_Note_Details] CHECK CONSTRAINT [FK__Goods_Dis__MenuI__1209AD79]
GO
ALTER TABLE [dbo].[Goods_Received_Note]  WITH CHECK ADD  CONSTRAINT [con] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Goods_Received_Note] CHECK CONSTRAINT [con]
GO
ALTER TABLE [dbo].[Goods_Received_Note_Details]  WITH CHECK ADD  CONSTRAINT [FK__Goods_Rec__GRNId__0D44F85C] FOREIGN KEY([GRNId])
REFERENCES [dbo].[Goods_Received_Note] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Goods_Received_Note_Details] CHECK CONSTRAINT [FK__Goods_Rec__GRNId__0D44F85C]
GO
ALTER TABLE [dbo].[Goods_Received_Note_Details]  WITH CHECK ADD  CONSTRAINT [FK__Goods_Rec__MenuI__0C50D423] FOREIGN KEY([MenuItemId])
REFERENCES [dbo].[MenuItems] ([Id])
GO
ALTER TABLE [dbo].[Goods_Received_Note_Details] CHECK CONSTRAINT [FK__Goods_Rec__MenuI__0C50D423]
GO
ALTER TABLE [dbo].[LastBalance]  WITH CHECK ADD  CONSTRAINT [FK__LastBalan__MenuI__18B6AB08] FOREIGN KEY([MenuItemId])
REFERENCES [dbo].[MenuItems] ([Id])
GO
ALTER TABLE [dbo].[LastBalance] CHECK CONSTRAINT [FK__LastBalan__MenuI__18B6AB08]
GO
ALTER TABLE [dbo].[MenuCategories]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MenuCategories_dbo.Places_Place_Id] FOREIGN KEY([Place_Id])
REFERENCES [dbo].[Places] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MenuCategories] CHECK CONSTRAINT [FK_dbo.MenuCategories_dbo.Places_Place_Id]
GO
ALTER TABLE [dbo].[MenuItems]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MenuItems_dbo.MenuCategories_MenuCategory_Id] FOREIGN KEY([MenuCategory_Id])
REFERENCES [dbo].[MenuCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MenuItems] CHECK CONSTRAINT [FK_dbo.MenuItems_dbo.MenuCategories_MenuCategory_Id]
GO
ALTER TABLE [dbo].[MenuItems]  WITH CHECK ADD  CONSTRAINT [FK_MenuItems_MenuItemType] FOREIGN KEY([MenuItemTypeId])
REFERENCES [dbo].[MenuItemType] ([Id])
GO
ALTER TABLE [dbo].[MenuItems] CHECK CONSTRAINT [FK_MenuItems_MenuItemType]
GO
ALTER TABLE [dbo].[MenuItems]  WITH CHECK ADD  CONSTRAINT [FK_MenuItems_Unit] FOREIGN KEY([UnitId])
REFERENCES [dbo].[Unit] ([Id])
GO
ALTER TABLE [dbo].[MenuItems] CHECK CONSTRAINT [FK_MenuItems_Unit]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderDetails_dbo.Orders_Order_Id] FOREIGN KEY([Order_Id])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_dbo.OrderDetails_dbo.Orders_Order_Id]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_ToMenuItems] FOREIGN KEY([MenuItem_Id])
REFERENCES [dbo].[MenuItems] ([Id])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_ToMenuItems]
GO
ALTER TABLE [dbo].[OrderForCancellation]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Orders1] FOREIGN KEY([User_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Orders1]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_OrderStatus] FOREIGN KEY([OrderStatus_Id])
REFERENCES [dbo].[OrderStatus] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_OrderStatus]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Tables] FOREIGN KEY([Table_Id])
REFERENCES [dbo].[Tables] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Tables]
GO
ALTER TABLE [dbo].[OrderSessions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderSessions_dbo.Orders_Order_Id] FOREIGN KEY([Order_Id])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderSessions] CHECK CONSTRAINT [FK_dbo.OrderSessions_dbo.Orders_Order_Id]
GO
ALTER TABLE [dbo].[OrderSessions]  WITH CHECK ADD  CONSTRAINT [FK_OrderSessions_ToTable] FOREIGN KEY([Table_Id])
REFERENCES [dbo].[Tables] ([Id])
GO
ALTER TABLE [dbo].[OrderSessions] CHECK CONSTRAINT [FK_OrderSessions_ToTable]
GO
ALTER TABLE [dbo].[PriceList]  WITH CHECK ADD  CONSTRAINT [FK__OrderPric__MenuI__1B9317B3] FOREIGN KEY([MenuItemId])
REFERENCES [dbo].[MenuItems] ([Id])
GO
ALTER TABLE [dbo].[PriceList] CHECK CONSTRAINT [FK__OrderPric__MenuI__1B9317B3]
GO
ALTER TABLE [dbo].[Reports]  WITH CHECK ADD  CONSTRAINT [FK__Reports__User_Id__68487DD7] FOREIGN KEY([User_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Reports] CHECK CONSTRAINT [FK__Reports__User_Id__68487DD7]
GO
ALTER TABLE [dbo].[Tables]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tables_dbo.Places_Place_Id] FOREIGN KEY([Place_Id])
REFERENCES [dbo].[Places] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tables] CHECK CONSTRAINT [FK_dbo.Tables_dbo.Places_Place_Id]
GO
ALTER TABLE [dbo].[UserDatas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserDatas_dbo.AspNetUsers_User_Id] FOREIGN KEY([User_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserDatas] CHECK CONSTRAINT [FK_dbo.UserDatas_dbo.AspNetUsers_User_Id]
GO
/****** Object:  StoredProcedure [dbo].[mbyllTurn]    Script Date: 3/3/2019 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[mbyllTurn](@userid nvarchar(128),@PosId as int,@cashTotal money,@TipsTotal money,  @id int output)
as 
begin

declare @Orders_No int,@Items_No int,@Orders_Total money

declare @lastsum decimal,@lastsasi int,@lastnumerfaturash int,@LastFiscalTotal decimal,@LastCash decimal,@LastTips decimal

declare @FiscalTotal decimal

declare @ReportDate as datetime


 begin try
 begin tran

 set @FiscalTotal=(
 select  isnull(sum(od.Quantity*od.SalePrice),0)
 from Orders o join
 OrderDetails od
on o.Id=od.Order_Id


where  o.OrderStatus_Id=10 and o.FiscalCash=1
and User_Id=@userid 

 )
 set @Orders_Total=(
 select  isnull(sum(od.Quantity*od.SalePrice),0)
 from Orders o join
 OrderDetails od
on o.Id=od.Order_Id


where  o.OrderStatus_Id=10 
and User_Id=@userid 

 )

select @Orders_No=isnull( count(distinct(o.Id)),0)  , @Items_No= isnull(sum(od.Quantity),0),@Orders_Total=isnull(sum(od.Quantity*od.SalePrice),0)
from Orders o join
 OrderDetails od
on o.Id=od.Order_Id


where   o.OrderStatus_Id=10
and User_Id=@userid 

--insert into report new row with new value

--get min date of non collected fatura

set @ReportDate=(select isnull(min(o.OperationTime),GETDATE()) from Orders o where o.OrderStatus_Id=10 and o.User_Id=@userid )


select @lastsum=isnull(sum(r.Orders_Total_Sum),0),@lastsasi=ISNULL(sum(r.Sold_Items_No),0),
  
  @lastnumerfaturash=ISNULL(sum(r.Orders_No),0),@LastCash=ISNULL(sum(r.Cash_Total),0),@LastTips=ISNULL(sum(r.Tips_Total_Sum),0),
  @LastFiscalTotal=ISNULL(sum(r.Fiscal_Orders_Total_Sum),0)
 from Reports r where CONVERT(date,r.Start_Date_Time)=CONVERT(date,@ReportDate) and r.User_Id=@userid

 declare @tempcash decimal
 
 set @tempcash=@cashTotal-@LastCash


insert into Reports  values(@Orders_No,@Items_No,@Orders_Total,@FiscalTotal,@tempcash,@TipsTotal,GETDATE(),@ReportDate,1,@userid,@PosId)


set @id=(SELECT SCOPE_IDENTITY());



commit tran
end try
begin catch


end catch



end


SET ANSI_NULLS ON



GO
USE [master]
GO
ALTER DATABASE [NewDb] SET  READ_WRITE 
GO
