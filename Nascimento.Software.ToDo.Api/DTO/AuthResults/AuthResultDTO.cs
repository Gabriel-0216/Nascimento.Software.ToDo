namespace Nascimento.Software.ToDo.Api.DTO.AuthResults
{
    public class AuthResultDTO
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public string Token { get; set; } = string.Empty;
    }
}
