

--print datetime(2020-11-25T09:14:21:00.560)
print DATEADD(day, 1, '2020/11/25')
select * from DangKy
--DangKy
insert into DangKy values('kh1','XM01243',getdate(),DATEADD(day, 7, '2020/11/25'))
insert into DangKy values('kh1','XM0123',Getdate(),  DATEADD(day, 1, '2020/11/25'))

drop table GiaTienLoaiXe
create table GiaTienLoaiXe(
	MaLoaiXe char(10),
	TenLoaiXe nvarchar(50),
	TenLoaiGia nvarchar(50),
	GiaTien real,
	NgayApDung date,
	primary key(MaLoaiXe, TenLoaiGia)
)
insert into GiaTienLoaiXe values('XM',N'Xe Máy',N'Trong Ngày',)

drop table Xe
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
	with check add constraint fk_check_loaixe
	foreign key(MaLoaiXe) references GiaTienLoaiXe(MaLoaiXe)
go
alter table Xe
	with check add constraint fk_check_thexe
	foreign key(MaTheXe) references TheXe(MaTheXe)
go

create table Users(
	id char(10),
	TenDangNhap varchar(20),
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

insert into Users values()

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


------------------------------------------------------
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


--- add data cho KhachHang

insert into KhachHang values('kh1',N'Nguyễn Hiếu', 0123456789),
('kh2',N'Lưu Văn cụi', 012346789),('kh3',N'Không Có tên', 0123996789),
('kh4',N'Tran Văn A', 0123456789),('kh5',N'Lê THị C', 0123456789)

-- LoaiTheXe
insert into LoaiTheXe values('TheTuan', N'Thẻ Tuần'),
('TheThang', N'Thẻ Tháng'),('VangLai', N'Vãng Lai')

--BaiXe
insert into BaiXe values('spktE', N'Bãi Sư Phạm Kỹ Thuật Khu E', N'Khu E, DH SPKT, Thủ Đức, HCM', 500),
('spktB', N'Bãi Sư Phạm Kỹ Thuật Khu B', N'Khu B, ĐH SPKT, Thủ Đức, HCM', 600),
('spktSVD', N'Bãi Sư Phạm Kỹ Thuật Khu SVĐ', N'SVĐ, DH SPKT, Thủ Đức, HCM', 30)

--TheXe
insert into TheXe values('XM0123', 'spktE', N'Đang sử dụng', 'VangLai'),('XD0123', 'spktB', N'Sẵn sàng sử dụng', 'VangLai'),
('XM01243', 'spktSVD', N'Đang sử dụng', 'TheTuan'),('OT0123', 'spktE', N'Đang sử dụng', 'TheThang'),
('XD01223', 'spktE', N'Bị mất', 'TheTuan'),('OT123', 'spktE', N'Đang sử dụng', 'TheThang'),
('XM10123', 'spktB', N'Sẵn sàng sử dụng', 'VangLai'),('OT0125', 'spktB', N'Sẵn sàng sử dụng', 'VangLai')

insert into TheXe values('Thang1', 'spktB', N'Sẵn sàng sử dụng', 'TheThang'),
						('Thang2', 'spktB', N'Sẵn sàng sử dụng', 'TheThang'),
						('Thang3', 'spktB', N'Sẵn sàng sử dụng', 'TheThang'),
						('Week1', 'spktB', N'Sẵn sàng sử dụng', 'TheTuan'),
						('Week2', 'spktB', N'Sẵn sàng sử dụng', 'TheTuan'),
						('Week3', 'spktB', N'Sẵn sàng sử dụng', 'TheTuan'),
						('VL1', 'spktB', N'Sẵn sàng sử dụng', 'VangLai'),
						('VL2', 'spktB', N'Sẵn sàng sử dụng', 'VangLai'),
						('VL3', 'spktB', N'Sẵn sàng sử dụng', 'VangLai')

-----
print DATEADD(day, 1, '2020/11/25')
select * from DangKy
--DangKy
insert into DangKy values('kh1','XM01243',getdate(),DATEADD(day, 7, '2020/11/25'))
insert into DangKy values('kh1','XM0123',Getdate(),  DATEADD(day, 1, '2020/11/25'))

-------
insert into Users values('1','hieu','12345',N'Nguyễn Hiếu', 083927347,1,'spktB'),
('2','cui','12345',N'LV Cụi', 0839273447,1,'spktE'),('3','Nam','12345',N'Doan nam', 083222347,1,'spktSVD'),
('4','Hoang','12345',N'Nguyễn Hoang', 083927347,1,'spktB')

------
insert into PhanQuyen values('1','Xem Doanh Thu','admin', 1),('2','Them nhanVien','admin', 1),('3','Them Xe',N'SoatVe', 1),
('4','Xem xe trong bai','SoatVe', 1)

insert into LoaiXe values('LX1', 'Xe May'), ('LX2', 'Xe Hoi')
