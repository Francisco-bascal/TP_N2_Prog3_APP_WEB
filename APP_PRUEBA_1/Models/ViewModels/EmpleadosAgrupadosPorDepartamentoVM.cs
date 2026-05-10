namespace APP_PRUEBA_1.Models.ViewModels
{
    public class EmpleadosAgrupadosPorDepartamentoVM
    {
        public string NombreDepartamento { get; set; } = null!;
        public List<Empleado> Empleados { get; set; } = new();
    }
}
