using System;
using System.Collections.Generic;
using System.Text;
using Employee.Repository.Interfaces;
using Dapper;
using Employee.Models;
using Employee.Models.Models;
using Microsoft.AspNetCore.Http; 
using System.Data;
using System.Data.SqlClient; 
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Employee.Repository
{
    public class CityRepository : ICityRepository
    {
        HttpRequest _request;
        private readonly string _connectionString;

        public CityRepository(string connectionString)
        {
            _connectionString = connectionString;

        }

        public void SetRequest(HttpRequest httpRequest)
        {
            this._request = httpRequest;
        }

        public async Task<BaseResponse> SelectCityByID(int iD)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters para = new DynamicParameters();

                    para.Add("@CityID", iD); 
                    var results = await connection.QueryAsync<City>("[Ref].[SelectCityByID]", para, commandType: CommandType.StoredProcedure);

                    return new BaseResponseRepository().GetSuccessResponse(results);
                }
            }

            catch (SqlException ex)
            {
                return new BaseResponseRepository().GetErrorResponse(ex);
            }
            catch (Exception ex)
            {
                return new BaseResponseRepository().GetErrorResponse(ex);
            }

        }

        public async Task<BaseResponse> City()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters para = new DynamicParameters();

                    var results = await connection.QueryAsync<City>("[Ref].[SelectCity]", para, commandType: CommandType.StoredProcedure);

                    return new BaseResponseRepository().GetSuccessResponse(results);
                }
            }

            catch (SqlException ex)
            {
                return new BaseResponseRepository().GetErrorResponse(ex);
            }
            catch (Exception ex)
            {
                return new BaseResponseRepository().GetErrorResponse(ex);
            }

        }

        public async Task<BaseResponse> InsertCity(CityRequest cityRequest)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    string JsonData = JsonConvert.SerializeObject(cityRequest);
                    para.Add("@JsonData", JsonData, DbType.String);
                    para.Add("@Operation", "I", DbType.String);

                    var results = await connection.QueryAsync<CityRequest>("[Ref].[InsertCity]", para, commandType: CommandType.StoredProcedure);
                    return new BaseResponseRepository().GetSuccessResponse(results);
                }
            }
            catch (SqlException ex)
            {
                return new BaseResponseRepository().GetErrorResponse(ex);
            }
            catch (Exception ex)
            {
                return new BaseResponseRepository().GetErrorResponse(ex);
            }
        }

        public async Task<BaseResponse> UpdateCity(CityRequest cityRequest)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    string JsonData = JsonConvert.SerializeObject(cityRequest);
                    para.Add("@JsonData", JsonData, DbType.String);
                    para.Add("@Operation", "U", DbType.String);

                    var results = await connection.QueryAsync<CityRequest>("[Ref].[InsertCity]", para, commandType: CommandType.StoredProcedure);
                    return new BaseResponseRepository().GetSuccessResponse(results);
                }
            }
            catch (SqlException ex)
            {
                return new BaseResponseRepository().GetErrorResponse(ex);
            }
            catch (Exception ex)
            {
                return new BaseResponseRepository().GetErrorResponse(ex);
            }
        }

        public async Task<BaseResponse> DeleteCity(int Id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@ID", Id);

                    var results = await connection.QueryAsync<CityRequest>("[Ref].[DeleteCity]", para, commandType: CommandType.StoredProcedure);
                    return new BaseResponseRepository().GetSuccessResponse(results);
                }
            }
            catch (SqlException ex)
            {
                return new BaseResponseRepository().GetErrorResponse(ex);
            }
            catch (Exception ex)
            {
                return new BaseResponseRepository().GetErrorResponse(ex);
            }
        }
    }

}
