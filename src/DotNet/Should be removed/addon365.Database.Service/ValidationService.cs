﻿using addon365.IService;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace addon365.Database.Service
{
    class ValidationService : IValidationService
    {
        public Task<HttpResponseMessage> GetServerStatus()
        {
            throw new NotImplementedException();
        }
    }
}
