
create database PARKING
GO

USE PARKING
GO

--==================TẠO BẢNG VÀ CÁC RÀNG BUỘC==================
create table BaiXe(
	baixe_id char(10),
	Ten nvarchar(50),
	DiaChi nvarchar(200),
	SucChua int,
	primary key(baixe_id)
)
GO

create table LoaiTheXe(
	MaLoaiThe char(10),
	TenLoaiThe nvarchar(50),
	primary key(MaLoaiThe)
)
GO

create table LoaiXe(
	MaLoaiXe char(10),
	TenLoaiXe nvarchar(50),
	primary key(MaLoaiXe)
)
GO

create table KhachHang(
	kh_id char(10),
	ten nvarchar(50),
	sdt char(15) unique,
	primary key(kh_id)
)
GO

create table TheXe(
	MaTheXe char(10),
	baixe_id char(10),
	TrangThai nvarchar(50), -- 'Bị mất', 'Đang sử dụng', 'Sẵn sàng sử dụng'
	MaLoaiThe char(10),
	MaLoaiXe char(10),
	primary key(MaTheXe),
	constraint fk_tx_MaLoaiThe -- tên constraint: fk + tên bảng + tên khóa ngoại
		foreign key(MaLoaiThe) 
		references LoaiTheXe(MaLoaiThe)
		on delete cascade
		on update cascade,
	constraint fk_tx_baixe_id
		foreign key(baixe_id) 
		references BaiXe(baixe_id)
		on delete cascade
		on update cascade,
	constraint fk_tx_MaLoaiXe
		foreign key(MaLoaiXe) 
		references LoaiXe(MaLoaiXe)
		on delete cascade
		on update cascade
)
GO

create table DangKy(
	kh_id char(10),
	MaTheXe char(10),
	NgayCap datetime,
	NgayHetHan datetime,
	primary key(kh_id, MaTheXe),
	constraint fk_dk_kh_id
		foreign key(kh_id) references KhachHang(kh_id)
		on delete cascade 
		on update cascade,
	constraint fk_dk_MaTheXe
		foreign key(MaTheXe) references TheXe(MaTheXe)
		on delete cascade 
		on update cascade
)
GO

create table BangGia(
	MaLoaiGia char(10) primary key,
	TenLoaiGia nvarchar(50), -- VD: Giá gửi theo ngày, tuần, tháng - giá phạt theo ngày
	GiaTien real,
	NgayApDung datetime,
	MaLoaiXe char(10) references LoaiXe(MaLoaiXe)
)
GO

create table Xe(
	BienSo varchar(10),
	AnhTruoc image,
	AnhSau image,
	ThoiGianVao datetime,
	ThoiGianRa datetime,
	MaTheXe char(10),
	MaLoaiXe char(10),
	baixe_id char(10)
)
go

alter table Xe
	with check add constraint fk_check_baixe
	foreign key(baixe_id) references BaiXe(baixe_id)
go

alter table Xe
	with check add constraint fk_check_thexe
	foreign key(MaTheXe) references TheXe(MaTheXe)
go

alter table Xe
	with check add constraint fk_check_maloaixe
	foreign key(MaLoaiXe) references LoaiXe(MaLoaiXe)
go

create table NhanVien(
	id char(10),
	Ten nvarchar(50),
	SDT bigint,
	ngayvao datetime,
	ngaynghi datetime,
	tendangnhap varchar(50),
	matkhau varchar(50),
	quyen varchar(50),
	baixe_id char(10),
	primary key(id),
	constraint fk_user_baixe_id
		foreign key(baixe_id) 
		references BaiXe(baixe_id)
		on update cascade
		on delete cascade
)
GO

create table HoaDon(
	maHD char(10) primary key,
	tregio int,
	tongtien real,
	ngayin datetime,
	ghichu nvarchar(200),
	mathexe char(10) references TheXe(MaTheXe)
)
GO

--==================1. CÁC VIEW CHO NHÂN VIÊN==================

-- 2. View khách hàng
create view view_KhachHang as
	select kh_id as [Mã KH], ten as [Tên KH], sdt as [SĐT]
	from KhachHang
GO

-- 3. View đăng ký
create view view_DangKy
as
	select DangKy.kh_id as N'Mã KH', ten as N'Tên Khách Hàng',DangKy.MaTheXe as N'Mã thẻ xe',
	TenLoaiThe as N'Tên loại thẻ', NgayCap as N'Ngày cấp',NgayHethan as N'Ngày hết hạn', TrangThai as N'Trạng thái thẻ'
	from DangKy inner join TheXe on TheXe.MaTheXe=DangKy.MaTheXe
	inner join LoaiTheXe on LoaiTheXe.MaLoaiThe=TheXe.MaLoaiThe
	inner join KhachHang on KhachHang.kh_id=DangKy.kh_id
GO

-- 4. View loại xe
create view view_Loaixe
as
	select * from LoaiXe
GO

