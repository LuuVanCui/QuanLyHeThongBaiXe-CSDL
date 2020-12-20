select * from DangKy
select * from KhachHang
select * from TheXe
select * from LoaiTheXe

--DangKy--------
create view view_DangKy
as
	select DangKy.kh_id as N'Mã KH', ten as N'Tên Khách Hàng',DangKy.MaTheXe as N'Mã thẻ xe',
	TenLoaiThe as N'Tên loại thẻ', NgayCap as N'Ngày cấp',NgayHethan as N'Ngày hết hạn'
	from DangKy inner join TheXe on TheXe.MaTheXe=DangKy.MaTheXe
	inner join LoaiTheXe on LoaiTheXe.MaLoaiThe=TheXe.MaLoaiThe
	inner join KhachHang on KhachHang.kh_id=DangKy.kh_id

select * from view_DangKy

create view view_KhachHang
as
	select * from KhachHang
	-- Test
	select * from view_KhachHang

-- Lấy các thẻ xe ở trạng thái sẵn sàng sử dụng theo mã loại thẻ và bãi xe id
create function f_layMaTheXeTheoLoaiThe(@maloaithe char(10), @baixe_id char(10))
	returns table
	as return 
		select * from TheXe
		where MaLoaiThe = @maloaithe and baixe_id = @baixe_id 
			and TrangThai = N'Sẵn sàng sử dụng'
	-- Test f_layMaTheXeTheoLoaiThe
	select * from f_layMaTheXeTheoLoaiThe('VangLai', 'spktB')

--LoaiTheXe---------------
create view view_LoaiTheXe
as
	select * from LoaiTheXe

-- Lấy tất cả các loại thẻ xe để đăng ký cho khách hàng, trừ thẻ cho khách vãng lai
create function f_layLoaiTheXeDangKy()
	returns table
	as return 
		select * from LoaiTheXe
		where MaLoaiThe != 'VangLai'
	-- Test f_layLoaiTheXeDangKy()
	select * from f_layLoaiTheXeDangKy()
	
-- Tìm kiếm tất cả thông tin có trong view đăng ký
create function f_timKiemTrongViewDangKy(@query nvarchar(50))
	returns table 
	as return
		SELECT * FROM view_DangKy 
		WHERE CONCAT([Mã KH], [Tên Khách Hàng], 
		[Mã thẻ xe], [Tên loại thẻ], [Ngày cấp], [Ngày hết hạn]) 
		LIKE '%' + @query + '%'

	-- Test f_timKiemTrongViewDangKy(@query nvarchar(50))
	select * from f_timKiemTrongViewDangKy('kh')

-- Insert vào bảng đăng ký
create proc p_insertDangKy 
	@kh_id char(10),
	@mathexe char(10),
	@ngaycap datetime,
	@ngayhethan datetime
	as begin
		insert into DangKy 
		values(@kh_id, @mathexe, @ngaycap, @ngayhethan)
	end

	-- Test procedure p_insertDangKy 
	exec p_insertDangKy @kh_id, @mathexe, @ngaycap, @ngayhethan
