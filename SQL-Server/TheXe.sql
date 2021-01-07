-- Thêm, xóa, sửa thẻ xe
Select * from TheXe

create proc insertUpdateTheXe @type char(10), @maThe char(10),  @baixeID char(10), @TrangThai nvarchar(20), @maLoaiThe char(10)
as
	begin
		if(@type = 'insert')
			begin
				insert into TheXe values(@maThe, @baixeID, @TrangThai, @maLoaiThe)
			end
		if(@type = 'update')
			begin
				update TheXe set  baixe_id =@baixeID , TrangThai =@TrangThai , MaLoaiThe = @maLoaiThe  where MaTheXe = @maThe
			end
	end
create proc deleteTheXe  @maThe char(10)
as
	begin
		delete from TheXe where MaTheXe = @maThe
	end