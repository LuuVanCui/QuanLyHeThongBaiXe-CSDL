--phần admin---------------------
-- 1. frmQLXE
--2. frmQLaiXe
--3. frmKhacHang
--4. frmLoaiXe
--5. frmNhanVien
--6. frmBangGia
--7. frmDoanhThu
--8. frmQLTheXe
--9. Trigger


--form QL Xe---------------

--1
-- thủ tục để tìm xe trong bãi khi người dùng nhấn chọn bãi xe và loại xe trên combobox
ALTER proc [dbo].[p_selectXe] @BaiXe nvarchar(20), @LoaiXe nvarchar(20)
as
	begin
		if(@BaiXe= 'Tất Cả' and @LoaiXe = 'Tất Cả')
			begin
				select x.MaTheXe,x.BienSo,x.AnhTruoc,x.AnhSau, x.ThoiGianVao,x.ThoiGianRa,l.TenLoaiXe,
					b.Ten as 'Ten Bai Xe' from Xe as x 
					inner join LoaiXe as l on x.MaLoaiXe=l.MaLoaiXe inner join  BaiXe as b on x.baixe_id=b.baixe_id
			end
		else if(@BaiXe='Tất Cả' and @LoaiXe <> 'Tất Cả')
			begin
				select x.MaTheXe,x.BienSo,x.AnhTruoc,x.AnhSau, x.ThoiGianVao,x.ThoiGianRa,l.TenLoaiXe,
				b.Ten as 'Ten Bai Xe' from Xe as x 
				inner join LoaiXe as l on x.MaLoaiXe=l.MaLoaiXe inner join  BaiXe as b on x.baixe_id=b.baixe_id
				where x.MaLoaiXe = @LoaiXe
			end
		else if(@BaiXe <>'Tất Cả' and @LoaiXe = 'Tất Cả')
			begin
				select x.MaTheXe,x.BienSo,x.AnhTruoc,x.AnhSau, x.ThoiGianVao,x.ThoiGianRa,l.TenLoaiXe,b.Ten as 'Ten Bai Xe' from Xe as x 
				inner join LoaiXe as l on x.MaLoaiXe=l.MaLoaiXe inner join  BaiXe as b on x.baixe_id=b.baixe_id
				where x.baixe_id = @BaiXe
			end
		else if(@BaiXe <> 'Tất Cả' and @LoaiXe <> 'Tất Cả')
			begin
				select x.MaTheXe,x.BienSo,x.AnhTruoc,x.AnhSau, x.ThoiGianVao,x.ThoiGianRa,l.TenLoaiXe,b.Ten as 'Ten Bai Xe' from Xe as x 
				inner join LoaiXe as l on x.MaLoaiXe=l.MaLoaiXe inner join  BaiXe as b on x.baixe_id=b.baixe_id
				where x.MaLoaiXe = @LoaiXe and x.baixe_id=@BaiXe
			end
	end 

go

-- Tìm kiếm xe
create function f_searchXe( @searchKey nvarchar(50))
  returns table
	as return	SELECT * FROM Xe WHERE CONCAT(MaTheXe, BienSo, MaLoaiXe, ThoiGianVao, ThoiGianRa, MaLoaiXe,baixe_id)
			LIKE '%' +@searchKey+ '%'
go
-- thủ tục show xe 
create proc p_showXe @baiXeId nvarchar(50), @loaiXe nvarchar(50)
as
	begin
		Select * from Xe where baixe_id = @baiXeId and MaLoaiXe =@loaiXe
	end
	go
-- thủ tục xóa xe theo bãi xe và loại xe trong một khoảng thời gian xác định
go
create proc deleteXeByDay @baixe char(10), @loaiXe char(10), @time1 datetime, @time2 datetime 
as	
	begin
		if(@baixe= 'Tất Cả' and @loaiXe = 'Tất Cả')
			begin 
				delete from Xe where ThoiGianRa is not null and ThoiGianVao >= @time1 and ThoiGianRa <= @time2
			end
		else if(@baixe = 'Tất Cả' and @loaiXe <> 'Tất Cả')
			begin
				delete from Xe where ThoiGianRa is not null and ThoiGianVao >= @time1 and ThoiGianRa <= @time2
										and MaLoaiXe = @loaiXe
			end
		else if(@baixe <> 'Tất Cả' and @loaiXe = 'Tất Cả')
			begin
				delete from Xe where ThoiGianRa is not null and ThoiGianVao >= @time1 and ThoiGianRa <= @time2
										and baixe_id = @baixe
			end
		else if(@baixe <> 'Tất Cả' and @loaiXe <> 'Tất Cả')
			begin
				delete from Xe where ThoiGianRa is not null and ThoiGianVao >= @time1 and ThoiGianRa <= @time2
										and MaLoaiXe = @loaiXe and baixe_id = @baixe
			end
	end
