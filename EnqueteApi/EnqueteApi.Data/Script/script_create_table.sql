
create table EnqueteApi.poll (
 id integer IDENTITY not null,
 poll_descriction varchar(40) not null
);

ALTER TABLE EnqueteApi.poll
   ADD CONSTRAINT PK_Poll_ID PRIMARY KEY CLUSTERED (id);


CREATE TABLE EnqueteApi.options(
  id integer IDENTITY not null,
  poll_id int not null,
  option_cout int,
  option_description varchar(40) not null 
 );

ALTER TABLE EnqueteApi.options
   ADD CONSTRAINT PK_Options_ID PRIMARY KEY CLUSTERED (id);

ALTER TABLE EnqueteApi.options
   ADD CONSTRAINT FK_Options_Poll_ID Foreign KEY (poll_id)
   References EnqueteApi.poll(id);

