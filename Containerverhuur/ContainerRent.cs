using System;

namespace Containerverhuur
{
    internal class ContainerRent
    {
        private const int percentageTotal = 100;

        private const int rentPerCubicMeterPerDay = 40;
        private const int priceRemoveContainerSmall = 60;
        private const int priceRemoveContainerBig = 125;
        private const int maxSizeContainerSmall = 2;
        private const int repeatCustomerPercentageReduction = 15;

        internal static double CalculatePrice(int startDay, int startMonth, int startYear, int stopDay, int stopMonth, int stopYear, int volume, int timesRemoved, bool repeatCustomer)
        {
            int amountOfDays = MoveTroughDays.AmountOfDays(startDay, startMonth, startYear, stopDay, stopMonth, stopYear);
            double price = amountOfDays * rentPerCubicMeterPerDay * volume;
            if(volume> maxSizeContainerSmall)
            {
                price += priceRemoveContainerBig * timesRemoved;
            }
            else
            {
                price += priceRemoveContainerSmall * timesRemoved;
            }
            if (repeatCustomer)
            {
                price *= 1.0 / percentageTotal * (percentageTotal - repeatCustomerPercentageReduction);
            }
            return price;
        }
    }
}