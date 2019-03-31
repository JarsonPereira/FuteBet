using FluentValidator;
using FuteBet.Dominio.Enum;
using FuteBet.Dominio.ValuesObjects;
using System;
using System.Collections.Generic;
using System.Text;


namespace FuteBet.Dominio.Entidade
{
    public class Usuario : FuteBet.Shared.Entidade.Entidade
    {
        public Usuario(Email email, Senha senha)
        {
            Email = email;
            Senha = senha;
            this.AddNotifications(email.Notifications);
            this.AddNotifications(senha.Notifications);
        }

        public Usuario(string nome, Documento documento, Email email, Senha senha, Status status)
        {
            Nome = nome;
            Documento = documento;
            Email = email;
            Senha = senha;
            Status = status;
            this.AddNotifications(documento.Notifications);
            this.AddNotifications(email.Notifications);
            this.AddNotifications(senha.Notifications);
            if (!string.IsNullOrEmpty(nome))
            {
                AddNotification("Nome", "Nome do úsuario não informado");
            }
        }


        public string Nome { get; private set; }
        public Documento Documento { get; private set; }
        public Email Email { get; private set; }
        public Senha Senha { get; private set; }
        public Status Status { get; private set; }
        public string TokenAcesso { get; private set; }
    }
}
