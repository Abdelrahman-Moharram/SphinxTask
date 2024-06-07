using AutoMapper;
using SpinxTask.Core.DTOs.Clients;
using SpinxTask.Core.DTOs;
using SpinxTask.Core.Interfaces;
using SpinxTask.Core.IServices;
using SpinxTask.Core.Models;
using Microsoft.EntityFrameworkCore;


namespace SpinxTask.Services
{
    public class ClientServices : IClientServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ClientServices(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<GetClientDTO>> ListClients(int take, int skip)
        {
            var Clients =
                await _unitOfWork
                    .Clients
                    .GetAllAsync(
                        orderBy: i => i.OrderBy(p => p.Name),
                        take: take,
                        skip: skip,
                        include:i=>i.Include(m=>m.Class).Include(m=>m.State )
                    );

            return _mapper.Map<List<GetClientDTO>>(Clients);
        }

        public async Task<GetClientDTO> GetClient(string Id)
        {
            var Clients =
                await _unitOfWork
                    .Clients
                    .FindAsync(
                        i=>i.Id == Id,
                        include: o =>o
                            .Include(m => m.Class)
                            .Include(m => m.State)
                            .Include(c => c.ClientProducts)
                                .ThenInclude(p => p.Product)
                         
                    );

            return _mapper.Map<GetClientDTO>(Clients);
        }

        public async Task<int> ClientsLength()
        {
            var length =
                await _unitOfWork
                    .Clients
                    .GetCount();

            return length;
        }


        public async Task<BaseResponse> AddClient(BaseClientDTO ClientDTO)
        {
            var Client = _mapper.Map<Client>(ClientDTO);
            await _unitOfWork.Clients.AddAsync(Client);
            _unitOfWork.SaveAsync();

            return new BaseResponse
            {
                IsSuccess = true,
                Message = "Client Added Successfully"
            };

        }

        public async Task<BaseResponse> EditClient(ClientDTO ClientDTO)
        {
            var OldClient = await _unitOfWork.Clients.FindAsync(i=>i.Id == ClientDTO.Id, disableTracking:true);
            var Client = _mapper.Map<Client>(ClientDTO);

            if (OldClient == null)
                return new BaseResponse
                {
                    IsSuccess = false,
                    Message = "This Client is not found"
                };

            if (OldClient.Code != Client.Code)
                return new BaseResponse
                {
                    IsSuccess = false,
                    Message = "Client Code is not Editable, Delete the Client and re-add him with a new valid data"
                };
            await _unitOfWork.Clients.UpdateAsync(Client);
            _unitOfWork.SaveAsync();

            return new BaseResponse
            {
                IsSuccess = true,
                Message = "Client Added Successfully"
            };

        }

        public async Task<BaseResponse> DeleteClient(string Id)
        {
            var Client = await _unitOfWork.Clients.GetById(Id);
            if (Client == null)
                return new BaseResponse
                {
                    IsSuccess = false,
                    Message = "This Client is not found"
                };

            _unitOfWork.Clients.DeleteAsync(Client);
            _unitOfWork.SaveAsync();
            return new BaseResponse
            {
                IsSuccess = true,
                Message = $"Client {Client.Name} Deleted Successfully"
            };
        }

        public async Task<CreateViewModel> GetClassesAndStates()
        {
            return new CreateViewModel
            {
                Classes = _unitOfWork.Classes.GetAllAsync().Result.Select(i => new BaseModule { Id = i.Id, Name = i.Name }).OrderBy(i=>i.Name).ToList(),
                States = _unitOfWork.States.GetAllAsync().Result.Select(i => new BaseModule { Id = i.Id, Name = i.Name }).OrderBy(i => i.Name).ToList()
            };
        }
    }
}
