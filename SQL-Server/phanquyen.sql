
-- Tạo nhóm quyền với các phân quyền cho nhân viên
exec sp_addrole NHANVIEN
grant select, insert, update on Xe to NHANVIEN

-- Tạo login, tạo user thuộc nhóm quyền
exec sp_addlogin cuinv, 1234, PARKING 
exec sp_adduser cuinv, user1, NHANVIEN
