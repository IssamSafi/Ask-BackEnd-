﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace FinalProject.core.Common
{
    public interface IDbContext
    {
        DbConnection Connection { get; }
    }
}
