using EnglishVkBot.DataAccess.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishVkBot.DataAccess.Entities
{
    public class EntityBase: IEntity
    {
        public long? Id { get; set; }
        
        public bool IsActive { get; set; }
    }
}
