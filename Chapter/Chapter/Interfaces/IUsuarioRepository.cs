using Chapter.Models;

namespace Chapter.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> Listar();
        Usuario BurcarPorId(int id);
        void Cadastrar(Usuario usuario);
        void Atualizar(int id,Usuario usuario);
        void Deletar(int id);
        Usuario Login(string email, string senha);

    }
}
