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

exec p_BaiXe 'delete', 'bx01'

select * from BaiXe