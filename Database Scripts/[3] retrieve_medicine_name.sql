create or replace procedure retrieve_medicine_name_( ret out sys_refcursor )
as
begin
open  ret for 
select medicine_name_ from medicine_;
end retrieve_medicine_name_;