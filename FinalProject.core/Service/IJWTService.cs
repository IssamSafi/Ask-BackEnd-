using FinalProject.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.core.Service
{
    public interface IJWTService
    {
        string Auth(Loginf login);

    }
}
