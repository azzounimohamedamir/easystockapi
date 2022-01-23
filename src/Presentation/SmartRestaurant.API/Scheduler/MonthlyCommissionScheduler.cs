using SmartRestaurant.Application.CommissionsMonthlyFees.Commands;
using SmartRestaurant.Application.Services;
using System;
using System.Diagnostics;

namespace SmartRestaurant.API.Scheduler
{

    public class CommissionScheduler
    {
        public void ExecuteCommissionMonthlyTasks()
        {
            var hour = 6;
            var minute = 0;

            ApplicationScheduler.IntervalInHours(hour, minute, 24, MonthlyCommission());
            Action MonthlyCommission()
            {
                return async () =>
                {
                    DateTime now = DateTime.Now;
                    if(now.Day == 1)
                    {
                        Debug.WriteLine("########## Calculate Last Month Commission Fees ##########");
                        await new MediatorService().SendAsync(new CalculateLastMonthCommissionFeesCommand());
                    }
                };
            }
        }
    }
}
