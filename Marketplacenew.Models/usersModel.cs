namespace Marketplacenew.Models{
			using System;
			using System.ComponentModel.DataAnnotations;
			using Microsoft.AspNetCore.Mvc;
                        using System.Collections.Generic;
			//This code generated from staging Powered by Mahat, Source Machine : stg , Build Number : #2024-07-004 (Updated on 07/07/2024 22:07) on 05/06/2025 11:28:18
			public class usersModel
			{

			 public System.Guid ?usersid	{ get; set; }
public System.Guid ?tenantid { get; set; }

[xssFilter]
public string firstname{ get; set; }

[xssFilter]
public string? lastname{ get; set; }

[xssFilter]
public string? profilepicture{ get; set; }

[xssFilter]
public string username{ get; set; }

[xssFilter]
public string userpassword{ get; set; }

[xssFilter]
public string? passwordkey{ get; set; }

[xssFilter]
public string emailid{ get; set; }

[xssFilter]
public string mobilenumber{ get; set; }

[xssFilter]
public string userrole{ get; set; }
public ICollection <users_alloweddevicesModel> alloweddevices { get; set; }
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
			

                
			 public class users_alloweddevicesModel
			{

			 

public string? devicename{ get; set; }


public string? deviceid{ get; set; }


public string? notificationid{ get; set; }
public string craftmyapp_actionmethodname{ get; set; }
public string cma_client_row_id{ get; set; }
public int? record_order{ get; set; }
public System.Guid ?users_alloweddevicesid { get; set; }
public System.Guid ?usersid { get; set; }



			}
			





                 public class usersChangePasswordModel
                {
                    public System.Guid ?usersid { get; set; }
                    [xssFilter]
                    public String userpassword{ get; set; }
                    public String passwordkey{ get; set; }
                    public System.Guid ?modifieduser	{ get; set; }



                }

                
 

                

                

			}
