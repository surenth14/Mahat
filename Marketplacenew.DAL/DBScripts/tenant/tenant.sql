CREATE TABLE IF NOT EXISTS tenant
(
tenantid uuid  PRIMARY KEY
,viewertenantids Jsonb  NULL
,businessname Varchar(50) NOT NULL
,businesstype Varchar(1080) NOT NULL
,natureofbusiness Varchar(1080) NOT NULL
,businessemail Varchar(128) NOT NULL
,businessphone Varchar(20) NOT NULL
,businesswebsite Varchar(256) NULL
,organizationlogo Varchar(4000) NULL
,numberofemployees int NULL
,addressline1 Varchar(256) NULL
,addressline2 Varchar(256) NULL
,city Varchar(256) NULL
,statename Varchar(256) NULL
,zip Varchar(256) NULL
,country Varchar(1080) NULL
,parentid uuid NULL
,UNIQUE(tenantid,businessname)

,createduser uuid NOT NULL
,createddate  Timestamp(3) NOT NULL DEFAULT NOW()
,modifieduser uuid
,modifieddate Timestamp(3)
,isdeleted Boolean DEFAULT false
)


