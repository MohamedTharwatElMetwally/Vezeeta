create or replace procedure retrieve_doctor_cost_ (doctor_id_ in number ,  ret out number)
as
begin
select examination_cost_ into ret from doctor_ where doctor_.doctor_id_ = doctor_id_;
end retrieve_doctor_cost_;