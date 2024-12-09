﻿using Mesta.CompetenceManagement.Integrations.Mdc.Persons;

namespace Mesta.CompetenceManagement.Domain
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty; 
        public DateTime DateOfBirth { get; set; }
        public string PersonalMobilePhone { get; set; }
        public string PersonalEmail { get; set; }
    }
}