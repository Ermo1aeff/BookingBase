USE [Booking_Base]
GO
/****** Object:  Table [dbo].[accounts]    Script Date: 07.10.2022 11:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accounts](
	[account_id] [int] IDENTITY(1,1) NOT NULL,
	[account_login] [varchar](50) NULL,
	[account_password] [varchar](50) NULL,
	[first_name_id] [int] NULL,
	[last_name_id] [int] NULL,
	[status] [int] NULL,
 CONSTRAINT [PK_accounts] PRIMARY KEY CLUSTERED 
(
	[account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cities]    Script Date: 07.10.2022 11:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cities](
	[city_id] [int] IDENTITY(1,1) NOT NULL,
	[country_id] [int] NULL,
	[city_name] [varchar](50) NULL,
 CONSTRAINT [PK_cities] PRIMARY KEY CLUSTERED 
(
	[city_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[countries]    Script Date: 07.10.2022 11:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[countries](
	[country_id] [int] IDENTITY(1,1) NOT NULL,
	[country_name] [varchar](200) NULL,
 CONSTRAINT [PK_countries] PRIMARY KEY CLUSTERED 
(
	[country_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[departures]    Script Date: 07.10.2022 11:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[departures](
	[departure_id] [int] IDENTITY(1,1) NOT NULL,
	[tour_id] [int] NULL,
	[date_begin] [date] NULL,
 CONSTRAINT [PK_departures] PRIMARY KEY CLUSTERED 
(
	[departure_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[first_names]    Script Date: 07.10.2022 11:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[first_names](
	[first_name_id] [int] IDENTITY(3,1) NOT NULL,
	[first_name] [varchar](50) NULL,
 CONSTRAINT [PK_first_names] PRIMARY KEY CLUSTERED 
(
	[first_name_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[included]    Script Date: 07.10.2022 11:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[included](
	[included] [int] IDENTITY(1,1) NOT NULL,
	[tour_id] [int] NULL,
	[inclusion_id] [int] NULL,
	[included_choice] [int] NULL,
	[included_description] [varchar](5000) NULL,
 CONSTRAINT [PK_inclusion] PRIMARY KEY CLUSTERED 
(
	[included] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[inclusions]    Script Date: 07.10.2022 11:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[inclusions](
	[inclusion_id] [int] IDENTITY(1,1) NOT NULL,
	[inclusion_name] [varchar](50) NULL,
 CONSTRAINT [PK_inclusions] PRIMARY KEY CLUSTERED 
(
	[inclusion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itirerary]    Script Date: 07.10.2022 11:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[itirerary](
	[itinerary] [int] IDENTITY(1,1) NOT NULL,
	[tour_id] [int] NULL,
	[day_num] [int] NULL,
	[itinerary_name] [varchar](50) NULL,
	[itirarary_description] [varchar](3000) NULL,
 CONSTRAINT [PK_itirerary] PRIMARY KEY CLUSTERED 
(
	[itinerary] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[last_names]    Script Date: 07.10.2022 11:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[last_names](
	[last_name_id] [int] IDENTITY(1,1) NOT NULL,
	[last_name] [varchar](50) NULL,
 CONSTRAINT [PK_last_names] PRIMARY KEY CLUSTERED 
(
	[last_name_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order_rooms]    Script Date: 07.10.2022 11:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order_rooms](
	[order_rooms] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NULL,
	[room_id] [int] NULL,
	[room_count] [int] NULL,
 CONSTRAINT [PK_order_rooms] PRIMARY KEY CLUSTERED 
(
	[order_rooms] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orders]    Script Date: 07.10.2022 11:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orders](
	[order_id] [int] IDENTITY(1,1) NOT NULL,
	[departures_id] [int] NULL,
	[contact_phone] [bigint] NULL,
	[person_count] [int] NULL,
	[price] [decimal](18, 2) NULL,
 CONSTRAINT [PK_orders] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[persons]    Script Date: 07.10.2022 11:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[persons](
	[person_id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NULL,
	[first_name_id] [int] NULL,
	[last_name_id] [int] NULL,
	[city_id] [int] NULL,
	[passport] [bigint] NULL,
	[birthday] [date] NULL,
 CONSTRAINT [PK_persons] PRIMARY KEY CLUSTERED 
(
	[person_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rooms]    Script Date: 07.10.2022 11:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rooms](
	[room_id] [int] IDENTITY(1,1) NOT NULL,
	[tour_id] [int] NULL,
	[room_name] [varchar](100) NULL,
	[beds_count] [int] NULL,
	[price] [decimal](18, 2) NULL,
 CONSTRAINT [PK_hotels] PRIMARY KEY CLUSTERED 
(
	[room_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tours]    Script Date: 07.10.2022 11:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tours](
	[tour_id] [int] IDENTITY(1,1) NOT NULL,
	[tour_name] [varchar](100) NULL,
	[city_begin_id] [int] NULL,
	[city_end_id] [int] NULL,
	[price] [decimal](18, 2) NULL,
	[day_count] [int] NULL,
	[max_group_size] [int] NULL,
 CONSTRAINT [PK_tours] PRIMARY KEY CLUSTERED 
(
	[tour_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[accounts] ON 

INSERT [dbo].[accounts] ([account_id], [account_login], [account_password], [first_name_id], [last_name_id], [status]) VALUES (1, N'ermolaeff', N'9517392', 3, 1, 1)
SET IDENTITY_INSERT [dbo].[accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[cities] ON 

INSERT [dbo].[cities] ([city_id], [country_id], [city_name]) VALUES (2, 1, N'Амстердам')
INSERT [dbo].[cities] ([city_id], [country_id], [city_name]) VALUES (3, 2, N'Берлин')
INSERT [dbo].[cities] ([city_id], [country_id], [city_name]) VALUES (4, 3, N'Вена')
INSERT [dbo].[cities] ([city_id], [country_id], [city_name]) VALUES (5, 4, N'Прага')
INSERT [dbo].[cities] ([city_id], [country_id], [city_name]) VALUES (6, 5, N'Варшава')
INSERT [dbo].[cities] ([city_id], [country_id], [city_name]) VALUES (7, 6, N'Париж')
INSERT [dbo].[cities] ([city_id], [country_id], [city_name]) VALUES (8, 7, N'Мадрид')
INSERT [dbo].[cities] ([city_id], [country_id], [city_name]) VALUES (9, 8, N'Лиссабон')
SET IDENTITY_INSERT [dbo].[cities] OFF
GO
SET IDENTITY_INSERT [dbo].[countries] ON 

INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (1, N'Недерланды')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (2, N'Германия')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (3, N'Австрия')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (4, N'Чехия')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (5, N'Польша')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (6, N'Франция')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (7, N'Испания')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (8, N'Португалия')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (9, N'Бельгия')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (10, N'Дания')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (11, N'Словакия')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (12, N'Венгрия')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (13, N'Сербия')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (14, N'Хорватия')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (15, N'Босния и Герцеговина')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (16, N'Косово')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (17, N'Черногория')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (18, N'Словения')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (19, N'Италия')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (20, N'Монако')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (21, N'Люксембург')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (22, N'Швейцария')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (23, N'Лихтенштейн')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (24, N'Молдавия')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (25, N'Румыния')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (26, N'Северная Македония')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (27, N'Албания')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (28, N'Болгария')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (29, N'Греция')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (30, N'Украина')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (31, N'Литва')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (32, N'Латвия')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (33, N'Эстония')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (34, N'Норвегия')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (35, N'Швеция')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (36, N'Финляндия')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (37, N'Великобритания')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (38, N'Ирландия')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (39, N'Грузия')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (40, N'Турция')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (41, N'Исландия')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (42, N'Мальта')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (43, N'Кипр')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (44, N'Андорра')
INSERT [dbo].[countries] ([country_id], [country_name]) VALUES (45, N'Ватикан')
SET IDENTITY_INSERT [dbo].[countries] OFF
GO
SET IDENTITY_INSERT [dbo].[departures] ON 

INSERT [dbo].[departures] ([departure_id], [tour_id], [date_begin]) VALUES (1, 9, CAST(N'2022-10-20' AS Date))
INSERT [dbo].[departures] ([departure_id], [tour_id], [date_begin]) VALUES (2, 9, CAST(N'2022-10-27' AS Date))
INSERT [dbo].[departures] ([departure_id], [tour_id], [date_begin]) VALUES (3, 9, CAST(N'2022-11-03' AS Date))
INSERT [dbo].[departures] ([departure_id], [tour_id], [date_begin]) VALUES (4, 9, CAST(N'2022-11-10' AS Date))
INSERT [dbo].[departures] ([departure_id], [tour_id], [date_begin]) VALUES (5, 9, CAST(N'2022-11-17' AS Date))
INSERT [dbo].[departures] ([departure_id], [tour_id], [date_begin]) VALUES (6, 9, CAST(N'2022-11-24' AS Date))
INSERT [dbo].[departures] ([departure_id], [tour_id], [date_begin]) VALUES (7, 9, CAST(N'2022-12-01' AS Date))
INSERT [dbo].[departures] ([departure_id], [tour_id], [date_begin]) VALUES (8, 9, CAST(N'2022-12-08' AS Date))
INSERT [dbo].[departures] ([departure_id], [tour_id], [date_begin]) VALUES (9, 9, CAST(N'2022-12-15' AS Date))
SET IDENTITY_INSERT [dbo].[departures] OFF
GO
SET IDENTITY_INSERT [dbo].[first_names] ON 

INSERT [dbo].[first_names] ([first_name_id], [first_name]) VALUES (3, N'Егор')
INSERT [dbo].[first_names] ([first_name_id], [first_name]) VALUES (4, N'Алексей')
SET IDENTITY_INSERT [dbo].[first_names] OFF
GO
SET IDENTITY_INSERT [dbo].[included] ON 

INSERT [dbo].[included] ([included], [tour_id], [inclusion_id], [included_choice], [included_description]) VALUES (3, 9, 1, 1, N'АМСТЕРДАМ : TULIP INN AMSTERDAM AIRPORT или NEW CENTURY или CORENDON VILLAGE AMSTERDAM

АМСТЕРДАМ : PARK PLAZA AMSTERDAM AIRPORT или IBIS AMSTERDAM CITY WEST или HOLIDAY INN EXPRESS AMSTERDAM ARENA TOWERS

БЕРЛИН : CENTRO PARK BERLIN или MERCURE BERLIN TEMPELHOF или TITANIC COMFORT MITTE

БЕРЛИН : NH BERLIN ALEXANDERPLATZ или MARITIM PROARTE BERLIN или MARITIM BERLIN

БЕРЛИН : GRAND CITY BERLIN EAST или ESTREL BERLIN

Мы знаем, насколько важны отели в вашей поездке. Отели были выбраны с учетом качества, цены и местоположения. Они расположены в городах, которые мы посещаем, большинство из них не в центре города, но все они находятся рядом с остановками общественного транспорта. Наше размещение не основано на роскошных отелях. Пожалуйста, имейте в виду, что стандарты, размеры кроватей и размеры номеров могут различаться в отелях одного класса в разных местах. Все номера оборудованы ванной комнатой и телевизором. Некоторые из них также предлагают мини-бар, сейф и фен. Во многих отелях, в основном в Северной Европе, нет кондиционеров или местное законодательство устанавливает ограниченные сроки использования.')
INSERT [dbo].[included] ([included], [tour_id], [inclusion_id], [included_choice], [included_description]) VALUES (4, 9, 2, 1, N'Англоязычный тур в: АМСТЕРДАМ, БЕРЛИН

Также обратите внимание, что ваш гид может меняться один или несколько раз во время тура. В некоторых турах, в зависимости от количества пассажиров, услуги могут предоставляться на двух языках (обычно на английском и испанском) либо в сопровождении двух туроператоров, по одному на каждый язык, либо одного туроператора для небольших групп, объясняющего на обоих языках.')
INSERT [dbo].[included] ([included], [tour_id], [inclusion_id], [included_choice], [included_description]) VALUES (5, 9, 3, 1, N'Базовая страховка включена в этот тур. Политика вступает в силу по прибытии в пункт назначения, в начале обслуживания Europamundo и заканчивается, когда маршрут, организованный нашей компанией, заканчивается.')
INSERT [dbo].[included] ([included], [tour_id], [inclusion_id], [included_choice], [included_description]) VALUES (6, 9, 4, 1, N'Завтрак "шведский стол"')
INSERT [dbo].[included] ([included], [tour_id], [inclusion_id], [included_choice], [included_description]) VALUES (7, 9, 5, 1, N'Обзорная экскурсия по городу: АМСТЕРДАМ, БЕРЛИН

Входные билеты: Мастерская огранки алмазов в Амстердаме в АМСТЕРДАМЕ, Мемориал Холокоста и Музей Берлинской стены в Берлине в БЕРЛИНЕ')
INSERT [dbo].[included] ([included], [tour_id], [inclusion_id], [included_choice], [included_description]) VALUES (8, 9, 6, 1, N'Включает трансфер по прибытии

Вечерний трансфер: Квартал красных фонарей в Амстердаме, район Кантштрассе в Берлине.')
INSERT [dbo].[included] ([included], [tour_id], [inclusion_id], [included_choice], [included_description]) VALUES (9, 9, 7, 0, N'Полеты не включены.')
INSERT [dbo].[included] ([included], [tour_id], [inclusion_id], [included_choice], [included_description]) VALUES (11, 9, 8, 0, N'КОНЦЕНТРАЦИОННЫЙ ЛАГЕРЬ ЗАКЗЕНХАУЗЕН T18 (4 часа)(30 евро)

В этом визите мы узнаем часть нашей современной истории. Это концентрационный лагерь, а не лагерь смерти. Когда он был создан в 1936 году, он стал «университетом» для членов СС, которым затем пришлось контролировать другие области. В нем мы увидим пример того, что представляли собой бараки, где заключенные жили бедно, изолированные карцеры, амбулатория смерти, применение он имел в течение всего нацистского периода и в последующие времена. - Автобус туда и обратно из Берлина. - Посещение и объяснения с местным гидом. Требуется 15 человек.


ПОТСДАМ Т18 (5 часов)(40 евро)

Небольшая столица земли Бранденбург, расположенная недалеко от Берлина, рядом с рекой Гафель, место проведения конференции, на которой Сталин, Трумэн и Черчилль определяют судьбы человечества с конца Второй мировой войны до падения Берлинской стены. Он также известен своим дворцом Сан-Суси, где мы прогуляемся по прекрасным садам «Немецкого Версаля», объекта Всемирного наследия ЮНЕСКО, а также снаружи посетим дворец Цецилиенхоф, где были подписаны Потсдамские договоры. Мы совершим круиз по озеру Ванзее, где 20 января 1942 года нацистское правительство одобрило «окончательное решение» еврейского вопроса, пересекая прекрасный жилой район Берлина с его старинными особняками, принадлежавшими бывшим высокопоставленным чиновникам режима, расположенным вдоль несколько озер, которые ведут нас к знаменитому"


КОНЦЕНТРАЦИОННЫЙ ЛАГЕРЬ ЗАКЗЕНХАУЗЕН T19 (4 часа) (30 евро)

В этом визите мы узнаем часть нашей современной истории. Это концентрационный лагерь, а не лагерь смерти. Когда он был создан в 1936 году, он стал «университетом» для членов СС, которым затем пришлось контролировать другие области. В нем мы увидим пример того, что представляли собой бараки, где заключенные жили бедно, изолированные карцеры, амбулатория смерти, применение он имел в течение всего нацистского периода и в последующие времена. ВЪЕЗД ДЕТЕЙ ДО 12 ЛЕТ ЗАПРЕЩЕН - Автобус туда и обратно из Берлина. - Посещение и объяснения с местным гидом. Требуется 15 человек.')
INSERT [dbo].[included] ([included], [tour_id], [inclusion_id], [included_choice], [included_description]) VALUES (12, 9, 5, 0, N'Другие виды деятельности и услуги не включены.')
SET IDENTITY_INSERT [dbo].[included] OFF
GO
SET IDENTITY_INSERT [dbo].[inclusions] ON 

INSERT [dbo].[inclusions] ([inclusion_id], [inclusion_name]) VALUES (1, N'Проживание')
INSERT [dbo].[inclusions] ([inclusion_id], [inclusion_name]) VALUES (2, N'Руководство')
INSERT [dbo].[inclusions] ([inclusion_id], [inclusion_name]) VALUES (3, N'Страхование')
INSERT [dbo].[inclusions] ([inclusion_id], [inclusion_name]) VALUES (4, N'Питание')
INSERT [dbo].[inclusions] ([inclusion_id], [inclusion_name]) VALUES (5, N'Дополнительные услуги')
INSERT [dbo].[inclusions] ([inclusion_id], [inclusion_name]) VALUES (6, N'Транспорт')
INSERT [dbo].[inclusions] ([inclusion_id], [inclusion_name]) VALUES (7, N'Рейсы')
INSERT [dbo].[inclusions] ([inclusion_id], [inclusion_name]) VALUES (8, N'По желанию')
INSERT [dbo].[inclusions] ([inclusion_id], [inclusion_name]) VALUES (9, N'COVID-19 Меры по хоране здоровья и безопасности')
SET IDENTITY_INSERT [dbo].[inclusions] OFF
GO
SET IDENTITY_INSERT [dbo].[itirerary] ON 

INSERT [dbo].[itirerary] ([itinerary], [tour_id], [day_num], [itinerary_name], [itirarary_description]) VALUES (1, 9, 1, N'Амстердам', N'Добро пожаловать в Европамундо!. Трансфер в отель и свободное время. Информацию о начале трассы вы получите во второй половине дня или сможете проверить информационные табло на стойке регистрации отеля.')
INSERT [dbo].[itirerary] ([itinerary], [tour_id], [day_num], [itinerary_name], [itirarary_description]) VALUES (2, 9, 2, N'Амстердам', N'ГЛАВНОЕ СЕГОДНЯ: Живописная типичная деревня Волендам. Лодка на озере I Jsselmeer. Обзорная экскурсия по Амстердаму. Сегодня у нас очень интересный и красивый день. Мы отправимся в ЗААНСЕ-СХАНС с его мельницами, каналами и типичными домами. ВОЛЕНДАМ, очень живописная рыбацкая деревня. Из Волендама на короткой лодке мы отправимся на МАРКЕН, остров, который был соединен с материком прочной дамбой, их дома были построены на сваях. Во второй половине дня мы включим панорамный тур по АМСТЕРДАМУ, чтобы увидеть его узкие каналы, площадь Дам, его официальные здания и парки, а также увидеть технику огранки алмазов. Переезд в район красных фонарей с его либеральными ценностями и многочисленными ресторанами со всех уголков мира. Вполне вероятно, что вы слышали об этом районе.')
INSERT [dbo].[itirerary] ([itinerary], [tour_id], [day_num], [itinerary_name], [itirarary_description]) VALUES (4, 9, 3, N'Амстердам, Гамельн, Берлин', N'ГЛАВНОЕ СЕГОДНЯ: Посетите деревню, прославившуюся благодаря детской сказке «Крысолов из Гамельна». Мы уезжаем из Амстердама в Германию. По пути мы остановимся в живописном немецком городке ХАМЕЛЕН. Здесь множество магазинов и улиц напоминают нам о городской легенде: Крысолов из Гамельна, написанной братьями Гримм. Мы продолжаем движение к БЕРЛИНУ, прибывая в конце дня.')
INSERT [dbo].[itirerary] ([itinerary], [tour_id], [day_num], [itinerary_name], [itirarary_description]) VALUES (5, 9, 4, N'Берлин', N'ГЛАВНОЕ СЕГОДНЯ: Обзорная экскурсия по Берлину. Мы посетим Мемориал Холокоста и музей Берлинской стены. Погрузитесь в местную культуру во время экскурсии по невероятной столице Германии Берлину. Мы посетим исторический центр, Музейный остров, Рейхстаг, Бранденбургские ворота и великолепные парки города. Мы продолжим наш визит, остановившись у Мемориала Холокоста и Музея Берлинской стены. Этот визит помогает нам понять сложную ситуацию, в которой находился город в ХХ веке. Время исследовать город. Проведите вечер в оживленном районе Кантштрассе, где можно пообедать в различных этнических ресторанах (индийских, восточных, итальянских, немецких и т. д.).')
INSERT [dbo].[itirerary] ([itinerary], [tour_id], [day_num], [itinerary_name], [itirarary_description]) VALUES (6, 9, 5, N'Берлин', N'После завтрака наши услуги заканчиваются.')
SET IDENTITY_INSERT [dbo].[itirerary] OFF
GO
SET IDENTITY_INSERT [dbo].[last_names] ON 

INSERT [dbo].[last_names] ([last_name_id], [last_name]) VALUES (1, N'Ермолаев')
INSERT [dbo].[last_names] ([last_name_id], [last_name]) VALUES (2, N'Наумов')
SET IDENTITY_INSERT [dbo].[last_names] OFF
GO
SET IDENTITY_INSERT [dbo].[order_rooms] ON 

INSERT [dbo].[order_rooms] ([order_rooms], [order_id], [room_id], [room_count]) VALUES (1, 1, 1, 1)
INSERT [dbo].[order_rooms] ([order_rooms], [order_id], [room_id], [room_count]) VALUES (2, 1, 2, 1)
SET IDENTITY_INSERT [dbo].[order_rooms] OFF
GO
SET IDENTITY_INSERT [dbo].[orders] ON 

INSERT [dbo].[orders] ([order_id], [departures_id], [contact_phone], [person_count], [price]) VALUES (1, 2, 89201182255, 5, CAST(2281.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[orders] OFF
GO
SET IDENTITY_INSERT [dbo].[persons] ON 

INSERT [dbo].[persons] ([person_id], [order_id], [first_name_id], [last_name_id], [city_id], [passport], [birthday]) VALUES (2, 1, 3, 1, NULL, 1234567890, CAST(N'2002-09-16' AS Date))
INSERT [dbo].[persons] ([person_id], [order_id], [first_name_id], [last_name_id], [city_id], [passport], [birthday]) VALUES (3, 1, 4, 1, NULL, 987654321, CAST(N'2000-05-25' AS Date))
SET IDENTITY_INSERT [dbo].[persons] OFF
GO
SET IDENTITY_INSERT [dbo].[rooms] ON 

INSERT [dbo].[rooms] ([room_id], [tour_id], [room_name], [beds_count], [price]) VALUES (1, 9, N'Двухместный номер', 2, CAST(370.00 AS Decimal(18, 2)))
INSERT [dbo].[rooms] ([room_id], [tour_id], [room_name], [beds_count], [price]) VALUES (2, 9, N'Трехместный номер', 3, CAST(347.00 AS Decimal(18, 2)))
INSERT [dbo].[rooms] ([room_id], [tour_id], [room_name], [beds_count], [price]) VALUES (3, 9, N'Oдноместный номер', 1, CAST(590.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[rooms] OFF
GO
SET IDENTITY_INSERT [dbo].[tours] ON 

INSERT [dbo].[tours] ([tour_id], [tour_name], [city_begin_id], [city_end_id], [price], [day_count], [max_group_size]) VALUES (9, N'Амстердам и Берлин', 2, 3, CAST(200.00 AS Decimal(18, 2)), 5, 50)
SET IDENTITY_INSERT [dbo].[tours] OFF
GO
ALTER TABLE [dbo].[accounts]  WITH CHECK ADD  CONSTRAINT [FK_accounts_first_names] FOREIGN KEY([first_name_id])
REFERENCES [dbo].[first_names] ([first_name_id])
GO
ALTER TABLE [dbo].[accounts] CHECK CONSTRAINT [FK_accounts_first_names]
GO
ALTER TABLE [dbo].[accounts]  WITH CHECK ADD  CONSTRAINT [FK_accounts_last_names] FOREIGN KEY([last_name_id])
REFERENCES [dbo].[last_names] ([last_name_id])
GO
ALTER TABLE [dbo].[accounts] CHECK CONSTRAINT [FK_accounts_last_names]
GO
ALTER TABLE [dbo].[cities]  WITH CHECK ADD  CONSTRAINT [FK_cities_countries] FOREIGN KEY([country_id])
REFERENCES [dbo].[countries] ([country_id])
GO
ALTER TABLE [dbo].[cities] CHECK CONSTRAINT [FK_cities_countries]
GO
ALTER TABLE [dbo].[departures]  WITH CHECK ADD  CONSTRAINT [FK_departures_tours] FOREIGN KEY([tour_id])
REFERENCES [dbo].[tours] ([tour_id])
GO
ALTER TABLE [dbo].[departures] CHECK CONSTRAINT [FK_departures_tours]
GO
ALTER TABLE [dbo].[included]  WITH CHECK ADD  CONSTRAINT [FK_included_inclusions] FOREIGN KEY([inclusion_id])
REFERENCES [dbo].[inclusions] ([inclusion_id])
GO
ALTER TABLE [dbo].[included] CHECK CONSTRAINT [FK_included_inclusions]
GO
ALTER TABLE [dbo].[included]  WITH CHECK ADD  CONSTRAINT [FK_included_tours] FOREIGN KEY([tour_id])
REFERENCES [dbo].[tours] ([tour_id])
GO
ALTER TABLE [dbo].[included] CHECK CONSTRAINT [FK_included_tours]
GO
ALTER TABLE [dbo].[itirerary]  WITH CHECK ADD  CONSTRAINT [FK_itirerary_tours] FOREIGN KEY([tour_id])
REFERENCES [dbo].[tours] ([tour_id])
GO
ALTER TABLE [dbo].[itirerary] CHECK CONSTRAINT [FK_itirerary_tours]
GO
ALTER TABLE [dbo].[order_rooms]  WITH CHECK ADD  CONSTRAINT [FK_order_rooms_orders1] FOREIGN KEY([order_id])
REFERENCES [dbo].[orders] ([order_id])
GO
ALTER TABLE [dbo].[order_rooms] CHECK CONSTRAINT [FK_order_rooms_orders1]
GO
ALTER TABLE [dbo].[order_rooms]  WITH CHECK ADD  CONSTRAINT [FK_order_rooms_rooms] FOREIGN KEY([room_id])
REFERENCES [dbo].[rooms] ([room_id])
GO
ALTER TABLE [dbo].[order_rooms] CHECK CONSTRAINT [FK_order_rooms_rooms]
GO
ALTER TABLE [dbo].[orders]  WITH CHECK ADD  CONSTRAINT [FK_orders_departures] FOREIGN KEY([departures_id])
REFERENCES [dbo].[departures] ([departure_id])
GO
ALTER TABLE [dbo].[orders] CHECK CONSTRAINT [FK_orders_departures]
GO
ALTER TABLE [dbo].[persons]  WITH CHECK ADD  CONSTRAINT [FK_persons_cities] FOREIGN KEY([city_id])
REFERENCES [dbo].[cities] ([city_id])
GO
ALTER TABLE [dbo].[persons] CHECK CONSTRAINT [FK_persons_cities]
GO
ALTER TABLE [dbo].[persons]  WITH CHECK ADD  CONSTRAINT [FK_persons_first_names] FOREIGN KEY([first_name_id])
REFERENCES [dbo].[first_names] ([first_name_id])
GO
ALTER TABLE [dbo].[persons] CHECK CONSTRAINT [FK_persons_first_names]
GO
ALTER TABLE [dbo].[persons]  WITH CHECK ADD  CONSTRAINT [FK_persons_last_names] FOREIGN KEY([last_name_id])
REFERENCES [dbo].[last_names] ([last_name_id])
GO
ALTER TABLE [dbo].[persons] CHECK CONSTRAINT [FK_persons_last_names]
GO
ALTER TABLE [dbo].[persons]  WITH CHECK ADD  CONSTRAINT [FK_persons_orders] FOREIGN KEY([order_id])
REFERENCES [dbo].[orders] ([order_id])
GO
ALTER TABLE [dbo].[persons] CHECK CONSTRAINT [FK_persons_orders]
GO
ALTER TABLE [dbo].[rooms]  WITH CHECK ADD  CONSTRAINT [FK_rooms_tours] FOREIGN KEY([tour_id])
REFERENCES [dbo].[tours] ([tour_id])
GO
ALTER TABLE [dbo].[rooms] CHECK CONSTRAINT [FK_rooms_tours]
GO
ALTER TABLE [dbo].[tours]  WITH CHECK ADD  CONSTRAINT [FK_tours_cities] FOREIGN KEY([city_begin_id])
REFERENCES [dbo].[cities] ([city_id])
GO
ALTER TABLE [dbo].[tours] CHECK CONSTRAINT [FK_tours_cities]
GO
ALTER TABLE [dbo].[tours]  WITH CHECK ADD  CONSTRAINT [FK_tours_cities1] FOREIGN KEY([city_end_id])
REFERENCES [dbo].[cities] ([city_id])
GO
ALTER TABLE [dbo].[tours] CHECK CONSTRAINT [FK_tours_cities1]
GO
