create database tumie
go

use tumie
go

--pettype
create table pettype
(
PetID int primary key identity(1,1),--宠物类型ID
PetName varchar(100)--宠物类型名称
)
--宠物类型表插入数据
insert into pettype values('猫')
insert into pettype values('鱼')
insert into pettype values('鸟')
insert into pettype values('狗')
insert into pettype values('兔')
select * from pettype
--创建商品详情表
create table petInfo
(
Cid int primary key identity(1,1), --id
Cphoto varchar(200) not null,--图片
Cname varchar(200) not null,--名字
Cprice float not null,--价格
CDescription varchar(100) not null,--描述
CReviews  varchar(200) ,--用户评价
CTags varchar(100),--标签
ISHeart int default(0),--是否收藏
Ctype int default(0) ,--状态0全部，1新品，2畅销款，3，特别款，4，明星款
PetID int references pettype(PetID)--外键
)
--详情表

--狗狗
insert into petInfo values('/static/picture/001.png','Impulse 狗粮',65,'这是测试的第一条','我家的泰迪特别喜欢！','Petfood. Pet, Animal.',1,1,4)
insert into petInfo values('/static/picture/002.png','Driven 狗粮',25,'这是测试的第2条','我家的泰迪特别喜欢！','Petfood. Pet, Animal.',1,1,4)
insert into petInfo values('/static/picture/003.png','Endeavor 狗粮',33.0,'这是狗粮','我家的泰迪特别喜欢！','Petfood. Pet, Animal.',1,1,4)
insert into petInfo values('/static/picture/004.png','Fusion 狗粮',20.19,'这是狗粮','我家的斗牛特别喜欢！','Petfood. Pet, Animal.',1,1,4)

--猫猫
insert into petInfo values('/static/picture/005.png','Endeavor 猫粮',33.0,'这是猫粮','我家的猫猫特别喜欢！','Petfood. Pet, Animal.',1,1,1)
insert into petInfo values('/static/picture/006.png','Fusion 猫粮',20.19,'这是猫粮','我家的猫猫特别喜欢！','Petfood. Pet, Animal.',1,1,1)
insert into petInfo values('/static/picture/007.png','Impulse 猫粮',10.19,'这是猫粮','我家的猫猫特别喜欢！','Petfood. Pet, Animal.',1,1,1)
insert into petInfo values('/static/picture/008.png','Driven 猫粮',10.19,'这是猫粮','我家的猫猫特别喜欢！','Petfood. Pet, Animal.',1,1,1)

--金鱼
insert into petInfo values('/static/picture/009.png','Driven 鱼粮',10.19,'这是鱼粮','我家的金鱼特别喜欢！','Petfood. Pet, Animal.',1,1,2)
insert into petInfo values('/static/picture/010.png','Impulse 鱼粮',10.19,'这是鱼粮','我家的金鱼特别喜欢！','Petfood. Pet, Animal.',1,1,2)
insert into petInfo values('/static/picture/011.png','Fusion 鱼粮',10.19,'这是鱼粮','我家的金鱼特别喜欢！','Petfood. Pet, Animal.',1,1,2)
insert into petInfo values('/static/picture/012.png','Endeavor 鱼粮',10.19,'这是鱼粮','我家的金鱼特别喜欢！','Petfood. Pet, Animal.',1,1,2)
--兔兔
insert into petInfo values('/static/picture/013.png','Fusion 兔粮',10.19,'这是兔粮','我家的猫猫特别喜欢！','Petfood. Pet, Animal.',1,1,5)
insert into petInfo values('/static/picture/014.png','Driven 兔粮',10.19,'这是兔粮','我家的猫猫特别喜欢！','Petfood. Pet, Animal.',1,1,5)
insert into petInfo values('/static/picture/015.png','Endeavor 兔粮',10.19,'这是兔粮','我家的猫猫特别喜欢！','Petfood. Pet, Animal.',1,1,5)
insert into petInfo values('/static/picture/016.png','Impulse 兔粮',10.19,'这是兔粮','我家的猫猫特别喜欢！','Petfood. Pet, Animal.',1,1,5)
--用户表
create table Userr
(
Usid int primary key identity(1,1),--会员编号

UName varchar(200) not null,--会员姓名
Uimg varchar(200),
Tel varchar(20) ,--会员电话
email varchar(100) not null,
Pwd varchar(200) not null,--密码
sex varchar(10) ,--性别
adress varchar(500),--地址
vipcode varchar(100) ,
onlinet int default(0) ,--0不在线，1在线
adminpwd int ,
adminid int default(0),--1是管理员
)
insert into Userr  values ('测试','','15303972158','895350055@','111111','男','河南省','',0,'',1)
insert into Userr  values ('测试1','','15303972159','8584@','111111','女','河南省','',0,'',0)

