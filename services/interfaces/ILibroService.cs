using models.dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace services.interfaces
{
    public interface ILibroService
    {
        public Task<AddLibroResponse> AddLibro(AddLibroRequest request);
        public Task<List<LibroResponse>> GetAllLibro();
    }
}