----------=============================================================
-- 2
-- frm Bãi Xe
-- Thêm bãi xe
create proc p_BaiXe @typestatement varchar(50) = '', @id char(10), @name nvarchar(50) = null, 
		@adrs nvarchar(200) = null, @slot int = null
	as begin
		if @typestatement = 'insert'
			begin
				insert into BaiXe
				values(@id, @name, @adrs, @slot)
			end
		else if @typestatement = 'update'
			begin
				update BaiXe 
				set Ten = @name, DiaChi = @adrs, SucChua = @slot
				where baixe_id = @id
			end
		else if @typestatement = 'delete'
			begin
				delete from BaiXe
				where baixe_id = @id
			end
		
	end
--proc tìm kiếm bãi xe 
create proc p_searchBaiXe @key Nvarchar
as
	begin
		SELECT * FROM BaiXe WHERE CONCAT(baixe_id, Ten, DiaChi, SucChua) LIKE '%' +@key+ '%'
	end
--3==========================frmKhacHang===========

-- proc Khách hàng------------------
--proc findKHByBaiXeID
--drop procedure p_findKHByBaiXeID
go
	create proc p_findKHByBaiXeID @id char(10)
	as
		begin
			if(@id = 'all')
				begin
					Select * from KhachHang
				end
			else
			begin
				select KhachHang.kh_id,KhachHang.ten, KhachHang.sdt from KhachHang inner join DangKy on KhachHang.kh_id = DangKy.kh_id
									inner join TheXe on TheXe.MaTheXe =DangKy.MaTheXe
									where TheXe.baixe_id = @id
			end
		end

go
-- Insert table Khách Hàng 
create proc p_InsertKhachHang @id char(10), @name nvarchar(50), @phone char(15)
	as begin
		insert into KhachHang
		values(@id, @name, @phone)
	end
go
-- Update table Khách Hàng
create proc p_updateKhachHang @id char(10), @name nvarchar(50), @phone char(15)
	as begin
		update KhachHang
		set	ten = @name, sdt = @phone
		where kh_id = @id
	end
go
-- Delete table Khách Hàng
create proc p_deleteKhachHang @id char(10)
	as begin
		delete from KhachHang where kh_id = @id
	end



-- Hàm Tìm khách hàng theo id

create function f_findCustomerById(@id char(10))
	returns table
	as return(
		select *
		from KhachHang
		where kh_id = @id
	)

drop function f_findCustomerById

select * from f_findCustomerById('KH1')

--- thủ tục search KH

create proc @searchKey nvarchar(50)
	as
		begin
			SELECT * FROM KhachHang WHERE CONCAT(kh_id, ten, sdt) LIKE '%' +@searchKey+ '%'
		end

	
	--========================frmLoaiXe========================================
	-- 4
select * from LoaiXe
alter proc p_LoaiXe @Action varchar(10) ='', @ma char(10) , @ten nvarchar(30) =''
as 
	begin 
		if(@Action='insert')
			begin
				insert into LoaiXe values(@ma,@ten)
			end
		else if(@Action='update')
			begin
				update LoaiXe set TenLoaiXe = @ten where MaLoaiXe= @ma
			end
		else if(@Action='delete')
			begin
				delete from LoaiXe where MaLoaiXe= @ma
			end
			
	end

-- proc search LoaiXe
create proc p_searchLoaiXe @key nvarchar
as
	begin
		SELECT * FROM LoaiXe WHERE CONCAT(MaLoaiXe, TenLoaiXe) LIKE '%' +@key+ '%'
	end

