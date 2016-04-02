using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntrotoEntityFramework.Data;
using System.Data.Entity.SqlServer; // used to bring out all the math functions 
namespace IntrotoEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            // EmployeesByLevelName("Mid Level");
            //EmployeePositionIdLambda(1);
            CreateEmployee("Steve", 3);
           // RetrieveEmployee();
        }

        //3.21.2016

        static void UseLambaNotes()
        {
            StoreContainer1 context = new StoreContainer1();

            //Lambda Expression
            // context.Employees.Where(e => e.Id == 1).First()//.Last(), .FirstorDefault(), LastorDefault();
            var employees = context.Employees.Where(e => e.Id == 1)
                             .Where(e => e.Name == "Mike Whitfield")
                             .Where(e => e.PositionId == 2)
                             //.ToList - grabs the recors to the local copy and breaks the wehere statement allows records to be manipulated by other functions
                             .Where(e => e.Salary > 5000)
                             //.Where(e => e.Salary > Add(5 , 3)) // can only be run after the To List collcetion
                             //.Where(e => e.Salary > SqlFunctions.Square(500)) -- can calculate without brining records local (dont use!!!)
                             .FirstOrDefault();

            //You can run multiple where statements until you have a  list that keeps the multiline where statemtn from combining into 1

            //Lambda Expression2
            /*
            var employees = context.Employees.Where(e => e.Id == 1))
                              .Select(x =>
                             new
                             {
                                 x.Id,
                                 x.Name,
                                 x.PsotionId,
                                 x.Salary
                             });
            */

            //Lambda Expression3
            var employees1 = context.Employees
                .Join(context.Positions, //inner positions
                e => e.PositionId, //Outer join key
                p => p.Id,         //Inner Join key
                (e, p) => new      //Result set, using parans means you are returning more thatn 1 var at 1 time
                {
                    e,
                    p
                })
                .Where(x => x.e.Id == 1)// x represents e and pa toghter as a retunred 
                .ToList()
                .Select(x =>
                   new Position // if you are using a new object you created in select, must use toList to bring local
                   {
                       Id = x.p.Id,
                       Name = x.p.Name,
                       LevelId = x.p.LevelId,
                       Employees = x.p.Employees,
                       Level = x.p.Level
                   });


            //Lambda expression (using a values as something else (x =>)
            context.Employees.OrderBy(x => x.Name).ThenByDescending(x => x.Name);

            /* can only be run after you grab the records when you break the where statement with a collection like toList
            static void Add()
            {
                return num1 + num2
            }
            */

        }

        static void EmployeePositionId()
        {
            StoreContainer1 context = new StoreContainer1();

            //employee table joined to position table - done
            //filter by employye id
            //selecting 3 columns fron position tabel -- last thing that get sexecuted - done
            //First or default -- brings back first record unless it is null value
            //IQueryable dont get run until it is put into a collection (list , array)


            //Exmple of a LinQ Query
            
            var result = (from e in context.Employees
                          join p in context.Positions
                          on e.PositionId equals p.Id
                          where e.Id == 1
                          select p).ToList();


            foreach (var item in result)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
                //console.writeline(item.level.name);
                foreach (var i in item.Employees)
                {
                    Console.WriteLine(i.Name);
                }
            }
        }

        static void EmployeePositionIdLambda(int positionId) {
            StoreContainer1 context = new StoreContainer1();

            var EmployeesLevels = context.Employees
                .Join(context.Positions, //inner positions
                e => e.PositionId,       //Outer join key
                p => p.Id,              //Inner Join key
                (e, p) => new           //Result set, using parans means you are returning more thatn 1 var at 1 time
                {
                    e,
                    p // represented as x
                })
                .Where(x => x.p.Id == positionId).ToList(); // x represents e and pa toghter as a retunred


            }


        static void EmployeeAddresId(int addressId)
        {
            StoreContainer1 context = new StoreContainer1();

            var result = (from e in context.Employees
                          join a in context.Addresses
                          on e.AddressId equals a.Id
                          where a.Id == addressId
                          select new
                                    {
                                        e.Id,
                                        e.Name,
                                        e.PositionId,
                                        e.AddressId,
                                        e.Salary
                                    }
                ).ToList(); 


            foreach (var item in result)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
            }
 
        }

        static void EmployeeAddresIdLambda(int addressId)
        {
            StoreContainer1 context = new StoreContainer1();

            var employeesLevels = context.Employees
                .Join(context.Addresses, //inner positions
                e => e.AddressId,       //Outer join key
                a => a.Id,              //Inner Join key
                (e, a) => new           //Result set, using parans means you are returning more thatn 1 var at 1 time
                {
                    e,
                    a // represented as x
                })
                .Where(x => x.a.Id == addressId);// x represents e and pa toghter as a retunred
        }


        static void EmployeesByLevelId(int levelId)
        {
            StoreContainer1 context = new StoreContainer1();

            var result = (from e in context.Employees
                          join p in context.Positions on e.PositionId equals p.Id
                          join l in context.Levels on p.LevelId equals l.Id
                          where l.Id == levelId
                          select e
                          ).ToList(); ;
            foreach (var item in result)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
            }
        }


        static void EmployeesByLevelIdLambda(int levelId)
        {
            StoreContainer1 context = new StoreContainer1();

            var employeesLevels = context.Employees
                .Join(context.Positions, //inner positions
                e => e.PositionId,       //Outer join key
                p => p.Id,              //Inner Join key
                (e, p) => new           //Result set, using parans means you are returning more thatn 1 var at 1 time
                {
                    e,
                    p // represented as x
                })
                .Join(context.Levels,
                x => x.p.LevelId,
                l => l.Id,
                (x, l) => new
                {
                    x,
                    l
                }
                )
                .Where(x => x.l.Id == levelId);// x represents e and pa toghter as a retunred
        }

        static void EmployeesByLevelName(string levelName)
        {
            StoreContainer1 context = new StoreContainer1();

            var result = (from e in context.Employees
                          join p in context.Positions on e.PositionId equals p.Id
                          join l in context.Levels on p.LevelId equals l.Id
                          where l.Name == levelName
                          select e
                          ).ToList(); ;
            foreach (var item in result)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
            }
        }

        static void EmployeesByLevelNameLambda(string levelName)
        {
            StoreContainer1 context = new StoreContainer1();

            var employeesLevels = context.Employees
                .Join(context.Positions, //inner positions
                e => e.PositionId,       //Outer join key
                p => p.Id,              //Inner Join key
                (e, p) => new           //Result set, using parans means you are returning more thatn 1 var at 1 time
                {
                    e,
                    p // represented as x
                })
                .Join(context.Levels,
                x => x.p.LevelId,
                l => l.Id,
                (x, l) => new
                {
                    x,
                    l
                }
                )
                .Where(x => x.l.Name == levelName);// x represents e and pa toghter as a retunred 


        }

        static void EmployessPositionId (int positionId)
        {
            StoreContainer1 context = new StoreContainer1();

            var result = (from e in context.Employees
                          join p in context.Positions on e.PositionId equals p.Id
                          where p.Id == positionId
                          select e

                          ).ToList(); ;
            foreach (var item in result)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
            }
        }

        static void EmployessPositionIdLambda(int positionId)
        {
            StoreContainer1 context = new StoreContainer1();

            var employeesPositionId = context.Employees
                .Join(context.Positions, //inner positions
                e => e.PositionId,       //Outer join key
                p => p.Id,              //Inner Join key
                (e, p) => new           //Result set, using parans means you are returning more thatn 1 var at 1 time
                {
                    e,
                    p // represented as x
                })
                .Where(x => x.p.Id == positionId);// x represents e and pa toghter as a retunred 
  
        }

        // 3.22.2016 CRUD -   Create -  (post) 
                // Retreive, (get)
                // Update,   (post)
                // Delete    (delete)

        static void CreateEmployee(string EmpName, int PosId)
        {
            StoreContainer1 context = new StoreContainer1();

            //Create new Employee
            Employee emp = new Employee();
            emp.Name = EmpName;
            emp.PositionId = PosId;
            emp.Salary = 4000;

            context.Employees.Add(emp);
            context.SaveChanges();
       }

        static void RetrieveEmployee()
        {
            StoreContainer1 context = new StoreContainer1();

            var employeesByName = context.Employees.Where(e => e.Name == "Woody").FirstOrDefault(); // returns only 1 record instead of collection

            if(employeesByName != null){
                employeesByName.Salary = 7000;
                context.SaveChanges();
            }

        }

        static void DeleteEmployee()
        {
            StoreContainer1 context = new StoreContainer1();

            var employeesByName = context.Employees.Where(e => e.Name == "Woody").FirstOrDefault(); // returns only 1 record instead of collection

            if (employeesByName != null)
            {
                context.Employees.Remove(employeesByName);
                context.SaveChanges();
            }

            
        }

    }
}
