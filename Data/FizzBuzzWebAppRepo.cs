using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using FizzBuzzWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FizzBuzzWebApp.Pages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FizzBuzzWebApp.Data
{
    public class FizzBuzzWebAppRepo : IFizzBuzzWebAppRepo
    {
        
        private readonly FizzBuzzWebAppDBContext _dbContext;

        public FizzBuzzWebAppRepo(FizzBuzzWebAppDBContext dbContext)
        {
            _dbContext = dbContext;
            
            
        }

        // Populates database table.
        public void PopulateDBTable()
        {
            _dbContext.Database.EnsureCreated();

            List<DBTableModel> DBsize = _dbContext.TableRows.ToList<DBTableModel>();

            // Checks whether table has already been populated (e.g web app being run for a second time) and only populates table if it is empty
            if (DBsize.Count == 0)
            {
                for (int i = 1; i <= 100; i++)
                {
                    if (i % 3 == 0 && i % 5 == 0)
                    {
                        DBTableModel TableEntry = new DBTableModel { ValueToDisplay = "FizzBuzz" };
                        _dbContext.TableRows.Add(TableEntry);
                        _dbContext.SaveChanges();
                    }
                    else if (i % 3 == 0)
                    {
                        DBTableModel TableEntry = new DBTableModel { ValueToDisplay = "Fizz" };
                        _dbContext.TableRows.Add(TableEntry);
                        _dbContext.SaveChanges();

                    }
                    else if (i % 5 == 0)
                    {
                        DBTableModel TableEntry = new DBTableModel { ValueToDisplay = "Buzz" };
                        _dbContext.TableRows.Add(TableEntry);
                        _dbContext.SaveChanges();

                    }
                    else
                    {
                        string i_string = i.ToString();
                        DBTableModel TableEntry = new DBTableModel { ValueToDisplay = i_string };
                        _dbContext.TableRows.Add(TableEntry);
                        _dbContext.SaveChanges();

                    }

                }

            }




        }

    }
}
