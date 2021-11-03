﻿using MM4Bank.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM4Bank.Domain.Entities
{
    public sealed class Account : Entity
    {
        //listar propriedades de Account
        public string Name { get; private set; }
        
        //aqui pode ser mudado de name para AccountNumber
        public Account(string name)
        {
            ValidateDomain(name);
        }

        public Account(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id Value");
            Id = id;
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        public ICollection<Client> Clients { get; set; }

        //podem ser criados n casos de validação aqui
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters");

            Name = name;
        }
    }
}