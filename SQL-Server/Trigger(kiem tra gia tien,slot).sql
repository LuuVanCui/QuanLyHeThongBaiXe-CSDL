use PARKING
---tạo trigger kiểm tra thời gian ra của xe phải lớn hơn thời gian vào
drop trigger tr_checkTimeOut

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

--test trigger
select * from Xe
update Xe set ThoiGianVao=getDate() where MaTheXe='XH0123'
update Xe set ThoiGianRa='2020-12-06 12:40:16.363' where MaTheXe='XH0123'


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

--test trigger
delete from BangGia where MaLoaiGia='XdNgay' and MaLoaiXe='XD'
insert into BangGia values('XdNgay','Xe Dap Theo Ngay',-2000,getdate(),'XD')



--Trigger kiem tra slot của bãi phải là số dương
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

	-- test trigger
	select * from BaiXe
	delete from BaiXe
	insert into BaiXe values('spktE', N'Bãi Sư Phạm Kỹ Thuật Khu E', N'Khu E, DH SPKT, Thủ Đức, HCM', -500)
