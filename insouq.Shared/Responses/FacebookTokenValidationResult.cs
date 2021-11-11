using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Shared.Responses
{
    public class FacebookTokenValidationResult
    {
        public string AppId { get; set; }
        public string Type { get; set; }
        public string Application { get; set; }
        public long DataAccessExpiresAt { get; set; }
        public long ExpiresAt { get; set; }
        public bool IsValid { get; set; }
        public string[] Scopes { get; set; }
        public string[] UserId { get; set; }


    }
}
