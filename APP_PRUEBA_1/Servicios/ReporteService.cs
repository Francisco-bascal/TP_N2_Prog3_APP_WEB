using APP_PRUEBA_1.Repositorios;
using APP_PRUEBA_1.Servicios.Validation;
using APP_PRUEBA_1.Models.ViewModels;
using APP_PRUEBA_1.Models;

namespace APP_PRUEBA_1.Servicios
{
    public class ReporteService : IReporteService
    {
        private readonly IEmpleadoRepository _repo;
        public ReporteService(IEmpleadoRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result<IEnumerable<EmpleadosPorDepartamentoVM>>> GetEmpleadosPorDepartamentoAsync() 
        {
            var empleadosDesignar = await _repo.GetEmpleadosAsync();
            var empleadosRetornar = empleadosDesignar.GroupBy(e => e.IdDepartamentoNavigation.Nombre).Select(r => new EmpleadosPorDepartamentoVM 
            {
                Departamento = r.Key,
                CantidadEmpleados = r.Count()

            });
            return Result<IEnumerable<EmpleadosPorDepartamentoVM>>.Success(empleadosRetornar);
        }

        public async Task<Result<IEnumerable<EmpleadosAgrupadosPorDepartamentoVM>>> GetEmpleadosAgrupadosPorDepartamentoAsync() 
        {
            var empleadosDesignar = await _repo.GetEmpleadosAsync();
            var empleadosRetornar = empleadosDesignar.GroupBy(e => e.IdDepartamentoNavigation.Nombre).Select(g => new EmpleadosAgrupadosPorDepartamentoVM
            {
                NombreDepartamento = g.Key,
                Empleados = g.OrderBy(e => e.Apellido).ThenBy(e => e.Nombre).ToList()
            })
            .OrderBy(g => g.NombreDepartamento).ToList();

            return Result<IEnumerable<EmpleadosAgrupadosPorDepartamentoVM>>.Success(empleadosRetornar);
        }
    }
}