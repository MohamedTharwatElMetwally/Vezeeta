create or replace procedure GetMaxUserID_ (MID out number)
as
begin
select max(user_id_)
into MID
from Users_;
end;