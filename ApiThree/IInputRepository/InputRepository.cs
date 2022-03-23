﻿using ApiThree.Contexts;
using ApiThree.Models;
using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace ApiThree
{
    public class InputRepository : IInputRepository
    {
        public object getAllInput(InputDbContext context)
        {
            return context.Todos.Select(c => new
            {
                NeId = c.NeId,
                NodeName = c.NodeName,
                Object = c.Object,
                Time = c.Time,
                Interval = c.Interval,
                Direction = c.Direction,
                NeAlias = c.NeAlias,
                NeType = c.NeType,
               // Position = c.Position,
                RFInputPower = c.RFInputPower,
                TID = c.TID,
                MeanRxLevel1m = c.MeanRxLevel1m,
               // IdLogNum = c.IdLogNum,
               // FailureDescription = c.FailureDescription
    }).ToList();
        }

        public object GetByInputByNeId(InputDbContext _context, string id)
        {
            return _context.Todos.Where(b => b.NeId == id).Select((c) => new
            {
                NeId = c.NeId,
                NodeName = c.NodeName,
                Object = c.Object,
                Time = c.Time,
                Interval = c.Interval,
                Direction = c.Direction,
                NeAlias = c.NeAlias,
                NeType = c.NeType,
               // Position = c.Position,
                RFInputPower = c.RFInputPower,
                TID = c.TID,
                MeanRxLevel1m = c.MeanRxLevel1m,
               // IdLogNum = c.IdLogNum,
               // FailureDescription = c.FailureDescription
            }).ToList();
        }
 

        public void getFilesFromFtp(InputDbContext _context, Ftp Ftp)
        {
 
            try
            {

                WebClient request = new WebClient();
                string url = "ftp://" + Ftp.remoteHost + Ftp.remotePath + Ftp.remoteFilename;
                Console.WriteLine("-------------url=  " + url + "----------------------------");
                request.Credentials = new NetworkCredential(Ftp.remoteUser, Ftp.remotePassword);
                Console.WriteLine("-------------------------------------------------");
 
                byte[] data = request.DownloadData(url);
 

                List<InputRF> list = new List<InputRF>();
                var engine = new FileHelperEngine<InputRF>();

                var encoding = new ASCIIEncoding();
                string dataString = encoding.GetString(data);
                var records = engine.ReadString(dataString);
                foreach (var record in records)
                {
                    list.Add(record);
                   
                    Console.WriteLine(record.MeanRxLevel1m);
                }

                 _context.Todos.AddRange(list);

                _context.SaveChanges();
            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine(e.ToString());
            }

            catch (WebException e)
            {
                Console.WriteLine(e.ToString());

            }
        }
 

        public void PostInput(InputDbContext context, InputRF input)
        {
            context.Add(input);
            context.SaveChanges();
        }

       
        }
}