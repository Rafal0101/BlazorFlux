using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFlux.Stores.CouterStore
{
    public interface IAction
    {
        public string Name { get; }
    }
}
