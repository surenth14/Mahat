
			  CREATE OR REPLACE FUNCTION  "Update_tenant"
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

				  ,pvar_modifieduser  uuid  
				  ,OUT pvar_returnMessage Varchar(4000)
			  )
			  RETURNS Varchar(4000) 
              AS $BODY$  
              
              BEGIN

			  /*This code generated from staging Powered by Mahat, Source Machine : stg , Build Number : #2024-07-004 (Updated on 07/07/2024 22:07) on 05/06/2025 11:28:20*/
			  


			  pvar_returnMessage:='';

			  if EXISTS (SELECT * from tenant where upper(tenant.businessname) = upper(pvar_businessname) and tenant.tenantid=pvar_tenantid  and tenant.tenantid <> pvar_tenantid)
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
 
			  IF(pvar_returnMessage='')
			  THEN

                    INSERT INTO tenant_history
SELECT *,NOW(),pvar_modifieduser::uuid,'Modified' FROM tenant
 WHERE tenantid= pvar_tenantid;

                    
                    UPDATE tenant SET
                    businessname=pvar_businessname
,businesstype=pvar_businesstype
,natureofbusiness=pvar_natureofbusiness
,businessemail=pvar_businessemail
,businessphone=pvar_businessphone
,businesswebsite=pvar_businesswebsite
,organizationlogo=pvar_organizationlogo
,numberofemployees=pvar_numberofemployees
,addressline1=pvar_addressline1
,addressline2=pvar_addressline2
,city=pvar_city
,statename=pvar_statename
,zip=pvar_zip
,country=pvar_country
,parentid=pvar_parentid

                    
                    ,modifieduser=pvar_modifieduser,modifieddate=NOW()
                    WHERE tenantid=pvar_tenantid;

                    IF(pvar_parentid is not null)
THEN
 

update users set viewertenantids=tenantid::varchar||','||(SELECT STRING_AGG(tenantid::varchar, ',') AS tenantids
FROM tenant
WHERE tenantid =pvar_parentid)
where tenantid=pvar_parentid;

END IF ;

                    


					
							
					pvar_returnMessage := '201.1';
			
			  END IF;

			  

			  			 /* EXCEPTION WHEN OTHERS THEN
			 
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
						,'Postgre Function Exception'
						,NOW()
						,'16'
						,'Update_tenant'
						,'update failed'
						);
                        pvar_returnMessage := 'Update_tenant - update failed';*/
			  	
			  END
              $BODY$
              LANGUAGE plpgsql;

