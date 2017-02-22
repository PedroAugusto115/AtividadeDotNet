using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioTelzir.Models
{
    public class FaleMais
    {
        private string name;
        private int minutes;

        public string getName()
        {
            return this.name;
        }

        public int getMinutes()
        {
            return this.minutes;
        }

        public void setName(string newName)
        {
            this.name = newName;
        }

        public void setMinutes(int newMinutes)
        {
            this.minutes = newMinutes;
        }
    }
}