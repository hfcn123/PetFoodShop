create database tumie
go

use tumie
go

--pettype
create table pettype
(
PetID int primary key identity(1,1),--��������ID
PetName varchar(100)--������������
)
--�������ͱ��������
insert into pettype values('è')
insert into pettype values('��')
insert into pettype values('��')
insert into pettype values('��')
insert into pettype values('��')
select * from pettype
--������Ʒ�����
create table petInfo
(
Cid int primary key identity(1,1), --id
Cphoto varchar(200) not null,--ͼƬ
Cname varchar(200) not null,--����
Cprice float not null,--�۸�
CDescription varchar(100) not null,--����
CReviews  varchar(200) ,--�û�����
CTags varchar(100),--��ǩ
ISHeart int default(0),--�Ƿ��ղ�
Ctype int default(0) ,--״̬0ȫ����1��Ʒ��2�����3���ر�4�����ǿ�
PetID int references pettype(PetID)--���
)
--�����

--����
insert into petInfo values('/static/picture/001.png','Impulse ����',65,'���ǲ��Եĵ�һ��','�Ҽҵ�̩���ر�ϲ����','Petfood. Pet, Animal.',1,1,4)
insert into petInfo values('/static/picture/002.png','Driven ����',25,'���ǲ��Եĵ�2��','�Ҽҵ�̩���ر�ϲ����','Petfood. Pet, Animal.',1,1,4)
insert into petInfo values('/static/picture/003.png','Endeavor ����',33.0,'���ǹ���','�Ҽҵ�̩���ر�ϲ����','Petfood. Pet, Animal.',1,1,4)
insert into petInfo values('/static/picture/004.png','Fusion ����',20.19,'���ǹ���','�ҼҵĶ�ţ�ر�ϲ����','Petfood. Pet, Animal.',1,1,4)

--èè
insert into petInfo values('/static/picture/005.png','Endeavor è��',33.0,'����è��','�Ҽҵ�èè�ر�ϲ����','Petfood. Pet, Animal.',1,1,1)
insert into petInfo values('/static/picture/006.png','Fusion è��',20.19,'����è��','�Ҽҵ�èè�ر�ϲ����','Petfood. Pet, Animal.',1,1,1)
insert into petInfo values('/static/picture/007.png','Impulse è��',10.19,'����è��','�Ҽҵ�èè�ر�ϲ����','Petfood. Pet, Animal.',1,1,1)
insert into petInfo values('/static/picture/008.png','Driven è��',10.19,'����è��','�Ҽҵ�èè�ر�ϲ����','Petfood. Pet, Animal.',1,1,1)

--����
insert into petInfo values('/static/picture/009.png','Driven ����',10.19,'��������','�ҼҵĽ����ر�ϲ����','Petfood. Pet, Animal.',1,1,2)
insert into petInfo values('/static/picture/010.png','Impulse ����',10.19,'��������','�ҼҵĽ����ر�ϲ����','Petfood. Pet, Animal.',1,1,2)
insert into petInfo values('/static/picture/011.png','Fusion ����',10.19,'��������','�ҼҵĽ����ر�ϲ����','Petfood. Pet, Animal.',1,1,2)
insert into petInfo values('/static/picture/012.png','Endeavor ����',10.19,'��������','�ҼҵĽ����ر�ϲ����','Petfood. Pet, Animal.',1,1,2)
--����
insert into petInfo values('/static/picture/013.png','Fusion ����',10.19,'��������','�Ҽҵ�èè�ر�ϲ����','Petfood. Pet, Animal.',1,1,5)
insert into petInfo values('/static/picture/014.png','Driven ����',10.19,'��������','�Ҽҵ�èè�ر�ϲ����','Petfood. Pet, Animal.',1,1,5)
insert into petInfo values('/static/picture/015.png','Endeavor ����',10.19,'��������','�Ҽҵ�èè�ر�ϲ����','Petfood. Pet, Animal.',1,1,5)
insert into petInfo values('/static/picture/016.png','Impulse ����',10.19,'��������','�Ҽҵ�èè�ر�ϲ����','Petfood. Pet, Animal.',1,1,5)
--�û���
create table Userr
(
Usid int primary key identity(1,1),--��Ա���

UName varchar(200) not null,--��Ա����
Uimg varchar(200),
Tel varchar(20) ,--��Ա�绰
email varchar(100) not null,
Pwd varchar(200) not null,--����
sex varchar(10) ,--�Ա�
adress varchar(500),--��ַ
vipcode varchar(100) ,
onlinet int default(0) ,--0�����ߣ�1����
adminpwd int ,
adminid int default(0),--1�ǹ���Ա
)
insert into Userr  values ('����','','15303972158','895350055@','111111','��','����ʡ','',0,'',1)
insert into Userr  values ('����1','','15303972159','8584@','111111','Ů','����ʡ','',0,'',0)