--订单表
create table orderinfo(
ordid int primary key identity(1,1),
ordhao int  not null,
ordName varchar(100) not null,
ordcount int not null,
ordprice float not null,
ordcprice float not null,
usid int references Userr(Usid)
)


--购物车表
create table cartinfo
(
cartid int primary key identity(1,1), ---商品id
cartname varchar(200) not null,--购物车-商品名字
cartphoto varchar(200) not null,--购物车-商品图片
cartprice float not null,--购物车商品价格
cartcount int not null,--商品个数
cid int references petInfo (Cid),--商品编号
useid int  references Userr (Usid),--用户编号

)
insert into cartinfo values('第一个购物车商品','/cartimg/img/cartdog01.png',18.58,1,1,1)
insert into cartinfo values('第2个购物车商品','/cartimg/img/cartdog01.png',18.58,1,1,1)

--详情表
create table single_product
(
id int primary key identity(1,1),
picture varchar(200) not null,
picture1 varchar(200) not null,
picture2 varchar(200) not null,
picture3 varchar(200) not null,
Cid int references petInfo(Cid),
typeid int not null
)
--商品狗粮
insert into single_product values('/static/picture/001.png','/static/picture/zl2-84.png','/static/picture/006.png','/static/picture/zl2-81.png',1,4)
insert into single_product values('/static/picture/002.png','/static/picture/zl2-84.png','/static/picture/cartdog02.png','/static/picture/zl2-81.png',2,4)
insert into single_product values('/static/picture/003.png','/static/picture/zl2-84.png','/static/picture/cartdog02.png','/static/picture/zl2-81.png',3,4)
insert into single_product values('/static/picture/004.png','/static/picture/zl2-84.png','/static/picture/cartdog02.png','/static/picture/zl2-81.png',4,4)
--商品猫粮
insert into single_product values('/static/picture/005.png','/static/picture/004.png','/static/picture/003.png','/static/picture/002.png',5,1)
insert into single_product values('/static/picture/006.png','/static/picture/003.png','/static/picture/cartdog02.png','/static/picture/004',6,1)
insert into single_product values('/static/picture/007.png','/static/picture/zl2-84.png','/static/picture/cartdog02.png','/static/picture/zl2-81.png',7,1)
insert into single_product values('/static/picture/008.png','/static/picture/001.png','/static/picture/002.png','/static/picture/zl2-81.png',8,1)
--商品鱼粮
insert into single_product values('/static/picture/009.png','/static/picture/zl2-84.png','/static/picture/cartdog02.png','/static/picture/zl2-81.png',9,2)
insert into single_product values('/static/picture/010.png','/static/picture/zl2-84.png','/static/picture/cartdog02.png','/static/picture/zl2-81.png',10,2)
insert into single_product values('/static/picture/011.png','/static/picture/005.png','/static/picture/cartdog02.png','/static/picture/zl2-81.png',11,2)
insert into single_product values('/static/picture/012.png','/static/picture/zl2-84.png','/static/picture/005.png','/static/picture/zl2-81.png',12,2)
--商品兔粮
insert into single_product values('/static/picture/013.png','/static/picture/zl2-84.png','/static/picture/cartdog02.png','/static/picture/zl2-81.png',13,5)
insert into single_product values('/static/picture/014.png','/static/picture/zl2-84.png','/static/picture/cartdog02.png','/static/picture/zl2-81.png',14,5)
insert into single_product values('/static/picture/015.png','/static/picture/zl2-84.png','/static/picture/cartdog02.png','/static/picture/zl2-81.png',15,5)
insert into single_product values('/static/picture/016.png','/static/picture/zl2-84.png','/static/picture/cartdog02.png','/static/picture/zl2-81.png',16,5)

select *from single_product
select * from petInfo
select * from cartinfo


--广告表
create table guangaoinfo
(
Gid int  primary key identity(1,1) ,
Gimg varchar(200) not null,
GName varchar(200) not null,
Gzhekou varchar(200) not null,
Gbiaoshi int  not null,
)
insert guangaoinfo values('/static/picture/12.png','狗粮','50%折扣优惠',1)
insert guangaoinfo values('/static/picture/23.png','猫粮','50%折扣优惠',1)

select *from guangaoinfo
select *from Userr