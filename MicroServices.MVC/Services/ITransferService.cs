using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroServices.MVC.Models.DTO;

namespace MicroServices.MVC.Services
{
    public interface ITransferService
    {
        Task Transfer(TransferDTO transferDto);
    }
}
