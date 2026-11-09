namespace HelpDesk.Models;

public enum PriorityLevels
{
    Baixa = 0,
    Media = 1,
    Alta = 2
}

public enum Statuses
{
    Aberto = 0,
    EmAndamento = 1,
    Concluido = 2,
    Cancelado = 3,
}

public class TicketModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public PriorityLevels Priority { get; set; }
    public Statuses Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CreatedByName { get; set; }
    public string UpdatedByName { get; set; }
    public string CreatedById { get; set; }
    public string UpdatedById { get; set; }
    
    public Guid UserId { get; set; }
    UserModel User { get; set; }
}