--������
create table orderinfo(
ordid int primary key identity(1,1),
ordhao int  not null,
ordName varchar(100) not null,
ordcount int not null,
ordprice float not null,
ordcprice float not null,
usid int references Userr(Usid)
)


--���ﳵ��
create table cartinfo
(
cartid int primary key identity(1,1), ---��Ʒid
cartname varchar(200) not null,--���ﳵ-��Ʒ����
cartphoto varchar(200) not null,--���ﳵ-��ƷͼƬ
cartprice float not null,--���ﳵ��Ʒ�۸�
cartcount int not null,--��Ʒ����
cid int references petInfo (Cid),--��Ʒ���
useid int  references Userr (Usid),--�û����

)
insert into cartinfo values('��һ�����ﳵ��Ʒ','/cartimg/img/cartdog01.png',18.58,1,1,1)
insert into cartinfo values('��2�����ﳵ��Ʒ','/cartimg/img/cartdog01.png',18.58,1,1,1)

--�����
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
--��Ʒ����
insert into single_product values('/static/picture/001.png','/static/picture/zl2-84.png','/static/picture/006.png','/static/picture/zl2-81.png',1,4)
insert into single_product values('/static/picture/002.png','/static/picture/zl2-84.png','/static/picture/cartdog02.png','/static/picture/zl2-81.png',2,4)
insert into single_product values('/static/picture/003.png','/static/picture/zl2-84.png','/static/picture/cartdog02.png','/static/picture/zl2-81.png',3,4)
insert into single_product values('/static/picture/004.png','/static/picture/zl2-84.png','/static/picture/cartdog02.png','/static/picture/zl2-81.png',4,4)
--��Ʒè��
insert into single_product values('/static/picture/005.png','/static/picture/004.png','/static/picture/003.png','/static/picture/002.png',5,1)
insert into single_product values('/static/picture/006.png','/static/picture/003.png','/static/picture/cartdog02.png','/static/picture/004',6,1)
insert into single_product values('/static/picture/007.png','/static/picture/zl2-84.png','/static/picture/cartdog02.png','/static/picture/zl2-81.png',7,1)
insert into single_product values('/static/picture/008.png','/static/picture/001.png','/static/picture/002.png','/static/picture/zl2-81.png',8,1)
--��Ʒ����
insert into single_product values('/static/picture/009.png','/static/picture/zl2-84.png','/static/picture/cartdog02.png','/static/picture/zl2-81.png',9,2)
insert into single_product values('/static/picture/010.png','/static/picture/zl2-84.png','/static/picture/cartdog02.png','/static/picture/zl2-81.png',10,2)
insert into single_product values('/static/picture/011.png','/static/picture/005.png','/static/picture/cartdog02.png','/static/picture/zl2-81.png',11,2)
insert into single_product values('/static/picture/012.png','/static/picture/zl2-84.png','/static/picture/005.png','/static/picture/zl2-81.png',12,2)
--��Ʒ����
insert into single_product values('/static/picture/013.png','/static/picture/zl2-84.png','/static/picture/cartdog02.png','/static/picture/zl2-81.png',13,5)
insert into single_product values('/static/picture/014.png','/static/picture/zl2-84.png','/static/picture/cartdog02.png','/static/picture/zl2-81.png',14,5)
insert into single_product values('/static/picture/015.png','/static/picture/zl2-84.png','/static/picture/cartdog02.png','/static/picture/zl2-81.png',15,5)
insert into single_product values('/static/picture/016.png','/static/picture/zl2-84.png','/static/picture/cartdog02.png','/static/picture/zl2-81.png',16,5)

select *from single_product
select * from petInfo
select * from cartinfo


--����
create table guangaoinfo
(
Gid int  primary key identity(1,1) ,
Gimg varchar(200) not null,
GName varchar(200) not null,
Gzhekou varchar(200) not null,
Gbiaoshi int  not null,
)
insert guangaoinfo values('/static/picture/12.png','����','50%�ۿ��Ż�',1)
insert guangaoinfo values('/static/picture/23.png','è��','50%�ۿ��Ż�',1)

select *from guangaoinfo
select *from Userr