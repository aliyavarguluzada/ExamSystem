﻿namespace ExamSystem.Results.Requests
{
    public class UpdateRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool isActive { get; set; }
    }
}
