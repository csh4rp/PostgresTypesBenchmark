create table table_int(
    id serial not null primary key,
    name text not null,
    value decimal
);

create table table_long(
    id bigserial not null primary key,
    name text not null,
    value decimal
);

create table table_guid(
    id uuid not null primary key,
    name text not null,
    value decimal
);

create table table_guid_default(
    id uuid not null primary key default uuid_generate_v1(),
    name text not null,
    value decimal
);


-- script to cluster guid_default

cluster table table_guid_default using table_guid_default_pkey;

-- script to get the id of the middle row

select t.* 
from (
select id, rank() over(order by id asc) as rank
from table_guid) as t
where t.rank = 250000