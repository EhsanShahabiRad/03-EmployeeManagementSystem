using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
    public class MessageService
    {
        public void onEmployeeEdited(object source, EventArgs e)
        {
            Console.WriteLine("Employee Successfully Edited" );
        }
    }
}
