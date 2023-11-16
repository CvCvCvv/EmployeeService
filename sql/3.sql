delete from public."Persons" p
WHERE (select extract(YEAR from age(current_timestamp, p."DateOfBirth"))) > 70
