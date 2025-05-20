namespace Marketplacenew.Models{
			using System;
			using System.ComponentModel.DataAnnotations;
			using Microsoft.AspNetCore.Mvc;
                        using System.Collections.Generic;
			//This code generated from staging Powered by Mahat, Source Machine : stg , Build Number : #2024-07-004 (Updated on 07/07/2024 22:07) on 05/06/2025 11:28:20
			public class tenantModel
			{

			 public System.Guid ?tenantid	{ get; set; }
public String viewertenantids { get; set; }

[xssFilter]
public string businessname{ get; set; }

[xssFilter]
public string businesstype{ get; set; }

[xssFilter]
public string natureofbusiness{ get; set; }

[xssFilter]
public string businessemail{ get; set; }

[xssFilter]
public string businessphone{ get; set; }

[xssFilter]
public string? businesswebsite{ get; set; }

[xssFilter]
public string? organizationlogo{ get; set; }

public int? numberofemployees{ get; set; }

[xssFilter]
public string? addressline1{ get; set; }

[xssFilter]
public string? addressline2{ get; set; }

[xssFilter]
public string? city{ get; set; }

[xssFilter]
public string? statename{ get; set; }

[xssFilter]
public string? zip{ get; set; }

[xssFilter]
public string? country{ get; set; }

public Guid? parentid	{ get; set; }
public System.Guid ?createduser	{ get; set; }
[DataType(DataType.Date)]
[ModelBinder(BinderType = typeof(DateTimeModelBinder))]
[DisplayFormat(DataFormatString="{0:dd/MM/yyyy}", ApplyFormatInEditMode=true)]
public System.DateTime ?createddate	{ get; set; }
public System.Guid ?modifieduser	{ get; set; }
[DataType(DataType.Date)]
[ModelBinder(BinderType = typeof(DateTimeModelBinder))]
[DisplayFormat(DataFormatString="{0:dd/MM/yyyy}", ApplyFormatInEditMode=true)]
public System.DateTime ?modifieddate	{ get; set; }
public bool isdeleted	{ get; set; }
[xssFilter]
                        [Required(ErrorMessage = "craftmyapp_actionmethodname is required,please pass current action name")]
                        public String craftmyapp_actionmethodname{ get; set; }



			}
			



                

                

                
 

                

                

			}