-- 5. View bảng giá
create view view_BangGia 
as
	select MaLoaiGia as N'Mã loại giá', TenLoaiGia as N'Tên loại giá', GiaTien as N'Giá tiền', NgayApDung as N'Ngày áp dụng',
	TenLoaiXe as N'Tên loại xe'
	from BangGia inner join LoaiXe
	on LoaiXe.MaLoaiXe=BangGia.MaloaiXe
GO

--==================THÊM DATA==================
insert into KhachHang (kh_id, ten, sdt) values ('KH00001', N'Lưu Văn Cụi', '7926172287');
insert into KhachHang (kh_id, ten, sdt) values ('KH00002', N'Nguyễn Ngọc Trung Hiếu', '1183284099');
insert into KhachHang (kh_id, ten, sdt) values ('KH00003', N'Nguyễn Văn A', '4548553792');
insert into KhachHang (kh_id, ten, sdt) values ('KH00004', N'Trần Thị Bích', '3478308067');
insert into KhachHang (kh_id, ten, sdt) values ('KH00005', N'Dương Trung Bảo', '4935423982');
insert into KhachHang (kh_id, ten, sdt) values ('KH00006', N'Võ Trần Minh Quân', '4218391566');
insert into KhachHang (kh_id, ten, sdt) values ('KH00007', N'Nguyễn Huỳnh Minh Tiến', '3062655849');
insert into KhachHang (kh_id, ten, sdt) values ('KH00008', N'Trần Quang Đại', '4847215936');
insert into KhachHang (kh_id, ten, sdt) values ('KH00009', N'Dương Cẩm Tú', '5546206179');
insert into KhachHang (kh_id, ten, sdt) values ('KH00010', N'Đặng Minh Toàn', '9682733956');

insert into LoaiXe values('XM', N'Xe máy');
insert into LoaiXe values('XD', N'Xe đạp');
insert into LoaiXe values('XH', N'Xe hơi');

insert into BangGia values('GiuXD', N'Giá giữ xe đạp', 3000, '2021-01-05 11:01:26.423', 'XD');
insert into BangGia values('GiuXM', N'Giá giữ xe máy', 5000, '2021-01-05 11:01:26.423', 'XM');
insert into BangGia values('GiuXH', N'Giá giữ xe hơi', 20000, '2021-01-05 11:01:26.423', 'XH');
insert into BangGia values('PhatXD', N'Giá phạt xe đạp', 20000, '2021-01-05 11:01:26.423', 'XD');
insert into BangGia values('PhatXM', N'Giá phạt xe máy', 50000, '2021-01-05 11:01:26.423', 'XM');
insert into BangGia values('PhatXH', N'Giá phạt xe hơi', 200000, '2021-01-05 11:01:26.423', 'XH');

insert into BaiXe values('spktA', N'SPKT A', N'Khu A, DH SPKT, Thủ Đức, HCM', 500);
insert into BaiXe values('spktB', N'SPKT B', N'Khu B, DH SPKT, Thủ Đức, HCM', 400);
insert into BaiXe values('spktC', N'SPKT C', N'Khu C, DH SPKT, Thủ Đức, HCM', 600);

insert into LoaiTheXe (MaLoaiThe, TenLoaiThe) values ('TheTuan', N'Thẻ Tuần');
insert into LoaiTheXe (MaLoaiThe, TenLoaiThe) values ('TheThang', N'Thẻ Tháng');
insert into LoaiTheXe (MaLoaiThe, TenLoaiThe) values ('VangLai', N'Vãng Lai');

