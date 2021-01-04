--==================1. CÁC VIEW CHO NHÂN VIÊN==================

-- View nhân viên xem thẻ xe
create view view_NVXemTheXe
as
	select MaTheXe as N'Mã thẻ',b.Ten as N'Tên bãi xe', TrangThai as N'Trạng thái', TenLoaiThe as N'Loại thẻ' 
	from TheXe
	inner join BaiXe as b
	on TheXe.baixe_id=b.baixe_id
	inner join LoaiTheXe
	on TheXe.MaLoaiThe= LoaiTheXe.MaLoaiThe

-- View khách hàng
create view view_KhachHang as
	select kh_id as [Mã KH], ten as [Tên KH], sdt as [SĐT]
	from KhachHang

-- View đăng ký
create view view_DangKy
as
	select DangKy.kh_id as N'Mã KH', ten as N'Tên Khách Hàng',DangKy.MaTheXe as N'Mã thẻ xe',
	TenLoaiThe as N'Tên loại thẻ', NgayCap as N'Ngày cấp',NgayHethan as N'Ngày hết hạn'
	from DangKy inner join TheXe on TheXe.MaTheXe=DangKy.MaTheXe
	inner join LoaiTheXe on LoaiTheXe.MaLoaiThe=TheXe.MaLoaiThe
	inner join KhachHang on KhachHang.kh_id=DangKy.kh_id

--==================1. CÁC FUNCTION CHO NHÂN VIÊN==================

-- Tìm kiếm tất cả thông tin có trong view NV xem thẻ xe
create function f_timKiemTheXe(@query nvarchar(50))
	returns table 
	as return
		SELECT * FROM view_NVXemTheXe 
		WHERE CONCAT([Mã thẻ], [Tên bãi xe], [Trạng thái], [Loại thẻ]) 
		LIKE '%' + @query + '%'

-- Tìm kiếm tất cả thông tin trong bảng khách hàng
create function f_timKiemKhachHang(@query nvarchar(50))
	returns table 
	as return
		SELECT * FROM view_KhachHang 
		WHERE CONCAT([Mã KH], [Tên KH], 
		SĐT) 
		LIKE '%' + @query + '%'

-- Lấy tất cả các loại thẻ xe để đăng ký cho khách hàng, trừ thẻ cho khách vãng lai
create function f_layLoaiTheXeDangKy()
	returns table
	as return 
		select * from LoaiTheXe
		where MaLoaiThe != 'VangLai'

-- Lấy các thẻ xe ở trạng thái sẵn sàng sử dụng theo mã loại thẻ và bãi xe id
create function f_layMaTheXeTheoLoaiThe(@maloaithe char(10), @baixe_id char(10))
	returns table
	as return 
		select * from TheXe
		where MaLoaiThe = @maloaithe and baixe_id = @baixe_id 
			and TrangThai = N'Sẵn sàng sử dụng'

-- Tìm kiếm tất cả thông tin có trong view đăng ký
create function f_timKiemTrongViewDangKy(@query nvarchar(50))
	returns table 
	as return
		SELECT * FROM view_DangKy 
		WHERE CONCAT([Mã KH], [Tên Khách Hàng], 
		[Mã thẻ xe], [Tên loại thẻ], [Ngày cấp], [Ngày hết hạn]) 
		LIKE '%' + @query + '%'

--==================1. CÁC STORE PROCEDURE CHO NHÂN VIÊN==================

-- Thêm khách hàng
create proc p_InsertKhachHang @id char(10), @name nvarchar(50), @phone char(15)
	as begin
		insert into KhachHang
		values(@id, @name, @phone)
	end

-- Cập nhật thông tin khách hàng
create proc p_updateKhachHang @id char(10), @name nvarchar(50), @phone char(15)
	as begin
		update KhachHang
		set	ten = @name, sdt = @phone
		where kh_id = @id
	end

-- Thêm dữ liệu vào bảng đăng ký
create proc p_insertDangKy 
	@kh_id char(10),
	@mathexe char(10),
	@ngaycap datetime,
	@ngayhethan datetime
	as begin
		insert into DangKy 
		values(@kh_id, @mathexe, @ngaycap, @ngayhethan)
	end


