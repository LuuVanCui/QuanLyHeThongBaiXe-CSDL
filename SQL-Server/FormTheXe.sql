select * from TheXe

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
