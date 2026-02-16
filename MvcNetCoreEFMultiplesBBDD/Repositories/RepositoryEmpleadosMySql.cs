using Microsoft.EntityFrameworkCore;
using MvcNetCoreEFMultiplesBBDD.Data;
using MvcNetCoreEFMultiplesBBDD.Models;

#region STORED PROCEDURES AND VIEWS
/*
 create view V_EMPLEADOS
as
    select EMP.EMP_NO, EMP.APELLIDO, EMP.OFICIO
    , EMP.SALARIO, DEPT.DEPT_NO, DEPT.DNOMBRE, DEPT.LOC 
    from EMP
    inner join DEPT
    on EMP.DEPT_NO = DEPT.DEPT_NO;
DELIMITER $$
create procedure SP_ALL_EMPLEADOS()
begin
	select * from V_EMPLEADOS;
end $$
DELIMITER ;
 */
#endregion

namespace MvcNetCoreEFMultiplesBBDD.Repositories
{
    public class RepositoryEmpleadosMySql : IRepositoryEmpleados
    {

        private HospitalContext context;

        public RepositoryEmpleadosMySql(HospitalContext context)
        {
            this.context = context;
        }
        public async Task<List<EmpleadoView>> GetEmpleadosVistaAsync()
        {
            string sql = "call SP_ALL_EMPLEADOS()";
            var consulta = this.context.EmpleadosView
                .FromSqlRaw(sql);
            return await consulta.ToListAsync();
            //var consulta = from datos in this.context.EmpleadosView 
            //               select datos;
            //return await consulta.ToListAsync();
        }

        public async Task<EmpleadoView> GetDetallesEmpleadoAsync(int id)
        {
            var consulta = from datos in this.context.EmpleadosView
                           where datos.IdEmpleado == id
                           select datos;
            return await consulta.FirstOrDefaultAsync();
        }
    }
}