--===================frmNhanVien============================
-- 5
create proc p_Users_insertUpdate	   
						@StatementType	varchar(15)='',
						@id				Char(10),
						@TenDangNhap	varchar(20),
						@MatKhau		varchar(20),
						@Ten			nvarchar(50),
						@SDT			varchar(15),
						@TrangThai		bit,
						@baixe_id		char(10)
as
	begin
	if(@StatementType = 'insert')
		Begin
			Insert into Users values(@id, @TenDangNhap, @MatKhau, @Ten, @SDT, @TrangThai, @baixe_id)
		end
	else if(@StatementType = 'update')
		Begin
			update Users set TenDangNhap=@TenDangNhap, MatKhau=@MatKhau, Ten=@Ten, SDT=@SDT, TrangThai=@TrangThai, baixe_id= @baixe_id
			Where id=@id
		end
	
end

create proc p_Users_Delete @id char(10)
as
	begin
		delete from Users Where id=@id
	end

ALTER view [dbo].[view_Users] 
	as
	 select id, TenDangNhap,MatKhau,Users.Ten,SDT,TrangThai,BaiXe =(select ten From BaiXe where BaiXe.baixe_id=Users.baixe_id) 
	 from Users,BaiXe where BaiXe.baixe_id=Users.baixe_id
GO

create proc p_searchUsers @key nvarchar
as
	begin
		SELECT * FROM view_Users WHERE CONCAT(id, TenDangNhap,MatKhau,Ten,SDT,TrangThai,BaiXe) LIKE '%' +@key+ '%'
	end
---===============================BangGia==============-------------
--6
ALTER view [dbo].[view_BangGia] 
as
	

GO
select * from [view_BangGia]
go
create proc p_insertUpdateBangGia @StatementType nvarchar(10), @ma char(10),
			@ten nvarchar(50), @gia real,@ngayApDung datetime,@MaLoaiXe char(10)
as
	begin
	if(@StatementType = 'insert')
		Begin
			Insert into BangGia values(@ma ,@ten  ,@gia ,@ngayApDung ,@MaLoaiXe )
		end
	else if(@StatementType = 'update')
		Begin
			update BangGia set TenLoaiGia=@ten, GiaTien=@gia, NgayApDung=@ngayApDung, MaLoaiXe=@MaLoaiXe
			Where MaLoaiGia = @ma
		end
	
end
go
create proc p_deleteBangGia @ma char(10)
as
	begin
		delete from BangGia Where MaLoaiGia = @ma
	end

---==============frmDoanhThu==================
-- tạo thủ tục cho form thống kê doanh thu theo ngày trong 1 khoảng thời gian xác định

Alter proc p_thongkeDoanhThu @NgayBatDau datetime, @NgayKetThuc datetime, @BaiXe char(10), @LoaiXe char(10)
	as 
	if(@BaiXe='All' and @LoaiXe='All') 
		begin
			select HoaDon.ngayin as N'Ngày', sum(HoaDon.tongtien) as N'Tổng doanh thu' from HoaDon
				where HoaDon.ngayin is not null and ngayin >= @NgayBatDau and ngayin <= @NgayKetThuc  group by ngayin 
		end
	else if(@BaiXe<>'All' and @LoaiXe='All') -- theo bãi xe
		begin
			select  HoaDon.ngayin as N'Ngày', sum(HoaDon.tongtien) as N'Tổng doanh thu' from HoaDon,TheXe
				where HoaDon.ngayin is not null and HoaDon.mathexe = TheXe.MaTheXe and TheXe.baixe_id = @BaiXe
				and ngayin >= @NgayBatDau and ngayin <= @NgayKetThuc  group by ngayin
		end
	else if(@BaiXe='All' and @LoaiXe<>'All') -- Theo loại xe
		begin
			select  HoaDon.ngayin as N'Ngày', sum(HoaDon.tongtien) as N'Tổng doanh thu' from HoaDon
				where HoaDon.maloaixe = @LoaiXe and ngayin >= @NgayBatDau and ngayin <= @NgayKetThuc  group by ngayin 
		end
	else if(@BaiXe<>'All' and @LoaiXe<>'All') -- Theo loại xe và bãi xe
		begin
			select  HoaDon.ngayin as N'Ngày', sum(HoaDon.tongtien) as N'Tổng doanh thu' from HoaDon,TheXe
				where HoaDon.ngayin is not null and HoaDon.mathexe = TheXe.MaTheXe and TheXe.baixe_id = @BaiXe
				and HoaDon.maloaixe = @LoaiXe and
				ngayin >= @NgayBatDau and ngayin <= @NgayKetThuc  group by ngayin
		end

