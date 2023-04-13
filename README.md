# Todo

[√] Page index To Login ui

[√] Rememenberme

[√] Create a user with account

use accountinfo

	add RememenberMe to module

	add checkbox to page

	add if to cs

		ture

		persisit

		false

		lougout

use identity
	
return url


Boostrap
	
	可以试试
	
	灰色的背景

	不对称的登陆界面

	叠加

	变形

	重复



	g m p

BugFix

	! null


Autorize

	remenber me
		
		inPrivate

			manual logout

	---multiple

Namespace
	
	√



# HRsystem
用于测试人力资源管理系统
基于大数据的企业人力资源管理系统
  具体人力资源管理系统的功能如下:
  
  系统管理：该模块主要是添加或删除用户、用户的登录、用户密码重置、退出系统等；
  
  信息管理：该模块主要分为部门信息管理和员工信息管理。
  员工信息管理主要有员工基本信息管理、员工薪资信息管理、员工奖罚信息管理、员工培训信息管理等；
  
  信息查询：该模块主要分为部门信息查询和员工信息查询。
  员工信息查询主要有员工基本信息查询、员工薪资信息查询、员工奖罚信息查询、员工培训信息查询等。



# 使用步骤

1.安装 environment文件夹下的exe文件

- aspnetcore-runtime-6.0.15-win-x64

- windowsdesktop-runtime-6.0.15-win-x64

- SqlLocalDB


2.第一次安装创建环境

安装ef工具包

dotnet tool update --global dotnet-ef

配置数据库创建文件

dotnet ef migrations add Start

确认数据库是否正常安装

sqllocaldb v

sqllocaldb s


	如果无法启动
	安装environment\other\VC_redist.x64
	并在cmd中执行以下指令
	sqllocaldb delete MSSQLLocalDB
	sqllocaldb create MSSQLLocalDB
	sqllocaldb start MSSQLLocalDB

启动成功或者已经启动localdb后 cmd输入以下指令

创建locadb数据库

dotnet ef database update

上面为第一次安装创建环境的命令，

3.创建完之后每次开启本地服务器只需要以下指令

开启服务器

dotnet run

如果要关闭服务器

在cmd界面按

ctrl+c

管理员账号为202008

密码为1324

超管可以在accountinfo界面修改所有人的密码。

---以下为调试用指令，无需使用---

Update-Database

sql server对象资源管理器

添加 sql server MSSQLLocalDB

nuget 程序包管理控制台 

SQLExpress
SQLEXPRESS

C:\Windows\SysWOW64

win r
输入regsvr32 vcruntime140_1.dll，点击回车，注册dll

change git user name in vs2022