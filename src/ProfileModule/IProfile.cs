using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileModule
{
    public interface IProfile
    {
        IAccount Owner { get; }
        DateTime Birthdate { get; set; }
        GenderType Gender { get; set; }
    }
}
