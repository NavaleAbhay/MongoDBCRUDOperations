﻿using MongoDB.Bson;  
namespace HR;
public class Employee{
    public ObjectId Id{get;set;}
    public string FirstName{get;set;}
    public string LastName{get;set;}
    public string Email{get;set;}
    public string Address{get;set;}
    public string Password{get;set;}
    public string ManagerId{get;set;}
    }