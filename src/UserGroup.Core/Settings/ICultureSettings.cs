using System;

namespace UserGroup.Settings
{
    public interface ICultureSettings
    {
        string[] PossibleCultures { get; }
        string DefaultCulture { get; }
    }
}