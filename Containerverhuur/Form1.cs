using OuderbijdrageSchool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Containerverhuur
{
    public partial class Form1 : Form
    {
        private const int widthMargin = 10;
        private const int heightMargin = 10;
        private const int rowHeight = 30;

        private const string rentStartDateString = "starting date of renting";
        private const string rendStopDateString = "stopping date of renting";
        private const string volumeString = "volume of the container in cubic meters";
        private const string timesRemovedString = "amount of times the container is removed or replaced";
        private const string repeatCustomerCheckBoxString = "repeat customer";
        private const string calculateRentPriceString = "calculate renting price";
        private const string priceMessageBoxString = "the rent total is ";

        private DateFormElement rentStartDate;
        private DateFormElement rentStopDate;
        private TextBoxWithLabelFormElement volume;
        private TextBoxWithLabelFormElement timesRemoved;
        private CheckBox repeatCustomerCheckBox;
        private Button calculateRentPrice;

        public Form1()
        {
            InitializeComponent();
            InitializeElements();
            ResetPosition();
        }
        private void InitializeElements()
        {
            rentStartDate = new DateFormElement(this, rentStartDateString);
            rentStopDate = new DateFormElement(this, rendStopDateString);
            volume = new TextBoxWithLabelFormElement(this, volumeString);
            timesRemoved = new TextBoxWithLabelFormElement(this, timesRemovedString);
            repeatCustomerCheckBox = new CheckBox();
            repeatCustomerCheckBox.Text = repeatCustomerCheckBoxString;
            Controls.Add(repeatCustomerCheckBox);
            calculateRentPrice = new Button();
            calculateRentPrice.Text = calculateRentPriceString;
            calculateRentPrice.Click += new EventHandler(CalculateRentPriceButtonFunction);
            Controls.Add(calculateRentPrice);
        }
        private void ResetPosition()
        {
            int row = 0;
            rentStartDate.ChangePosition(widthMargin, heightMargin + rowHeight * row);
            row++;
            rentStopDate.ChangePosition(widthMargin, heightMargin + rowHeight * row);
            row++;
            volume.ChangePosition(widthMargin, heightMargin + rowHeight * row);
            row++;
            timesRemoved.ChangePosition(widthMargin, heightMargin + rowHeight * row);
            row++;
            repeatCustomerCheckBox.Location = new Point(widthMargin, heightMargin + rowHeight * row);
            row++;
            calculateRentPrice.Location = new Point(widthMargin, heightMargin + rowHeight * row);
        }
        private void CalculateRentPriceButtonFunction(object sender, EventArgs e)
        {
            int[] startDate = rentStartDate.GetDate();
            int[] stopDate = rentStopDate.GetDate();

            int startDay = startDate[DateFormElement.GetDayIndex()];
            int startMonth = startDate[DateFormElement.GetMonthIndex()];
            int startYear = startDate[DateFormElement.GetYearIndex()];
            int stopDay = stopDate[DateFormElement.GetDayIndex()];
            int stopMonth = stopDate[DateFormElement.GetMonthIndex()];
            int stopYear = stopDate[DateFormElement.GetYearIndex()];

            int volume;
            try
            {
                volume = int.Parse(this.volume.GetValue());
            }
            catch (FormatException exception)
            {
                volume = 0;
            }
            int timesRemoved;
            try
            {
                timesRemoved = int.Parse(this.timesRemoved.GetValue());
            }
            catch (FormatException exception)
            {
                timesRemoved = 0;
            }

            bool repeatCustomer = repeatCustomerCheckBox.Checked;

            double price = ContainerRent.CalculatePrice(startDay, startMonth, startYear, stopDay, stopMonth, stopYear, volume, timesRemoved, repeatCustomer);

            MessageBox.Show(priceMessageBoxString + price);
        }
    }
}
