using ApiThree.Contexts;
using ApiThree.Models;
using FileHelpers;
 using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace ApiThree
{
    public class AggRepository : IAggRepository
    {
        public object getAllAgg(AggDbContext context)
        {
            return context.Todos.Select(c => new
            {
                NETWORK_SID = c.NETWORK_SID,
                RSL_DEVIATION = c.RSL_DEVIATION,
                checkpoint = c.checkpoint
            }).ToList();
        }

  
      

       public  Agg update(AggDbContext context, InputDbContext _contextInput, RadioDbContext _contextRadio)
        {
            var showPiece = _contextInput.Todos.Select(c => new
            {
                NETWORK_SID = c.NETWORK_SID,
                MeanRxLevel1m = c.MeanRxLevel1m,
             }).ToList().LastOrDefault();

  var showPiece2 = _contextRadio.Todos.Select(c => new
            {
                NETWORK_SID = c.NETWORK_SID,
                MaxRxLevel = c.MaxRxLevel,
            }).ToList().LastOrDefault();
            Console.WriteLine("----------------------------------------------------------------------");

            Console.WriteLine("---------------------"+ showPiece2.MaxRxLevel + "----------------------------");
            Console.WriteLine("---------------------+"+ showPiece.MeanRxLevel1m + "+----------------------------");
            Console.WriteLine("----------------------------------------------------------------------");

            // .OrderByDescending(p => p.Date)

            Agg Y = new Agg( );
            float x = float.Parse(showPiece.MeanRxLevel1m) - float.Parse(showPiece2.MaxRxLevel);
            //float y = 3;
            Y.RSL_DEVIATION = Convert.ToString(x);
            Y.checkpoint =""+ DateTime.Today.ToString("yyyy-dd-MM", CultureInfo.InvariantCulture); 
            context.Add(Y);
            context.SaveChanges();
            return Y;
         
        }



        //***********************************************************************************
        public void AddAgg(AggDbContext context, InputDbContext _contextInput, RadioDbContext _contextRadio)
        {
            int count = 200;

            List<float> inputs = new List<float>();
            List<float> radios = new List<float>();

            List<string> d1 = new List<string>();
            List<string> d2 = new List<string>();


            Console.WriteLine("-----***************************************----------------");

            //*****************************************
          
            var ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            ci.NumberFormat.NumberDecimalSeparator = ".";
            string y3 ="";
            foreach (var product in _contextInput.Todos) // query executed and data obtained from database
              {
                y3 = "" + product.MeanRxLevel1m.ToString()/*.Replace(".", ",")*/;
                Console.WriteLine(y3);
                Console.WriteLine("-----...........................----------------");

                if (float.TryParse(y3, out float yyy) == true)
                {
                    Console.WriteLine("-float INput->" + yyy);
                    Console.WriteLine("-----...........................----------------");


                    DateTime date = DateTime.ParseExact(product.Time, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    string formattedDate = date.ToString("yyyy-MM-dd ");
                    Console.WriteLine(formattedDate);


                    inputs.Add(yyy);
                    d1.Add(formattedDate);

                }




            }
           

              foreach (var product in _contextRadio.Todos) // query executed and data obtained from database
              {
                y3 = "" + product.MaxRxLevel.ToString()/*.Replace(".", ",")*/;
                Console.WriteLine(y3);
                Console.WriteLine("-----...........................----------------");

                if (float.TryParse(y3, out float yyy) == true)
                {
                    Console.WriteLine("-float RADIO-->" + yyy);
                    Console.WriteLine("-----...........................----------------");
                   
                         DateTime date = DateTime.ParseExact(product.Time, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    string formattedDate = date.ToString("yyyy-MM-dd");
                    Console.WriteLine(formattedDate);


                    inputs.Add(yyy);
                    d2.Add(formattedDate);

                    radios.Add(yyy);


                }

            }




              //*************************

              List<Agg> list = new List<Agg>();


              for (int j = 0; j <= count; j++)
              {

                 
                      Console.WriteLine("-------if boucl-------"+j+"----------------");

                      Agg Y = new Agg();
                     // string ik1 = inputs[j].Replace('.', ',');
                     // string ik2 = radios[j].Replace('.', ',');

                      float kpi = inputs[j] - radios[j];
                      Y.RSL_DEVIATION =Convert.ToString(Math.Abs(kpi));
                      Console.WriteLine("-----RSL---------" + Y.RSL_DEVIATION + "----------------");

                 Y.checkpoint = d2[j];
               // Y.checkpoint = "2001-01-01";

                list.Add(Y);
                  
              }
            context.Todos.AddRange(list);

            context.SaveChanges();

           


              

           








        }





        //**********************************************************************************


        //**********************************************************************************


        //**********************************************************************************


    }

}