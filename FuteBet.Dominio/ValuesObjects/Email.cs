using FluentValidator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FuteBet.Dominio.ValuesObjects
{
    public class Email:Notifiable
    {
        public Email(string endereco)
        {
            Endereco = endereco;
            if (!ValidaEmail(Endereco))
            {
                AddNotification("Email", "O endereço de email está em um formato invalido.");
            }
        }

        public string Endereco { get; private set; }

        public bool ValidaEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}
