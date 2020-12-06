use PARKING
select * from Users
alter table Users alter column SDT varchar(15)


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



