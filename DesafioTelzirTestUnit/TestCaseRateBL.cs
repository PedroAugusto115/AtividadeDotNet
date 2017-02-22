using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DesafioTelzir.BL;

namespace DesafioTelzirTestUnit
{
    public class TestCaseRateBL
    {
        string filelocationRate = "RatesDataSource.xml";
        string filelocationFaleMais = "FaleMaisDataSource.xml";

        [Test]
        public void origin_11_dest_16_min_20_faleMais_n()
        {
            RateBL rate = new RateBL();
            Assert.AreEqual(38.00, rate.getTotalRateWithoutFaleMais(11, 16, 20, filelocationRate));
        }

        [Test]
        public void origin_11_dest_16_min_20_faleMais_y30()
        {
            RateBL rate = new RateBL();
            Assert.AreEqual(0.00, rate.getTotalRateWithFaleMais(11, 16, 20, 30, filelocationRate, filelocationFaleMais));
        }

        [Test]
        public void origin_18_dest_11_min_200_faleMais_y120()
        {
            RateBL rate = new RateBL();
            double expected = 167.20;
            Assert.AreEqual(expected, rate.getTotalRateWithFaleMais(18, 11, 200, 120, filelocationRate, filelocationFaleMais));
        }

        [Test]
        public void origin_18_dest_11_min_200_faleMais_n()
        {
            RateBL rate = new RateBL();
            double expected = 380.00;
            Assert.AreEqual(expected, rate.getTotalRateWithoutFaleMais(18, 11, 200, filelocationRate));
        }

        [Test]
        public void check_if_rates_exists()
        {
            RateBL rate = new RateBL();
            Assert.IsNotEmpty(rate.getRates(filelocationRate));
        }

        [Test]
        public void get_rate_by_origin_11_destination_16()
        {
            RateBL rate = new RateBL();
            Assert.IsNotNull(rate.getRateByOriginAndDestination(11, 16, filelocationRate));
        }

        [Test]
        public void check_if_rate_with_invalid_data_does_not_throw_exception()
        {
            RateBL rate = new RateBL();
            try
            {
                rate.getRateByOriginAndDestination(0, 0, filelocationRate);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [Test]
        public void check_if_invalid_file_location_throws_FileNotFoundException()
        {
            RateBL rate = new RateBL();
            var ex = Assert.Throws<System.IO.FileNotFoundException>(() => rate.getRates("C://RatesDataSource.xml"));
        }

        [Test]
        public void check_if_calculation_without_FaleMais_with_invalid_data_returns_zero()
        {
            RateBL rate = new RateBL();
            Assert.AreEqual(0.00, rate.getTotalRateWithoutFaleMais(15, 20, 100, filelocationRate));
        }

        [Test]
        public void check_if_calculation_with_FaleMais_with_invalid_data_returns_zero()
        {
            RateBL rate = new RateBL();
            Assert.AreEqual(0.00, rate.getTotalRateWithFaleMais(15, 20, 100, 25, filelocationRate, filelocationFaleMais));
        }
    }
}
