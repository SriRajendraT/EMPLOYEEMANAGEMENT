using EMPLOYEEMANAGEMENT.DAL;
using EMPLOYEEMANAGEMENT.Models;
using EMPLOYEEMANAGEMENT.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EMPLOYEEMANAGEMENT.Repository.Classes
{
    public class EMPREPO : IEMPREPO
    {
        private readonly AppDbContext _dbContext;

        public EMPREPO(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddOrUpdateEmp(Employee employee)
        {
            if (employee.EMPID > 0)
            {
                var emp = await getEmpById(employee.EMPID);
                if (emp != null)
                {
                    employee.ACTIVEFLAG = YESORNO.YES;
                    employee.DELETEFLAG = YESORNO.NO;
                    _dbContext.Entry<Employee>(employee).State = EntityState.Modified;
                }
            }
            else
            {
                employee.ACTIVEFLAG = YESORNO.YES;
                employee.DELETEFLAG = YESORNO.NO;
                await _dbContext.AddAsync(employee);
            }
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteEmp(Employee employee)
        {
            var emp = await getEmpById(employee.EMPID);
            if (emp != null)
            {
                employee.ACTIVEFLAG = YESORNO.NO;
                employee.DELETEFLAG = YESORNO.YES;
                _dbContext.Entry<Employee>(employee).State = EntityState.Modified;
                return await _dbContext.SaveChangesAsync() > 0;
            }
            else return false;
        }

        private async Task<Employee> getEmpById(int eid)
        {
            var emps = await (from em in _dbContext.Employees
                              join gnd in _dbContext.Genders on em.EMPGENDER equals gnd.GENDERID
                              join dpt in _dbContext.Departments on em.EMPDEPT equals dpt.DEPTID
                              join st in _dbContext.States on em.EMPSTATE equals st.STATEID
                              join ct in _dbContext.Cities on em.EMPCITY equals ct.CITYID

                              select new EmpExt
                              {
                                  EMPID = em.EMPID,
                                  EMPNAME = em.EMPNAME,
                                  EMPEMAIL = em.EMPEMAIL,
                                  EMPPHONE = em.EMPPHONE,
                                  EMPADDRESS = em.EMPADDRESS,
                                  EMPGENDER = em.EMPGENDER,
                                  EMPDEPT = em.EMPDEPT,
                                  EMPSTATE = em.EMPSTATE,
                                  EMPCITY = em.EMPCITY,
                                  ACTIVEFLAG = em.ACTIVEFLAG,
                                  DELETEFLAG = em.DELETEFLAG,
                                  EMPGENDERNAME = gnd.GENDERNAME,
                                  EMPSTATENAME = st.STATENAME,
                                  EMPCITYNAME = ct.CITYNAME,
                                  EMPDEPTNAME = dpt.DEPTNAME,
                                  EMPSAL = em.EMPSAL,
                                  //EMPDOJ = em.EMPDOJ,
                                  //EMPDOB = em.EMPDOB
                              })
                              .Where(x => x.ACTIVEFLAG == YESORNO.YES
                                    && x.DELETEFLAG == YESORNO.NO
                                    && x.EMPID == eid).FirstOrDefaultAsync();
            return emps;
        }

        public async Task<List<EmpExt>> GetAllEmps()
        {
            var emps = await (from em in _dbContext.Employees
                              join gnd in _dbContext.Genders on em.EMPGENDER equals gnd.GENDERID
                              join dpt in _dbContext.Departments on em.EMPDEPT equals dpt.DEPTID
                              join st in _dbContext.States on em.EMPSTATE equals st.STATEID
                              join ct in _dbContext.Cities on em.EMPCITY equals ct.CITYID

                              where em.ACTIVEFLAG == YESORNO.YES && em.DELETEFLAG == YESORNO.NO
                              orderby em.EMPID descending

                              select new EmpExt
                              {
                                  EMPID = em.EMPID,
                                  EMPNAME = em.EMPNAME,
                                  EMPEMAIL = em.EMPEMAIL,
                                  EMPPHONE = em.EMPPHONE,
                                  EMPADDRESS = em.EMPADDRESS,
                                  EMPGENDER = em.EMPGENDER,
                                  EMPDEPT = em.EMPDEPT,
                                  EMPSTATE = em.EMPSTATE,
                                  EMPCITY = em.EMPCITY,
                                  ACTIVEFLAG = em.ACTIVEFLAG,
                                  DELETEFLAG = em.DELETEFLAG,
                                  EMPGENDERNAME = gnd.GENDERNAME,
                                  EMPSTATENAME = st.STATENAME,
                                  EMPCITYNAME = ct.CITYNAME,
                                  EMPDEPTNAME = dpt.DEPTNAME,
                                  EMPSAL = em.EMPSAL,
                                  //EMPDOJ = em.EMPDOJ,
                                  //EMPDOB = em.EMPDOB
                              })
                              .ToListAsync();
            return emps;
        }

        public async Task<List<EmpExt>> GetAllEmpsByName(KeyValue kv)
        {
            var emps = await (from em in _dbContext.Employees
                              join gnd in _dbContext.Genders on em.EMPGENDER equals gnd.GENDERID
                              join dpt in _dbContext.Departments on em.EMPDEPT equals dpt.DEPTID
                              join st in _dbContext.States on em.EMPSTATE equals st.STATEID
                              join ct in _dbContext.Cities on em.EMPCITY equals ct.CITYID

                              select new EmpExt
                              {
                                  EMPID = em.EMPID,
                                  EMPNAME = em.EMPNAME,
                                  EMPEMAIL = em.EMPEMAIL,
                                  EMPPHONE = em.EMPPHONE,
                                  EMPADDRESS = em.EMPADDRESS,
                                  EMPGENDER = em.EMPGENDER,
                                  EMPDEPT = em.EMPDEPT,
                                  EMPSTATE = em.EMPSTATE,
                                  EMPCITY = em.EMPCITY,
                                  ACTIVEFLAG = em.ACTIVEFLAG,
                                  DELETEFLAG = em.DELETEFLAG,
                                  EMPGENDERNAME = gnd.GENDERNAME,
                                  EMPSTATENAME = st.STATENAME,
                                  EMPCITYNAME = ct.CITYNAME,
                                  EMPDEPTNAME = dpt.DEPTNAME,
                                  EMPSAL = em.EMPSAL,
                                  //EMPDOJ = em.EMPDOJ,
                                  //EMPDOB = em.EMPDOB
                              })
                              .Where(x => x.ACTIVEFLAG == YESORNO.YES
                                    && x.DELETEFLAG == YESORNO.NO
                                    && x.EMPNAME.Contains(kv.value1))
                                    .OrderBy(x => x.EMPNAME)
                                    .ToListAsync();
            return emps;
        }

        public async Task<EmpExt> GetEmpById(KeyValue kv)
        {
            var emps = await (from em in _dbContext.Employees
                              join gnd in _dbContext.Genders on em.EMPGENDER equals gnd.GENDERID
                              join dpt in _dbContext.Departments on em.EMPDEPT equals dpt.DEPTID
                              join st in _dbContext.States on em.EMPSTATE equals st.STATEID
                              join ct in _dbContext.Cities on em.EMPCITY equals ct.CITYID

                              select new EmpExt
                              {
                                  EMPID = em.EMPID,
                                  EMPNAME = em.EMPNAME,
                                  EMPEMAIL = em.EMPEMAIL,
                                  EMPPHONE = em.EMPPHONE,
                                  EMPADDRESS = em.EMPADDRESS,
                                  EMPGENDER = em.EMPGENDER,
                                  EMPDEPT = em.EMPDEPT,
                                  EMPSTATE = em.EMPSTATE,
                                  EMPCITY = em.EMPCITY,
                                  ACTIVEFLAG = em.ACTIVEFLAG,
                                  DELETEFLAG = em.DELETEFLAG,
                                  EMPGENDERNAME = gnd.GENDERNAME,
                                  EMPSTATENAME = st.STATENAME,
                                  EMPCITYNAME = ct.CITYNAME,
                                  EMPDEPTNAME = dpt.DEPTNAME,
                                  EMPSAL = em.EMPSAL,
                                  //EMPDOJ = em.EMPDOJ,
                                  //EMPDOB = em.EMPDOB
                              })
                              .Where(x => x.ACTIVEFLAG == YESORNO.YES
                                    && x.DELETEFLAG == YESORNO.NO
                                    && x.EMPID == kv.key1).FirstOrDefaultAsync();
            return emps;
        }

        public async Task<int> GetTotalEmployeeCount()
        {
            return await _dbContext.Employees.CountAsync(x => x.ACTIVEFLAG == YESORNO.YES && x.DELETEFLAG == YESORNO.NO);
        }
    }
}
