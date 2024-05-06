using System.ComponentModel.DataAnnotations;

namespace cancellieri.andre.ecommerc.Models;

public class Utente
{
    
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Cognome { get; set; }
    public string? Email { get; set; }
    public DateTime data_nascita { get; set; }
    public string? Password { get; set; }
}
