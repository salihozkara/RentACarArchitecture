using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.Colors.Rules;

public class ColorBusinessRules
{ 
    private readonly IColorRepository _colorRepository;
    public ColorBusinessRules(IColorRepository colorRepository)
    {
        _colorRepository = colorRepository;
    }

    public async Task ColorNameCanNotBeDuplicatedWhenInserting(string name)
    {
        var result = await _colorRepository.GetListAsync(b=>b.Name == name);
        if(result.Items.Any())
        {
            throw new BusinessException("Color name exists");
        }
    }
}