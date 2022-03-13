using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.Transmissions.Rules;

public class TransmissionBusinessRules
{ 
    private readonly ITransmissionRepository _transmissionRepository;
    public TransmissionBusinessRules(ITransmissionRepository transmissionRepository)
    {
        _transmissionRepository = transmissionRepository;
    }

    public async Task TransmissionNameCanNotBeDuplicatedWhenInserting(string name)
    {
        var result = await _transmissionRepository.GetListAsync(b=>b.Name == name);
        if(result.Items.Any())
        {
            throw new BusinessException("Transmission name exists");
        }
    }
}