exec  p_thongkeDoanhThu '2020-12-06', '2020-12-07', 'spktE ', 'XM'
exec  p_thongkeDoanhThu '2020-12-06', '2020-12-07', 'All', 'XM'
select * from HoaDon
 delete from HoaDon
insert into HoaDon values('1','vbhbvwhr',30000,'2020-12-06 22:31:14.000','khong co ghi chu','OT0123    ', 'XH')
insert into HoaDon values('2','vbhbvwhr',70000,'2020-12-06 22:31:14.000','khong co ghi chu','OT123     ', 'XH')
insert into HoaDon values('3','vbhbvwhr',60000,'2020-12-06 22:31:14.000','khong co ghi chu','XM0123    ', 'XM')
insert into HoaDon values('4','vbhbvwhr',50000,'2020-12-06 22:31:14.000','khong co ghi chu','XM0123    ', 'XM')
insert into HoaDon values('5','vbhbvwhr',50000,'2020-11-06 22:31:14.000','khong co ghi chu','XM0123    ', 'XM')
insert into HoaDon values('6','vbhbvwhr',50000,'2020-11-06 22:31:14.000','khong co ghi chu','XM0123    ', 'XM')
insert into HoaDon values('7','vbhbvwhr',50000,'2020-10-06 22:31:14.000','khong co ghi chu','XM0123    ', 'XM')



--====================frmTheXe======================
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

-- function tìm kiếm thẻ xe
create function searchTheXe(@maThe char(10), @baiXe char(10))
returns table
	as
		return 
			SELECT * FROM Xe WHERE CONCAT(MaTheXe, BienSo, MaLoaiXe, ThoiGianVao, ThoiGianRa, MaLoaiXe,baixe_id)
			LIKE '%' +@searchKey+ '%'

--==============frmLoaiTheXe================
select * from LoaiTheXe

create proc insertUpdateLoaiTheXe @type char(10), @ma char(10), @ten nvarchar(30)
as
	begin
		if(@type='insert')
			begin
				insert into LoaiTheXe(MaLoaiThe,TenLoaiThe) values(@ma,@ten)
			end
		else if(@type='update')
			begin
				update LoaiTheXe set  TenLoaiThe = @ten where MaLoaiThe=@ma
			end
	end
go
create proc deleteLoaiTheXe @ma char(10)
as
	begin
		delete from LoaiTheXe where MaLoaiThe=@ma
	end

create function f_searchLoaiTheXe(@key nvarchar(50))
returns table
	as
		return SELECT * FROM LoaiTheXe WHERE CONCAT(MaLoaiThe,TenLoaiThe)
			LIKE '%' +@key+ '%'

go
--9. trigger------------------------------------
go
create trigger tr_checkTimeOut on Xe 
for update
as
	begin 
		declare @timeIn datetime
		declare @timeOut datetime
		select @timeOut = inserted.ThoiGianRa from inserted
		select @timeIn = Xe.ThoiGianVao from Xe
	
		if(@timeIn<@timeOut)
			begin
				print N'thời gian ra phải lớn hơn thời gian vào'
				rollback tran
				return
			end
		else print @timeOut
	end

go

-- trigger kiem tra giá tiền nhap vào ở bảng giá phải là số dương
create trigger tr_CheckPrice on BangGia for insert, update
as
	begin
		Declare @Giatien real
		select @Giatien= GiaTien from Inserted
		if(@Giatien < 0)
			Begin
				print N'Giá tiền phải là số dương'
				rollback tran
				return
			end
	end

go

create trigger tr_checkSlot on BaiXe 
for insert, update
as
	begin
		if((select SucChua from inserted)<0)
			begin
				print N'Sức chứa phải >= 0'
				rollback tran
				return
			end
	end
