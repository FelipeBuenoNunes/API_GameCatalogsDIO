using System.ComponentModel.DataAnnotations;

namespace API_GameCatalogsDIO.InputModel
{ 
    public class GameInputModel
    {
        const string ERROR_MESSAGE_PARAMETER = "Parametro tem que ser informado!";

        [Required(ErrorMessage = ERROR_MESSAGE_PARAMETER)]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "O nome do jogo deve conter entre 3 e 30 caracteres")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = ERROR_MESSAGE_PARAMETER)]
        public string ReleaseDate { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "A Descrição do jogo deve conter entre 3 e 30 caracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = ERROR_MESSAGE_PARAMETER)]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "A produtora do jogo deve conter entre 3 e 30 caracteres")]
        public string Producer { get; set; }

        [Required(ErrorMessage = ERROR_MESSAGE_PARAMETER)]
        public double Price { get; set; }
    }
}