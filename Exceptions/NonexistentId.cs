using System;

namespace API_GameCatalogsDIO.Excpetions
{
    public class NonexistentId : Exception
    {
        public NonexistentId()
            : base("Este id n�o est� cadastrado")
        { }
    }
}