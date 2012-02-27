using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserGroup.Services
{
    public interface ISlugger
    {
        string GenerateFrom(string text);
    }


}