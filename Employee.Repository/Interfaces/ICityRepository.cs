using System;
using System.Collections.Generic;
using System.Text;
using Employee.Models;
using Employee.Models.Models;
using Microsoft.AspNetCore.Http;

using System.Threading.Tasks;

namespace Employee.Repository.Interfaces
{
   public interface ICityRepository
    {
        Task<BaseResponse> City();
        Task<BaseResponse> SelectCityByID(int id);
        Task<BaseResponse> InsertCity(CityRequest cityRequest);
        Task<BaseResponse> UpdateCity(CityRequest cityRequest);
        Task<BaseResponse> DeleteCity(int id);
        void SetRequest(HttpRequest httpRequest);
    }
}
