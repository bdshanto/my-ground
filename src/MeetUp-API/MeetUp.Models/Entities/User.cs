﻿namespace MeetUp.Domains.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash{ get; set; }
        public byte[] PasswordSalt{ get; set; }
    }
}