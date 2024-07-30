﻿namespace ProjeYonetimSistemi.UI.MVC.Dto.Task
{
    public class taskDto
    {
        public string? TaskName { get; set; } // Görev ismi
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedDate { get; set; } // Eklenme tarihi
        public string? Status { get; set; } // Projenin ne durumda olduğu
        public int ProjectId { get; set; }
    }
}
