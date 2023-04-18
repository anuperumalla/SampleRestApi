using System;
namespace EmpRestApi.Domain
{
	public class Employee
	{
		
            public int EmployeeId { get; set; }

            public string? FirstName { get; set; }

            public string? LastName { get; set; }

            public string? Organisation { get; set; }

            public DateTime? DateOfJoin { get; set; }

    }
}


