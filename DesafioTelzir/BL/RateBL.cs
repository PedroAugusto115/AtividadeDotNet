using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using DesafioTelzir.Models;
using DesafioTelzir.DAO;

namespace DesafioTelzir.BL
{
    public class RateBL
    {
        public List<Rate> getRates(string filelocation)
        {
            List<Rate> rates = new List<Rate>();
            RateDAO ratedao = new RateDAO();
            return rates = ratedao.getRates(filelocation);
        }

        public Rate getRateByOriginAndDestination(int searchOrigin, int searchDestination, string filelocation)
        {
            RateDAO ratedao = new RateDAO();
            Rate rate = ratedao.getRateByOriginAndDestination(searchOrigin, searchDestination, filelocation);
            return rate;
        }

        public List<int> getRatesOrigins(string filelocation)
        {
            List<int> listOrigins = new List<int>();
            RateDAO ratedao = new RateDAO();
            return listOrigins = ratedao.getRatesOrigins(filelocation);
        }

        public List<int> getRatesDestinationsByOrigin(int searchOrigin, string filelocation)
        {
            List<int> listDestinations = new List<int>();
            RateDAO ratedao = new RateDAO();
            return listDestinations = ratedao.getRatesDestinationsByOrigin(searchOrigin, filelocation);
        }

        public List<FaleMais> getFaleMais(string filelocation)
        {
            List<FaleMais> listPromo = new List<FaleMais>();
            FaleMaisDAO falemaisdao = new FaleMaisDAO();
            return listPromo = falemaisdao.getFaleMais(filelocation);
        }

        public FaleMais getFaleMaisById(int searchId, string filelocation)
        {
            FaleMais promo = new FaleMais();
            FaleMaisDAO falemaisdao = new FaleMaisDAO();
            return promo = falemaisdao.getFaleMaisById(searchId, filelocation);
        }

        public double getTotalRateWithoutFaleMais(int origin, int destination, int minutes, string filelocation)
        {
            if (origin != 0 && destination != 0 && minutes != 0)
            {
                Rate rate = getRateByOriginAndDestination(origin, destination, filelocation);

                double totalRate = 0.0;

                totalRate = rate.getPrice() * minutes;

                return totalRate;
            }
            else
            {
                return 0.00;
            }
        }

        public double getTotalRateWithFaleMais(int origin, int destination, int minutes, int faleMais, string filelocationRate, string filelocationFaleMais)
        {
            if (origin != 0 && destination != 0 && minutes != 0 && faleMais != 0)
            {
                double totalRate = 0.0;

                FaleMais falemais = new FaleMais();

                falemais = getFaleMaisById(faleMais, filelocationFaleMais);

                double totalMinutes = minutes - falemais.getMinutes();

                if (totalMinutes <= 0)
                {
                    return totalRate = 0.0;
                }
                else
                {
                    double excedentRate = 1.1; // 10% de acrescimo

                    Rate rate = getRateByOriginAndDestination(origin, destination, filelocationRate);

                    totalRate = (rate.getPrice() * excedentRate) * totalMinutes; //(valor do minuto + 10%) * minutos excedentes 
                }

                return totalRate;
            }
            else
            {
                return 0.00;
            }
        }

    }
}