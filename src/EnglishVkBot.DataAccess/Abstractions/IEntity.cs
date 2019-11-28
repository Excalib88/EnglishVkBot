using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishVkBot.DataAccess.Abstractions
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
