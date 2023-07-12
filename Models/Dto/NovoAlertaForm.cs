namespace Projeto_Nemo.Models.Dto
{
   public class NovoAlertaForm
   {
      public String Nome { get; set; } = null!;
        
      public int Min { get; set; }
        
      public int Max { get; set; }

      public int AquarioId { get; set; }
      
      public int AquarioParametroId { get; set; }
   } 
}

