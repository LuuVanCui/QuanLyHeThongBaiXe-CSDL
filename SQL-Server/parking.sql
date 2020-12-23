create table KhachHang(
	kh_id char(10),
	ten nvarchar(50),
	sdt char(15) unique,
	primary key(kh_id)
)

create table LoaiTheXe(
	MaLoaiThe char(10),
	TenLoaiThe nvarchar(50),
	primary key(MaLoaiThe)
)

create table BaiXe(
	baixe_id char(10),
	Ten nvarchar(50),
	DiaChi nvarchar(200),
	SucChua int,
	primary key(baixe_id)
)

create table TheXe(
	MaTheXe char(10),
	baixe_id char(10),
	TrangThai nvarchar(50), -- 'Bị mất', 'Đang sử dụng', 'Sẵn sàng sử dụng'
	MaLoaiThe char(10),
	primary key(MaTheXe),
	constraint fk_tx_MaLoaiXe -- tên constraint: fk + tên bảng + tên khóa ngoại
		foreign key(MaLoaiThe) 
		references LoaiTheXe(MaLoaiThe)
		on delete cascade
		on update cascade,
	constraint fk_tx_baixe_id
		foreign key(baixe_id) 
		references BaiXe(baixe_id)
		on delete cascade
		on update cascade
)

create table DangKy(
	kh_id char(10),
	MaTheXe char(10),
	NgayCap date,
	NgayHetHan date,
	primary key(kh_id, MaTheXe, NgayCap, NgayHetHan),
	constraint fk_dk_kh_id
		foreign key(kh_id) references KhachHang(kh_id)
		on delete cascade 
		on update cascade,
	constraint fk_dk_MaTheXe
		foreign key(MaTheXe) references TheXe(MaTheXe)
		on delete cascade 
		on update cascade
)

create table LoaiXe(
	MaLoaiXe char(10),
	TenLoaiXe nvarchar(50),
	primary key(MaLoaiXe)
)

create table BangGia(
	MaLoaiGia char(10) primary key,
	TenLoaiGia nvarchar(50), -- VD: Giá gửi theo ngày, tuần, tháng - giá phạt theo ngày
	GiaTien real,
	NgayApDung datetime,
	MaLoaiXe char(10) references LoaiXe(MaLoaiXe)
)

create table Xe(
	BienSo varchar(10),
	AnhTruoc image,
	AnhSau image,
	ThoiGianVao datetime,
	ThoiGianRa datetime,
	MaTheXe char(10),
	MaLoaiXe char(10),
	baixe_id char(10),
	primary key(BienSo, ThoiGianVao),
)

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

create table Users(
	id char(10),
	TenDangNhap varchar(20) unique,
	MatKhau varchar(20),
	Ten nvarchar(50),
	SDT bigint,
	TrangThai bit,
	baixe_id char(10),
	primary key(id),
	constraint fk_user_baixe_id
		foreign key(baixe_id) 
		references BaiXe(baixe_id)
		on update cascade
		on delete cascade
)

