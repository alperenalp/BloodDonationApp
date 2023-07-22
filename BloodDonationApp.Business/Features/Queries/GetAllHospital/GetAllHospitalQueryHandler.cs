using BloodDonationApp.Business.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Business.Features.Queries.GetAllHospital
{
    public class GetAllHospitalQueryHandler : IRequestHandler<GetAllHospitalQueryRequest, GetAllHospitalQueryResponse>
    {
        private readonly IHospitalService _hospitalService;

        public GetAllHospitalQueryHandler(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        public async Task<GetAllHospitalQueryResponse> Handle(GetAllHospitalQueryRequest request, CancellationToken cancellationToken)
        {
            var hospitals = await _hospitalService.GetHospitalListAsync();
            return new() { Hospitals = hospitals };
        }
    }
}
