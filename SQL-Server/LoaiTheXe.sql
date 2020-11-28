-- Thêm loại thẻ xe
create proc p_insertLoaiTheXe @maloaithe char(10), @tenloaithe nvarchar(50)
	as begin
		insert into LoaiTheXe
		values(@maloaithe, @tenloaithe)
	end

-- Cập nhật loại thẻ xe
create proc p_updateLoaiTheXe @maloaithe char(10), @tenloaithe nvarchar(50)
	as begin
		update LoaiTheXe
		set TenLoaiThe = @tenloaithe
		where MaLoaiThe = @maloaithe
	end

-- Xoá loại thẻ xe
create proc p_deleteLoaiTheXe @maloaithe char(10)
	as begin
		delete from LoaiTheXe
		where MaLoaiThe = @maloaithe
	end