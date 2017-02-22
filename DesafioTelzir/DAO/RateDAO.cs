using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Web.Hosting;
using System.IO;

using DesafioTelzir.Models;

namespace DesafioTelzir.DAO
{
    public class RateDAO
    {
        public List<Rate> getRates(string filelocation)
        {
            try
            {
                XElement xml = XElement.Load(filelocation);

                List<Rate> rates = new List<Rate>();

                //Utilização de LINQ to XML para buscar os dados no arquivo XML
                var search = (from p in xml.Elements("Rate")
                              select p);

                if (search != null)
                {
                    foreach (var rateObj in search)
                    {
                        Rate rate = new Rate();

                        rate.setOrigin(Convert.ToInt32(rateObj.Attribute("rtOrigin").Value));
                        rate.setDestination(Convert.ToInt32(rateObj.Attribute("rtDestination").Value));
                        rate.setPrice(Convert.ToDouble(rateObj.Attribute("rtPrice").Value));

                        rates.Add(rate);
                    }

                    return rates;
                }
                else
                {
                    return rates;
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                throw new System.IO.FileNotFoundException("Arquivo de dados não encontrado. " + ex.FileName);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException("Registros não encontrados. " + ex.Source);
            }
        }

        public Rate getRateByOriginAndDestination(int searchOrigin, int searchDestination, string filelocation)
        {
            try
            {
                XElement xml = XElement.Load(filelocation);


                //Utilização de LINQ to XML para buscar o valor solicitado no arquivo XML
                var search = (from p in xml.Elements("Rate")
                              where (int)p.Attribute("rtOrigin") == searchOrigin
                               && (int)p.Attribute("rtDestination") == searchDestination
                              select p).FirstOrDefault();

                if (search != null)
                {

                    Rate rate = new Rate();

                    rate.setOrigin(Convert.ToInt32(search.Attribute("rtOrigin").Value));
                    rate.setDestination(Convert.ToInt32(search.Attribute("rtDestination").Value));
                    rate.setPrice(Convert.ToDouble(search.Attribute("rtPrice").Value));

                    return rate;
                }
                else
                {
                    Rate rate = new Rate();
                    return rate;
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                throw new System.IO.FileNotFoundException("Arquivo de dados não encontrado. " + ex.FileName);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException("Registros não encontrados. " + ex.StackTrace);
            }
        }

        public List<int> getRatesOrigins(string filelocation)
        {
            try
            {
                XElement xml = XElement.Load(filelocation);

                List<int> rates = new List<int>();

                //Utilização de LINQ to XML para buscar os dados no arquivo XML
                var search = (from p in xml.Elements("Rate")
                              select p);

                if (search != null)
                {
                    foreach (var rateObj in search)
                    {
                        int rateOrigin = Convert.ToInt32(rateObj.Attribute("rtOrigin").Value);

                        rates.Add(rateOrigin);
                    }

                    return rates.Distinct().ToList();
                }
                else
                {
                    return rates;
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                throw new System.IO.FileNotFoundException("Arquivo de dados não encontrado. " + ex.FileName);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException("Registros não encontrados. " + ex.StackTrace);
            }
        }

        public List<int> getRatesDestinationsByOrigin(int searchOrigin, string filelocation)
        {
            try
            {
                XElement xml = XElement.Load(filelocation);

                List<int> rates = new List<int>();

                //Utilização de LINQ to XML para buscar os dados no arquivo XML
                var search = (from p in xml.Elements("Rate")
                              where (int)p.Attribute("rtOrigin") == searchOrigin
                              select p);

                if (search != null)
                {
                    foreach (var rateObj in search)
                    {
                        int rateDestination = Convert.ToInt32(rateObj.Attribute("rtDestination").Value);

                        rates.Add(rateDestination);
                    }

                    return rates.Distinct().ToList();
                }
                else
                {
                    return rates;
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                throw new System.IO.FileNotFoundException("Arquivo de dados não encontrado. " + ex.FileName);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException("Registros não encontrados. " + ex.StackTrace);
            }
        }
    }
}