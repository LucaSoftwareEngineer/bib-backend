using models.dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace services.interfaces
{
    public interface INoleggioService
    {
        public Task<AddNoleggioResponse> AddNoleggio(AddNoleggioRequest request);
    }
}
