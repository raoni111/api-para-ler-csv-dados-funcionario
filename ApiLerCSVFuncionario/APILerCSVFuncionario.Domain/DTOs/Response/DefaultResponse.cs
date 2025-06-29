﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APILerCSVFuncionario.Domain.DTOs.Response
{
    public class DefaultResponse<ResponseType> where ResponseType : new()
    {
        public bool? Success { get; set; }
        public string? Message { get; set; }
        public ResponseType? Data { get; set; } 

        public DefaultResponse()
        {
            Data = default;
        }
    }
}
