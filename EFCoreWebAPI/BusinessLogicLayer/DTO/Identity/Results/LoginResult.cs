﻿namespace BusinessLogicLayer.DTO.Identity.Results
{
    public class LoginResult
    {
        public bool successful { get; set; }
        public string error { get; set; }
        public string token { get; set; }
    }
}