insert into TheXe values('AM_XD0001', 'spktA', N'Sẵn sàng sử dụng', 'TheThang', 'XD');
insert into TheXe values('AM_XD0002', 'spktA', N'Sẵn sàng sử dụng', 'TheThang', 'XD');
insert into TheXe values('AM_XD0003', 'spktA', N'Sẵn sàng sử dụng', 'TheThang', 'XD');
insert into TheXe values('AM_XD0004', 'spktA', N'Sẵn sàng sử dụng', 'TheThang', 'XD');
insert into TheXe values('AM_XD0005', 'spktA', N'Sẵn sàng sử dụng', 'TheThang', 'XD');
insert into TheXe values('AM_XM0001', 'spktA', N'Sẵn sàng sử dụng', 'TheThang', 'XM');
insert into TheXe values('AM_XM0002', 'spktA', N'Sẵn sàng sử dụng', 'TheThang', 'XM');
insert into TheXe values('AM_XM0003', 'spktA', N'Sẵn sàng sử dụng', 'TheThang', 'XM');
insert into TheXe values('AM_XM0004', 'spktA', N'Sẵn sàng sử dụng', 'TheThang', 'XM');
insert into TheXe values('AM_XM0005', 'spktA', N'Sẵn sàng sử dụng', 'TheThang', 'XM');
insert into TheXe values('AM_XH0001', 'spktA', N'Sẵn sàng sử dụng', 'TheThang', 'XH');
insert into TheXe values('AM_XH0002', 'spktA', N'Sẵn sàng sử dụng', 'TheThang', 'XH');
insert into TheXe values('AM_XH0003', 'spktA', N'Sẵn sàng sử dụng', 'TheThang', 'XH');
insert into TheXe values('AM_XH0004', 'spktA', N'Sẵn sàng sử dụng', 'TheThang', 'XH');
insert into TheXe values('AM_XH0005', 'spktA', N'Sẵn sàng sử dụng', 'TheThang', 'XH');
insert into TheXe values('AW_XD0001', 'spktA', N'Sẵn sàng sử dụng', 'TheTuan', 'XD');
insert into TheXe values('AW_XD0002', 'spktA', N'Sẵn sàng sử dụng', 'TheTuan', 'XD');
insert into TheXe values('AW_XD0003', 'spktA', N'Sẵn sàng sử dụng', 'TheTuan', 'XD');
insert into TheXe values('AW_XD0004', 'spktA', N'Sẵn sàng sử dụng', 'TheTuan', 'XD');
insert into TheXe values('AW_XD0005', 'spktA', N'Sẵn sàng sử dụng', 'TheTuan', 'XD');
insert into TheXe values('AW_XM0001', 'spktA', N'Sẵn sàng sử dụng', 'TheTuan', 'XM');
insert into TheXe values('AW_XM0002', 'spktA', N'Sẵn sàng sử dụng', 'TheTuan', 'XM');
insert into TheXe values('AW_XM0003', 'spktA', N'Sẵn sàng sử dụng', 'TheTuan', 'XM');
insert into TheXe values('AW_XM0004', 'spktA', N'Sẵn sàng sử dụng', 'TheTuan', 'XM');
insert into TheXe values('AW_XM0005', 'spktA', N'Sẵn sàng sử dụng', 'TheTuan', 'XM');
insert into TheXe values('AW_XH0001', 'spktA', N'Sẵn sàng sử dụng', 'TheTuan', 'XH');
insert into TheXe values('AW_XH0002', 'spktA', N'Sẵn sàng sử dụng', 'TheTuan', 'XH');
insert into TheXe values('AW_XH0003', 'spktA', N'Sẵn sàng sử dụng', 'TheTuan', 'XH');
insert into TheXe values('AW_XH0004', 'spktA', N'Sẵn sàng sử dụng', 'TheTuan', 'XH');
insert into TheXe values('AW_XH0005', 'spktA', N'Sẵn sàng sử dụng', 'TheTuan', 'XH');
insert into TheXe values('AVL_XD001', 'spktA', N'Sẵn sàng sử dụng', 'VangLai', 'XD');
insert into TheXe values('AVL_XD002', 'spktA', N'Sẵn sàng sử dụng', 'VangLai', 'XD');
insert into TheXe values('AVL_XD003', 'spktA', N'Sẵn sàng sử dụng', 'VangLai', 'XD');
insert into TheXe values('AVL_XD004', 'spktA', N'Sẵn sàng sử dụng', 'VangLai', 'XD');
insert into TheXe values('AVL_XD005', 'spktA', N'Sẵn sàng sử dụng', 'VangLai', 'XD');
insert into TheXe values('AVL_XM001', 'spktA', N'Sẵn sàng sử dụng', 'VangLai', 'XM');
insert into TheXe values('AVL_XM002', 'spktA', N'Sẵn sàng sử dụng', 'VangLai', 'XM');
insert into TheXe values('AVL_XM003', 'spktA', N'Sẵn sàng sử dụng', 'VangLai', 'XM');
insert into TheXe values('AVL_XM004', 'spktA', N'Sẵn sàng sử dụng', 'VangLai', 'XM');
insert into TheXe values('AVL_XM005', 'spktA', N'Sẵn sàng sử dụng', 'VangLai', 'XM');
insert into TheXe values('AVL_XH001', 'spktA', N'Sẵn sàng sử dụng', 'VangLai', 'XH');
insert into TheXe values('AVL_XH002', 'spktA', N'Sẵn sàng sử dụng', 'VangLai', 'XH');
insert into TheXe values('AVL_XH003', 'spktA', N'Sẵn sàng sử dụng', 'VangLai', 'XH');
insert into TheXe values('AVL_XH004', 'spktA', N'Sẵn sàng sử dụng', 'VangLai', 'XH');
insert into TheXe values('AVL_XH005', 'spktA', N'Sẵn sàng sử dụng', 'VangLai', 'XH');

