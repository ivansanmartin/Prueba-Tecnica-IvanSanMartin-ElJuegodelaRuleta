using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers.Dtos
{
    public class ApiResponse<T>
    {
        public bool Ok { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}