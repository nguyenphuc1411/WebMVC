IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240409144243_initial'
)
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240409144243_initial'
)
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [ImageUser] nvarchar(max) NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240409144243_initial'
)
BEGIN
    CREATE TABLE [DanhMuc] (
        [DanhMucId] int NOT NULL IDENTITY,
        [TenDanhMuc] nvarchar(50) NOT NULL,
        [HinhAnh] nvarchar(255) NOT NULL,
        [TrangThai] bit NOT NULL,
        CONSTRAINT [PK_DanhMuc] PRIMARY KEY ([DanhMucId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240409144243_initial'
)
BEGIN
    CREATE TABLE [DonHang] (
        [DonHangId] int NOT NULL IDENTITY,
        [ThoiGianDat] datetime2 NOT NULL,
        [SDT] nvarchar(15) NOT NULL,
        [Note] nvarchar(max) NULL,
        [DiaChiGiaoHang] nvarchar(max) NOT NULL,
        [TrangThai] nvarchar(30) NOT NULL,
        [NguoiDungId] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_DonHang] PRIMARY KEY ([DonHangId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240409144243_initial'
)
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240409144243_initial'
)
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240409144243_initial'
)
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240409144243_initial'
)
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240409144243_initial'
)
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240409144243_initial'
)
BEGIN
    CREATE TABLE [SanPham] (
        [SanPhamId] int NOT NULL IDENTITY,
        [TenSanPham] nvarchar(200) NOT NULL,
        [Gia] int NOT NULL,
        [GiamGia] int NOT NULL,
        [ManHinh] real NOT NULL,
        [CameraSau] nvarchar(100) NOT NULL,
        [CameraSelfie] nvarchar(100) NOT NULL,
        [CPU] nvarchar(50) NOT NULL,
        [GPU] nvarchar(50) NOT NULL,
        [PIN] int NOT NULL,
        [RAM] int NOT NULL,
        [ROM] int NOT NULL,
        [HDH] nvarchar(20) NOT NULL,
        [XuatXu] nvarchar(30) NOT NULL,
        [MoTa] nvarchar(max) NOT NULL,
        [Kho] int NOT NULL,
        [HinhAnh] nvarchar(100) NOT NULL,
        [DanhMucId] int NULL,
        CONSTRAINT [PK_SanPham] PRIMARY KEY ([SanPhamId]),
        CONSTRAINT [FK_SanPham_DanhMuc_DanhMucId] FOREIGN KEY ([DanhMucId]) REFERENCES [DanhMuc] ([DanhMucId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240409144243_initial'
)
BEGIN
    CREATE TABLE [DanhGia] (
        [DanhGiaId] int NOT NULL IDENTITY,
        [SoSao] int NOT NULL,
        [ThoiGian] datetime2 NOT NULL,
        [NoiDung] nvarchar(max) NULL,
        [NguoiDungId] nvarchar(max) NOT NULL,
        [SanPhamId] int NULL,
        CONSTRAINT [PK_DanhGia] PRIMARY KEY ([DanhGiaId]),
        CONSTRAINT [FK_DanhGia_SanPham_SanPhamId] FOREIGN KEY ([SanPhamId]) REFERENCES [SanPham] ([SanPhamId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240409144243_initial'
)
BEGIN
    CREATE TABLE [DonHangChiTiet] (
        [ChiTietId] int NOT NULL IDENTITY,
        [SoLuong] int NOT NULL,
        [SanPhamId] int NULL,
        [DonHangId] int NOT NULL,
        CONSTRAINT [PK_DonHangChiTiet] PRIMARY KEY ([ChiTietId]),
        CONSTRAINT [FK_DonHangChiTiet_DonHang_DonHangId] FOREIGN KEY ([DonHangId]) REFERENCES [DonHang] ([DonHangId]) ON DELETE CASCADE,
        CONSTRAINT [FK_DonHangChiTiet_SanPham_SanPhamId] FOREIGN KEY ([SanPhamId]) REFERENCES [SanPham] ([SanPhamId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240409144243_initial'
)
BEGIN
    CREATE TABLE [GioHang] (
        [GioHangId] int NOT NULL IDENTITY,
        [SoLuong] int NOT NULL,
        [SanPhamId] int NULL,
        [NguoiDungId] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_GioHang] PRIMARY KEY ([GioHangId]),
        CONSTRAINT [FK_GioHang_SanPham_SanPhamId] FOREIGN KEY ([SanPhamId]) REFERENCES [SanPham] ([SanPhamId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240409144243_initial'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] ON;
    EXEC(N'INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
    VALUES (N''bc213ce5-3a36-4a96-a334-8873d8aabefd'', NULL, N''Admin'', N''Admin''),
    (N''e7afa888-e8ad-4204-971f-f7b5e0224eb0'', NULL, N''Client'', N''Client'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240409144243_initial'
)
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240409144243_initial'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240409144243_initial'
)
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240409144243_initial'
)
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240409144243_initial'
)
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240409144243_initial'
)
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240409144243_initial'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240409144243_initial'
)
BEGIN
    CREATE INDEX [IX_DanhGia_SanPhamId] ON [DanhGia] ([SanPhamId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240409144243_initial'
)
BEGIN
    CREATE INDEX [IX_DonHangChiTiet_DonHangId] ON [DonHangChiTiet] ([DonHangId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240409144243_initial'
)
BEGIN
    CREATE INDEX [IX_DonHangChiTiet_SanPhamId] ON [DonHangChiTiet] ([SanPhamId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240409144243_initial'
)
BEGIN
    CREATE INDEX [IX_GioHang_SanPhamId] ON [GioHang] ([SanPhamId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240409144243_initial'
)
BEGIN
    CREATE INDEX [IX_SanPham_DanhMucId] ON [SanPham] ([DanhMucId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240409144243_initial'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240409144243_initial', N'8.0.3');
END;
GO

COMMIT;
GO

