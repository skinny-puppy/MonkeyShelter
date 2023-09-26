using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonkeyShelter.Services
{

    public class IvicaService : IIvicaService
    {
        public string GetName()
        {
            return "Test Service";
        }
    }
}