﻿namespace TicketBookingApp.Application.Models.Identity
{
    public class AuthResponse
    {
        public string Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string  Token { get; set; }
    }
}