select * from TheXe
select * from Xe

delete from Xe 
delete from Xe where BienSo='1234'

update TheXe set TrangThai=N'Sẵn sàng sử dụng'

-- Hàm lấy xe ra, truyền vào mã thẻ xe, kết quả là xe trong bãi cần lấy ra
create function f_layXeRa(@mathexe char(10)) 
	returns table
	as return 
		select * from Xe
		where MaTheXe=@mathexe and ThoiGianRa is null

	-- Test hàm
	select * from f_layXeRa('OT0125')


create function f_layTenLoaiXe(@maloaixe char(10))
	returns nvarchar(50)
	as begin
		declare @tenloaixe nvarchar(50)
		select @tenloaixe=TenLoaiXe from LoaiXe where MaLoaiXe='LX1'
		return @tenloaixe
	end

	-- Test 
	select dbo.f_layTenLoaiXe('LX1')


-- Thủ tục insert và update xe ra vào
alter proc [dbo].[p_insertUpdateXe] 
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

	-- insert xe
	exec p_insertUpdateXe 'insert', 'spktB     ', '121', '123', null, '2020-12-18 16:05:23.540', '1234', '2345', 'lx1'
	-- update xe
	exec p_insertUpdateXe 'update', 'OT0125    ', '1234', '2020-12-18 16:05:23.540', '2020-12-18 16:05:23.540', '1', '1', '1', '1'


-- Trigger cập nhật trạng thái của thẻ xe khi xe vào
alter trigger tr_capNhatTrangThaiXeRaVao
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

-- Trigger kiểm tra tính hợp lệ của thẻ xe khi check in
create trigger 

