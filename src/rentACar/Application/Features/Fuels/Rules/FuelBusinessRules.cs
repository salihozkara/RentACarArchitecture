using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.Fuels.Rules;

public class FuelBusinessRules
{
    IFuelRepository _fuelRepository;
    public FuelBusinessRules(IFuelRepository fuelRepository)
    {
        _fuelRepository = fuelRepository;
    }

    public async Task FuelNameCanNotBeDuplicatedWhenInserting(string name)
    {
        var result = await _fuelRepository.GetListAsync(b=>b.Name == name);
        if(result.Items.Any())
        {
            throw new BusinessException("Fuel name exists");
        }
    }
}