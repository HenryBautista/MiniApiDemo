using Microsoft.EntityFrameworkCore;
using MinApiDemo.Models;
using MinApiDemo.Repository;

namespace MinApiDemo.Services;
public class BussinesLogic
{
    private readonly RatioDb _ratioDb;

    public BussinesLogic(RatioDb ratiodb)
    {
        _ratioDb = ratiodb;
    }

    public async Task<Ratio> GetRatio(decimal value)
    {
        var ratio = await _ratioDb.Ratios.FirstOrDefaultAsync(ratio =>
            ratio.LowerBound <= value && 
            ratio.UpperBound >= value);

        return ratio ?? new Ratio();
    }
}