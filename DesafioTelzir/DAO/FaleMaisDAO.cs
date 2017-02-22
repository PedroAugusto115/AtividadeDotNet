using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Xml.Linq;
using System.IO;
using DesafioTelzir.Models;

namespace DesafioTelzir.DAO
{
    public class FaleMaisDAO
    {
        public List<FaleMais> getFaleMais(string filelocation)
        {
            try
            {
                XElement xml = XElement.Load(filelocation);

                List<FaleMais> promos = new List<FaleMais>();

                //Utilização de LINQ to XML para buscar os dados no arquivo XML
                var search = (from p in xml.Elements("falemaisPromo")
                              select p);

                if (search != null)
                {
                    foreach (var promoObj in search)
                    {
                        FaleMais promo = new FaleMais();

                        promo.setName(promoObj.Attribute("flname").Value);
                        promo.setMinutes(Convert.ToInt32(promoObj.Attribute("flid").Value));

                        promos.Add(promo);
                    }

                    return promos;
                }
                else
                {
                    return promos;
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

        public FaleMais getFaleMaisById(int searchId, string filelocation)
        {
            try
            {
                XElement xml = XElement.Load(filelocation);

                //Utilização de LINQ to XML para buscar o valor solicitado no arquivo XML
                var search = (from p in xml.Elements("falemaisPromo")
                              where (int)p.Attribute("flid") == searchId
                              select p).FirstOrDefault();

                FaleMais promo = new FaleMais();

                if (search != null)
                {
                    promo.setName(search.Attribute("flname").Value);
                    promo.setMinutes(Convert.ToInt32(search.Attribute("flid").Value));
                }

                return promo;
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