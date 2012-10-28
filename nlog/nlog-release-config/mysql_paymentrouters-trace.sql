
create table LogTable
(
    sequence_id int not null auto_increment,
    machine_name varchar(50) not null,
    process_id int not null,
    thread_id int not null,
    time_stamp datetime not null,
    level varchar(5) not null,
    logger varchar(80) not null,
    activity_id char(36) null,
    related_activity_id char(36) null,
    message varchar(400) not null,
    exception varchar(max) null,
    primary key (sequence_id, time_stamp)
) engine=InnoDB
partition by range columns(time_stamp)
(partition p20121018 values less than ('2012-10-27 00:00'),
 partition p20121019 values less than ('2012-10-28 00:00'));
