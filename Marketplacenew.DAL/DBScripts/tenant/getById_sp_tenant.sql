 
			  
			  CREATE OR REPLACE FUNCTION  "getById_sp_tenant"
			  (
				  pvar_tenantid Varchar
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

                ,tenantid uuid
                
            )
            AS $BODY$
            BEGIN
			  /*This code generated from staging Powered by Mahat, Source Machine : stg , Build Number : #2024-07-004 (Updated on 07/07/2024 22:07) on 05/06/2025 11:28:20*/
               
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
			  WHERE CAST(tenant.tenantid AS Varchar)=pvar_tenantid
                       ;

					 	
			  END
              $BODY$
              LANGUAGE plpgsql;