insert into TheXe values('BM_XD0001', 'spktB', N'Sẵn sàng sử dụng', 'TheThang', 'XD');
insert into TheXe values('BM_XD0002', 'spktB', N'Sẵn sàng sử dụng', 'TheThang', 'XD');
insert into TheXe values('BM_XD0003', 'spktB', N'Sẵn sàng sử dụng', 'TheThang', 'XD');
insert into TheXe values('BM_XD0004', 'spktB', N'Sẵn sàng sử dụng', 'TheThang', 'XD');
insert into TheXe values('BM_XD0005', 'spktB', N'Sẵn sàng sử dụng', 'TheThang', 'XD');
insert into TheXe values('BM_XM0001', 'spktB', N'Sẵn sàng sử dụng', 'TheThang', 'XM');
insert into TheXe values('BM_XM0002', 'spktB', N'Sẵn sàng sử dụng', 'TheThang', 'XM');
insert into TheXe values('BM_XM0003', 'spktB', N'Sẵn sàng sử dụng', 'TheThang', 'XM');
insert into TheXe values('BM_XM0004', 'spktB', N'Sẵn sàng sử dụng', 'TheThang', 'XM');
insert into TheXe values('BM_XM0005', 'spktB', N'Sẵn sàng sử dụng', 'TheThang', 'XM');
insert into TheXe values('BM_XH0001', 'spktB', N'Sẵn sàng sử dụng', 'TheThang', 'XH');
insert into TheXe values('BM_XH0002', 'spktB', N'Sẵn sàng sử dụng', 'TheThang', 'XH');
insert into TheXe values('BM_XH0003', 'spktB', N'Sẵn sàng sử dụng', 'TheThang', 'XH');
insert into TheXe values('BM_XH0004', 'spktB', N'Sẵn sàng sử dụng', 'TheThang', 'XH');
insert into TheXe values('BM_XH0005', 'spktB', N'Sẵn sàng sử dụng', 'TheThang', 'XH');
insert into TheXe values('BW_XD0001', 'spktB', N'Sẵn sàng sử dụng', 'TheTuan', 'XD');
insert into TheXe values('BW_XD0002', 'spktB', N'Sẵn sàng sử dụng', 'TheTuan', 'XD');
insert into TheXe values('BW_XD0003', 'spktB', N'Sẵn sàng sử dụng', 'TheTuan', 'XD');
insert into TheXe values('BW_XD0004', 'spktB', N'Sẵn sàng sử dụng', 'TheTuan', 'XD');
insert into TheXe values('BW_XD0005', 'spktB', N'Sẵn sàng sử dụng', 'TheTuan', 'XD');
insert into TheXe values('BW_XM0001', 'spktB', N'Sẵn sàng sử dụng', 'TheTuan', 'XM');
insert into TheXe values('BW_XM0002', 'spktB', N'Sẵn sàng sử dụng', 'TheTuan', 'XM');
insert into TheXe values('BW_XM0003', 'spktB', N'Sẵn sàng sử dụng', 'TheTuan', 'XM');
insert into TheXe values('BW_XM0004', 'spktB', N'Sẵn sàng sử dụng', 'TheTuan', 'XM');
insert into TheXe values('BW_XM0005', 'spktB', N'Sẵn sàng sử dụng', 'TheTuan', 'XM');
insert into TheXe values('BW_XH0001', 'spktB', N'Sẵn sàng sử dụng', 'TheTuan', 'XH');
insert into TheXe values('BW_XH0002', 'spktB', N'Sẵn sàng sử dụng', 'TheTuan', 'XH');
insert into TheXe values('BW_XH0003', 'spktB', N'Sẵn sàng sử dụng', 'TheTuan', 'XH');
insert into TheXe values('BW_XH0004', 'spktB', N'Sẵn sàng sử dụng', 'TheTuan', 'XH');
insert into TheXe values('BW_XH0005', 'spktB', N'Sẵn sàng sử dụng', 'TheTuan', 'XH');
insert into TheXe values('BVL_XD001', 'spktB', N'Sẵn sàng sử dụng', 'VangLai', 'XD');
insert into TheXe values('BVL_XD002', 'spktB', N'Sẵn sàng sử dụng', 'VangLai', 'XD');
insert into TheXe values('BVL_XD003', 'spktB', N'Sẵn sàng sử dụng', 'VangLai', 'XD');
insert into TheXe values('BVL_XD004', 'spktB', N'Sẵn sàng sử dụng', 'VangLai', 'XD');
insert into TheXe values('BVL_XD005', 'spktB', N'Sẵn sàng sử dụng', 'VangLai', 'XD');
insert into TheXe values('BVL_XM001', 'spktB', N'Sẵn sàng sử dụng', 'VangLai', 'XM');
insert into TheXe values('BVL_XM002', 'spktB', N'Sẵn sàng sử dụng', 'VangLai', 'XM');
insert into TheXe values('BVL_XM003', 'spktB', N'Sẵn sàng sử dụng', 'VangLai', 'XM');
insert into TheXe values('BVL_XM004', 'spktB', N'Sẵn sàng sử dụng', 'VangLai', 'XM');
insert into TheXe values('BVL_XM005', 'spktB', N'Sẵn sàng sử dụng', 'VangLai', 'XM');
insert into TheXe values('BVL_XH001', 'spktB', N'Sẵn sàng sử dụng', 'VangLai', 'XH');
insert into TheXe values('BVL_XH002', 'spktB', N'Sẵn sàng sử dụng', 'VangLai', 'XH');
insert into TheXe values('BVL_XH003', 'spktB', N'Sẵn sàng sử dụng', 'VangLai', 'XH');
insert into TheXe values('BVL_XH004', 'spktB', N'Sẵn sàng sử dụng', 'VangLai', 'XH');
insert into TheXe values('BVL_XH005', 'spktB', N'Sẵn sàng sử dụng', 'VangLai', 'XH');

