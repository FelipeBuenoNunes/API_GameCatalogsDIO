using System;

namespace API_GameCatalogsDIO.Excpetions
{
    public class UnregisteredGame : Exception
    {
        public UnregisteredGame()
            : base("Este jogo n�o est� cadastrado")
        {}
    }
}