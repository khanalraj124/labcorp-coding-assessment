namespace WebApplication1.Models
{
    public abstract class Employee
    {
        public float VacationDays { get; protected set; }
        public int WorkDays { get; protected set; }
        public Employee()
        {
            VacationDays = 0;
            WorkDays = 0;
        }

        /// <summary>
        /// Calculate the work days
        /// </summary>
        /// <param name="days">number of days</param>
        /// <exception cref="ArgumentException"></exception>
        public virtual void Work(int days)
        {
            if (days < 0 || days > 260)
            {
                throw new ArgumentException("Invalid number of days worked.");
            }

            WorkDays += days;
        }

        /// <summary>
        /// Calculate vacation days
        /// </summary>
        /// <param name="days">number of days</param>
        public virtual void TakeVacation(float days)
        {
            if (days <= VacationDays)
            {
                VacationDays -= days;
            }
            else
            {
                VacationDays = 0;
            }
        }
    }

    /// <summary>
    /// Hourly Employee class
    /// </summary>
    public class HourlyEmployee : Employee
    {
        public HourlyEmployee()
        {
            VacationDays = 10;
        }
    }

    /// <summary>
    /// Salaried employee class
    /// </summary>
    public class SalariedEmployee : Employee
    {
        public SalariedEmployee()
        {
            VacationDays = 15;
        }
    }

    /// <summary>
    /// Manager Class
    /// </summary>
    public class Manager : SalariedEmployee
    {
        public Manager()
        {
            VacationDays = 30;
        }
    }
}
