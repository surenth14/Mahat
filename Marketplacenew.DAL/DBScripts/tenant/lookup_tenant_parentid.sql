
								CREATE OR REPLACE FUNCTION  "lookup_tenant_parentid"
								(
                                pvar_businesstype character varying
,pvar_parentid Varchar(50)=null

                                
                                )
								RETURNS TABLE("tenantid" Varchar
,businessname Varchar
) 
						 		AS $BODY$
                                
								BEGIN
								/*This code generated from staging Powered by Mahat, Source Machine : stg , Build Number : #2024-07-004 (Updated on 07/07/2024 22:07) on 05/06/2025 11:28:20*/
							    

                                
                                RETURN QUERY        
								SELECT  
								CAST(tenant.tenantid AS Varchar) as tenantid,CAST(tenant.businessname AS Varchar) as businessname
								FROM tenant
								WHERE tenant.natureofbusiness ilike '%Lead%'
                                AND tenant.businesstype=pvar_businesstype 
                                AND tenant.isdeleted=false 
                                
                                ;
								
											
								END
                                $BODY$
                                LANGUAGE plpgsql;

