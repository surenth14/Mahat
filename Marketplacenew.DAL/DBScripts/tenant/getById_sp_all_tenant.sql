
			  CREATE OR REPLACE FUNCTION  "getById_sp_all_tenant"
              (
			  pvar_tenantid Varchar
			  )
              RETURNS TABLE(
                "tenantid" uuid
,businessname Varchar
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
,parentid Varchar
,createduser uuid
,createddate Timestamp(5)
,modifieduser uuid
,modifieddate Timestamp(5)

                
                
                
                )

              AS $BODY$
                BEGIN
			   
			  /*This code generated from staging Powered by Mahat, Source Machine : stg , Build Number : #2024-07-004 (Updated on 07/07/2024 22:07) on 05/06/2025 11:28:20*/
			  		 
              RETURN QUERY
			  SELECT  
				 tenant.tenantid
,tenant.businessname
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
,CAST(_tenant.businessname AS VARCHAR) as parentid

				 ,tenant.createduser,tenant.createddate,tenant.modifieduser,tenant.modifieddate
                 
                 
			  FROM  tenant 
LEFT OUTER JOIN tenant _tenant ON tenant.parentid=_tenant.tenantid

			  WHERE CAST(tenant.tenantid AS Varchar)=pvar_tenantid ;
			  
					 	
			  END
              $BODY$
              LANGUAGE plpgsql;

