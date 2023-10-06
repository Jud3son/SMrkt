﻿namespace SuperMarketBackend.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public int UserType { get; set; }
    }
}
