using Base.Lgm.Core.Models.Dto.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Lgm.Core.Models.Dto.Response
{
    public class UserResponse : UserRequest
    {
        public int IdUser { get; set; }
    }
}
