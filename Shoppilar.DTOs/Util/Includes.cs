using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.Util;

public abstract class Includes
{
    #region Person

    public static readonly string PersonIncludeAuth =
        IncludeHelper.GetIncludePaths<Person>(p => p.PersonType!, p => p.Image!);

    #endregion
}