using System;
using System.Collections.Generic;
using System.Text;
using FluentValidator;

namespace FuteBet.Shared.Entidade
{
    public abstract class Entidade:Notifiable
    {
        public Guid ID { get; private set; }

        public Entidade()
        {
            ID = Guid.NewGuid();
        }
    }
}
