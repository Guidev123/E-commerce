﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourSneaker.Core.Comunication
{
    public class ResponseResult
    {
        public ResponseResult()
        {
            Errors = new ResponseErrorMessages();
        }
        public string? Title { get; set; } = string.Empty;
        public int? Status { get; set; }
        public ResponseErrorMessages? Errors { get; set; }
    }

    public class ResponseErrorMessages
    { 
        public ResponseErrorMessages()
        {
            Messages = new List<string>();
        }
        public List<string>? Messages { get; set; }
    }
}
