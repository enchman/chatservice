using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatModule
{
    public interface IRoom
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }
}
