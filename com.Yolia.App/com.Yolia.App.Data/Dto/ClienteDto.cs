﻿using com.Yolia.App.Data.Model;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.Yolia.App.Data.Dto
{
    public class ClienteDto { 
  
        public ClienteDto()
        {
            Domicilios = new List<DomicilioDto>();
            Servicios = new List<ServicioDto>();
        }

        public int ClienteId { get; set; }
        public string ClienteRFC { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NumFijo { get; set; }
        public string NumMovil { get; set; }
        public List<DomicilioDto> Domicilios { get; set; }
        public List<ServicioDto> Servicios { get; set; }


        internal static List<ClienteDto> ToMap(List<Cliente> listEntity)
        {
            List<ClienteDto> listDto = (from entity in listEntity select ToMap(entity)).ToList();
            return listDto;
        }


        internal static ClienteDto ToMap(Cliente entity)
        {
            if (entity == null) return null;
            TinyMapper.Bind<Domicilio, DomicilioDto>();
            TinyMapper.Bind<Servicio, ServicioDto>();
            ClienteDto dto = TinyMapper.Map<ClienteDto>(entity);
            return dto;
        }

        internal static Cliente ToUnMap(ClienteDto dto)
        {
            if (dto == null) return null;
            TinyMapper.Bind<ClienteDto, Cliente>(config =>
            {
                config.Ignore(_dto => _dto.Domicilios);
                config.Ignore(_dto => _dto.Servicios);
            });
            Cliente entity = TinyMapper.Map<Cliente>(dto);
            return entity;
        }

    }
}
