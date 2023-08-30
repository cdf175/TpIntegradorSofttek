namespace TpIntegradorSofttek.DTOs
{
    public class TrabajoDTO
    {
        public DateTime Fecha { get; set; }
        public int CodProyecto { get; set; }
        public int CodServicio { get; set; }
        public int CantHoras { get; set; }
        public decimal ValorHora { get; set; }
        public Decimal Costo { get; set; }
    }
}
