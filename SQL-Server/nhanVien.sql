----------------1. CÁC VIEW CHO NHÂN VIÊN --------------------

-- View nhân viên xem thẻ xe
create view view_NVXemTheXe
as
	select MaTheXe as N'Mã thẻ',b.Ten as N'Tên bãi xe', TrangThai as N'Trạng thái', TenLoaiThe as N'Loại thẻ' 
	from TheXe
	inner join BaiXe as b
	on TheXe.baixe_id=b.baixe_id
	inner join LoaiTheXe
	on TheXe.MaLoaiThe= LoaiTheXe.MaLoaiThe

-- 

----------------1. CÁC FUNCTION CHO NHÂN VIÊN --------------------



----------------1. CÁC STORE PROCEDURE CHO NHÂN VIÊN --------------------
