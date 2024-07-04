using Models;
using GestranTeste.DTO;
using Repository;
using Microsoft.EntityFrameworkCore;

namespace GestranTeste.Services.Implementations
{
    public class VeiculoImplementations : IVeiculosService
    {
        private GestranContext _context;
        public VeiculoImplementations(GestranContext context) {
            _context = context;
        }

        public void Create(VeiculoDTO veiculoDTO)
        {
            var veiculo = new Veiculo
            {
                Id = veiculoDTO.Id,
                Ano = veiculoDTO.Ano,
                Modelo = veiculoDTO.Modelo,
                Placa = veiculoDTO.Placa
            };

            try
            {
                _context.Add(veiculo);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public void Update(VeiculoDTO veiculoDTO) 
        {
            var veiculo = new Veiculo
            {
                Id = veiculoDTO.Id,
                Ano = veiculoDTO.Ano,
                Modelo = veiculoDTO.Modelo,
                Placa = veiculoDTO.Placa
            };

            var result = _context.Veiculos.SingleOrDefault(p=>p.Id == veiculo.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(veiculo);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }            
        }

        public void Delete(long Id)
        {
            var result = _context.Veiculos.SingleOrDefault(p=>p.Id == Id);
            if (result != null)
            {
                try
                {
                    _context.Veiculos.Remove(result);
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
            return _context.Veiculos.Any(p => p.Id == Id);            
        }

        public List<VeiculoDTO> FindAll()
        {
            return _context.Veiculos                   
                             .Select(c=> new VeiculoDTO
                             {
                                 Id = c.Id,
                                 Placa = c.Placa,
                                 Modelo = c.Modelo, 
                                 Ano = c.Ano
                             }).ToList();

        }

        public VeiculoDTO FindById(long Id)
        {
            var veiculo = _context.Veiculos
                    .FirstOrDefault(c => c.Id == Id);

            if (veiculo != null) { return null; }

            return new VeiculoDTO
            {
                Id = veiculo.Id,
                Ano = veiculo.Ano,
                Modelo = veiculo.Modelo,
                Placa = veiculo.Placa
            };
        }
    }
}