insert into TheXe values('CM_XD0001', 'spktC', N'Sẵn sàng sử dụng', 'TheThang', 'XD');
insert into TheXe values('CM_XD0002', 'spktC', N'Sẵn sàng sử dụng', 'TheThang', 'XD');
insert into TheXe values('CM_XD0003', 'spktC', N'Sẵn sàng sử dụng', 'TheThang', 'XD');
insert into TheXe values('CM_XD0004', 'spktC', N'Sẵn sàng sử dụng', 'TheThang', 'XD');
insert into TheXe values('CM_XD0005', 'spktC', N'Sẵn sàng sử dụng', 'TheThang', 'XD');
insert into TheXe values('CM_XM0001', 'spktC', N'Sẵn sàng sử dụng', 'TheThang', 'XM');
insert into TheXe values('CM_XM0002', 'spktC', N'Sẵn sàng sử dụng', 'TheThang', 'XM');
insert into TheXe values('CM_XM0003', 'spktC', N'Sẵn sàng sử dụng', 'TheThang', 'XM');
insert into TheXe values('CM_XM0004', 'spktC', N'Sẵn sàng sử dụng', 'TheThang', 'XM');
insert into TheXe values('CM_XM0005', 'spktC', N'Sẵn sàng sử dụng', 'TheThang', 'XM');
insert into TheXe values('CM_XH0001', 'spktC', N'Sẵn sàng sử dụng', 'TheThang', 'XH');
insert into TheXe values('CM_XH0002', 'spktC', N'Sẵn sàng sử dụng', 'TheThang', 'XH');
insert into TheXe values('CM_XH0003', 'spktC', N'Sẵn sàng sử dụng', 'TheThang', 'XH');
insert into TheXe values('CM_XH0004', 'spktC', N'Sẵn sàng sử dụng', 'TheThang', 'XH');
insert into TheXe values('CM_XH0005', 'spktC', N'Sẵn sàng sử dụng', 'TheThang', 'XH');
insert into TheXe values('CW_XD0001', 'spktC', N'Sẵn sàng sử dụng', 'TheTuan', 'XD');
insert into TheXe values('CW_XD0002', 'spktC', N'Sẵn sàng sử dụng', 'TheTuan', 'XD');
insert into TheXe values('CW_XD0003', 'spktC', N'Sẵn sàng sử dụng', 'TheTuan', 'XD');
insert into TheXe values('CW_XD0004', 'spktC', N'Sẵn sàng sử dụng', 'TheTuan', 'XD');
insert into TheXe values('CW_XD0005', 'spktC', N'Sẵn sàng sử dụng', 'TheTuan', 'XD');
insert into TheXe values('CW_XM0001', 'spktC', N'Sẵn sàng sử dụng', 'TheTuan', 'XM');
insert into TheXe values('CW_XM0002', 'spktC', N'Sẵn sàng sử dụng', 'TheTuan', 'XM');
insert into TheXe values('CW_XM0003', 'spktC', N'Sẵn sàng sử dụng', 'TheTuan', 'XM');
insert into TheXe values('CW_XM0004', 'spktC', N'Sẵn sàng sử dụng', 'TheTuan', 'XM');
insert into TheXe values('CW_XM0005', 'spktC', N'Sẵn sàng sử dụng', 'TheTuan', 'XM');
insert into TheXe values('CW_XH0001', 'spktC', N'Sẵn sàng sử dụng', 'TheTuan', 'XH');
insert into TheXe values('CW_XH0002', 'spktC', N'Sẵn sàng sử dụng', 'TheTuan', 'XH');
insert into TheXe values('CW_XH0003', 'spktC', N'Sẵn sàng sử dụng', 'TheTuan', 'XH');
insert into TheXe values('CW_XH0004', 'spktC', N'Sẵn sàng sử dụng', 'TheTuan', 'XH');
insert into TheXe values('CW_XH0005', 'spktC', N'Sẵn sàng sử dụng', 'TheTuan', 'XH');
insert into TheXe values('CVL_XD001', 'spktC', N'Sẵn sàng sử dụng', 'VangLai', 'XD');
insert into TheXe values('CVL_XD002', 'spktC', N'Sẵn sàng sử dụng', 'VangLai', 'XD');
insert into TheXe values('CVL_XD003', 'spktC', N'Sẵn sàng sử dụng', 'VangLai', 'XD');
insert into TheXe values('CVL_XD004', 'spktC', N'Sẵn sàng sử dụng', 'VangLai', 'XD');
insert into TheXe values('CVL_XD005', 'spktC', N'Sẵn sàng sử dụng', 'VangLai', 'XD');
insert into TheXe values('CVL_XM001', 'spktC', N'Sẵn sàng sử dụng', 'VangLai', 'XM');
insert into TheXe values('CVL_XM002', 'spktC', N'Sẵn sàng sử dụng', 'VangLai', 'XM');
insert into TheXe values('CVL_XM003', 'spktC', N'Sẵn sàng sử dụng', 'VangLai', 'XM');
insert into TheXe values('CVL_XM004', 'spktC', N'Sẵn sàng sử dụng', 'VangLai', 'XM');
insert into TheXe values('CVL_XM005', 'spktC', N'Sẵn sàng sử dụng', 'VangLai', 'XM');
insert into TheXe values('CVL_XH001', 'spktC', N'Sẵn sàng sử dụng', 'VangLai', 'XH');
insert into TheXe values('CVL_XH002', 'spktC', N'Sẵn sàng sử dụng', 'VangLai', 'XH');
insert into TheXe values('CVL_XH003', 'spktC', N'Sẵn sàng sử dụng', 'VangLai', 'XH');
insert into TheXe values('CVL_XH004', 'spktC', N'Sẵn sàng sử dụng', 'VangLai', 'XH');
insert into TheXe values('CVL_XH005', 'spktC', N'Sẵn sàng sử dụng', 'VangLai', 'XH');

