select * from Xe
select * from LoaiXe
select * from BaiXe
insert into BaiXe values('spktE', N'Bãi Sư Phạm Kỹ Thuật Khu E', N'Khu E, DH SPKT, Thủ Đức, HCM', 500)
insert into BaiXe values('spktB', N'Bãi Sư Phạm Kỹ Thuật Khu B', N'Khu B, ĐH SPKT, Thủ Đức, HCM', 600)
insert into BaiXe values('spktSVD', N'Bãi Sư Phạm Kỹ Thuật Khu SVĐ', N'SVĐ, DH SPKT, Thủ Đức, HCM', 30)

-- view cho admin xem Xe
create view view_AdminXe
as
	select x.MaTheXe,x.BienSo,x.AnhTruoc,x.AnhSau, x.ThoiGianVao,x.ThoiGianRa,l.TenLoaiXe,b.Ten as 'Ten Bai Xe' from Xe as x 
		inner join LoaiXe as l
		on x.MaLoaiXe=l.MaLoaiXe
		inner join  BaiXe as b
		on x.baixe_id=b.baixe_id

select * from view_AdminXe


-- view cho nv xem Xe
create view view_NVXemXe
as
	select x.MaTheXe,x.BienSo,x.AnhTruoc,x.AnhSau, x.ThoiGianVao,x.ThoiGianRa,l.TenLoaiXe from Xe as x 
		inner join LoaiXe as l
		on x.MaLoaiXe=l.MaLoaiXe

select * from view_NVXemXe

--TheXe
select * from TheXe

create view view_NVXemTheXe
as
	select MaTheXe as N'Mã thẻ',b.Ten as N'Tên bãi xe', TrangThai as N'Trạng thái', TenLoaiThe as N'Loại thẻ' 
	from TheXe
	inner join BaiXe as b
	on TheXe.baixe_id=b.baixe_id
	inner join LoaiTheXe
	on TheXe.MaLoaiThe= LoaiTheXe.MaLoaiThe

select * from view_NVXemTheXe

-- LoaiXe
create view view_Loaixe
as
	select * from LoaiXe

select * from view_Loaixe

--LoaiTheXe---------------
create view view_LoaiTheXe
as
	select * from LoaiTheXe

select * from view_LoaiTheXe

--KhachHang-------------
create view view_KhachHang
as
	select * from KhachHang

--DangKy--------
create view view_DangKy
as
	select DangKy.kh_id as N'Mã KH', ten as N'Tên Khách Hàng',DangKy.MaTheXe as N'Mã thẻ xe',
	TenLoaiThe as N'Tên loại thẻ', NgayCap as N'tên loại thẻ',NgayHethan as N'Ngày hết hạn'
	from DangKy inner join TheXe on TheXe.MaTheXe=DangKy.MaTheXe
	inner join LoaiTheXe on LoaiTheXe.MaLoaiThe=TheXe.MaLoaiThe
	inner join KhachHang on KhachHang.kh_id=DangKy.kh_id

select * from view_DangKy

--BangGia-----------------
create view view_BangGia 
as
	select MaLoaiGia as N'Mã loại giá', TenLoaiGia as N'Tên loại giá', GiaTien as N'Giá tiền', NgayApDung as N'Ngày áp dụng',
	TenLoaiXe as N'Tên loại xe'
	from BangGia inner join LoaiXe
	on LoaiXe.MaLoaiXe=BangGia.MaloaiXe

--BaiXe-----------------
create view view_BaiXe
as	
	select * from BaiXe

select * from view_BaiXe

create view view_MaTheXeCheckIn
	as 
	select * from TheXe
	where TrangThai=N'Sẵn sàng sử dụng'

create view view_MaTheXeCheckOut
	as 
	select * from TheXe
	where TrangThai=N'Đang sử dụng'
