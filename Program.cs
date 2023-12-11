namespace EmployeeManagementSystem
{

    class Program
    {
        static void Main(string[] args)
        {

            List<IEmployee> employees = new List<IEmployee>();
            employees.Add(new FullTimeEmployee("Reza", 25, 15));
            employees.Add(new FullTimeEmployee("Kaveh", 12, 3));
            employees.Add(new PartTimeEmployee("Ehsan", 15, 2));
            employees.Add(new PartTimeEmployee("Eshghe Kaveh", 9, 1));



            ReportEmployee reporter = new ReportEmployee();

            reporter.SortByName(employees);
            Console.WriteLine("======================================================================");

            reporter.SortByNameDescending(employees);
            Console.WriteLine("======================================================================");

            reporter.FilterSalaryBelow(employees, 1000);
            reporter.FilterSalaryAbove(employees, 1000);
            Console.WriteLine("======================================================================");

            reporter.HighestPaid(employees);
            Console.WriteLine("======================================================================");


            MessageService messageService = new MessageService();
            EmployeeEditor employeeEditor = new EmployeeEditor();
            var EmployeeToEdit = employees[1];
           
           employeeEditor.EmployeeEdited += messageService.onEmployeeEdited;
            employees[1] = employeeEditor.EditEmployee(EmployeeToEdit, "Esme Hamijoori", 11, 5);

            reporter.SortByName(employees);
            Console.WriteLine("======================================================================");




        }
    }
}