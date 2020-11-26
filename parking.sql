create table KhachHang(
	kh_id char(10),
	ten nvarchar(50),
	sdt bigint,
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
	BienSo int,
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

create table PhanQuyen(
	id_chucnang char(10),
	TenChucNang nvarchar(50),
	LoaiNguoiDung nvarchar(50),
	DuocCapQuyen bit,
	primary key(id_chucnang)
)

create table Quyen(
	userId char(10),
	id_chucnang char(10),
	primary key(userId, id_chucnang),
	constraint fk_quyen_user_id
		foreign key(userId) 
		references Users(id)
		on delete cascade
		on update cascade,
	constraint fk_quyen_chucnang_id
		foreign key(id_chucnang) 
		references PhanQuyen(id_chucnang)
		on delete cascade
		on update cascade
)


-- Trigger cập nhật trạng thái của thẻ xe khi xe vào của khách vãng lai
create trigger tr_capNhatTrangThaiXeRaVao
	on Xe after insert, update as
	begin
		declare @mathexe char(10), @tgRa datetime
		select @mathexe = MaTheXe, @tgRa = ThoiGianRa from inserted
		if (@tgRa is null)
			begin
				update TheXe
				set TrangThai='Đang sử dụng'
				where MaTheXe = @mathexe
				print 'Đã cập nhật trạng thái của xe vào'
			end
		else 
			begin
				update TheXe
				set TrangThai='Sẵn sàng sử dụng'
				where MaTheXe = @mathexe
				print 'Đã cập nhật trạng thái của xe ra'
			end
	end
