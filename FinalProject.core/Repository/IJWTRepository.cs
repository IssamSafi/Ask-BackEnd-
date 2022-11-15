using FinalProject.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.core.Repository
{
    public interface IJWTRepository
    {
        Loginf Auth(Loginf login);

    }
}