insert into NhanVien values('admin1', 'Nguyễn Văn A', 0932932934, null, null, 'admin', 'admin', 'admin', null)
insert into NhanVien values('nv1', 'Nguyễn Hiếu', 0938283923, '8/1/2020', null, 'nhanvien', '123', 'nhanvien', 'spktA')
insert into NhanVien values('nv2', 'Văn Cụi', 0322849343, '8/1/2020', null, 'nhanvien', '123', 'nhanvien', 'spktB')
insert into NhanVien values('nv3', 'Quang Đại', 0364948383, '8/1/2020', null, 'nhanvien', '123', 'nhanvien', 'spktC')
GO

--==================2. CÁC FUNCTION CHO NHÂN VIÊN==================

-- 2. Tìm kiếm tất cả thông tin trong bảng khách hàng
create function f_timKiemKhachHang(@query nvarchar(50))
	returns table 
	as return
		SELECT * FROM view_KhachHang 
		WHERE CONCAT([Mã KH], [Tên KH], 
		SĐT) 
		LIKE '%' + @query + '%'
GO

-- 3. Lấy tất cả các loại thẻ xe để đăng ký cho khách hàng, trừ thẻ cho khách vãng lai
create function f_layLoaiTheXeDangKy()
	returns table
	as return 
		select * from LoaiTheXe
		where MaLoaiThe != 'VangLai'
GO

-- 4. Lấy các thẻ xe ở trạng thái sẵn sàng sử dụng theo mã loại thẻ và bãi xe id
create function f_layMaTheXeTheoLoaiThe(@maloaithe char(10), @baixe_id char(10))
	returns table
	as return 
		select * from TheXe
		where MaLoaiThe = @maloaithe and baixe_id = @baixe_id 
			and TrangThai = N'Sẵn sàng sử dụng'
GO

-- 5. Tìm kiếm tất cả thông tin có trong view đăng ký
create function f_timKiemTrongViewDangKy(@query nvarchar(50))
	returns table 
	as return
		SELECT * FROM view_DangKy 
		WHERE CONCAT([Mã KH], [Tên Khách Hàng], 
		[Mã thẻ xe], [Tên loại thẻ], [Ngày cấp], [Ngày hết hạn], [Trạng thái thẻ]) 
		LIKE '%' + @query + '%'
GO

-- 6. Lấy tất cả các mã thẻ xe dành cho khách vãng lai với trạng thái sẵn sàng sử dụng của 1 bãi xe nào đó
create function f_maTheXeCheckInKhachVangLai(@baixeId char(10)) 
	returns table
	as return
		select * from TheXe
		where TrangThai=N'Sẵn sàng sử dụng'	and baixe_id = @baixeId and MaLoaiThe='VangLai'
GO

-- Lấy tất cả các mã thẻ xe dành cho khách đăng ký với trạng thái sẵn sàng sử dụng của 1 bãi xe nào đó
create function f_maTheXeCheckInKhachDangKy(@baixeId char(10)) 
	returns table
	as return
		-- Lấy tất cả các khách hàng đang đăng ký giữ xe trong bãi
		select tx.MaTheXe, tx.MaLoaiXe from TheXe tx, DangKy dk
		where tx.MaTheXe=dk.MaTheXe and
			tx.baixe_id = @baixeId and tx.TrangThai=N'Đang sử dụng'
			and tx.MaTheXe not in (-- Lấy tất cả các Mã thẻ xe đang được giữ trong bãi
									select tx.MaTheXe from TheXe tx, DangKy dk, Xe x
									where dk.MaTheXe=tx.MaTheXe and tx.MaTheXe=x.MaTheXe and
										tx.baixe_id=@baixeId and tx.TrangThai=N'Đang sử dụng' and 
										x.ThoiGianRa is null)

		
