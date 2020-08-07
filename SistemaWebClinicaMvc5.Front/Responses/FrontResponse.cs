using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaWebClinicaMvc5.Front.Responses
{
    public class FrontResponse<T>
    {
        public FrontResponse(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
    }
}