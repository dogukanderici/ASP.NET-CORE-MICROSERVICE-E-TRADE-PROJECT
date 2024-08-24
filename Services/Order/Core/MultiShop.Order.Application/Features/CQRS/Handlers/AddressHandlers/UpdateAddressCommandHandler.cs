using AutoMapper;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;

        public UpdateAddressCommandHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateAddressCommand updateAddressCommand)
        {
            var checkToData = await _repository.GetByIdAsync(updateAddressCommand.AddressId);

            if (checkToData != null)
            {
                // Dto olarak gönderilen veri güncelleme işlemi için Entity'i oluşturur.
                var valueFromDtoForUpdate = _mapper.Map<Address>(updateAddressCommand);

                await _repository.UpdateAsync(valueFromDtoForUpdate);
            }
        }
    }
}
