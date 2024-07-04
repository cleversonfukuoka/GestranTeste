using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestranTeste.DTO;
using Models;
using Repository;

namespace GestranTeste.Services.Implementations
{
    public class ChecklistImplementations : IChecklistService
    {
        private GestranContext _context;
        public ChecklistImplementations(GestranContext context) {
            _context = context;
        }

        public void Create(CheckListDTO checklistDTO)
        {
            var checklist = new Checklist()
            {
                Veiculo_Id = checklistDTO.veiculo.Id,
                Usuario_Executor_Id = checklistDTO.usuarioExecutor.Id,
                Data_Inicio = checklistDTO.Data_Inicio,
                Data_Fim = checklistDTO.Data_Fim,
                Finalizado = checklistDTO.Finalizado,
                Aprovado = checklistDTO.Aprovado,
                Usuario_Supervisor_Id = checklistDTO.usuarioSupervisor.Id,
                Items = checklistDTO.checklistItems
                    .Select(s => new ChecklistItem
                    {                        
                        Item_Inspecao_Id = s.itemInspecaoDTO.Id,
                        Conforme = s.Conforme,
                        Observacao = s.Observacao
                    }).ToList()
            };

            try
            {
                _context.Add(checklist);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public void Update(CheckListDTO checklistDTO) 
        {
            var checklist = _context.Checklists
                .Include(c => c.Items)
                .FirstOrDefault(c => c.Id == checklistDTO.Id);
            
            if (checklist == null) { return; }
            
            try
            {
                checklist.Veiculo_Id = checklistDTO.veiculo.Id;
                checklist.Usuario_Executor_Id = checklistDTO.usuarioExecutor.Id;
                checklist.Data_Inicio = checklistDTO.Data_Inicio;
                checklist.Data_Fim = checklistDTO.Data_Fim;
                checklist.Finalizado = checklistDTO.Finalizado;
                checklist.Aprovado = checklistDTO.Aprovado;
                checklist.Usuario_Supervisor_Id = checklistDTO.usuarioSupervisor.Id;

                // Atualizar os itens do checklist
                _context.ChecklistItens.RemoveRange(checklist.Items);
                checklist.Items = checklistDTO.checklistItems.Select(i => new ChecklistItem
                {
                    Item_Inspecao_Id = i.itemInspecaoDTO.Id,
                    Conforme = i.Conforme,
                    Observacao = i.Observacao
                }).ToList();
                
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }           
            
        }

        public void Delete(long Id)
        {
            var result = _context.Checklists.SingleOrDefault(p=>p.Id == Id);
            if (result != null)
            {
                try
                {
                    _context.Checklists.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(long Id)
        {
            return _context.Checklists.Any(p => p.Id.Equals(Id));            
        }

        public List<CheckListDTO> FindAll()
        {
            return _context.Checklists
                .Include(c=>c.Veiculo_Id)
                .Include(c=>c.Usuario_Executor_Id)
                .Include(c=>c.Usuario_Supervisor_Id)
                .Include(c=>c.Items)
                .ThenInclude(i=>i.Item_Inspecao_Id)
                .Select(c=> new CheckListDTO
                {
                    Id = c.Id,
                    veiculoId = c.Veiculo_Id,
                    usuarioExecutorId = c.Usuario_Executor_Id,
                    usuarioSupervisorId = c.Usuario_Supervisor_Id,
                    Data_Inicio = c.Data_Inicio,
                    Data_Fim = c.Data_Fim,
                    Finalizado = c.Finalizado,
                    Aprovado = c.Aprovado,
                    checklistItems = c.Items
                        .Select(i=> new CheckListItemDTO
                        {
                            Id=i.Id,                            
                            ChecklistId = i.Checklist_Id,
                            ItemInspecaoId = i.Item_Inspecao_Id,
                            Conforme = i.Conforme,
                            Observacao = i.Observacao
                        }).ToList()                    
                }).ToList();            
        }

        public CheckListDTO FindById(long Id)
        {
            var checklist = _context.Checklists
                                .Include(c => c.Veiculo_Id)
                                .Include(c => c.Usuario_Executor_Id)
                                .Include(c => c.Usuario_Supervisor_Id)
                                .Include(c => c.Items)
                                .ThenInclude(i => i.Item_Inspecao_Id)
                                .FirstOrDefault(c => c.Id == Id);

            if (checklist == null) return null;

            return new CheckListDTO
            {
                Id = checklist.Id,
                veiculoId = checklist.Veiculo_Id,
                //veiculo.Placa = checklist.Veiculo.Placa,
                //usuarioExecutor.Id = checklist.UsuarioExecutorId,
                //usuarioExecutor.Nome = checklist.UsuarioExecutor.Nome,
                //DataInicio = checklist.DataInicio,
                //DataFim = checklist.DataFim,
                Finalizado = checklist.Finalizado,
                Aprovado = checklist.Aprovado,
                //UsuarioSupervisorId = checklist.UsuarioSupervisorId,
                //UsuarioSupervisorNome = checklist.UsuarioSupervisor?.Nome,
                //Items = checklist.Items.Select(i => new CheckListItemDTO
                /*{
                    Id = i.Id,
                    ChecklistId = i.Checklist_Id,
                    ItemInspecaoId = i.Item_Inspecao_Id,
                    itemInspecaoDTO.Descricao = _context.ItensInspecao
                                .Where(w => w.Id == i.Item_Inspecao_Id)
                                .Select(s => s.Descricao),

                    Conforme = i.Conforme,
                    Observacao = i.Observacao
                }).ToList()*/
            };
        }
 
    }
}
