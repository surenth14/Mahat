
			  CREATE OR REPLACE FUNCTION  "Create_tenant"
			  (
				  pvar_tenantid uuid
,
pvar_businessname Varchar(50)
,
pvar_businesstype  Varchar(1024)
,
pvar_natureofbusiness  Varchar(1024)
,
pvar_businessemail Varchar(128)
,
pvar_businessphone Varchar(10)
,
pvar_businesswebsite Varchar(256)
,
pvar_organizationlogo Varchar(256)
,
pvar_numberofemployees int
,
pvar_addressline1 Varchar(256)
,
pvar_addressline2 Varchar(256)
,
pvar_city Varchar(256)
,
pvar_statename Varchar(256)
,
pvar_zip Varchar(256)
,
pvar_country  Varchar(1024)
,
pvar_parentid  uuid
 
				  ,pvar_createduser  uuid 

				  ,OUT pvar_returnMessage Varchar(4000)
			  )
			  RETURNS Varchar(4000) 
              AS $BODY$  
              
              BEGIN

				/*This code generated from staging Powered by Mahat, Source Machine : stg , Build Number : #2024-07-004 (Updated on 07/07/2024 22:07) on 05/06/2025 11:28:20*/
		

			  
			  
			  
			  pvar_returnMessage:='';
			  IF EXISTS (SELECT * from tenant where upper(tenant.businessname::varchar) = upper(pvar_businessname::varchar) and tenant.tenantid=pvar_tenantid)
																THEN

																pvar_returnMessage := pvar_returnMessage||'Business  Name Already Exists.';

																END IF;

              IF(pvar_businesstype is not null AND pvar_businesstype!='0' AND LENGTH(pvar_businesstype)>0)
                                                            THEN                        
                                                                 if(CAST((SELECT Count(T1.T1) 
                                                                FROM regexp_split_to_table(pvar_businesstype, ',') AS T1
                                                                    INNER JOIN regexp_split_to_table((Select  fielddesc 
                                                                from lookups  where fieldname='businesstype'
                                                                and entityname='tenant' LIMIT 1), ',') AS T2 on T1.T1 = T2.T2) AS int) <> CAST((SELECT Count(T1.T1)
                                                                FROM regexp_split_to_table(pvar_businesstype, ',')  AS T1) AS int))
                                                                THEN
                                                                        pvar_returnMessage := pvar_returnMessage || 'businesstype value is invalid';


                                                                END IF;
                                                            END IF;
IF(pvar_country is not null AND pvar_country!='0' AND LENGTH(pvar_country)>0)
                                                            THEN                        
                                                                 if(CAST((SELECT Count(T1.T1) 
                                                                FROM regexp_split_to_table(pvar_country, ',') AS T1
                                                                    INNER JOIN regexp_split_to_table((Select  fielddesc 
                                                                from lookups  where fieldname='country'
                                                                and entityname='tenant' LIMIT 1), ',') AS T2 on T1.T1 = T2.T2) AS int) <> CAST((SELECT Count(T1.T1)
                                                                FROM regexp_split_to_table(pvar_country, ',')  AS T1) AS int))
                                                                THEN
                                                                        pvar_returnMessage := pvar_returnMessage || 'country value is invalid';


                                                                END IF;
                                                            END IF;
IF(pvar_natureofbusiness is not null AND pvar_natureofbusiness!='0' AND LENGTH(pvar_natureofbusiness)>0)
                                                            THEN                        
                                                                 if(CAST((SELECT Count(T1.T1) 
                                                                FROM regexp_split_to_table(pvar_natureofbusiness, ',') AS T1
                                                                    INNER JOIN regexp_split_to_table((Select  fielddesc 
                                                                from lookups  where fieldname='natureofbusiness'
                                                                and entityname='tenant' LIMIT 1), ',') AS T2 on T1.T1 = T2.T2) AS int) <> CAST((SELECT Count(T1.T1)
                                                                FROM regexp_split_to_table(pvar_natureofbusiness, ',')  AS T1) AS int))
                                                                THEN
                                                                        pvar_returnMessage := pvar_returnMessage || 'natureofbusiness value is invalid';


                                                                END IF;
                                                            END IF;
  
			  if(pvar_returnMessage='')
			  THEN

			  

			  INSERT INTO tenant(
				 businessname
,businesstype
,natureofbusiness
,businessemail
,businessphone
,businesswebsite
,organizationlogo
,numberofemployees
,addressline1
,addressline2
,city
,statename
,zip
,country
,parentid

				 ,createduser
				 ,tenantid
				 
                
			  )
			  VALUES (
 				 pvar_businessname
,pvar_businesstype
,pvar_natureofbusiness
,pvar_businessemail
,pvar_businessphone
,pvar_businesswebsite
,pvar_organizationlogo
,pvar_numberofemployees
,pvar_addressline1
,pvar_addressline2
,pvar_city
,pvar_statename
,pvar_zip
,pvar_country
,pvar_parentid

				 ,pvar_createduser
				 ,pvar_tenantid
				 
                   
			  );
			   
               

			  IF(pvar_parentid is not null)
THEN
 

update users set viewertenantids=tenantid::varchar||','||(SELECT STRING_AGG(tenantid::varchar, ',') AS tenantids
FROM tenant
WHERE tenantid =pvar_parentid)
where tenantid=pvar_parentid;

END IF ;


			  
					 
			  pvar_returnMessage := '201.1';
               
              END IF;
			   

			  
			  /*EXCEPTION WHEN OTHERS THEN
			 
						INSERT INTO system_logging
						(
						Log_code
						,system_logging_guid
						,log_application
						,log_date
						,log_level
						,log_logger
						,log_message
						)
						VALUES
						('16'
						,gen_random_uuid()
						,'Store Proc Exception'
						,NOW()
						,'16'
						,'Create_tenant'
						,'insert failed'
						);
                        pvar_returnMessage := 'Create_tenant - Insert failed';*/
			  	
			  END
              $BODY$
              LANGUAGE plpgsql;

