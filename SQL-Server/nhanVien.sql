
create database PARKING
GO

USE PARKING
GO

--==================TẠO BẢNG VÀ CÁC RÀNG BUỘC==================
create table KhachHang(
	kh_id char(10),
	ten nvarchar(50),
	sdt char(15) unique,
	primary key(kh_id)
)
GO

create table LoaiTheXe(
	MaLoaiThe char(10),
	TenLoaiThe nvarchar(50),
	primary key(MaLoaiThe)
)
GO

create table BaiXe(
	baixe_id char(10),
	Ten nvarchar(50),
	DiaChi nvarchar(200),
	SucChua int,
	primary key(baixe_id)
)
GO

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
GO

create table DangKy(
	kh_id char(10),
	MaTheXe char(10),
	NgayCap date,
	NgayHetHan date,
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

create table LoaiXe(
	MaLoaiXe char(10),
	TenLoaiXe nvarchar(50),
	primary key(MaLoaiXe)
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
	baixe_id char(10),
	primary key(BienSo, ThoiGianVao),
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
	tenHD nvarchar(50),
	tongtien real,
	ngayin datetime,
	ghichu nvarchar(200),
	mathexe char(10) references TheXe(MaTheXe)
)
GO

--==================1. CÁC VIEW CHO NHÂN VIÊN==================

-- 1. View nhân viên xem thẻ xe
create view view_NVXemTheXe
as
	select MaTheXe as N'Mã thẻ',b.Ten as N'Tên bãi xe', TrangThai as N'Trạng thái', TenLoaiThe as N'Loại thẻ' 
	from TheXe
	inner join BaiXe as b
	on TheXe.baixe_id=b.baixe_id
	inner join LoaiTheXe
	on TheXe.MaLoaiThe= LoaiTheXe.MaLoaiThe
GO

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

--==================2. CÁC FUNCTION CHO NHÂN VIÊN==================

-- 1. Tìm kiếm tất cả thông tin có trong view NV xem thẻ xe
create function f_timKiemTheXe(@query nvarchar(50))
	returns table 
	as return
		SELECT * FROM view_NVXemTheXe 
		WHERE CONCAT([Mã thẻ], [Tên bãi xe], [Trạng thái], [Loại thẻ]) 
		LIKE '%' + @query + '%'
GO

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

-- 6. Lấy tất cả các mã thẻ xe với trạng thái sẵn sàng sử dụng của 1 bãi xe nào đó
create function f_maTheXeCheckIn(@baixeId char(10)) 
	returns table
	as return
		select * from TheXe
		where TrangThai=N'Sẵn sàng sử dụng'	and baixe_id = @baixeId
GO

-- 7. Lấy tất cả các mã thẻ xe với trạng thái đang sử dụng của 1 bãi xe nào đó
create function f_maTheXeCheckOut(@baixeId char(10)) 
	returns table
	as return
		select * from TheXe
		where TrangThai=N'Đang sử dụng'	and baixe_id = @baixeId
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
		select @tenloaixe=TenLoaiXe from LoaiXe where MaLoaiXe='LX1'
		return @tenloaixe
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