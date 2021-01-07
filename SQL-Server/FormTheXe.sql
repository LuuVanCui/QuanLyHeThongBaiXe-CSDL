select * from TheXe

create view [dbo].[view_NVXemTheXe]
as
	select MaTheXe as [Mã thẻ] ,b.Ten as [Tên bãi xe], 
		TrangThai as [Trạng thái], TenLoaiThe as [Loại thẻ]
	from TheXe
	inner join BaiXe as b
	on TheXe.baixe_id=b.baixe_id
	inner join LoaiTheXe
	on TheXe.MaLoaiThe= LoaiTheXe.MaLoaiThe

-- Tìm kiếm tất cả thông tin có trong view NV xem thẻ xe
create function f_timKiemTheXe(@query nvarchar(50))
	returns table 
	as return
		SELECT * FROM view_NVXemTheXe 
		WHERE CONCAT([Mã thẻ], [Tên bãi xe], [Trạng thái], [Loại thẻ]) 
		LIKE '%' + @query + '%'

	-- Test f_timKiemTheXe(@query nvarchar(50))
	select * from f_timKiemTheXe('lai')

select * from TheXe
