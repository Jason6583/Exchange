using System;

namespace ConsoleApp
{
    class Program
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

//this project is used for generating dbcontext from database reverse engineering
//steps to do reverse engineering
// 1) make sure there is no error and no pending changes to commit
// 2) set this project as startup project
// 3) select entity project in package manager console
// 4) execute command Scaffold-DbContext "Host=localhost;Database=Exchange;Username=postgres;Password=root" Npgsql.EntityFrameworkCore.PostgreSQL -force
// 5) carefully check all the changes done by scafflod command. remove constructor,OnConfiguring from db context classes. from entity class remove already present methods in partial class