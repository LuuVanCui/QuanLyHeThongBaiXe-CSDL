select * from Xe

create proc p_insertUpdateXe 
	@statementType varchar(20) = '',
	@BienSo varchar(15),
	@AnhTruoc image,
	@AnhSau image,
	@ThoiGianVao datetime,
	@ThoiGianRa datetime,
	@MaTheXe char(10),
	@MaLoaiXe char(10),
	@baixe_id char(10)

as
	if(@statementType ='insert')
		begin
			insert into Xe values(@BienSo,@AnhTruoc,@AnhSau,@ThoiGianVao,@ThoiGianRa,@MaTheXe,@MaLoaiXe,@baixe_id)
		end
	else if(@statementType= 'update')
		begin
			update Xe set AnhTruoc=@AnhTruoc,AnhSau=@AnhSau,ThoiGianRa=@ThoiGianRa,MaTheXe=@MaTheXe,
					MaLoaiXe=@MaLoaiXe, @baixe_id=baixe_id  where BienSo=@BienSo and ThoiGianVao=@ThoiGianVao
		end

create proc p_deleteXe @BienSoXe char(10),@ThoiGianVao datetime
as
	begin
		delete from Xe where BienSo=@BienSoXe and ThoiGianVao=@ThoiGianVao
	end

	---------------- thu tuc
create proc p_showXe @baiXeId nvarchar(50), @loaiXe nvarchar(50)
as
	begin
		Select * from Xe where baixe_id = @baiXeId and MaLoaiXe =@loaiXe
	end


	create proc p_searchXe @searchKey nvarchar(50)
	as
		begin
			SELECT * FROM Xe WHERE CONCAT(BienSo, MaLoaiXe, ThoiGianVao, ThoiGianRa, MaLoaiXe,baixe_id) LIKE '%' +@searchKey+ '%'
		end

	exec p_searchXe 'X'
