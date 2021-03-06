USE [master]
GO
/****** Object:  Database [designPro]    Script Date: 12/7/2021 19:31:51 ******/
CREATE DATABASE [designPro]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'designPro', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\designPro.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'designPro_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\designPro_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [designPro] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [designPro].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [designPro] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [designPro] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [designPro] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [designPro] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [designPro] SET ARITHABORT OFF 
GO
ALTER DATABASE [designPro] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [designPro] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [designPro] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [designPro] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [designPro] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [designPro] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [designPro] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [designPro] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [designPro] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [designPro] SET  DISABLE_BROKER 
GO
ALTER DATABASE [designPro] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [designPro] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [designPro] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [designPro] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [designPro] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [designPro] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [designPro] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [designPro] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [designPro] SET  MULTI_USER 
GO
ALTER DATABASE [designPro] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [designPro] SET DB_CHAINING OFF 
GO
ALTER DATABASE [designPro] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [designPro] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [designPro] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [designPro] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [designPro] SET QUERY_STORE = OFF
GO
USE [designPro]
GO
/****** Object:  Table [dbo].[categoria]    Script Date: 12/7/2021 19:31:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoria](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_categoria] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[comentario]    Script Date: 12/7/2021 19:31:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comentario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idProyecto] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
	[contenido] [text] NULL,
 CONSTRAINT [PK_comentario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mensaje]    Script Date: 12/7/2021 19:31:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mensaje](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idUsuarioEmisor] [int] NOT NULL,
	[idUsuarioReceptor] [int] NOT NULL,
	[contenido] [text] NULL,
	[leido] [bit] NULL,
 CONSTRAINT [PK_mensaje] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proyecto]    Script Date: 12/7/2021 19:31:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proyecto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[titulo] [varchar](50) NULL,
	[visitas] [int] NULL,
	[rutaImgPortada] [text] NULL,
	[promedioValoraciones] [float] NULL,
	[fechaCreado] [date] NULL,
	[idCategoria] [int] NULL,
	[idUsuario] [int] NULL,
 CONSTRAINT [PK_proyecto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[seccion]    Script Date: 12/7/2021 19:31:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[seccion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idProyecto] [int] NULL,
	[contenidoTexto] [text] NULL,
	[rutaUrlImagen] [text] NULL,
	[rutaUrlVideo] [text] NULL,
 CONSTRAINT [PK_seccion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sigue]    Script Date: 12/7/2021 19:31:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sigue](
	[idSeguido] [int] NULL,
	[idSeguidor] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tag]    Script Date: 12/7/2021 19:31:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tag](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_tag] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tagProyecto]    Script Date: 12/7/2021 19:31:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tagProyecto](
	[idTag] [int] NOT NULL,
	[idProyecto] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 12/7/2021 19:31:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](75) NULL,
	[contrasenia] [varchar](50) NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](50) NULL,
	[fechaNac] [date] NULL,
	[pais] [varchar](50) NULL,
	[ciudad] [varchar](50) NULL,
	[rutaImgPerfil] [text] NULL,
	[profesion] [varchar](50) NULL,
	[empresa] [varchar](50) NULL,
	[urlSitioWebProfesional] [text] NULL,
	[descripcionPersonal] [text] NULL,
	[visitasTotales] [int] NULL,
	[promedioValoraciones] [float] NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[valoracion]    Script Date: 12/7/2021 19:31:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[valoracion](
	[idProyecto] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
	[valoracion] [float] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[comentario]  WITH CHECK ADD  CONSTRAINT [FK_comentario_proyecto] FOREIGN KEY([idProyecto])
REFERENCES [dbo].[proyecto] ([id])
GO
ALTER TABLE [dbo].[comentario] CHECK CONSTRAINT [FK_comentario_proyecto]
GO
ALTER TABLE [dbo].[comentario]  WITH CHECK ADD  CONSTRAINT [FK_comentario_usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[usuario] ([id])
GO
ALTER TABLE [dbo].[comentario] CHECK CONSTRAINT [FK_comentario_usuario]
GO
ALTER TABLE [dbo].[mensaje]  WITH CHECK ADD  CONSTRAINT [FK_mensaje_usuario] FOREIGN KEY([idUsuarioEmisor])
REFERENCES [dbo].[usuario] ([id])
GO
ALTER TABLE [dbo].[mensaje] CHECK CONSTRAINT [FK_mensaje_usuario]
GO
ALTER TABLE [dbo].[mensaje]  WITH CHECK ADD  CONSTRAINT [FK_mensaje_usuario1] FOREIGN KEY([idUsuarioReceptor])
REFERENCES [dbo].[usuario] ([id])
GO
ALTER TABLE [dbo].[mensaje] CHECK CONSTRAINT [FK_mensaje_usuario1]
GO
ALTER TABLE [dbo].[proyecto]  WITH CHECK ADD  CONSTRAINT [FK_proyecto_categoria] FOREIGN KEY([idCategoria])
REFERENCES [dbo].[categoria] ([id])
GO
ALTER TABLE [dbo].[proyecto] CHECK CONSTRAINT [FK_proyecto_categoria]
GO
ALTER TABLE [dbo].[proyecto]  WITH CHECK ADD  CONSTRAINT [FK_proyecto_usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[usuario] ([id])
GO
ALTER TABLE [dbo].[proyecto] CHECK CONSTRAINT [FK_proyecto_usuario]
GO
ALTER TABLE [dbo].[seccion]  WITH CHECK ADD  CONSTRAINT [FK_seccion_proyecto] FOREIGN KEY([idProyecto])
REFERENCES [dbo].[proyecto] ([id])
GO
ALTER TABLE [dbo].[seccion] CHECK CONSTRAINT [FK_seccion_proyecto]
GO
ALTER TABLE [dbo].[sigue]  WITH CHECK ADD  CONSTRAINT [FK_sigue_usuario] FOREIGN KEY([idSeguido])
REFERENCES [dbo].[usuario] ([id])
GO
ALTER TABLE [dbo].[sigue] CHECK CONSTRAINT [FK_sigue_usuario]
GO
ALTER TABLE [dbo].[sigue]  WITH CHECK ADD  CONSTRAINT [FK_sigue_usuario1] FOREIGN KEY([idSeguidor])
REFERENCES [dbo].[usuario] ([id])
GO
ALTER TABLE [dbo].[sigue] CHECK CONSTRAINT [FK_sigue_usuario1]
GO
ALTER TABLE [dbo].[tagProyecto]  WITH CHECK ADD  CONSTRAINT [FK_tagProyecto_proyecto] FOREIGN KEY([idProyecto])
REFERENCES [dbo].[proyecto] ([id])
GO
ALTER TABLE [dbo].[tagProyecto] CHECK CONSTRAINT [FK_tagProyecto_proyecto]
GO
ALTER TABLE [dbo].[tagProyecto]  WITH CHECK ADD  CONSTRAINT [FK_tagProyecto_tag] FOREIGN KEY([idTag])
REFERENCES [dbo].[tag] ([id])
GO
ALTER TABLE [dbo].[tagProyecto] CHECK CONSTRAINT [FK_tagProyecto_tag]
GO
ALTER TABLE [dbo].[valoracion]  WITH CHECK ADD  CONSTRAINT [FK_valoracion_proyecto] FOREIGN KEY([idProyecto])
REFERENCES [dbo].[proyecto] ([id])
GO
ALTER TABLE [dbo].[valoracion] CHECK CONSTRAINT [FK_valoracion_proyecto]
GO
ALTER TABLE [dbo].[valoracion]  WITH CHECK ADD  CONSTRAINT [FK_valoracion_usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[usuario] ([id])
GO
ALTER TABLE [dbo].[valoracion] CHECK CONSTRAINT [FK_valoracion_usuario]
GO

USE [designPro]
GO
INSERT INTO [dbo].[proyecto]
           ([titulo]
           ,[visitas]
           ,[rutaImgPortada]
           ,[promedioValoraciones]
           ,[fechaCreado]
           ,[idCategoria]
           ,[idUsuario])
     VALUES
           ('Galletitas Artesanales',14,'https://mir-s3-cdn-cf.behance.net/projects/404/16353249.548adff527f73.jpg',3,'2021-07-12',3,1),
		   ('Fertil Riego',1,'https://www.tierrafertil.com.mx/wp-content/uploads/2018/11/16-11-18RIEGO.jpg',4,'2021-07-05',1,2),
		   ('Blog de fotografía',11,'https://www.educadictos.com/wp-content/uploads/2018/04/blog-fotograf%C3%ADa.jpg',4,'2021-07-04',2,3),
		   ('Galletitas Artesanales',14,'https://mir-s3-cdn-cf.behance.net/projects/404/16353249.548adff527f73.jpg',3,'2021-07-12',3,1)
GO

USE [designPro]
GO
INSERT INTO [dbo].[usuario]
           ([email]
           ,[contrasenia]
           ,[nombre]
           ,[apellido]
           ,[fechaNac]
           ,[pais]
           ,[ciudad]
           ,[rutaImgPerfil]
           ,[profesion]
           ,[empresa]
           ,[urlSitioWebProfesional]
           ,[descripcionPersonal]
           ,[visitasTotales]
           ,[promedioValoraciones])
     VALUES
           ('juan@juan.com','aaaaaaaa','Juan','Juan','1997-05-12','Uruguay','maldonado','https://www.cucinare.tv/wp-content/uploads/2020/03/Galletitas-dulces.jpg','Chef','Galletitas artesanales','www.instagram.com','Soy un gran chef de galletitas',1,5),
		   ('eugenioperdomo627@gmail.com','bbbbbbbb','Eugenio','Perdomo','1997-06-12','Uruguay','maldonado','www.instagram.com','Programador','Fertil Riego','www.instagram.com','Soy un programador',1,5),
		   ('fran@fran.com','cccccccc','Fran','Sugo','1994-08-12','Uruguay','maldonado','www.instagram.com','Fotografo Amateur','Galletitas artesanales','www.instagram.com','Soy un fotografo',1,5)
GO

USE [designPro]
GO
INSERT INTO [dbo].[categoria]([nombre])VALUES
(StartUp),(Hobby),(Proyecto Independiente)
GO

USE [designPro]
GO
INSERT INTO [dbo].[comentario]([idProyecto],[idUsuario],[contenido])VALUES
(1,1,'Me gustan las galletas'),
(1,2,'Me encanta'),
(1,3,'Estas imagenes están muy buenas'),
(2,2,'No me lo puedo creer'),
(2,3,'Esta bastante bien')
GO

USE [designPro]
GO
INSERT INTO [dbo].[mensaje]([idUsuarioEmisor],[idUsuarioReceptor],[contenido],[leido])VALUES
(1,2,'Tu proyecto está fabuloso',1),
(1,3,'Buen día, ¿como estas?',0),
(2,1,'Gracias por el mensaje',1)
GO

USE [designPro]
GO
INSERT INTO [dbo].[seccion]([idProyecto],[contenidoTexto],[rutaUrlImagen],[rutaUrlVideo])VALUES
(1,'Emprendimiento de galletitas artesanales','https://d26lpennugtm8s.cloudfront.net/stores/093/780/products/42_1-7cfd9db5b839d6438615132721144302-1024-1024.jpeg','https://www.youtube.com/'),
(2,'Startup de riego para productores de mediana escala','http://ecuaplantas.com/wp-content/uploads/2019/05/r.f.-produccion-foto-3.JPG-400x400.jpeg','https://www.youtube.com/'),
(3,'Blog personal de fotografía de paisajes naturales','https://viapais.com.ar/resizer/biR7zCH6ZDriAnNVNf3zM1qlyKM=/1200x630/smart/cloudfront-us-east-1.images.arcpublishing.com/grupoclarin/JOEBU2GKOZF7DIEFA4IVKVJCFU.jpg','https://www.youtube.com/'),
(1,'Nuevas recetas todas las semanas','https://www.cucinare.tv/wp-content/uploads/2020/03/Galletitas-dulces.jpg','https://www.youtube.com/')
GO

USE [designPro]
GO
INSERT INTO [dbo].[tag]([nombre])VALUES
('Tecnología'),
('Matemática'),
('Culinario'),
('Turismo'),
('Arte'),
GO

USE [designPro]
GO
INSERT INTO [dbo].[tagProyecto]([idTag],[idProyecto])VALUES
(1,2),
(3,1),
(5,1),
(5,3)
GO

USE [designPro]
GO

INSERT INTO [dbo].[valoracion]([idProyecto],[idUsuario],[valoracion])VALUES
(1,1,5),
(2,1,4),
(3,2,4),
(2,2,5),
(1,2,2),
GO

USE [master]
GO
ALTER DATABASE [designPro] SET  READ_WRITE 
GO

