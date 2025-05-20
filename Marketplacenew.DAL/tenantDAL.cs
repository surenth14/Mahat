namespace Marketplacenew.DAL{
			    using System;
			    using System.Text;
			    using System.Data;
			    using System.Data.Common;
			    using Marketplacenew.Models;
                            using EncrypDecrypt;
                            using Microsoft.Extensions.Logging;
                            using Newtonsoft.Json;
				using Newtonsoft.Json.Linq;
                using Npgsql;
				using NpgsqlTypes;
				using System.Text.RegularExpressions;

			    //This code generated from staging Powered by Mahat, Source Machine : stg , Build Number : #2024-07-004 (Updated on 07/07/2024 22:07) on 05/06/2025 11:28:21
                            public class tenantDAL
                            {
                                        public virtual string db_connectionstring{get;set;}
                                        private readonly ILogger<tenantDAL>? _logger;

                                    public tenantDAL(string connectionString, ILogger<tenantDAL>? logger = null)
                                    {

                                            db_connectionstring=connectionString;
                                            _logger = logger;
                                    }
				  
			        
              public virtual string Create_tenant(tenantModel model)
			  { 
				  String ResponseMessage="";
					 
					try{
							 
                            using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
					        {
						        npsql.Open();
						        using (var dbCommand = new NpgsqlCommand("\"Create_tenant\"", npsql))
						        {
                                        dbCommand.CommandType = CommandType.StoredProcedure;
						            	
								        					dbCommand.Parameters.AddWithValue("pvar_tenantid",NpgsqlDbType.Uuid,(object)model.tenantid??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_businessname",NpgsqlDbType.Varchar,(object)model.businessname??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_businesstype",NpgsqlDbType.Varchar,(object)model.businesstype??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_natureofbusiness",NpgsqlDbType.Varchar,(object)model.natureofbusiness??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_businessemail",NpgsqlDbType.Varchar,(object)model.businessemail??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_businessphone",NpgsqlDbType.Varchar,(object)model.businessphone??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_businesswebsite",NpgsqlDbType.Varchar,(object)model.businesswebsite??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_organizationlogo",NpgsqlDbType.Varchar,(object)model.organizationlogo??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_numberofemployees",NpgsqlDbType.Integer,(object)model.numberofemployees??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_addressline1",NpgsqlDbType.Varchar,(object)model.addressline1??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_addressline2",NpgsqlDbType.Varchar,(object)model.addressline2??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_city",NpgsqlDbType.Varchar,(object)model.city??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_statename",NpgsqlDbType.Varchar,(object)model.statename??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_zip",NpgsqlDbType.Varchar,(object)model.zip??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_country",NpgsqlDbType.Varchar,(object)model.country??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_parentid",NpgsqlDbType.Uuid,(object)model.parentid??DBNull.Value);
dbCommand.Parameters.AddWithValue("pvar_createduser",NpgsqlDbType.Uuid,(object)model.createduser??DBNull.Value);	
					
                                        NpgsqlParameter outParm = new NpgsqlParameter("pvar_returnMessage", NpgsqlDbType.Varchar)
                                        {
                                             Direction = ParameterDirection.Output
                                        };
                                        dbCommand.Parameters.Add(outParm);

                                        dbCommand.ExecuteNonQuery();
								        ResponseMessage = outParm.Value.ToString();
								        if (dbCommand.Connection.State != ConnectionState.Closed)
                    			        {
										         dbCommand.Connection.Dispose();
								        }

						        }
						        npsql.Close();
					        }
 

                                        }catch(Exception ex){
                                                ResponseMessage=ex.Message;
                                                _logger?.LogError(ex, "Error in Create_tenant");
                                        }
					
					return ResponseMessage;

			   }
public virtual tenantModel getById_tenant(string tenantid)
									 {
										DataTable dataTable = new DataTable();
										DataSet dataSet = new DataSet();
										try{
												 
												using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
												{
													npsql.Open();
													using (var dbCommand = new NpgsqlCommand("\"getById_sp_tenant\"", npsql))
													{
														dbCommand.CommandType = CommandType.StoredProcedure;
														dbCommand.Parameters.AddWithValue("pvar_tenantid",(object)tenantid??DBNull.Value);
														using (NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(dbCommand))
														{
															dataSet.Reset();
															dataAdapter.Fill(dataSet);
															dataTable = dataSet.Tables[0];
															if (dbCommand.Connection.State != ConnectionState.Closed)
															{
																dbCommand.Connection.Dispose();
															}
														}
													}
													npsql.Close();
												}
					 
										}catch{
												throw;
										}
										if (dataTable.Rows.Count > 0)
										{
											DataRow row = dataTable.Rows[0];
											return ModelConverter.ConvertDataRowToModel<tenantModel>(row);
										}
										else
										{
											return null;
										}
									 }
			 public virtual string  Update_tenant(tenantModel model)
			 { 
				 String ResponseMessage="";
					try{
						 	 
							using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
							{
								npsql.Open();
								using (var dbCommand = new NpgsqlCommand("\"Update_tenant\"", npsql))
								{
										dbCommand.CommandType = CommandType.StoredProcedure;
															dbCommand.Parameters.AddWithValue("pvar_tenantid",NpgsqlDbType.Uuid,(object)model.tenantid??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_businessname",NpgsqlDbType.Varchar,(object)model.businessname??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_businesstype",NpgsqlDbType.Varchar,(object)model.businesstype??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_natureofbusiness",NpgsqlDbType.Varchar,(object)model.natureofbusiness??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_businessemail",NpgsqlDbType.Varchar,(object)model.businessemail??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_businessphone",NpgsqlDbType.Varchar,(object)model.businessphone??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_businesswebsite",NpgsqlDbType.Varchar,(object)model.businesswebsite??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_organizationlogo",NpgsqlDbType.Varchar,(object)model.organizationlogo??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_numberofemployees",NpgsqlDbType.Integer,(object)model.numberofemployees??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_addressline1",NpgsqlDbType.Varchar,(object)model.addressline1??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_addressline2",NpgsqlDbType.Varchar,(object)model.addressline2??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_city",NpgsqlDbType.Varchar,(object)model.city??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_statename",NpgsqlDbType.Varchar,(object)model.statename??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_zip",NpgsqlDbType.Varchar,(object)model.zip??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_country",NpgsqlDbType.Varchar,(object)model.country??DBNull.Value);

dbCommand.Parameters.AddWithValue("pvar_parentid",NpgsqlDbType.Uuid,(object)model.parentid??DBNull.Value);
dbCommand.Parameters.AddWithValue("pvar_modifieduser",NpgsqlDbType.Uuid,model.modifieduser);	
										NpgsqlParameter outParm = new NpgsqlParameter("@returnMessage", NpgsqlDbType.Varchar)
										{
											 Direction = ParameterDirection.Output
										};
										dbCommand.Parameters.Add(outParm);

										dbCommand.ExecuteNonQuery();
										ResponseMessage = outParm.Value.ToString();
										if (dbCommand.Connection.State != ConnectionState.Closed)
										{
												 dbCommand.Connection.Dispose();
										}

								}
								npsql.Close();
							}		 

					}catch(Exception ex){
						ResponseMessage=ex.Message;
					}
					
					return ResponseMessage;

			   }
public virtual string  Remove_tenant(string id,string loginUserID)
			  { 
				  String ResponseMessage="";
					try{ 
							using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
							{
								npsql.Open();
								using (var dbCommand = new NpgsqlCommand("\"Remove_tenant\"", npsql))
								{
										dbCommand.CommandType = CommandType.StoredProcedure;
										dbCommand.Parameters.AddWithValue("pvar_tenantid",(object)id??DBNull.Value);
										dbCommand.Parameters.AddWithValue("pvar_modifieduser",(object)loginUserID??DBNull.Value);
										NpgsqlParameter outParm = new NpgsqlParameter("@returnMessage", NpgsqlDbType.Varchar)
										{
											 Direction = ParameterDirection.Output
										};
										dbCommand.Parameters.Add(outParm);

										dbCommand.ExecuteNonQuery();
										ResponseMessage = outParm.Value.ToString();
										if (dbCommand.Connection.State != ConnectionState.Closed)
										{
												 dbCommand.Connection.Dispose();
										}

								}
								npsql.Close();
							}	 

					}catch(Exception ex){
						ResponseMessage=ex.Message;
					}
					
					return ResponseMessage;

			   }
public virtual System.Data.DataTable ViewList_tenant()
			  { 
					DataTable dataTable = new DataTable();
                DataSet dataSet = new DataSet(); 

					try{
 
							using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
							{
								npsql.Open();
								using (var dbCommand = new NpgsqlCommand("\"ViewList_tenant\"", npsql))
								{
									dbCommand.CommandType = CommandType.StoredProcedure;
									
									using (NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(dbCommand))
									{
										dataSet.Reset();
										dataAdapter.Fill(dataSet);
										dataTable = dataSet.Tables[0];
										if (dbCommand.Connection.State != ConnectionState.Closed)
										{
											dbCommand.Connection.Dispose();
										}
									}
								}
								npsql.Close();
							}

						 

					}catch{
						throw;
					}


					return dataTable;	


					 

			   }
			   
			 
public virtual System.Data.DataTable get_all_tenant(string tenantid)
			  { 

				    DataTable dataTable = new DataTable();
					DataSet dataSet = new DataSet();

					try{
 
							using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
							{
								npsql.Open();
								using (var dbCommand = new NpgsqlCommand("\"get_all_tenant\"", npsql))
								{
									dbCommand.CommandType = CommandType.StoredProcedure;
									dbCommand.Parameters.AddWithValue("pvar_tenantid",(object)tenantid??DBNull.Value);
									
									using (NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(dbCommand))
									{
										dataSet.Reset();
										dataAdapter.Fill(dataSet);
										dataTable = dataSet.Tables[0];
										if (dbCommand.Connection.State != ConnectionState.Closed)
										{
											dbCommand.Connection.Dispose();
										}
									}
								}
								npsql.Close();
							}
						

					}catch{
						throw;
					}
					return dataTable;	


					 

			   }
public virtual System.Data.DataTable get_project_tenant(string businesstype,string tenantid)
			  { 
					DataTable dataTable = new DataTable();
                DataSet dataSet = new DataSet(); 

					try{
 
							using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
							{
								npsql.Open();
								using (var dbCommand = new NpgsqlCommand("\"get_project_tenant\"", npsql))
								{
									dbCommand.CommandType = CommandType.StoredProcedure;
									dbCommand.Parameters.AddWithValue("pvar_businesstype",(object)businesstype??DBNull.Value);dbCommand.Parameters.AddWithValue("pvar_tenantid",(object)tenantid??DBNull.Value);
									using (NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(dbCommand))
									{
										dataSet.Reset();
										dataAdapter.Fill(dataSet);
										dataTable = dataSet.Tables[0];
										if (dbCommand.Connection.State != ConnectionState.Closed)
										{
											dbCommand.Connection.Dispose();
										}
									}
								}
								npsql.Close();
							}

						 

					}catch{
						throw;
					}


					return dataTable;	


					 

			   }
			   
			 
public virtual System.Data.DataTable getById_allinfo_tenant(string tenantid)
			 {
				DataSet dataSet=new DataSet();
				DataTable dataTable = new DataTable();
				try{
					     
						using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
						{
							npsql.Open();
							using (var dbCommand = new NpgsqlCommand("\"getById_sp_all_tenant\"", npsql))
							{
								dbCommand.CommandType = CommandType.StoredProcedure;
								dbCommand.Parameters.AddWithValue("pvar_tenantid",(object)tenantid??DBNull.Value);
								using (NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(dbCommand))
								{
									dataSet.Reset();
									dataAdapter.Fill(dataSet);
									dataTable = dataSet.Tables[0];
									if (dbCommand.Connection.State != ConnectionState.Closed)
									{
										dbCommand.Connection.Dispose();
									}
								}
							}
							npsql.Close();
						}
					 
				}catch{
						throw;
				}
				return dataTable;
			 }
			  
public virtual System.Data.DataTable lookup_tenant_parentid(string businesstype="")
							        {
                                            DataSet dataSet = new DataSet();
									        DataTable dataTable=new DataTable();
									        try{

                                        		        using (NpgsqlConnection npsql = new NpgsqlConnection(db_connectionstring))
					                                    {
						                                    npsql.Open();
						                                    using (var dbCommand = new NpgsqlCommand("\"lookup_tenant_parentid\"", npsql))
						                                    {
                                            
                                                                dbCommand.Parameters.AddWithValue("pvar_businesstype",(object)businesstype??DBNull.Value);  
																
																 
                                                                dbCommand.CommandType = CommandType.StoredProcedure;
							                                    using (NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(dbCommand))
                                                                {
                                                                    dataSet.Reset();
                                                                    dataAdapter.Fill(dataSet);
                                                                    dataTable = dataSet.Tables[0];
                                                                    if (dbCommand.Connection.State != ConnectionState.Closed)
												                    {
													                    dbCommand.Connection.Dispose();
												                    }
                                                                }
						                                    }
						                                    npsql.Close();
					                                    }
			 

										 
									        }catch{
										        throw;
									        }
									        return dataTable;
							        }







			    }


			    }
