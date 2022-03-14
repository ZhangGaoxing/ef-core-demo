/*==============================================================*/
/* DBMS name:      PostgreSQL 9.x                               */
/* Created on:     2022/3/14 9:29:24                            */
/*==============================================================*/


/*==============================================================*/
/* Table: doctor                                                */
/*==============================================================*/
create table doctor (
   id                   SERIAL not null,
   name                 VARCHAR(20)          not null,
   hospital_id          INT4                 not null,
   is_deleted           INT4                 null default 0,
   creator_id           VARCHAR(50)          null,
   created_dt           TIMESTAMP            null default 'now()',
   modifier_id          VARCHAR(50)          null,
   modified_dt          TIMESTAMP            null,
   constraint PK_DOCTOR primary key (id)
);

comment on table doctor is
'医生';

comment on column doctor.id is
'医生ID';

comment on column doctor.name is
'医生姓名';

comment on column doctor.hospital_id is
'所属医院ID';

comment on column doctor.is_deleted is
'删除标记';

comment on column doctor.creator_id is
'创建者ID';

comment on column doctor.created_dt is
'创建时间';

comment on column doctor.modifier_id is
'修改者ID';

comment on column doctor.modified_dt is
'修改时间';

/*==============================================================*/
/* Table: hospital                                              */
/*==============================================================*/
create table hospital (
   id                   SERIAL not null,
   name                 VARCHAR(20)          not null,
   is_deleted           INT4                 null default 0,
   creator_id           VARCHAR(50)          null,
   created_dt           TIMESTAMP            null default 'now()',
   modifier_id          VARCHAR(50)          null,
   modified_dt          TIMESTAMP            null,
   constraint PK_HOSPITAL primary key (id)
);

comment on table hospital is
'医院';

comment on column hospital.id is
'医院ID';

comment on column hospital.name is
'医院名称';

comment on column hospital.is_deleted is
'删除标记';

comment on column hospital.creator_id is
'创建者ID';

comment on column hospital.created_dt is
'创建时间';

comment on column hospital.modifier_id is
'修改者ID';

comment on column hospital.modified_dt is
'修改时间';

/*==============================================================*/
/* Table: patient                                               */
/*==============================================================*/
create table patient (
   id                   SERIAL not null,
   name                 VARCHAR(20)          not null,
   sex                  VARCHAR(10)          null,
   age                  INT2                 null,
   mobile               VARCHAR(15)          null,
   is_deleted           INT4                 null default 0,
   creator_id           VARCHAR(50)          null,
   created_dt           TIMESTAMP            null default 'now()',
   modifier_id          VARCHAR(50)          null,
   modified_dt          TIMESTAMP            null,
   constraint PK_PATIENT primary key (id)
);

comment on table patient is
'病人';

comment on column patient.id is
'病人ID';

comment on column patient.name is
'病人姓名';

comment on column patient.sex is
'性别';

comment on column patient.age is
'年龄';

comment on column patient.mobile is
'手机号';

comment on column patient.is_deleted is
'删除标记';

comment on column patient.creator_id is
'创建者ID';

comment on column patient.created_dt is
'创建时间';

comment on column patient.modifier_id is
'修改者ID';

comment on column patient.modified_dt is
'修改时间';

/*==============================================================*/
/* Table: report                                                */
/*==============================================================*/
create table report (
   id                   SERIAL not null,
   report_type_cd       VARCHAR(20)          not null,
   doctor_id            INT4                 not null,
   patient_id           INT4                 not null,
   result               BOOL                 not null default FALSE,
   collect_time         TIMESTAMP            null,
   test_time            TIMESTAMP            null,
   report_time          TIMESTAMP            null,
   description          VARCHAR(200)         null,
   is_deleted           INT4                 null default 0,
   creator_id           VARCHAR(50)          null,
   created_dt           TIMESTAMP            null default 'now()',
   modifier_id          VARCHAR(50)          null,
   modified_dt          TIMESTAMP            null,
   constraint PK_REPORT primary key (id)
);

comment on table report is
'检测报告';

comment on column report.id is
'检测报告ID';

comment on column report.report_type_cd is
'检测报告类型ID';

comment on column report.doctor_id is
'医生ID';

comment on column report.patient_id is
'病人ID';

comment on column report.result is
'检测结果';

comment on column report.collect_time is
'检测样本收集时间';

comment on column report.test_time is
'检测时间';

comment on column report.report_time is
'报告生成时间';

comment on column report.description is
'备注';

comment on column report.is_deleted is
'删除标记';

comment on column report.creator_id is
'创建者ID';

comment on column report.created_dt is
'创建时间';

comment on column report.modifier_id is
'修改者ID';

comment on column report.modified_dt is
'修改时间';

/*==============================================================*/
/* Table: report_type                                           */
/*==============================================================*/
create table report_type (
   cd                   VARCHAR(20)          not null,
   name                 VARCHAR(20)          null,
   description          VARCHAR(200)         null default 'covid',
   is_deleted           INT4                 null default 0,
   creator_id           VARCHAR(50)          null,
   created_dt           TIMESTAMP            null default 'now()',
   modifier_id          VARCHAR(50)          null,
   modified_dt          TIMESTAMP            null,
   constraint PK_REPORT_TYPE primary key (cd)
);

comment on table report_type is
'检测报告类型';

comment on column report_type.cd is
'检测报告类型ID';

comment on column report_type.name is
'名称';

comment on column report_type.description is
'描述';

comment on column report_type.is_deleted is
'删除标记';

comment on column report_type.creator_id is
'创建者ID';

comment on column report_type.created_dt is
'创建时间';

comment on column report_type.modifier_id is
'修改者ID';

comment on column report_type.modified_dt is
'修改时间';

alter table doctor
   add constraint FK_DOCTOR_REFERENCE_HOSPITAL foreign key (hospital_id)
      references hospital (id)
      on delete restrict on update restrict;

alter table report
   add constraint FK_REPORT_REFERENCE_DOCTOR foreign key (doctor_id)
      references doctor (id)
      on delete restrict on update restrict;

alter table report
   add constraint FK_REPORT_REFERENCE_REPORT_T foreign key (report_type_cd)
      references report_type (cd)
      on delete restrict on update restrict;

alter table report
   add constraint FK_REPORT_REFERENCE_PATIENT foreign key (patient_id)
      references patient (id)
      on delete restrict on update restrict;

