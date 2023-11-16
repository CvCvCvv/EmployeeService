SELECT p."Firstname" ,p."Surname" , p."Patronymic" , 
p."DateOfBirth" , e."DateOfEmployment" ,d."Name" , jp."Name", jp."SalaryIncrement" * e."Tariff" as salary
FROM public."Employees" e, public."Persons" p , public."Departments" d , public."JobPosts" jp 
WHERE p."Id" = e."PersonId"  and e."DepartmentId"  = d."Id" and e."JobPostId" = jp."Id"
and e."JobPostId" = jp."Id"
