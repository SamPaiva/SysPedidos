using System.Collections.Generic;

namespace SysPedidos.Model.IRepository
{
    public interface ICardapioRepository
    {
        List<Cardapio> CardapioList();

        int AddItemCardapio(Cardapio cardapio);

        Cliente CardapioDetails(long id);

        int EditCardapio(Cardapio cardapio);

        int DeleteCardapio(long id);
    }
}
