﻿using ApiThree.Contexts;
using ApiThree.Models;

namespace ApiThree
{
    public interface IInputRepository
    {
       
        object getAllInput(InputDbContext context);
        object GetByInputByNeId(InputDbContext context, string id);
        void getFilesFromFtp(InputDbContext context, Ftp ftp);
        void PostInput(InputDbContext context, InputRF inputpower);
 
    }
}
