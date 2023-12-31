USE [BloodDonationAppDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7.08.2023 14:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 7.08.2023 14:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 7.08.2023 14:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 7.08.2023 14:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 7.08.2023 14:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 7.08.2023 14:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 7.08.2023 14:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 7.08.2023 14:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bloods]    Script Date: 7.08.2023 14:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bloods](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Bloods] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HospitalBloods]    Script Date: 7.08.2023 14:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HospitalBloods](
	[BloodId] [int] NOT NULL,
	[HospitalId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_HospitalBloods_1] PRIMARY KEY CLUSTERED 
(
	[BloodId] ASC,
	[HospitalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hospitals]    Script Date: 7.08.2023 14:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hospitals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](250) NULL,
	[Phone] [varchar](15) NULL,
 CONSTRAINT [PK_Hospitals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 7.08.2023 14:47:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Birthday] [date] NULL,
	[BloodId] [int] NULL,
	[Type] [varchar](25) NOT NULL,
	[HospitalId] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230722100734_Initial', N'7.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230722105928_added_identity_package', N'7.0.8')
GO
SET IDENTITY_INSERT [dbo].[Bloods] ON 

INSERT [dbo].[Bloods] ([Id], [Type]) VALUES (1, N'A Rh+')
INSERT [dbo].[Bloods] ([Id], [Type]) VALUES (2, N'B Rh+')
INSERT [dbo].[Bloods] ([Id], [Type]) VALUES (3, N'0 Rh+')
INSERT [dbo].[Bloods] ([Id], [Type]) VALUES (4, N'AB Rh+')
INSERT [dbo].[Bloods] ([Id], [Type]) VALUES (5, N'A Rh-')
INSERT [dbo].[Bloods] ([Id], [Type]) VALUES (6, N'B Rh-')
INSERT [dbo].[Bloods] ([Id], [Type]) VALUES (7, N'0 Rh-')
INSERT [dbo].[Bloods] ([Id], [Type]) VALUES (8, N'AB Rh-')
SET IDENTITY_INSERT [dbo].[Bloods] OFF
GO
INSERT [dbo].[HospitalBloods] ([BloodId], [HospitalId], [Quantity]) VALUES (1, 1, 25)
INSERT [dbo].[HospitalBloods] ([BloodId], [HospitalId], [Quantity]) VALUES (1, 4, 50)
INSERT [dbo].[HospitalBloods] ([BloodId], [HospitalId], [Quantity]) VALUES (1, 4004, 70)
INSERT [dbo].[HospitalBloods] ([BloodId], [HospitalId], [Quantity]) VALUES (1, 6004, 20)
INSERT [dbo].[HospitalBloods] ([BloodId], [HospitalId], [Quantity]) VALUES (2, 1, 13)
INSERT [dbo].[HospitalBloods] ([BloodId], [HospitalId], [Quantity]) VALUES (2, 4, 12)
INSERT [dbo].[HospitalBloods] ([BloodId], [HospitalId], [Quantity]) VALUES (3, 1, 0)
INSERT [dbo].[HospitalBloods] ([BloodId], [HospitalId], [Quantity]) VALUES (3, 2, 0)
INSERT [dbo].[HospitalBloods] ([BloodId], [HospitalId], [Quantity]) VALUES (3, 4, 100)
INSERT [dbo].[HospitalBloods] ([BloodId], [HospitalId], [Quantity]) VALUES (6, 4004, 100)
INSERT [dbo].[HospitalBloods] ([BloodId], [HospitalId], [Quantity]) VALUES (6, 5004, 5)
GO
SET IDENTITY_INSERT [dbo].[Hospitals] ON 

INSERT [dbo].[Hospitals] ([Id], [Name], [Address], [Phone]) VALUES (1, N'Merkezefendi Devlet Hastanesi', N'Manisa Yunusemre', N'+90123456789012')
INSERT [dbo].[Hospitals] ([Id], [Name], [Address], [Phone]) VALUES (2, N'Celal Bayar Hastanesi', N'Manisa', N'505 444 5500')
INSERT [dbo].[Hospitals] ([Id], [Name], [Address], [Phone]) VALUES (4, N'Hospital', N'Nişancıpaşa Mahallesi Şehzadeler/Manisa', N'0533 111 2222')
INSERT [dbo].[Hospitals] ([Id], [Name], [Address], [Phone]) VALUES (1004, N'Mediator CQRS Hastanesi', N'Komut ve sorguların ayrımı ', N'03138501111')
INSERT [dbo].[Hospitals] ([Id], [Name], [Address], [Phone]) VALUES (2004, N'8 Eylül Hastanesi', N'Uzunyol Mahallesi', N'0545 888 4545')
INSERT [dbo].[Hospitals] ([Id], [Name], [Address], [Phone]) VALUES (4004, N'Işık Hastanes', N'Işık mahallesi', N'1234567')
INSERT [dbo].[Hospitals] ([Id], [Name], [Address], [Phone]) VALUES (5004, N'Alisa Hastanesi', N'Alisa mahallesi', N'444 44 0000')
INSERT [dbo].[Hospitals] ([Id], [Name], [Address], [Phone]) VALUES (6004, N'Alp Hastanesiii', N'x adresi', N'1234567')
SET IDENTITY_INSERT [dbo].[Hospitals] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [LastName], [Username], [Password], [Email], [Birthday], [BloodId], [Type], [HospitalId]) VALUES (10, NULL, NULL, N'admin', N'123', NULL, NULL, NULL, N'Admin', NULL)
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Username], [Password], [Email], [Birthday], [BloodId], [Type], [HospitalId]) VALUES (11, N'Hospital', N'Hospital', N'hospital', N'123', NULL, NULL, NULL, N'Hospital', 4)
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Username], [Password], [Email], [Birthday], [BloodId], [Type], [HospitalId]) VALUES (12, N'User', N'Sample', N'user', N'123', N'sample@mail.com', CAST(N'2001-01-01' AS Date), 1, N'User', NULL)
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Username], [Password], [Email], [Birthday], [BloodId], [Type], [HospitalId]) VALUES (1005, N'Celal Bayar Hastanesi', N'Hospital', N'celalbayar', N'123', NULL, NULL, NULL, N'Hospital', 2)
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Username], [Password], [Email], [Birthday], [BloodId], [Type], [HospitalId]) VALUES (3005, N'Talha', N'Erdoğan', N'talha', N'123', N'aaa@gmail.com', CAST(N'2023-07-17' AS Date), 3, N'User', NULL)
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Username], [Password], [Email], [Birthday], [BloodId], [Type], [HospitalId]) VALUES (3006, N'Merkezefendi', N'Hospital', N'merkezefendi', N'123', NULL, NULL, NULL, N'Hospital', 1)
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Username], [Password], [Email], [Birthday], [BloodId], [Type], [HospitalId]) VALUES (4005, N'Hatice', N'Şahintürk', N'hatce', N'123', N'hatce@gmail.com', CAST(N'2023-07-22' AS Date), 1, N'User', NULL)
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Username], [Password], [Email], [Birthday], [BloodId], [Type], [HospitalId]) VALUES (7006, N'Işık Hastanesi', N'Hospital', N'isik', N'123', NULL, NULL, NULL, N'Hospital', 4004)
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Username], [Password], [Email], [Birthday], [BloodId], [Type], [HospitalId]) VALUES (8005, N'Halil', N'Alisa', N'halil', N'123', N'halil@example.com', CAST(N'2023-08-01' AS Date), 6, N'User', NULL)
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Username], [Password], [Email], [Birthday], [BloodId], [Type], [HospitalId]) VALUES (8006, N'Alisa', N'Hastanesi', N'alisa', N'123', NULL, NULL, NULL, N'Hospital', 5004)
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Username], [Password], [Email], [Birthday], [BloodId], [Type], [HospitalId]) VALUES (9005, N'Alperen', N'Alp', N'alperen', N'123', N'alperen.alp045@gmail.com', CAST(N'2023-08-07' AS Date), 1, N'User', NULL)
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Username], [Password], [Email], [Birthday], [BloodId], [Type], [HospitalId]) VALUES (9006, N'Alp', N'hastane', N'alphastane', N'123', NULL, NULL, NULL, N'Hospital', 6004)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[HospitalBloods]  WITH CHECK ADD  CONSTRAINT [FK_HospitalBloods_Bloods] FOREIGN KEY([BloodId])
REFERENCES [dbo].[Bloods] ([Id])
GO
ALTER TABLE [dbo].[HospitalBloods] CHECK CONSTRAINT [FK_HospitalBloods_Bloods]
GO
ALTER TABLE [dbo].[HospitalBloods]  WITH CHECK ADD  CONSTRAINT [FK_HospitalBloods_Hospitals1] FOREIGN KEY([HospitalId])
REFERENCES [dbo].[Hospitals] ([Id])
GO
ALTER TABLE [dbo].[HospitalBloods] CHECK CONSTRAINT [FK_HospitalBloods_Hospitals1]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Bloods] FOREIGN KEY([BloodId])
REFERENCES [dbo].[Bloods] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Bloods]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Hospitals] FOREIGN KEY([HospitalId])
REFERENCES [dbo].[Hospitals] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Hospitals]
GO
