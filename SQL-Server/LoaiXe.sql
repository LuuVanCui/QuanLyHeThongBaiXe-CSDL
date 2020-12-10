create proc p_insertUpdateLoaiXe @type varchar(10),
								 @ma	char(10),
								@ten nvarchar(50)
as
	begin
		if(@type='insert')
			begin
				insert into LoaiXe values(@ma,@ten)
			end
		else if(@type='update')
			begin
				update LoaiXe set TenLoaiXe=@ten where  MaLoaiXe =@ma
			end
		else if(@type='delete')
			begin
				delete from LoaiXe where  MaLoaiXe =@ma
			end
	end

	exec p_insertUpdateLoaiXe 'insert','xm',N'Xe máy'
	exec p_insertUpdateLoaiXe 'update','XM',N'Xe mayy'
	use PARKING
	
	select * from loaiXe
	Delete from LoaiXe
	update LoaiXe set TenLoaiXe='sfnjew' where  MaLoaiXe ='XD'