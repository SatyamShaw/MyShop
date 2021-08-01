﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public abstract class BaseModel
    {
        public string Id { get; set; }
        public DateTime createdDate { get; set; }

        public BaseModel()
        {
            this.Id = Guid.NewGuid().ToString();
            this.createdDate = DateTime.Now;
        }
    }
}
