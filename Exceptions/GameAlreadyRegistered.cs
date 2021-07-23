using System;

namespace API_GameCatalogsDIO.Excpetions
{
    public class GameAlreadyRegistered : Exception
    {
        public GameAlreadyRegistered()
            : base("Jogo já cadastrado")
        { }
    }
}