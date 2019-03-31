using FluentValidator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FuteBet.Dominio.ValuesObjects
{
    public class Senha : Notifiable
    {
        public Senha(string senhaForte)
        {
            SenhaForte = senhaForte;
            if (!ValidaSenha(SenhaForte)){
                AddNotification("Senha", "Senha fraca.");
            }
        }

        public string SenhaForte { get; private set; }

        public bool ValidaSenha(string senha)
        {
            Regex regex = new Regex(@"^[^\W_]{4}$");
            Match match = regex.Match(senha);

            return (match.Success);
        }
    }
}
