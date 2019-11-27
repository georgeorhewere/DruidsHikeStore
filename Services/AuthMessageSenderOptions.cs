using System;
using System.Collections.Generic;

using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;

namespace DruidsHikeStore.Services
{
    public class AuthMessageSenderOptions
    {
        
        public AuthMessageSenderOptions()
        {
            
        }
        

        public string SendGridUser { get; set; }
        public string SendGridKey { get; set; }
    }
}
