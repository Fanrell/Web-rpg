﻿namespace RPG.Models;

public class User
{
    public Guid Id { get; set;}
    public string Username { get; set;}
    public string PasswordHash { get; set;}
    public string EmailHash { get; set;}

}