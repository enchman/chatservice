using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ChatService.Data
{
    public class DataContext: DbContext
    {
        DbSet<Acc>
    }
}
