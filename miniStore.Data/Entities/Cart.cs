﻿using System;
using System.Collections.Generic;
using System.Text;

namespace miniStore.Data.Entities
{
    public  class Cart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }

        public Guid UserId { get; set; }

        public Product Product { get; set; }

        public DateTime DateCreated { get; set; }

    }
}
