<<<<<<<< HEAD:src/backend/ServicesDeskUCABWS/Entities/ErrorViewModel.cs
namespace ProyectD.Entities
========
namespace ServiceDeskUCAB.Models
>>>>>>>> 756014dd828ec633bcf089b98d42ecd33f359102:src/frontend/ServiceDeskUCAB/Models/ErrorViewModel.cs
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}