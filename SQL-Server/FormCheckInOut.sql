select * from TheXe
select * from Xe
delete from Xe where BienSo='1234'

update TheXe set TrangThai=N'Sẵn sàng sử dụng'

-- Hàm lấy xe ra, truyền vào mã thẻ xe, kết quả là xe trong bãi cần lấy ra
create function f_layXeRa(@mathexe char(10)) 
	returns table
	as return 
		select * from Xe
		where MaTheXe=@mathexe and ThoiGianRa is null

	-- Test hàm
	select * from f_layXeRa('XM01243')


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
create proc [dbo].[p_insertUpdateXe] 
	@statementType varchar(20),
	@MaTheXe char(10),
	@BienSo varchar(15),
	@ThoiGianRa datetime,
	@ThoiGianVao datetime,
	@AnhTruoc image,
	@AnhSau image,
	@MaLoaiXe char(10),
	@baixe_id char(10)
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

exec p_insertUpdateXe 'update', 'OT0125    ', '1234', '2020-12-18 16:05:23.540', '2020-12-18 16:05:23.540', '1', '1', '1', '1'