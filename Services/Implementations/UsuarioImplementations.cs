using Models;
using GestranTeste.DTO;
using Repository;

namespace GestranTeste.Services.Implementations
{
    public class UsuarioImplementations : IUsuariosService
    {
        private GestranContext _context;
        public UsuarioImplementations(GestranContext context)
        {
            _context = context;
        }

        public void Create(UsuarioDTO usuarioDTO)
        {
            var usuario = new Usuario
            {
                Id = usuarioDTO.Id,
                Nome = usuarioDTO.Nome
            };

            try
            {
                _context.Add(usuario);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public void Update(UsuarioDTO usuarioDTO)
        {
            var usuario = new Usuario
            {
                Id = usuarioDTO.Id,
                Nome = usuarioDTO.Nome
            };

            var result = _context.Usuarios.SingleOrDefault(p => p.Id == usuario.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(usuario);
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
            var result = _context.Usuarios.SingleOrDefault(p => p.Id == Id);
            if (result != null)
            {
                try
                {
                    _context.Usuarios.Remove(result);
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
            return _context.Usuarios.Any(p => p.Id == Id);
        }

        public List<UsuarioDTO> FindAll()
        {
            return _context.Usuarios
                .Select(c => new UsuarioDTO
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Tipo = c.Tipo
                }).ToList();            
        }

        public UsuarioDTO FindById(long Id)
        {
            var usuario = _context.Usuarios.SingleOrDefault(p => p.Id == Id);

            if (usuario != null) {  return null ; }

            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Tipo = usuario.Tipo
            };
        }
    }
}
