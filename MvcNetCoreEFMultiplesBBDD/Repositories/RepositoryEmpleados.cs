using Microsoft.EntityFrameworkCore;
using MvcNetCoreEFMultiplesBBDD.Data;
using MvcNetCoreEFMultiplesBBDD.Models;

#region STORED PROCEDURES
/*
--ORACLE
create or replace view V_EMPLEADOS
as
    select EMP.EMP_NO, EMP.APELLIDO, EMP.OFICIO
    , EMP.SALARIO, DEPT.DEPT_NO, DEPT.DNOMBRE, DEPT.LOC
    from EMP
    inner join DEPT
    on EMP.DEPT_NO = DEPT.DEPT_NO;
/
--SQL SERVER
create view V_EMPLEADOS
as
	select EMP.EMP_NO, EMP.APELLIDO, EMP.OFICIO
	, EMP.SALARIO, DEPT.DEPT_NO, DEPT.DNOMBRE
	, DEPT.LOC
	from EMP 
	inner join DEPT
	on EMP.DEPT_NO = DEPT.DEPT_NO
go
 */
#endregion

namespace MvcNetCoreEFMultiplesBBDD.Repositories
{
    public class RepositoryEmpleados
    {
        private HospitalContext context;
        public RepositoryEmpleados(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<List<EmpleadoView>> GetEmpleadosViewAsync()
        {
            var consulta = from datos in this.context.EmpleadosView
                           select datos;
            return await consulta.ToListAsync();
        }

        public async Task<EmpleadoView> FindEmpleadoViewAsync(int idEmpleado)
        {
            var consulta = from datos in this.context.EmpleadosView
                           where datos.IdEmpleado == idEmpleado
                           select datos;
            return await consulta.FirstOrDefaultAsync();
        }
    }
}
