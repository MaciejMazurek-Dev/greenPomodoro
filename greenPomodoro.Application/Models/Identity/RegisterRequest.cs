﻿namespace greenPomodoro.Application.Models.Identity
{
    public class RegisterRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
