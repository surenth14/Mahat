 
			  
			  CREATE OR REPLACE FUNCTION  "get_project_tenant"
              (
			  pvar_businesstype Varchar=null,
              pvar_tenantid  Varchar=null
              )
			 RETURNS TABLE(
                businessname Varchar
,businesstype Varchar
,natureofbusiness Varchar
,businessemail Varchar
,businessphone Varchar
,businesswebsite Varchar
,organizationlogo Varchar
,numberofemployees int
,addressline1 Varchar
,addressline2 Varchar
,city Varchar
,statename Varchar
,zip Varchar
,country Varchar
,parentid uuid
,createduser uuid
,createddate Timestamp(5)
,modifieduser uuid
,modifieddate Timestamp(5)

                ,"tenantid" uuid
                 
               )
               AS $BODY$
                declare lvar_tenantid varchar[];
                declare lstr_usersid varchar;

               BEGIN
             /*This code generated from staging Powered by Mahat, Source Machine : stg , Build Number : #2024-07-004 (Updated on 07/07/2024 22:07) on 05/06/2025 11:28:20*/
                 SELECT  SPLIT_PART(pvar_tenantid, '|', 1),SPLIT_PART(pvar_tenantid, '|', 2) into lstr_usersid,pvar_tenantid;
		
                
                SELECT STRING_TO_ARRAY(viewertenantids, ',') into lvar_tenantid
				FROM users where users.usersid::varchar=lstr_usersid;				
				
			    if(pvar_businesstype is null or LENGTH(CAST(pvar_businesstype as Varchar))=0)
                then
				  pvar_businesstype :='%';
				else
				  pvar_businesstype := '%' || pvar_businesstype || '%';
                end if;
                RETURN QUERY
			  SELECT 

				 tenant.businessname
,tenant.businesstype
,tenant.natureofbusiness
,tenant.businessemail
,tenant.businessphone
,tenant.businesswebsite
,tenant.organizationlogo
,tenant.numberofemployees
,tenant.addressline1
,tenant.addressline2
,tenant.city
,tenant.statename
,tenant.zip
,tenant.country
,tenant.parentid

				 ,tenant.createduser,tenant.createddate,tenant.modifieduser,tenant.modifieddate
				 
                ,tenant.tenantid
				 
			  FROM tenant
			  WHERE   
           ((lvar_tenantid is not null and cast(tenant.tenantid as varchar) = Any(lvar_tenantid)) OR (pvar_tenantid is null or (cast(pvar_tenantid as varchar))='00000000-0000-0000-0000-000000000000' or LENGTH(CAST(pvar_tenantid as Varchar))=0 or CAST(tenant.tenantid as VARCHAR)=pvar_tenantid))
              AND (CAST(tenant.businesstype AS Varchar) like pvar_businesstype OR tenant.businesstype IS NULL ) 
              
			   AND tenant.isdeleted=false;
			 

					 	
			  END
              $BODY$
              LANGUAGE plpgsql;

