-- Insert table Khách Hàng 
create proc p_InsertKhachHang @id char(10), @name nvarchar(50), @phone char(15)
	as begin
		insert into KhachHang
		values(@id, @name, @phone)
	end

exec p_InsertKhachHang 'KH1', 'Nguyen Van A', '01234563223'
exec p_InsertKhachHang 'KH2', 'Nguyen Van B', '01234563223'
exec p_InsertKhachHang 'KH3', 'Nguyen Van C', '01234563223'

select * from KhachHang

-- Update table Khách Hàng
create proc p_updateKhachHang @id char(10), @name nvarchar(50), @phone char(15)
	as begin
		update KhachHang
		set	ten = @name, sdt = @phone
		where kh_id = @id
	end

exec p_updateKhachHang 'KH2', 'Nguyen Van B', '123123123'
select * from KhachHang

-- Delete table Khách Hàng
create proc p_deleteKhachHang @id char(10)
	as begin
		delete from KhachHang where kh_id = @id
	end

exec p_deleteKhachHang 'KH2'
select * from KhachHang


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


-- các hàm thủ tục view bên admin
--view Lấy KH theo bãi xe
--