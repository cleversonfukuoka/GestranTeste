using Models;
using GestranTeste.DTO;
using Repository;

namespace GestranTeste.Services.Implementations
{
    public class ItemInspecaoImplementations : IItensInspecaoService
    {
        private GestranContext _context;
        public ItemInspecaoImplementations(GestranContext context)
        {
            _context = context;
        }

        public void Create(ItemInspecaoDTO itemInspecaoDTO)
        {
            var itemInspecao = new ItemInspecao
            {
                Id = itemInspecaoDTO.Id,
                Descricao = itemInspecaoDTO.Descricao
            };

            try
            {
                _context.Add(itemInspecao);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public void Update(ItemInspecaoDTO itemInspecaoDTO)
        {
            var itemInspecao = new ItemInspecao
            {
                Id = itemInspecaoDTO.Id,
                Descricao = itemInspecaoDTO.Descricao
            };

            var result = _context.ItensInspecao.SingleOrDefault(p => p.Id == itemInspecao.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(itemInspecao);
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
            var result = _context.ItensInspecao.SingleOrDefault(p => p.Id == Id);
            if (result != null)
            {
                try
                {
                    _context.ItensInspecao.Remove(result);
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
            return _context.ItensInspecao.Any(p => p.Id == Id);
        }

        public List<ItemInspecaoDTO> FindAll()
        {
            return _context.ItensInspecao
                    .Select(c=> new ItemInspecaoDTO
                    {
                        Id = c.Id,
                        Descricao = c.Descricao
                    }).ToList();            
        }

        public ItemInspecaoDTO FindById(long Id)
        {
            var iteminspecao = _context.ItensInspecao
                    .FirstOrDefault(c => c.Id == Id);

            if (iteminspecao == null) { return null; }

            return new ItemInspecaoDTO
            {
                Id = iteminspecao.Id,
                Descricao = iteminspecao.Descricao
            };
        }

    }
}