GO

-- 7. Lấy tất cả các mã thẻ xe với trạng thái đang sử dụng của 1 bãi xe nào đó
create function f_maTheXeCheckOut(@baixeId char(10)) 
	returns table
	as return
		select * from Xe 
		where baixe_id=@baixeId and ThoiGianRa is null
GO

-- 8. Hàm lấy xe ra, truyền vào mã thẻ xe, kết quả là thông tin của xe trong bãi cần lấy ra
create function f_layXeRa(@mathexe char(10)) 
	returns table
	as return 
		select * from Xe
		where MaTheXe=@mathexe and ThoiGianRa is null
GO

-- 9. Lấy tên loại xe cụ thể khi truyền vào mã loại xe
create function f_layTenLoaiXe(@maloaixe char(10))
	returns nvarchar(50)
	as begin
		declare @tenloaixe nvarchar(50)
		select @tenloaixe=TenLoaiXe from LoaiXe where MaLoaiXe=@maloaixe
		return @tenloaixe
	end
GO


-- Hàm lấy ra tên loại xe khi truyền mã thẻ xe vào
create function layTenLoaiXeTheoMaTheXe(@mathexe char(10)) 
	returns nvarchar(50)
	as begin
		declare @maloaixe char(10)
		
		select @maloaixe=MaLoaiXe 
		from TheXe where MaTheXe=@mathexe
		
		declare @tenloaixe nvarchar(50)
		set @tenloaixe = dbo.f_layTenLoaiXe(@maloaixe)
		return @tenloaixe
	end
GO

-- 10. Nhân viên xem bãi xe
create function f_NVXemTheXe(@baixeId char(10))
	returns table
	as return
		select MaTheXe as N'Mã thẻ',b.Ten as N'Tên bãi xe', TrangThai as N'Trạng thái', TenLoaiThe as N'Loại thẻ' 
		from TheXe
		inner join BaiXe as b
		on TheXe.baixe_id=b.baixe_id
		inner join LoaiTheXe
		on TheXe.MaLoaiThe= LoaiTheXe.MaLoaiThe
		where b.baixe_id = @baixeId
GO

-- 1. Tìm kiếm tất cả thông tin có trong view NV xem thẻ xe
create function f_timKiemTheXe(@query nvarchar(50), @baixeId char(10))
	returns table 
	as return
		SELECT * FROM f_NVXemTheXe(@baixeId)
		WHERE CONCAT([Mã thẻ], [Tên bãi xe], [Trạng thái], [Loại thẻ]) 
		LIKE '%' + @query + '%'
GO

-- Lấy giá tiền giữ xe
create function layGiaGiuXe(@maloaixe char(10), @maloaigia char(10)) 
	returns real
	as begin
		declare @giaTien real
		select @giaTien = GiaTien 
		from BangGia where MaLoaiXe=@maloaixe and MaLoaiGia=@maloaigia
		
		return @giaTien
	end
GO

-- Kiểm tra thẻ có phải là thẻ dành cho khách vãng lai hay không
create function laTheVangLai(@mathexe char(10))
	returns int
	begin
		if exists(select * from TheXe
			where MaLoaiThe='VangLai' and MaTheXe=@mathexe)
			return 1
		return 0
	end
GO

-- Tính số ngày trễ của thẻ xe đã đăng ký
create function f_soNgayTreCuaTheDangKy(@mathexe char(10))
	returns int
	as begin
		declare @ngayhethan datetime
		select @ngayhethan = dk.NgayHetHan from TheXe tx, DangKy dk
		where tx.MaTheXe=dk.MaTheXe and tx.MaTheXe=@mathexe
	
		declare @soNgayHetHan int
		set @soNgayHetHan = DATEDIFF (DAY, @ngayhethan, GETDATE())
		return @soNgayHetHan
	end
GO
--==================3. CÁC STORE PROCEDURE CHO NHÂN VIÊN==================

-- 1. Thêm khách hàng
create proc p_InsertKhachHang @id char(10), @name nvarchar(50), @phone char(15)
	as begin
		insert into KhachHang
		values(@id, @name, @phone)
	end
GO

-- 2. Cập nhật thông tin khách hàng
create proc p_updateKhachHang @id char(10), @name nvarchar(50), @phone char(15)
	as begin
		update KhachHang
		set	ten = @name, sdt = @phone
		where kh_id = @id
	end
GO

-- 3. Thêm dữ liệu vào bảng đăng ký
create proc p_insertDangKy 
	@kh_id char(10),
	@mathexe char(10),
	@ngaycap datetime,
	@ngayhethan datetime
	as begin
		insert into DangKy 
		values(@kh_id, @mathexe, @ngaycap, @ngayhethan)
	end
GO

-- 4. Cập nhật bảng đăng ký
create proc p_updateDangKy 
	@kh_id char(10),
	@mathexe char(10),
	@ngaycap datetime,
	@ngayhethan datetime
	as begin
		update DangKy
		set NgayCap = @ngaycap, NgayHetHan = @ngayhethan
		where kh_id = @kh_id and MaTheXe = @mathexe
	end
