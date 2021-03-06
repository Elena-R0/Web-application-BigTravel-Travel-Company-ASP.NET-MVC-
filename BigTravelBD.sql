USE [BigTravel]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 09.12.2021 15:25:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[id_country] [int] IDENTITY(1,1) NOT NULL,
	[Name_country] [varchar](30) NULL,
	[Description_country] [varchar](max) NULL,
	[image] [varchar](50) NULL,
 CONSTRAINT [PK_Country1] PRIMARY KEY CLUSTERED 
(
	[id_country] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 09.12.2021 15:25:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[id_customer] [int] IDENTITY(1,1) NOT NULL,
	[Series] [varchar](4) NULL,
	[Number] [varchar](6) NULL,
	[sername] [varchar](50) NULL,
	[name] [varchar](30) NULL,
	[patronymic] [varchar](50) NULL,
	[date_of_birth] [date] NULL,
	[adress] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[phone] [varchar](11) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[id_customer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employes]    Script Date: 09.12.2021 15:25:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employes](
	[id_employes] [int] IDENTITY(1,1) NOT NULL,
	[sername] [varchar](50) NULL,
	[name] [varchar](30) NULL,
	[patronymic] [varchar](50) NULL,
	[date_of_birth] [date] NULL,
	[salary] [decimal](18, 0) NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[phone] [varchar](11) NULL,
 CONSTRAINT [PK_Employes] PRIMARY KEY CLUSTERED 
(
	[id_employes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hotel]    Script Date: 09.12.2021 15:25:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hotel](
	[id_hotel] [int] IDENTITY(1,1) NOT NULL,
	[Namehotel] [varchar](50) NULL,
	[image] [varchar](50) NULL,
	[description_hotel] [varchar](max) NULL,
 CONSTRAINT [PK_hotel] PRIMARY KEY CLUSTERED 
(
	[id_hotel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_status]    Script Date: 09.12.2021 15:25:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_status](
	[idOrder_status] [int] NOT NULL,
	[NameStatus] [varchar](50) NULL,
 CONSTRAINT [PK_Order_status] PRIMARY KEY CLUSTERED 
(
	[idOrder_status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 09.12.2021 15:25:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[id_orders] [int] IDENTITY(1,1) NOT NULL,
	[id_customer] [int] NOT NULL,
	[id_employes] [int] NOT NULL,
	[id_vouchers] [int] NOT NULL,
	[Date_registration] [date] NOT NULL,
	[Number] [int] NULL,
	[idOrder_status] [int] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[id_orders] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 09.12.2021 15:25:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[idPayment] [int] IDENTITY(1,1) NOT NULL,
	[id_customer] [int] NULL,
	[id_orders] [int] NULL,
	[bank_card_num] [varchar](50) NULL,
	[date_payment] [date] NULL,
	[Id_PayType] [int] NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[idPayment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PayType]    Script Date: 09.12.2021 15:25:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayType](
	[Id_PayType] [int] NOT NULL,
	[Name_PayType] [varchar](50) NULL,
 CONSTRAINT [PK_PayType] PRIMARY KEY CLUSTERED 
(
	[Id_PayType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reis]    Script Date: 09.12.2021 15:25:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reis](
	[id_reis] [int] IDENTITY(1,1) NOT NULL,
	[id_order] [int] NULL,
	[Point_departure] [varchar](30) NULL,
	[Destination] [varchar](20) NULL,
	[Departure_date] [datetime] NULL,
	[Date_arrival] [datetime] NULL,
 CONSTRAINT [PK_reis] PRIMARY KEY CLUSTERED 
(
	[id_reis] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Route]    Script Date: 09.12.2021 15:25:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Route](
	[id_route] [int] IDENTITY(1,1) NOT NULL,
	[id_country] [int] NULL,
	[Place] [varchar](50) NULL,
	[Place_description] [varchar](max) NULL,
	[Place_image] [varchar](50) NULL,
 CONSTRAINT [PK_Route] PRIMARY KEY CLUSTERED 
(
	[id_route] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vouchers]    Script Date: 09.12.2021 15:25:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vouchers](
	[id_vouchers] [int] NOT NULL,
	[name_vouchers] [varchar](50) NULL,
	[id_route] [int] NULL,
	[id_hotel] [int] NULL,
	[Departure_date] [date] NULL,
	[Date_arrival] [date] NULL,
	[Information_vouchers] [varchar](max) NULL,
	[Excursions] [varchar](max) NULL,
	[image] [varchar](50) NULL,
	[Cost] [money] NULL,
	[number_trips] [int] NULL,
 CONSTRAINT [PK_Vouchers] PRIMARY KEY CLUSTERED 
(
	[id_vouchers] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([id_country], [Name_country], [Description_country], [image]) VALUES (1, N'Швейцария', N'Швейцария – это страна, которая привлекает туристов круглый год. Она имеет элегантные города с неповторимым колоритом и знаменитые курорты с комфортабельными отелями.', N'idcontryCHE.jpg')
INSERT [dbo].[Country] ([id_country], [Name_country], [Description_country], [image]) VALUES (2, N'Египет', N'Египет - это загадочная и прекрасная страна фараонов и пирамид, интересных музеев и древних памятников, это величественный Сфинкс и прославленный Каир, лунные пейзажи Синайского полуострова и неповторимая восточная экзотика. ', N'idcontryEGY.jpg')
INSERT [dbo].[Country] ([id_country], [Name_country], [Description_country], [image]) VALUES (3, N'Испания', N'Испания — это яркая, веселая, праздничная и солнечная страна. Здесь субтропический климат, и солнце светит 260 дней в году. Побережья Пиренейского полуострова, Канарских островов и Балеарского архипелага имеют превосходные пляжи, которые покорят даже самых придирчивых туристов.	', N'idcontryESP.jpg')
INSERT [dbo].[Country] ([id_country], [Name_country], [Description_country], [image]) VALUES (4, N'Япония', N'Островное государство в Восточной Азии. Находится в Тихом океане к востоку от Японского моря, Китая, Северной и Южной Кореи, России. Занимает территорию от Охотского моря на севере до Восточно-Китайского моря и Тайваня на юге. Поэтическое название - Страна восходящего солнца.	', N'idcontryJPN.jpg')
INSERT [dbo].[Country] ([id_country], [Name_country], [Description_country], [image]) VALUES (5, N'Польша', N'Для любителей природы Польша – это пляжи Балтийского моря, и незабываемые экскурсии в дюны. Для поклонников водного спорта Польша – это туры на отдых на мазурских озерах в окружении живописной природы. Туристам, предпочитающим активный отдых – Польские Татры с их целебным горным воздухом.	', N'idcontryPOL.png')
INSERT [dbo].[Country] ([id_country], [Name_country], [Description_country], [image]) VALUES (6, N'Швеция', N'Швеция - крупнейшее государство Северной Европы, расположенное на Скандинавском полуострове. Омывается водами Балтийского моря и граничит с другими скандинавскими странами - Норвегией и Финляндией.', N'idcontrySWE.jpg')
INSERT [dbo].[Country] ([id_country], [Name_country], [Description_country], [image]) VALUES (7, N'Турция', N'Турция - одна из самых древних стран, обладающая богатейшим наследием. Расположена на территории Малой Азии и небольшой своей частью в юго-восточной Европе, поэтому это место уникального сочетания восточных традиций и европейской культуры. Славится гостеприимством, особым уютом и прекрасным сервисом.	', N'idcontryTUR.jpg')
SET IDENTITY_INSERT [dbo].[Country] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([id_customer], [Series], [Number], [sername], [name], [patronymic], [date_of_birth], [adress], [Password], [Email], [phone]) VALUES (1, N'4601', N'729722', N'Сиротов', N'Иван', N'Дмитриевич', CAST(N'1984-03-28' AS Date), N'г.Новосибирск, ул.Широкая, д.5', N'Sirotov80_', N'Sidor@gmail.com', N'+7949376428')
INSERT [dbo].[Customer] ([id_customer], [Series], [Number], [sername], [name], [patronymic], [date_of_birth], [adress], [Password], [Email], [phone]) VALUES (2, N'4777', N'729439', N'Петрушина', N'Ольга', N'Алексеевна', CAST(N'1974-01-02' AS Date), N'г.Благовещенск, ул.Пионерская, д.7', N'7402Petr_', N'Olga02@gmail.com', N'+7963742699')
INSERT [dbo].[Customer] ([id_customer], [Series], [Number], [sername], [name], [patronymic], [date_of_birth], [adress], [Password], [Email], [phone]) VALUES (3, N'4569', N'880630', N'Лужков', N'Роман', N'Ираклиевич', CAST(N'1965-07-26' AS Date), N'г.Новороссийск, ул.Хуторская, д.25', N'LuzkovRom_n07', N'roman88@yandex.ru', N'+7948419783')
INSERT [dbo].[Customer] ([id_customer], [Series], [Number], [sername], [name], [patronymic], [date_of_birth], [adress], [Password], [Email], [phone]) VALUES (4, N'4856', N'698121', N'Федин', N'Виктор', N'Геннадьевич', CAST(N'1987-06-15' AS Date), N'г.Хасавюрт, ул.Ленина В.И., д.24', N'vikTH1_', N'viktor1962@yandex.ru', N'+7945487923')
INSERT [dbo].[Customer] ([id_customer], [Series], [Number], [sername], [name], [patronymic], [date_of_birth], [adress], [Password], [Email], [phone]) VALUES (5, N'4762', N'586322', N'Калугин', N'Сергей', N'Валерьевич', CAST(N'1990-04-27' AS Date), N'г. Тула, Садовый пер., д.6', N'Kalugin04_', N'sergey1965@mail.ru', N'+7944263153')
INSERT [dbo].[Customer] ([id_customer], [Series], [Number], [sername], [name], [patronymic], [date_of_birth], [adress], [Password], [Email], [phone]) VALUES (7, N'6768', N'000975', N'Еда', N'Сладость', N'вкус', CAST(N'1999-01-01' AS Date), N'402 Meco Dr', N'fffff', N'slad@gmail.com', N'+789323134')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Employes] ON 

INSERT [dbo].[Employes] ([id_employes], [sername], [name], [patronymic], [date_of_birth], [salary], [Email], [Password], [phone]) VALUES (1, N'Якущенко', N'Вениамин', N'Михаилович', CAST(N'1994-02-03' AS Date), CAST(25500 AS Decimal(18, 0)), N'Oveniamin9182@gmail.com', N'urist', N'+7979923297')
INSERT [dbo].[Employes] ([id_employes], [sername], [name], [patronymic], [date_of_birth], [salary], [Email], [Password], [phone]) VALUES (2, N'Перминова', N'Ева', N'Максимовна', CAST(N'1961-05-22' AS Date), CAST(36000 AS Decimal(18, 0)), N'eva1961@yandex.ru', N'meneg61', N'+7938478157')
INSERT [dbo].[Employes] ([id_employes], [sername], [name], [patronymic], [date_of_birth], [salary], [Email], [Password], [phone]) VALUES (3, N'Подчасов', N'Константин', N'Германович', CAST(N'1988-10-22' AS Date), CAST(26556 AS Decimal(18, 0)), N'konstantin8702@mail.ru', N'Chasov22', N'+7951367493')
INSERT [dbo].[Employes] ([id_employes], [sername], [name], [patronymic], [date_of_birth], [salary], [Email], [Password], [phone]) VALUES (4, N'Татаурова', N'Катерина', N'Акимовна', CAST(N'1988-12-22' AS Date), CAST(45000 AS Decimal(18, 0)), N'katerina1988@gmail.com', N'Director', N'+7929524773')
INSERT [dbo].[Employes] ([id_employes], [sername], [name], [patronymic], [date_of_birth], [salary], [Email], [Password], [phone]) VALUES (5, N'Татарова', N'Антонина', N'Марковна', CAST(N'1963-12-22' AS Date), CAST(25000 AS Decimal(18, 0)), N'antonina2862@mail.ru', N'meneg12', N'+7929450334')
INSERT [dbo].[Employes] ([id_employes], [sername], [name], [patronymic], [date_of_birth], [salary], [Email], [Password], [phone]) VALUES (10, N'Кравкова', N'Аполлинария', N'Федоровна', CAST(N'1989-12-01' AS Date), CAST(34555 AS Decimal(18, 0)), N'3', N'3', N'+7849322112')
SET IDENTITY_INSERT [dbo].[Employes] OFF
GO
SET IDENTITY_INSERT [dbo].[hotel] ON 

INSERT [dbo].[hotel] ([id_hotel], [Namehotel], [image], [description_hotel]) VALUES (2, N'Caballero de Gracia', N'Caballero de Gracia.jpg', N'Уютные семейные апартаменты Caballero de Gracia находятся на тихой улице и предлагают спокойный и комфортабельный отдых. В номерах запрещено курить. Персонал гостиницы предоставит всю необходимую туристическую информацию. Апартаменты Caballero de Gracia расположены в 70 метрах от Гран Виа. За 4 минуты можно дойти до площади Пуэрта дель Соль. В непосредственной близости располагаются многие магазины, рестораны и бары.')
INSERT [dbo].[hotel] ([id_hotel], [Namehotel], [image], [description_hotel]) VALUES (3, N'Viking Suite Hotel', N'Viking Suite Hotel.jpg', N'Новый апарт-отель Viking удобно расположен в центре Кемера. Гостям предлагаются просторные апартаменты с современными удобствами и приятной атмосферой.')
INSERT [dbo].[hotel] ([id_hotel], [Namehotel], [image], [description_hotel]) VALUES (4, N'Chateau de Mathod', N'Chateau de Mathod.jpg', N'Отель типа «постель и завтрак» Chateau de Mathod расположен в городе Матхуд региона Во, в 28 км от Лозанны. К услугам гостей спа-центр, гидромассажная ванна и бесплатная частная парковка на территории. В числе удобств номеров телевизор с плоским экраном, гостиный уголок, кофемашина и чайник, а также собственная ванная комната с бесплатными туалетно-косметическими принадлежностями и феном. ')
INSERT [dbo].[hotel] ([id_hotel], [Namehotel], [image], [description_hotel]) VALUES (6, N'Tolip Hotel Alexandria', N'Tolip Hotel Alexandria.jpg', N'Этот 5-звездочный отель находится в Александрии. К услугам гостей открытый бассейн, спа-салон, тренажерный зал и современные номера с видом на море или город. В местах общего пользования предоставляется бесплатный Wi-Fi.4')
INSERT [dbo].[hotel] ([id_hotel], [Namehotel], [image], [description_hotel]) VALUES (7, N'Bania Thermal & Ski', N'Bania Thermal & Ski.jpg', N'Отель Bania Thermal & Ski находится в селе Бялка-Татшаньска, рядом с аквапарком Terma Bania, в который гостям предоставляется бесплатный неограниченный доступ. С территории отеля открывается прекрасный вид на Татры.')
INSERT [dbo].[hotel] ([id_hotel], [Namehotel], [image], [description_hotel]) VALUES (9, N'Hyperion Hotel Basel', N'Hyperion Hotel Basel.jpg', N'Отель Hyperion Basel с фитнес-центром, сауной и бесплатным доступом в интернет размещается в самом высоком жилом здании Базеля рядом с Торгово-выставочным центром Базель-Мессе и всего в нескольких минутах ходьбы от исторической части города.')
INSERT [dbo].[hotel] ([id_hotel], [Namehotel], [image], [description_hotel]) VALUES (10, N'Aparthotel Mariano Cubi Barcelona', N'Aparthotel Mariano Cubi Barcelona.jpg', N'Апарт-отель Mariano Cubi находится всего в 200 метрах от проспекта Диагональ в Барселоне и в 15 минутах ходьбы от проспекта Грасиа. К услугам гостей номера с кондиционером и бесплатным Wi-Fi, в некоторых из которых обустроена мини-кухня.

Во всех просторных номерах постелен деревянный пол, подключено спутниковое телевидение и установлен стол. По прибытии гости получают бесплатный бокал кавы.')
INSERT [dbo].[hotel] ([id_hotel], [Namehotel], [image], [description_hotel]) VALUES (11, N'Eurotel Montreux', N'Eurotel Montreux.jpg', N'Четырехзвездочный улучшенный отель Eurotel Montreux расположен прямо на берегу Женевского озера в городе Монтрё. Из всех номеров открывается панорамный вид на озеро и Альпы. К услугам гостей бесплатный Wi-Fi. В номерах подключено спутниковое телевидение и установлен мини-бар. В большинстве номеров имеется балкон.')
INSERT [dbo].[hotel] ([id_hotel], [Namehotel], [image], [description_hotel]) VALUES (12, N'Hilton Marsa Alam Nubian Resort', N'Hilton Marsa Alam Nubian Resort.jpg', N'Этот курортный отель расположен в Египте, на пляже западного побережья Красного моря. Отель похож на небольшую деревню, окруженную 4 открытыми бассейнами. К услугам гостей круглосуточный тренажерный зал и номера с видом на Красное море.')
INSERT [dbo].[hotel] ([id_hotel], [Namehotel], [image], [description_hotel]) VALUES (13, N'Super Hotel Lohas Akasaka 3', N'Super Hotel Lohas Akasaka 3.jpg', N'Найти идеальный отель в Минато не должно быть сложной задачей. Добро пожаловать в Super Hotel Lohas Akasaka, прекрасный вариант для размещения подобных вам путешественников.
Учитывая близкое расположение таких популярных мест, как Toyokawa Inari Tokyo Betsuin (0,3 км) и Villa Tokyo (1,3 км), гости отеля Super Hotel Lohas Akasaka без труда смогут посетить одни из самых известных достопримечательностей Минато.')
SET IDENTITY_INSERT [dbo].[hotel] OFF
GO
INSERT [dbo].[Order_status] ([idOrder_status], [NameStatus]) VALUES (1, N'Оплачен')
INSERT [dbo].[Order_status] ([idOrder_status], [NameStatus]) VALUES (2, N'Не оплачен')
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([id_orders], [id_customer], [id_employes], [id_vouchers], [Date_registration], [Number], [idOrder_status]) VALUES (1, 4, 1, 14, CAST(N'2021-01-18' AS Date), 3, 1)
INSERT [dbo].[Orders] ([id_orders], [id_customer], [id_employes], [id_vouchers], [Date_registration], [Number], [idOrder_status]) VALUES (2, 3, 2, 5, CAST(N'2020-11-20' AS Date), 1, 1)
INSERT [dbo].[Orders] ([id_orders], [id_customer], [id_employes], [id_vouchers], [Date_registration], [Number], [idOrder_status]) VALUES (4, 4, 5, 14, CAST(N'2020-11-19' AS Date), 2, 2)
INSERT [dbo].[Orders] ([id_orders], [id_customer], [id_employes], [id_vouchers], [Date_registration], [Number], [idOrder_status]) VALUES (8, 2, 2, 11, CAST(N'2020-12-10' AS Date), 4, 1)
INSERT [dbo].[Orders] ([id_orders], [id_customer], [id_employes], [id_vouchers], [Date_registration], [Number], [idOrder_status]) VALUES (9, 5, 5, 12, CAST(N'2020-12-24' AS Date), 2, 2)
INSERT [dbo].[Orders] ([id_orders], [id_customer], [id_employes], [id_vouchers], [Date_registration], [Number], [idOrder_status]) VALUES (11, 1, 2, 5, CAST(N'2020-12-05' AS Date), 4, 2)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Payment] ON 

INSERT [dbo].[Payment] ([idPayment], [id_customer], [id_orders], [bank_card_num], [date_payment], [Id_PayType]) VALUES (1, 4, 1, N'5369 9099 9531 1012', CAST(N'2021-01-22' AS Date), 2)
INSERT [dbo].[Payment] ([idPayment], [id_customer], [id_orders], [bank_card_num], [date_payment], [Id_PayType]) VALUES (2, 3, 2, N'5405 1011 7266 3144', CAST(N'2020-11-23' AS Date), 1)
INSERT [dbo].[Payment] ([idPayment], [id_customer], [id_orders], [bank_card_num], [date_payment], [Id_PayType]) VALUES (3, 4, 4, N'5369 9099 9531 1012', CAST(N'2020-11-22' AS Date), 2)
INSERT [dbo].[Payment] ([idPayment], [id_customer], [id_orders], [bank_card_num], [date_payment], [Id_PayType]) VALUES (4, 2, 8, N'5522 0030 8057 0593', CAST(N'2020-12-11' AS Date), 2)
INSERT [dbo].[Payment] ([idPayment], [id_customer], [id_orders], [bank_card_num], [date_payment], [Id_PayType]) VALUES (5, 5, 9, N'5369 9069 2090 5801', CAST(N'2020-12-24' AS Date), 1)
SET IDENTITY_INSERT [dbo].[Payment] OFF
GO
INSERT [dbo].[PayType] ([Id_PayType], [Name_PayType]) VALUES (1, N'Наличные')
INSERT [dbo].[PayType] ([Id_PayType], [Name_PayType]) VALUES (2, N'Безналичные')
GO
SET IDENTITY_INSERT [dbo].[reis] ON 

INSERT [dbo].[reis] ([id_reis], [id_order], [Point_departure], [Destination], [Departure_date], [Date_arrival]) VALUES (3, 4, N'г. Хасавюрт', N'Швейцария', CAST(N'2021-03-01T07:00:00.000' AS DateTime), CAST(N'2021-03-01T05:34:00.000' AS DateTime))
INSERT [dbo].[reis] ([id_reis], [id_order], [Point_departure], [Destination], [Departure_date], [Date_arrival]) VALUES (6, 8, N'г. Благовещенск', N'Испания', CAST(N'2021-04-20T00:00:00.000' AS DateTime), CAST(N'2021-04-27T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[reis] OFF
GO
SET IDENTITY_INSERT [dbo].[Route] ON 

INSERT [dbo].[Route] ([id_route], [id_country], [Place], [Place_description], [Place_image]) VALUES (1, 1, N'Женева', N'Город на юго-западе Швейцарии. Столица одноимённого франкоязычного кантона и административный центр одноимённой коммуны. С населением в 499 тыс. человек Женева является вторым по величине городом страны.', N'Geneva.jpg')
INSERT [dbo].[Route] ([id_route], [id_country], [Place], [Place_description], [Place_image]) VALUES (4, 2, N'Александрия', N'Город в дельте Нила, главный морской порт и второй по величине город Египта. Простирается на 32 км вдоль побережья Средиземного моря.', N'Alexsandria.jpg')
INSERT [dbo].[Route] ([id_route], [id_country], [Place], [Place_description], [Place_image]) VALUES (5, 3, N'Барселона', N'Город в Испании, столица автономной области Каталония и провинции Барселона. Порт на Средиземном море в 120 км от границы Франции. Крупнейший промышленный и торговый центр Испании.', N'barselona.jpg')
INSERT [dbo].[Route] ([id_route], [id_country], [Place], [Place_description], [Place_image]) VALUES (7, 4, N'Киото', N'Японский город, определённый указом правительства. Расположен в центральной части острова Хонсю, в центре региона Кансай, в юго-западной части префектуры Киото. Город является административным центром этой префектуры. Один из ведущих городов региона Кансай и городского района Осака - Кобе - Киото.', N'kioto.jpg')
INSERT [dbo].[Route] ([id_route], [id_country], [Place], [Place_description], [Place_image]) VALUES (10, 5, N'Краков', N'Город на юге Польши, расположенный на реке Висле в 295 км от Варшавы. Население насчитывает 779 115 жителей, вместе с ближайшими пригородами - свыше 1 млн, является вторым по населению и площади городом Польши после Варшавы. Административный центр Малопольского воеводства, центр архиепархии.', N'krakov.jpg')
INSERT [dbo].[Route] ([id_route], [id_country], [Place], [Place_description], [Place_image]) VALUES (14, 6, N'Гётеборг', N'Город на юго-западе Швеции в лене Вестра-Гёталанд. Является вторым по величине городом Швеции после Стокгольма. Площадь города - около 450 км?.', N'Geteborn.jpg')
INSERT [dbo].[Route] ([id_route], [id_country], [Place], [Place_description], [Place_image]) VALUES (16, 7, N'Стамбул', N'Крупнейший город Турции, главный торговый, промышленный и культурный центр, основной порт страны. По численности населения третий город в Европе.', N'Stambul.jpg')
SET IDENTITY_INSERT [dbo].[Route] OFF
GO
INSERT [dbo].[Vouchers] ([id_vouchers], [name_vouchers], [id_route], [id_hotel], [Departure_date], [Date_arrival], [Information_vouchers], [Excursions], [image], [Cost], [number_trips]) VALUES (5, N'Испания мечты!', 5, 2, CAST(N'2021-11-25' AS Date), CAST(N'2021-12-02' AS Date), N'Поездка в Испанию представляет собой прекрасное захватывающее путешествие, в котором можно отлично насладиться и достопримечательностями страны, и ее пляжами.', N'Групповая пешеходная экскурсия по Готическому кварталу и бульвару Рамблас', N'испания.jpg', 79000.0000, 40)
INSERT [dbo].[Vouchers] ([id_vouchers], [name_vouchers], [id_route], [id_hotel], [Departure_date], [Date_arrival], [Information_vouchers], [Excursions], [image], [Cost], [number_trips]) VALUES (6, N'В гостях у сказки', 14, 11, CAST(N'2021-04-20' AS Date), CAST(N'2021-02-01' AS Date), N'Идеальный маршрут для первого знакомства с этой удивительной, уникальной страной, где соседствуют разные культуры, разные языки, разные традиции и обычаи.', N'Экскурсия в Цюрих и на Рейнский водопад из Базеля', N'CHE.jpg', 70990.0000, 25)
INSERT [dbo].[Vouchers] ([id_vouchers], [name_vouchers], [id_route], [id_hotel], [Departure_date], [Date_arrival], [Information_vouchers], [Excursions], [image], [Cost], [number_trips]) VALUES (9, N'Польша на ладони', 7, 4, CAST(N'2021-03-06' AS Date), CAST(N'2021-03-18' AS Date), N'Полноценный отдых в Польше — это когда отдыхающий наслаждается всеми видами отдыха! Здесь вы сможете легко подобрать и купить горящую путевку заранее.', N'Экскурсия по экспозиции в музее Завода Шиндлера', N'Польша.jpg', 59000.0000, 35)
INSERT [dbo].[Vouchers] ([id_vouchers], [name_vouchers], [id_route], [id_hotel], [Departure_date], [Date_arrival], [Information_vouchers], [Excursions], [image], [Cost], [number_trips]) VALUES (11, N'Барселона– столица средиземноморья ', 10, 10, CAST(N'2021-04-20' AS Date), CAST(N'2021-04-27' AS Date), N'Испания – страна с необыкновенно богатой историей и уникальной культурой. Недаром миллионы туристов со всего света приезжают 
в Испанию ежегодно, и среди них очень много тех, кто возвращается сюда снова и снова, потому что за один раз нельзя узнать всю Испанию – ее можно только полюбить 
раз и навсегда...
', N'Автобусная экскурсия "Театр-музей Сальвадора Дали и Жирона"', N'1.jpg', 115000.0000, 15)
INSERT [dbo].[Vouchers] ([id_vouchers], [name_vouchers], [id_route], [id_hotel], [Departure_date], [Date_arrival], [Information_vouchers], [Excursions], [image], [Cost], [number_trips]) VALUES (12, N'Отдых, солнце, море!', 4, 3, CAST(N'2021-02-05' AS Date), CAST(N'2021-02-19' AS Date), N'Отдых в Турции - это недорогой отдых при европейском качестве обслуживания. Изумительная природа, золотые песчаные пляжи, живописные горы, покрытые сосновыми реликтовыми лесами, яркое солнце и, конечно, кристально-чистое, ласковое и теплое море — все это делает курорты Турции привлекательными для туристов.', N'Великая столица Османов', N'tur.jpg', 60000.0000, 50)
INSERT [dbo].[Vouchers] ([id_vouchers], [name_vouchers], [id_route], [id_hotel], [Departure_date], [Date_arrival], [Information_vouchers], [Excursions], [image], [Cost], [number_trips]) VALUES (14, N'Шарм Эль Шейх', 5, 12, CAST(N'2021-02-01' AS Date), CAST(N'2021-02-10' AS Date), N'Шарм-Эль-Шейх в переводе с арабского означает «Залив шейха». Это наиболее популярный, современный и стремительно развивающийся курорт на Синайском полуострове. Здесь находится множество отелей, торговых центров и ресторанов.	', N'Скала Абу Симбел', N'Шарм_Эль_Шейх.jpg', 80000.0000, 34)
INSERT [dbo].[Vouchers] ([id_vouchers], [name_vouchers], [id_route], [id_hotel], [Departure_date], [Date_arrival], [Information_vouchers], [Excursions], [image], [Cost], [number_trips]) VALUES (17, N'Сакура в цвету!', 16, 13, CAST(N'2021-03-01' AS Date), CAST(N'2021-03-10' AS Date), N'Тур «Сакура в цвету!» подарит Вам 9 дней 
в волшебном облаке японской сакуры. Вас 
ждут самые живописные и популярные места для любования сакурой в шести городах Японии: Токио, Киото, Осаке, Камакуре, Хаконэ. 
', N'Наследие самураев
', N'2.jpg', 228000.0000, 65)
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customer] FOREIGN KEY([id_customer])
REFERENCES [dbo].[Customer] ([id_customer])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customer]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Employes] FOREIGN KEY([id_employes])
REFERENCES [dbo].[Employes] ([id_employes])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Employes]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Order_status] FOREIGN KEY([idOrder_status])
REFERENCES [dbo].[Order_status] ([idOrder_status])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Order_status]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Vouchers] FOREIGN KEY([id_vouchers])
REFERENCES [dbo].[Vouchers] ([id_vouchers])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Vouchers]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Customer] FOREIGN KEY([id_customer])
REFERENCES [dbo].[Customer] ([id_customer])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Customer]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Orders] FOREIGN KEY([id_orders])
REFERENCES [dbo].[Orders] ([id_orders])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Orders]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_PayType] FOREIGN KEY([Id_PayType])
REFERENCES [dbo].[PayType] ([Id_PayType])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_PayType]
GO
ALTER TABLE [dbo].[reis]  WITH CHECK ADD  CONSTRAINT [FK_reis_Orders] FOREIGN KEY([id_order])
REFERENCES [dbo].[Orders] ([id_orders])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[reis] CHECK CONSTRAINT [FK_reis_Orders]
GO
ALTER TABLE [dbo].[Route]  WITH CHECK ADD  CONSTRAINT [FK_Route_Country] FOREIGN KEY([id_country])
REFERENCES [dbo].[Country] ([id_country])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Route] CHECK CONSTRAINT [FK_Route_Country]
GO
ALTER TABLE [dbo].[Vouchers]  WITH CHECK ADD  CONSTRAINT [FK_Vouchers_hotel] FOREIGN KEY([id_hotel])
REFERENCES [dbo].[hotel] ([id_hotel])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Vouchers] CHECK CONSTRAINT [FK_Vouchers_hotel]
GO
ALTER TABLE [dbo].[Vouchers]  WITH CHECK ADD  CONSTRAINT [FK_Vouchers_Route] FOREIGN KEY([id_route])
REFERENCES [dbo].[Route] ([id_route])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Vouchers] CHECK CONSTRAINT [FK_Vouchers_Route]
GO
