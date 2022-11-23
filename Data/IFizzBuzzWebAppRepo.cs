using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
namespace FizzBuzzWebApp.Data
{
    public interface IFizzBuzzWebAppRepo
    {
        void PopulateDBTable();

    }
}
