update "Employees" 
set	 "Tariff" = 15000 / selected."SalaryIncrement"
from (select e."Id", jp."SalaryIncrement" 
from public."Employees" e, public."JobPosts" jp 
where e."JobPostId" = jp."Id" and e."Tariff" * jp."SalaryIncrement" < 15000) as selected
where "Employees"."Id" = selected."Id"