GO

-- 5. Cập nhật trạng thái của thẻ xe khi trả thẻ
create proc p_traTheXe
	@mathexe char(10)
	as begin
		declare @status nvarchar(50)
		select @status = TrangThai 
		from TheXe
		where MaTheXe = @mathexe

		if (@status = N'Sẵn sàng sử dụng')
			begin
				RAISERROR('Đã trả thẻ',16,1)
			end
		else 
			begin
				update TheXe 
				set TrangThai=N'Sẵn sàng sử dụng'
				where MaTheXe=@mathexe
			end
	end
GO

-- 6. Thêm và cập nhật xe trong bãi
create proc p_insertUpdateXe 
	@statementType varchar(20),
	@baixe_id char(10),
	@MaTheXe char(10),
	@BienSo varchar(15),
	@ThoiGianRa datetime = null,
	@ThoiGianVao datetime = null,
	@AnhTruoc image = null,
	@AnhSau image = null,
	@MaLoaiXe char(10) = null
as
	if(@statementType ='insert')
		begin
			insert into Xe values(@BienSo,@AnhTruoc,@AnhSau,@ThoiGianVao, null, @MaTheXe,@MaLoaiXe,@baixe_id)
		end
	else if(@statementType= 'update')
		begin
			update Xe set ThoiGianRa=@ThoiGianRa
			where BienSo=@BienSo and MaTheXe=@MaTheXe and ThoiGianRa is null and baixe_id=@baixe_id
		end
GO

-- Thêm dữ liệu vào bảng hóa đơn
create proc insertHoaDon 
	@tregio int,
	@tongtien real,
	@ngayin datetime,
	@ghichu nvarchar(200),
	@mathexe char(10)
	as begin
		declare @maHoaDon char(10)
		set @maHoaDon = LEFT(CAST(RAND()*1000000000 AS INT),10)
		insert into HoaDon 
			values(@maHoaDon, @tregio, @tongtien, @ngayin, @ghichu, @mathexe)
	end
GO
--==================4. CÁC TRIGGER CHO NHÂN VIÊN==================

-- 1. Cập nhật trạng thái của thẻ xe sau khi khách hàng đăng ký giữ xe
create trigger tr_capNhatTrangThaiTheKhiDangKy on DangKy
	after insert as
	begin
		declare @mathexe char(10)
		select @mathexe = MaTheXe from inserted
		update TheXe
		set TrangThai=N'Đang sử dụng'
		where MaTheXe=@mathexe
	end
GO

-- 2. Cập nhật trạng thái của thẻ xe khi xe ra vào bãi
create trigger tr_capNhatTrangThaiXeRaVao
	on Xe after insert, update as
	begin
		declare @mathexe char(10), @tgRa datetime
		select @mathexe = MaTheXe, @tgRa = ThoiGianRa from inserted

		if (dbo.laTheVangLai(@mathexe) = 1)
			begin
				if (@tgRa is null)
					begin
						update TheXe
						set TrangThai= N'Đang sử dụng'
						where MaTheXe = @mathexe
						print N'Đã cập nhật trạng thái của xe vào'
					end
				else 
					begin
						update TheXe
						set TrangThai=N'Sẵn sàng sử dụng'
						where MaTheXe = @mathexe
						print N'Đã cập nhật trạng thái của xe ra'
					end
			end
	end
GO


-- 3. Trigger kiểm tra thời gian xe ra khỏi bãi có hợp lệ không?
create trigger tr_checkTimeOut on Xe 
for update
as
	begin 
		declare @timeIn datetime
		declare @timeOut datetime
		select @timeOut = inserted.ThoiGianRa from inserted
		select @timeIn = Xe.ThoiGianVao from Xe
	
		if(@timeIn<@timeOut)
			begin
				print N'thời gian ra phải lớn hơn thời gian vào'
				rollback tran
				return
			end
		else print @timeOut
	end
GO

-- 4. Kiểm tra tính hợp lệ của dữ liệu khi thêm vào bảng khách hàng.
create trigger tr_kiemTraInputKhachHang on KhachHang
	for insert
as
	begin 
		declare @id char(10)
		declare @ten nvarchar(50)
		declare @sdt char(15)
		select @id = kh_id, @ten = ten, @sdt = sdt from inserted
		
		if @id='' or @ten='' or @sdt=''
			begin
				RAISERROR(N'Dữ liệu vào không được rỗng.',16,1)
				rollback
				return
			end
	end
GO

create trigger tr_baoTheHetHan on Xe
for insert
as begin
	declare @mathexe char(10)
	declare @ngayhethan datetime
	
	select @mathexe=MaTheXe from inserted
	select @ngayhethan=NgayHetHan from DangKy
	where MaTheXe=@mathexe

	if (@ngayhethan < GETDATE())
		begin
			raiserror(N'Thẻ bị quá hạn.',16,1)
			rollback tran
		end
end
GO