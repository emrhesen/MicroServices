﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServices.Banking.Application.Models
{
    public class AccountTransfer
    {
        public int ToAccount { get; set; }
        public int FromAccount { get; set; }
        public decimal TransferAmount { get; set; }
    }
}
