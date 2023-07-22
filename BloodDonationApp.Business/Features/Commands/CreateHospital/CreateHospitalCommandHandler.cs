using BloodDonationApp.Business.DTOs.Requests;
using BloodDonationApp.Business.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Business.Features.Commands.CreateHospital
{
    public class CreateHospitalCommandHandler : IRequestHandler<CreateHospitalCommandRequest, CreateHospitalCommandResponse>
    {
        private readonly IHospitalService _hospitalService;
        public CreateHospitalCommandHandler(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        public async Task<CreateHospitalCommandResponse> Handle(CreateHospitalCommandRequest request, CancellationToken cancellationToken)
        {
            var hospital = new CreateNewHospitalRequest
            {
                Name = request.Name,
                Address = request.Address,
                Phone = request.Phone
            };
            await _hospitalService.CreateHospitalAsync(hospital);
            return new();
        }
    }
}
