using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioTelzir.Models
{
    public class Rate
    {
        private int origin;
        private int destination;
        private double price; 

        public int getOrigin()
        {
            return this.origin;
        }

        public int getDestination()
        {
            return this.destination;
        }

        public double getPrice()
        { 
            return this.price; 
        }

        public void setOrigin(int newOrigin)
        {
            this.origin = newOrigin;
        }

        public void setDestination(int newDestination)
        {
            this.destination = newDestination;
        }

        public void setPrice(double newPrice)
        {
            this.price = newPrice;
        }
    }
}