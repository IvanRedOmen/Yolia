﻿using com.Yolia.App.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.Yolia.App.Data.Service
{
    public interface IClienteService
    {
        List<ClienteDto> GetAll();
        ClienteDto Save(ClienteDto dto);
        ClienteDto FindClienteById(int id);
        ClienteDto Update(ClienteDto dto);
    }
}
