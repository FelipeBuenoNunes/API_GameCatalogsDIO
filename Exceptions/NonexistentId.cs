using System;

namespace API_GameCatalogsDIO.Excpetions
{
    public class NonexistentId : Exception
    {
        public NonexistentId()
            : base("Este id não está cadastrado")
        { }
    }
}