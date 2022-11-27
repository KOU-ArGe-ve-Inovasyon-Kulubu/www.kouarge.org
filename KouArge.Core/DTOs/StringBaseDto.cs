﻿namespace KouArge.Core.DTOs
{
    public abstract class StringBaseDto
    {
        public string Id { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
    }
}
