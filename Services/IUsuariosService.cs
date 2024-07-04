using GestranTeste.DTO;

namespace GestranTeste.Services
{
    public interface IUsuariosService
    {
        void Create(UsuarioDTO usuario);
        void Update(UsuarioDTO usuario);
        UsuarioDTO FindById(long Id);
        List<UsuarioDTO> FindAll();
        void Delete(long id);

    }
}
